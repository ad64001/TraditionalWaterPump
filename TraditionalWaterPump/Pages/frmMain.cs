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
        public frmMain()
        {
            InitializeComponent();
            this.Load += frmMain_Load;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.sysInfo = infoService.GetSysInfoFromPath(sysInfoPath);

            if (sysInfo == null)
            {
                new FrmMsgNoAck("系统配置加载失败", "系统配置").ShowDialog();
                return;
            }
        }

        private void btn_ParamSet_Click(object sender, EventArgs e)
        {
            new FrmParamSet(this.sysInfo,this.infoService,this.sysInfoPath).ShowDialog();
        }
    }

}
