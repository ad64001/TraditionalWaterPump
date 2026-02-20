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
    public partial class FrmUserManager : Form
    {
        private SysAdminService sysAdminService = new SysAdminService();
        private List<SysAdmin> sysAdmins = new List<SysAdmin>();
        public FrmUserManager()
        {
            InitializeComponent();
            this.dgv_User.AutoGenerateColumns = false;
            this.Load += FrmUserManager_Load;
        }

        private void FrmUserManager_Load(object sender, EventArgs e)
        {
            this.cmb_Role.Items.AddRange(Enum.GetNames(typeof(RoleName)));
            RefreshUserList();
            if (sysAdmins.Count>0)
            {
                UpdateUserInfo(sysAdmins.First());
            }
        }

        private void RefreshUserList()
        {
            sysAdmins = sysAdminService.QuerySysAdmin();
            if (sysAdmins.Count > 0)
            {
                this.dgv_User.DataSource = null;
                this.dgv_User.DataSource = sysAdmins;
            }
            else
            {
                this.dgv_User.DataSource = null;
            }
        }

        private void UpdateUserInfo(SysAdmin sysAdmin)
        {
            this.tb_UserName.Text = sysAdmin.LoginName;
            this.tb_UserPwd.Text = sysAdmin.LoginPwd;
            this.cmb_Role.Text = sysAdmin.RoleName.ToString();
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

        private void dgv_User_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewHelper.DgvRowPostPaint(this.dgv_User, e);
        }

        private void lbl_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (this.tb_UserName.Text.Trim().Length == 0)
            {
                new FrmMsgNoAck("用户名为空","增加用户").ShowDialog();
                return;
            }
            if (this.tb_UserPwd.Text.Trim().Length == 0)
            {
                new FrmMsgNoAck("密码为空", "增加用户").ShowDialog();
                return;
            }
            if (this.cmb_Role.Text.Trim().Length == 0)
            {
                new FrmMsgNoAck("角色名为空", "增加用户").ShowDialog();
                return;
            }

            if (sysAdmins.Where(s => s.LoginName == this.tb_UserName.Text.Trim()).Count()>0)
            {
                    new FrmMsgNoAck("用户名已存在", "增加用户").ShowDialog();
                    return;
            }

            SysAdmin sysAdmin = new SysAdmin()
            {
                LoginName = this.tb_UserName.Text.Trim(),
                LoginPwd = this.tb_UserPwd.Text.Trim(),
                RoleName = (RoleName)Enum.Parse(typeof(RoleName), this.cmb_Role.Text.Trim())
            };

            if (sysAdminService.AddSysAdmin(sysAdmin))
            {
                RefreshUserList();
            }
            else
            {
                new FrmMsgNoAck("增加用户失败", "增加用户").ShowDialog();
                return;
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (this.tb_UserName.Text.Trim().Length == 0)
            {
                new FrmMsgNoAck("用户名为空", "修改用户").ShowDialog();
                return;
            }
            if (this.tb_UserPwd.Text.Trim().Length == 0)
            {
                new FrmMsgNoAck("密码为空", "修改用户").ShowDialog();
                return;
            }
            if (this.cmb_Role.Text.Trim().Length == 0)
            {
                new FrmMsgNoAck("角色名为空", "修改用户").ShowDialog();
                return;
            }

            SysAdmin sysAdmin = new SysAdmin()
            {
                LoginId = sysAdmins[this.dgv_User.SelectedRows[0].Index].LoginId,
                LoginName = this.tb_UserName.Text.Trim(),
                LoginPwd = this.tb_UserPwd.Text.Trim(),
                RoleName = (RoleName)Enum.Parse(typeof(RoleName), this.cmb_Role.Text.Trim())
            };

            if (sysAdminService.UpdateSysAdmin(sysAdmin))
            {
                RefreshUserList();
            }
            else
            {
                new FrmMsgNoAck("修改用户失败", "修改用户").ShowDialog();
                return;
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (this.dgv_User.SelectedRows.Count > 0)
            {
                int loginId = sysAdmins[this.dgv_User.SelectedRows[0].Index].LoginId;
                if (sysAdminService.DeleteSysAdmin(loginId))
                {
                    RefreshUserList();
                }
                else
                {
                    new FrmMsgNoAck("删除用户失败", "修改用户").ShowDialog();
                    return;
                }
            }
        }
    }
}
