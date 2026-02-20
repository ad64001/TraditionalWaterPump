using MiniExcelLibs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TraditionalWaterPump.Models;
using TraditionalWaterPump.Services;
using TraditionalWaterPump.ViewModels;
using xbd.DataConvertLib;

namespace TraditionalWaterPump
{
    public partial class FrmReport : Form
    {
        private List<string> maxCondition = new List<string>();
        private List<string> minCondition = new List<string>();
        private List<string> avgCondition = new List<string>();
        private HistoryDataService _historyDataService = new HistoryDataService();
        public FrmReport()
        {
            InitializeComponent();


            this.cmb_ReportType.Items.Add("小时报表");
            this.cmb_ReportType.Items.Add("日报表");
            this.cmb_ReportType.SelectedIndex = 0;

            InitialColumnList();
        }

        private void InitialColumnList()
        {
            List<string> columnList = new List<string>();
            columnList.Add("PressureIn");
            columnList.Add("PressureOut");
            columnList.Add("TempIn1");
            columnList.Add("TempIn2");
            columnList.Add("TempOut");
            columnList.Add("PressureTank1");
            columnList.Add("PressureTank2");
            columnList.Add("LevelTank1");
            columnList.Add("LevelTank2");
            columnList.Add("PressureTankOut");

            foreach (var item in columnList)
            {
                maxCondition.Add($"Max({item})");
                minCondition.Add($"Min({item})");
                avgCondition.Add($"Avg({item})");
            }
        }

        #region 无边框拖动 

