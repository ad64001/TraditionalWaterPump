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
    }
}
