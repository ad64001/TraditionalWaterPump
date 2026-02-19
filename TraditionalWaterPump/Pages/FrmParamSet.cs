using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TraditionalWaterPump.ViewModels
{
    public partial class FrmParamSet : Form
    {
        private SysInfo _sysInfo;
        private SysInfoService _infoService;
        private string _sysInfoPath;

        public FrmParamSet(SysInfo sysInfo, SysInfoService infoService, string sysInfoPath)
        {
            InitializeComponent();
            _sysInfo = sysInfo;
            _infoService = infoService;
            _sysInfoPath = sysInfoPath;

            this.tx_cpu.DataSource = Enum.GetNames(typeof(xbd.s7netplus.CpuType));

            if (this._sysInfo!=null)
            {
                this.tx_Ip.Text = this._sysInfo.IpAddress;
                this.tx_cpu.Text = this._sysInfo.CpuType.ToString();
                this.tx_rack.Text = this._sysInfo.Rack.ToString();
                this.tx_slot.Text = this._sysInfo.Slot.ToString();

                this.xt_autoStart.Checked = this._sysInfo.AutoStart;
                this.xt_screenTime.Text = this._sysInfo.ScreenTime.ToString();
                this.xt_logoffTime.Text = this._sysInfo.LogoffTime.ToString();

            }
            this.xt_autoStart.CheckedChanged += this.xt_autoStart_CheckedChanged;


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

        private void btn_PlcSet_Click(object sender, EventArgs e)
        {
            if (this._sysInfo==null)
            {
                this._sysInfo = new SysInfo();
            }

            this._sysInfo.IpAddress = this.tx_Ip.Text;
            this._sysInfo.CpuType = (xbd.s7netplus.CpuType)Enum.Parse(typeof(xbd.s7netplus.CpuType), this.tx_cpu.Text.Trim(),true);
            this._sysInfo.Rack = Convert.ToInt16(this.tx_rack.Text.Trim());
            this._sysInfo.Slot = Convert.ToInt16(this.tx_slot.Text.Trim());

            bool result = _infoService.SetSysInfoToPath(this._sysInfo, this._sysInfoPath);
            if (result)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                new FrmMsgNoAck("通信参数写入失败","通信参数").ShowDialog();
            }
        }

        private void btn_PlcCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btn_SysSet_Click(object sender, EventArgs e)
        {
            if (this._sysInfo == null)
            {
                this._sysInfo = new SysInfo();
            }

            this._sysInfo.AutoStart = this.xt_autoStart.Checked;
            this._sysInfo.ScreenTime = Convert.ToInt32(this.xt_screenTime.Text.Trim());
            this._sysInfo.LogoffTime = Convert.ToInt32(this.xt_logoffTime.Text.Trim());
            this._sysInfo.CameraIndex = this.xt_cameraIndex.SelectedIndex;

            bool result = _infoService.SetSysInfoToPath(this._sysInfo, this._sysInfoPath);
            if (result)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                new FrmMsgNoAck("通信参数写入失败", "通信参数").ShowDialog();
            }
        }

        private void btn_SysCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void lbl_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void xt_autoStart_CheckedChanged(object sender, EventArgs e)
        {
            AutoStart(this.xt_autoStart.Checked);
        }

        #region 开机启动
        /// <summary>  
        /// 修改程序在注册表中的键值  
        /// </summary>  
        /// <param name="isAuto">true:开机启动,false:不开机自启</param> 
        private void AutoStart(bool isAuto = true)
        {
            if (isAuto == true)
            {
                RegistryKey R_local = Registry.CurrentUser;
                RegistryKey R_run = R_local.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                R_run.SetValue("TraditionalWaterPump", System.Windows.Forms.Application.ExecutablePath);
                R_run.Close();
                R_local.Close();
            }
            else
            {
                RegistryKey R_local = Registry.CurrentUser;
                RegistryKey R_run = R_local.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                R_run.DeleteValue("TraditionalWaterPump", false);
                R_run.Close();
                R_local.Close();
            }
        }
        #endregion
    }
}