        private Point mPoint;
        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }

        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }

        #endregion

        private void cmb_ReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cmb_ReportType.SelectedIndex)
            {
                case 0:
                    this.dtp_ReportTime.CustomFormat = "yyyy-MM-dd HH:00:00";
                    break;
                case 1:
                    this.dtp_ReportTime.CustomFormat = "yyyy-MM-dd 00:00:00";
                    break;
                default:
                    this.dtp_ReportTime.CustomFormat = "yyyy-MM-dd HH:00:00";
                    break;
            }
        }


        private void lbl_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Query_Click(object sender, EventArgs e)
        {
            List<string> startList = new List<string>();
            List<string> endList = new List<string>();

            DateTime dateTime =Convert.ToDateTime(this.dtp_ReportTime.Text);

            switch (this.cmb_ReportType.SelectedIndex)
            {
                case 0:
                    for (int i = 0;i<60;i++)
                    {
                        startList.Add(dateTime.AddMinutes(i).ToString("yyyy-MM-dd HH:mm:00"));
                        endList.Add(dateTime.AddMinutes(i+1).ToString("yyyy-MM-dd HH:mm:59"));
                    }
                    break;
                case 1:
                    for (int i = 0; i < 24; i++)
                    {
                        startList.Add(dateTime.AddHours(i).ToString("yyyy-MM-dd HH:mm:00"));
                        endList.Add(dateTime.AddHours(i + 1).ToString("yyyy-MM-dd HH:mm:59"));
                    }
                    break;
                default:
                    break;
            }

            List<string> conditionList = this.rdb_Max.Checked ? maxCondition : (this.rdb_Min.Checked ? minCondition : avgCondition);

            Task.Run(() =>
            {
                Task<OperateResult<DataTable>>[] taskList = new Task<OperateResult<DataTable>>[startList.Count];
                for (int i = 0;i<taskList.Length;i++)
                {
                    taskList[i] = Task.Factory.StartNew((index) =>
                    {
                        return _historyDataService.GetReportDataByCondition(startList[(int)index], endList[(int)index], conditionList,index.ToString());

                    }, i);
                }
                Task<OperateResult<DataTable>[]> task = Task.WhenAll(taskList);
                if (task.Result.Length>0&&task.Result.First().IsSuccess)
                {
                    DataTable dataTable = GetAllDataTable(task.Result);
                    if (dataTable!=null)
                    {
                        UpdateDataTable(dataTable,startList);
                    }
                    else
                    {
                        this.Invoke(new Action(() =>
                        {
                            new FrmMsgNoAck("查询到数据为空", "数据查询").ShowDialog();
                        }));
                    }
                }
                else
                {
                    this.Invoke(new Action(() =>
                    {
                        new FrmMsgNoAck("没有查询到数据", "数据查询").ShowDialog();
                    }));
                        
                }
            });
        }

        private void UpdateDataTable(DataTable dataTable, List<string> startList)
        {
            if (this.dgv_Data.InvokeRequired)
            {
                this.dgv_Data.Invoke(new Action<DataTable, List<string>>(UpdateDataTable), dataTable, startList);
            }
            else
            {
                this.dgv_Data.Rows.Clear();
                for (int i = 0;i<dataTable.Rows.Count;i++)
                {
                    int rowIndex = this.dgv_Data.Rows.Add();
                    this.dgv_Data.Rows[rowIndex].Cells[0].Value = startList[i];
                    for (int j = 0;j<dataTable.Columns.Count;j++)
                    {
                        if (dataTable.Rows[rowIndex][j] is DBNull)
                        {
                            this.dgv_Data.Rows[rowIndex].Cells[j + 1].Value = "---";
                        }
                        else
                        {
                            this.dgv_Data.Rows[rowIndex].Cells[j + 1].Value = dataTable.Rows[rowIndex][j];
                        }
                        
                    }
                }
            }
        }

        private DataTable GetAllDataTable(OperateResult<DataTable>[] dataTable)
        {
            List<DataTable> dataTableList = new List<DataTable>();
            foreach (var item in dataTable)
            {
                if (item.IsSuccess)
                {
                    dataTableList.Add(item.Content);
                }
            }
            if (dataTableList.Count > 0)
            {
                dataTableList = dataTableList.OrderBy(x => Convert.ToInt32(x.TableName)).ToList();
                DataTable resultTable = dataTableList.First().Clone();
                object[] rowData = new object[resultTable.Columns.Count];
                for (int i = 0;i < dataTableList.Count; i++)
                {
                    for (int j = 0;j < dataTableList[i].Rows.Count;j++)
                    {
                        dataTableList[i].Rows[j].ItemArray.CopyTo(rowData, 0);
                        resultTable.Rows.Add(rowData);
                    }
                }
                return resultTable;
            }
            else
            {
                return null;
            }

            
        }

        private void dgv_Data_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewHelper.DgvRowPostPaint(this.dgv_Data, e);
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Title = "选择文件";
            saveFileDialog.Filter = "Excel文件(*.xlsx)|*.xlsx|CSV文件(*.csv)|*.csv";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.FileName = "数据报表_" + Convert.ToDateTime(this.dtp_ReportTime.Text).ToString("yyyyMMddHHmmss")
                +"_"+this.cmb_ReportType.Text;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    MiniExcel.SaveAsAsync(saveFileDialog.FileName, GetHistoryDataFromDgv());
                    Process.Start(saveFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    new FrmMsgNoAck("导出失败:" + ex.Message, "数据导出").ShowDialog();
                }
            }
        }

        private List<HistoryData> GetHistoryDataFromDgv()
        {
            if (this.dgv_Data.Rows.Count > 0)
            {
                List<HistoryData> historyDatas = new List<HistoryData>();
                foreach (DataGridViewRow item in this.dgv_Data.Rows)
                {
                    historyDatas.Add(new HistoryData()
                    {
                        InsertTime = Convert.ToDateTime(item.Cells[0].Value),
                        PressureIn = item.Cells[1].Value.ToString(),
                        PressureOut = item.Cells[2].Value.ToString(),
                        TempIn1 = item.Cells[3].Value.ToString(),
                        TempIn2 = item.Cells[4].Value.ToString(),
                        TempOut = item.Cells[5].Value.ToString(),
                        PressureTank1 = item.Cells[6].Value.ToString(),
                        PressureTank2 = item.Cells[7].Value.ToString(),
                        LevelTank1 = item.Cells[8].Value.ToString(),
                        LevelTank2 = item.Cells[9].Value.ToString(),
                        PressureTankOut = item.Cells[10].Value.ToString()
                    });
                }
                return historyDatas;
            }
            else
            {
                return new List<HistoryData>();
            }
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            DataGridViewHelper.Print_DataGridView(this.dgv_Data);
        }
    }
}
