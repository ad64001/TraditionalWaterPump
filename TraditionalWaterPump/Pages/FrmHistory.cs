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

namespace TraditionalWaterPump
{
    public partial class FrmHistory : Form
    {
        private HistoryDataService _historyDataService = new HistoryDataService();
        private List<HistoryData> _historyDataList = new List<HistoryData>();
        public FrmHistory()
        {
            InitializeComponent();

            this.dgv_Data.AutoGenerateColumns = false;
            this.dgv_Data.Columns[0].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

            this.dtp_Start.Value = DateTime.Now.AddHours(-2.0);
            this.dtp_End.Value = DateTime.Now;
        }

        private void lbl_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Query_Click(object sender, EventArgs e)
        {
            TimeSpan timeSpan = this.dtp_End.Value - this.dtp_Start.Value;
            if (timeSpan.TotalSeconds<0)
            {
                new FrmMsgNoAck("开始时间不能大于结束时间","数据查询").ShowDialog();
                return;
            }

            var result = _historyDataService.GetHistoryDataByTime(this.dtp_Start.Value, this.dtp_End.Value);
            if (result.IsSuccess)
            {
                if (result.Content.Count > 0)
                {
                    this._historyDataList = result.Content;
                    this.dgv_Data.DataSource = null;
                    this.dgv_Data.DataSource = result.Content;
                }
                else
                {
                    new FrmMsgNoAck("该时间未查询到数据", "数据查询").ShowDialog();
                }
            }
            else
            {
                new FrmMsgNoAck("查询出错"+result.Message, "数据查询").ShowDialog();
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
            saveFileDialog.FileName = "历史数据_" +this.dtp_Start.Value.ToString("yyyyMMddHHmmss")+"_"+this.dtp_End.Value.ToString("yyyyMMddHHmmss");

            if (saveFileDialog.ShowDialog()==DialogResult.OK)
            {
                try
                {
                    MiniExcel.SaveAsAsync(saveFileDialog.FileName, this._historyDataList);
                    Process.Start(saveFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    new FrmMsgNoAck("导出失败:"+ex.Message,"数据导出").ShowDialog();
                }
            }

        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            DataGridViewHelper.Print_DataGridView(this.dgv_Data);
        }
    }
}
