using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TraditionalWaterPump.ViewModels;
using xbd.ControlLib;
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

        /// <summary>
        /// Timer服务
        /// </summary>
        private System.Windows.Forms.Timer updataTimer = new System.Windows.Forms.Timer();

        /// <summary>
        /// 第一次扫描
        /// </summary>
        private bool FirstScan = true;

        private MessageFilter _messageFilter;

        private DateTime LoginTime = DateTime.Now;

        private CameraHelper _cameraHelper;

        public frmMain()
        {
            InitializeComponent();

            this.updataTimer.Interval = 500;
            this.updataTimer.Tick += UpdataTimer_Tick;
            this.updataTimer.Start();

            this.Load += frmMain_Load;
            this.FormClosing += frmMain_FormClosing;
        }

        private void UpdataTimer_Tick(object sender, EventArgs e)
        {
            this.lbl_Time.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + new CultureInfo("zh-CN").DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek);

            if (plcDataService != null)
            {
                this.led_PLCState.State = plcDataService.IsConnected;
            }

            if (sysInfo.ScreenTime>0)
            {
                Program.TickCount++;
                if (sysInfo.ScreenTime*1000/this.updataTimer.Interval == Program.TickCount)
                {
                    LockWorkStation();
                }
            }

            if (sysInfo.LogoffTime>0)
            {
                if (Program.CurrentUser!=null)
                {
                    TimeSpan timeSpan = DateTime.Now - LoginTime;
                    if (timeSpan.TotalSeconds>sysInfo.LogoffTime)
                    {
                        Program.CurrentUser = null;
                        this.btn_UserLogin.Text = "用户登录";
                    }
                }
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _cameraHelper?.StopCamera();
            cts?.Cancel();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            this.sysInfo = infoService.GetSysInfoFromPath(sysInfoPath);

            if (sysInfo == null)
            {
                new FrmMsgNoAck("系统配置加载失败", "系统配置").ShowDialog();
                return;
            }

            if (sysInfo.ScreenTime > 0)
            {
                _messageFilter = new MessageFilter();
                Application.AddMessageFilter(_messageFilter);
            }

            cts = new CancellationTokenSource();

            Task.Run(new Action(() =>
            {
                PLCCommunication();
            }));

            this._cameraHelper = new CameraHelper(sysInfo.CameraIndex,this.vsp_Panel);
            this._cameraHelper.StartCamera();
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
                    Thread.Sleep(300);

                }
                else
                {
                    if (plcDataService.IsFristScan)
                    {
                        Thread.Sleep(4000);
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
            if (this.InvokeRequired)
            {
                try
                {
                    this.Invoke(new Action<PlcData>(UpdataUIData), plcData);
                }
                catch (Exception)
                {
                    return;
                }
                
            }
            else
            {
                //第一次扫描
                if (FirstScan)
                {
                    this.tg_Pump1.Checked = plcData.InPump1State;
                    this.tg_Pump2.Checked = plcData.InPump2State;
                    FirstScan = false;
                }
                this.lbl_PressureIn.Text = plcData.PressureIn.ToString("f2") + " bar";
                this.lbl_PressureOut.Text = plcData.PressureOut.ToString("f2") + " bar";
                this.meter_PressureIn.Value = plcData.PressureIn;
                this.meter_PressureOut.Value = plcData.PressureOut;

                this.ms_TempIn1.ParamValue = plcData.TempIn1;
                this.ms_TempIn2.ParamValue = plcData.TempIn2;
                this.ms_TempOut.ParamValue = plcData.TempOut;
                this.ms_PressureTank1.ParamValue = plcData.PressureTank1;
                this.ms_PressureTank2.ParamValue = plcData.PressureTank2;
                this.ms_PressureTankOut.ParamValue = plcData.PressureTankOut;

                this.led_RunState.State = plcData.SysRunState;
                this.led_SysAlarmState.State = !plcData.SysAlarmState;

                this.lbl_PressureTank1.Text = plcData.PressureTank1.ToString("f2");
                this.lbl_PressureLevel1.Text = plcData.PressureTank1.ToString("f2");
                this.lbl_PressureTank2.Text = plcData.PressureTank2.ToString("f2");
                this.lbl_PressureLevel2.Text = plcData.PressureTank2.ToString("f2");
                this.lbl_PressureTankOut.Text = plcData.PressureTankOut.ToString("f2");

                this.lbl_TempIn1.Text = plcData.TempIn1.ToString("f2");
                this.lbl_TempIn2.Text = plcData.TempIn2.ToString("f2");
                this.lbl_TempOut.Text = plcData.TempOut.ToString("f2");

                this.pump_In1.IsRun = plcData.InPump1State;
                this.pump_In2.IsRun = plcData.InPump2State;

                this.valve_In.State = plcData.ValveInState;
                this.valve_Out.State = plcData.ValveOutState;

                this.motor_Pump1.PumpState = plcData.CirclePump2State ? PumpState.运行 : PumpState.停止;
                this.motor_Pump2.PumpState = plcData.CirclePump1State ? PumpState.运行 : PumpState.停止;

                this.wave_Tank1.Value = Convert.ToInt32((plcData.LevelTank1 / 2.0f) * 100.0f);
                this.wave_Tank2.Value = Convert.ToInt32((plcData.LevelTank2 / 2.0f) * 100.0f);

                this.lbl_PreTankOut.Text = plcData.PressureTankOut.ToString("f2");

                this.btn_Pump1.Text = plcData.CirclePump1State ? "停止" : "启动";
                this.btn_Pump2.Text = plcData.CirclePump2State ? "停止" : "启动";
            }
            
        }

        private void btn_ParamSet_Click(object sender, EventArgs e)
        {
            new FrmParamSet(this.sysInfo,this.infoService,this.sysInfoPath).ShowDialog();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Pump1_Click(object sender, EventArgs e)
        {
            plcDataService.InCirclePump1Control(this.btn_Pump1.Text == "启动");
        }

        private void btn_Pump2_Click(object sender, EventArgs e)
        {
            plcDataService.InCirclePump2Control(this.btn_Pump2.Text == "启动");
        }

        private void tg_Pump2_CheckedChanged(object sender, EventArgs e)
        {
            if (plcDataService.InPump2Control(this.tg_Pump2.Checked)==false)
            {
                this.tg_Pump2.CheckedChanged -= tg_Pump2_CheckedChanged;
                this.tg_Pump2.Checked = !this.tg_Pump2.Checked;
                this.tg_Pump2.CheckedChanged += tg_Pump2_CheckedChanged;
            }
        }

        private void tg_Pump1_CheckedChanged(object sender, EventArgs e)
        {
            if (plcDataService.InPump1Control(this.tg_Pump1.Checked)==false)
            {
                this.tg_Pump1.CheckedChanged -= tg_Pump1_CheckedChanged;
                this.tg_Pump1.Checked = !this.tg_Pump1.Checked;
                this.tg_Pump1.CheckedChanged += tg_Pump1_CheckedChanged;
            }
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            plcDataService.SysReset();
        }

        private void CommonValve_In_DoubleClick(object sender, EventArgs e)
        {
            if (sender is xbdValve valve)
            {
                FrmValveControl frmValveControl = new FrmValveControl(valve.ValveName,valve.State,this.plcDataService);
                frmValveControl.ShowDialog();
            }
        }

        #region 系统锁屏

        [DllImport("user32")]
        public static extern bool LockWorkStation();

        #endregion
    }

    #region 消息筛选器 
    public class MessageFilter : IMessageFilter
    {
        public bool PreFilterMessage(ref Message m)
        {
            //如果检测到有鼠标或则键盘的消息，则使计数为0.....
            if (m.Msg == 0x0200 || m.Msg == 0x0201 || m.Msg == 0x0204 || m.Msg == 0x0207)
            {
                Program.TickCount = 0;
            }
            return false;
        }
    }
    #endregion
}
