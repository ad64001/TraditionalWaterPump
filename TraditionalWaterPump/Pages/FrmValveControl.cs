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
    public partial class FrmValveControl : Form
    {
        public FrmValveControl(string valveName,bool state,PlcDataService dataService)
        {
            InitializeComponent();
            this.TopMost = true;
            this.state = state;
            this.dataService = dataService;
            this.valveName = valveName;
            this.lbl_Message.Text = $"当前{valveName}状态：{(state ? "开" : "关")}\n点击确定将切换状态";

        }

        private string valveName = string.Empty;
        private bool state = false;
        private PlcDataService dataService;

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (dataService.IsConnected)
            {
                bool result = true;
                switch (valveName)
                {
                    case "进水阀":
                        result = dataService.ValveInControl(!this.state);
                        break;
                    case "出水阀":
                        result = dataService.ValveOutControl(!this.state);
                        break;
                    default:
                        new FrmMsgNoAck("未知阀门", "阀门控制").ShowDialog();
                        break;
                }

                if (result)
                {
                   this.DialogResult = DialogResult.OK;
                }
                else
                {
                    new FrmMsgNoAck("阀门控制失败", "阀门控制").ShowDialog();
                }
            }
            else
            {
                new FrmMsgNoAck("PLC连接错误", "阀门控制").ShowDialog();
            }
            
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void lbl_exit_Click(object sender, EventArgs e)
        {
            this.Close();
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
