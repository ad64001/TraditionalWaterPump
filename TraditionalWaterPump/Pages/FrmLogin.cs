using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TraditionalWaterPump.ViewModels;

namespace TraditionalWaterPump
{
    public partial class FrmLogin : Form
    {
        private SysAdminService sysAdminService = new SysAdminService();
        public FrmLogin()
        {
            InitializeComponent();
            this.Load += FrmLogin_Load;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            var sysAdmins = sysAdminService.QuerySysAdmin();
            if (sysAdmins.Count>0)
            {
                foreach (var item in sysAdmins)
                {
                    this.cmb_User.Items.Add(item.LoginName);
                }
                this.cmb_User.SelectedIndex = 0;
            }
            else
            {
                new FrmMsgNoAck("没有可以使用的用户","登录提示").ShowDialog();
            }
        }

        private void lbl_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (this.cmb_User.Text.Trim().Length == 0)
            {
                new FrmMsgNoAck("选择登录用户","登录提示").ShowDialog();
                return;
            }

            if (this.tb_Pwd.Text.Trim().Length == 0)
            {
                new FrmMsgNoAck("输入登陆密码", "登录提示").ShowDialog();
                return;
            }

            SysAdmin sysAdmin = new SysAdmin()
            {
                LoginName = this.cmb_User.Text.Trim(),
                LoginPwd = this.tb_Pwd.Text.Trim()
            };

            sysAdmin = sysAdminService.AdminLogin(sysAdmin);
            if (sysAdmin == null)
            {
                new FrmMsgNoAck("登录错误", "登录提示").ShowDialog();
                return;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                Program.CurrentUser = sysAdmin;
            }

        }

        private void btn_Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Login_Click(null,null);
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
