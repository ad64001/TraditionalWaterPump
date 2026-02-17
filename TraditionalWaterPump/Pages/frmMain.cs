using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TraditionalWaterPump.ViewModels;
using xbd.s7netplus;

namespace TraditionalWaterPump
{
    public partial class frmMain : Form
    {
        /// <summary>
        /// 系统配置路径
        /// </summary>
        private string sysInfoPath = Application.StartupPath + "\\SysInfo.ini";
        /// <summary>
        /// 系统配置服务
        /// </summary>
        private SysInfoService infoService = new SysInfoService();
        /// <summary>
        /// 系统配置对象
        /// </summary>
        private SysInfo sysInfo = new SysInfo();
        /// <summary>
        /// 多线程取消源
        /// </summary>
        private CancellationTokenSource cts;

        /// <summary>
        /// Plc服务
        /// </summary>
        private PlcDataService plcDataService = new PlcDataService();
        public frmMain()
        {
            InitializeComponent();
            this.Load += frmMain_Load;
            this.FormClosing += frmMain_FormClosing;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            cts.Cancel();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            this.sysInfo = infoService.GetSysInfoFromPath(sysInfoPath);

            if (sysInfo == null)
            {
                new FrmMsgNoAck("系统配置加载失败", "系统配置").ShowDialog();
                return;
            }

            cts = new CancellationTokenSource();

            Task.Run(new Action(() =>
            {
                PLCCommunication();
            }));
        }
        /// <summary>
        /// 多线程方法
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>

        private void PLCCommunication()
        {
            while (!cts.IsCancellationRequested)
            {
                if (plcDataService.IsConnected)
                {
                    var data = plcDataService.ReadPlcData();
                    if (data.IsSuccess)
                    {
                        plcDataService.ErrorTimes = 0;
                        this.UpdataUIData(data.Content);
                    }
                    else
                    {
                        plcDataService.ErrorTimes++;
                        if (plcDataService.ErrorTimes >= plcDataService.AllowErrorTimes)
                        {
                            plcDataService.IsConnected = false;
                        }
                    }

                }
                else
                {
                    if (plcDataService.IsFristScan)
                    {
                        Thread.Sleep(6000);
                        plcDataService.Disconnect();

                    }
                    else
                    {
                        plcDataService.IsFristScan = false;
                    }

                    var result = plcDataService.Connect(this.sysInfo);
                    plcDataService.IsConnected = result.IsSuccess;
                }
            }
        }

        /// <summary>
        /// 通用UI更新方法
        /// </summary>
        /// <param name="plcData"></param>
        private void UpdataUIData(PlcData plcData)
        {

        }

        private void btn_ParamSet_Click(object sender, EventArgs e)
        {
            new FrmParamSet(this.sysInfo,this.infoService,this.sysInfoPath).ShowDialog();
        }
    }

}
