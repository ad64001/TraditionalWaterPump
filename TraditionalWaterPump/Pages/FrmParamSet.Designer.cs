namespace TraditionalWaterPump.ViewModels
{
    partial class FrmParamSet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainPanel = new System.Windows.Forms.Panel();
            this.xt_cameraIndex = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tx_cpu = new System.Windows.Forms.ComboBox();
            this.xt_autoStart = new xbd.ControlLib.xbdToggle();
            this.btn_SysCancel = new System.Windows.Forms.Button();
            this.btn_SysSet = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.xt_logoffTime = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.xt_screenTime = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_PlcCancel = new System.Windows.Forms.Button();
            this.btn_PlcSet = new System.Windows.Forms.Button();
            this.tx_slot = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tx_rack = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tx_Ip = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.lbl_exit = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.MainPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.TopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(45)))));
            this.MainPanel.Controls.Add(this.xt_cameraIndex);
            this.MainPanel.Controls.Add(this.label16);
            this.MainPanel.Controls.Add(this.tx_cpu);
            this.MainPanel.Controls.Add(this.xt_autoStart);
            this.MainPanel.Controls.Add(this.btn_SysCancel);
            this.MainPanel.Controls.Add(this.btn_SysSet);
            this.MainPanel.Controls.Add(this.label10);
            this.MainPanel.Controls.Add(this.xt_logoffTime);
            this.MainPanel.Controls.Add(this.label11);
            this.MainPanel.Controls.Add(this.xt_screenTime);
            this.MainPanel.Controls.Add(this.label12);
            this.MainPanel.Controls.Add(this.label13);
            this.MainPanel.Controls.Add(this.label14);
            this.MainPanel.Controls.Add(this.label9);
            this.MainPanel.Controls.Add(this.btn_PlcCancel);
            this.MainPanel.Controls.Add(this.btn_PlcSet);
            this.MainPanel.Controls.Add(this.tx_slot);
            this.MainPanel.Controls.Add(this.label8);
            this.MainPanel.Controls.Add(this.tx_rack);
            this.MainPanel.Controls.Add(this.label7);
            this.MainPanel.Controls.Add(this.label6);
            this.MainPanel.Controls.Add(this.tx_Ip);
            this.MainPanel.Controls.Add(this.label5);
            this.MainPanel.Controls.Add(this.label4);
            this.MainPanel.Controls.Add(this.panel1);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(1, 1);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(594, 345);
            this.MainPanel.TabIndex = 0;
            // 
            // xt_cameraIndex
            // 
            this.xt_cameraIndex.FormattingEnabled = true;
            this.xt_cameraIndex.Location = new System.Drawing.Point(448, 242);
            this.xt_cameraIndex.Name = "xt_cameraIndex";
            this.xt_cameraIndex.Size = new System.Drawing.Size(122, 23);
            this.xt_cameraIndex.TabIndex = 31;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(45)))));
            this.label16.Font = new System.Drawing.Font("宋体", 12F);
            this.label16.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label16.Location = new System.Drawing.Point(541, 204);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 20);
            this.label16.TabIndex = 30;
            this.label16.Text = "秒";
            // 
            // tx_cpu
            // 
            this.tx_cpu.FormattingEnabled = true;
            this.tx_cpu.Location = new System.Drawing.Point(118, 156);
            this.tx_cpu.Name = "tx_cpu";
            this.tx_cpu.Size = new System.Drawing.Size(121, 23);
            this.tx_cpu.TabIndex = 28;
            // 
            // xt_autoStart
            // 
            this.xt_autoStart.Checked = false;
            this.xt_autoStart.FalseColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.xt_autoStart.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xt_autoStart.Location = new System.Drawing.Point(468, 108);
            this.xt_autoStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xt_autoStart.Name = "xt_autoStart";
            this.xt_autoStart.Size = new System.Drawing.Size(77, 33);
            this.xt_autoStart.SwitchType = xbd.ControlLib.SwitchType.Quadrilateral;
            this.xt_autoStart.TabIndex = 27;
            this.xt_autoStart.Texts = null;
            this.xt_autoStart.TrueColor = System.Drawing.Color.LimeGreen;
            // 
            // btn_SysCancel
            // 
            this.btn_SysCancel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_SysCancel.FlatAppearance.BorderSize = 0;
            this.btn_SysCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SysCancel.Image = global::TraditionalWaterPump.Properties.Resources.Yellow;
            this.btn_SysCancel.Location = new System.Drawing.Point(468, 284);
            this.btn_SysCancel.Name = "btn_SysCancel";
            this.btn_SysCancel.Size = new System.Drawing.Size(85, 33);
            this.btn_SysCancel.TabIndex = 26;
            this.btn_SysCancel.Text = "取消设置";
            this.btn_SysCancel.UseVisualStyleBackColor = true;
            this.btn_SysCancel.Click += new System.EventHandler(this.btn_SysCancel_Click);
            // 
            // btn_SysSet
            // 
            this.btn_SysSet.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_SysSet.FlatAppearance.BorderSize = 0;
            this.btn_SysSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SysSet.Image = global::TraditionalWaterPump.Properties.Resources.Pink;
            this.btn_SysSet.Location = new System.Drawing.Point(371, 284);
            this.btn_SysSet.Name = "btn_SysSet";
            this.btn_SysSet.Size = new System.Drawing.Size(91, 33);
            this.btn_SysSet.TabIndex = 25;
            this.btn_SysSet.Text = "设置完成";
            this.btn_SysSet.UseVisualStyleBackColor = true;
            this.btn_SysSet.Click += new System.EventHandler(this.btn_SysSet_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 12F);
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label10.Location = new System.Drawing.Point(322, 241);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 20);
            this.label10.TabIndex = 23;
            this.label10.Text = "摄像头索引:";
            // 
            // xt_logoffTime
            // 
            this.xt_logoffTime.Location = new System.Drawing.Point(450, 200);
            this.xt_logoffTime.Name = "xt_logoffTime";
            this.xt_logoffTime.Size = new System.Drawing.Size(85, 25);
            this.xt_logoffTime.TabIndex = 22;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 12F);
            this.label11.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label11.Location = new System.Drawing.Point(345, 200);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 20);
            this.label11.TabIndex = 21;
            this.label11.Text = "注销时间:";
            // 
            // xt_screenTime
            // 
            this.xt_screenTime.Location = new System.Drawing.Point(450, 158);
            this.xt_screenTime.Name = "xt_screenTime";
            this.xt_screenTime.Size = new System.Drawing.Size(85, 25);
            this.xt_screenTime.TabIndex = 20;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 12F);
            this.label12.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label12.Location = new System.Drawing.Point(345, 157);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 20);
            this.label12.TabIndex = 19;
            this.label12.Text = "熄屏时间:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 12F);
            this.label13.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label13.Location = new System.Drawing.Point(345, 117);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(119, 20);
            this.label13.TabIndex = 17;
            this.label13.Text = "开机自启动:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label14.Location = new System.Drawing.Point(345, 76);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 18);
            this.label14.TabIndex = 16;
            this.label14.Text = "系统参数";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("宋体", 12F);
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Location = new System.Drawing.Point(290, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(2, 241);
            this.label9.TabIndex = 15;
            this.label9.Text = "IP:";
            // 
            // btn_PlcCancel
            // 
            this.btn_PlcCancel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_PlcCancel.FlatAppearance.BorderSize = 0;
            this.btn_PlcCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_PlcCancel.Image = global::TraditionalWaterPump.Properties.Resources.Yellow;
            this.btn_PlcCancel.Location = new System.Drawing.Point(154, 283);
            this.btn_PlcCancel.Name = "btn_PlcCancel";
            this.btn_PlcCancel.Size = new System.Drawing.Size(85, 33);
            this.btn_PlcCancel.TabIndex = 14;
            this.btn_PlcCancel.Text = "取消设置";
            this.btn_PlcCancel.UseVisualStyleBackColor = true;
            this.btn_PlcCancel.Click += new System.EventHandler(this.btn_PlcCancel_Click);
            // 
            // btn_PlcSet
            // 
            this.btn_PlcSet.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_PlcSet.FlatAppearance.BorderSize = 0;
            this.btn_PlcSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_PlcSet.Image = global::TraditionalWaterPump.Properties.Resources.Pink;
            this.btn_PlcSet.Location = new System.Drawing.Point(57, 283);
            this.btn_PlcSet.Name = "btn_PlcSet";
            this.btn_PlcSet.Size = new System.Drawing.Size(91, 33);
            this.btn_PlcSet.TabIndex = 13;
            this.btn_PlcSet.Text = "设置完成";
            this.btn_PlcSet.UseVisualStyleBackColor = true;
            this.btn_PlcSet.Click += new System.EventHandler(this.btn_PlcSet_Click);
            // 
            // tx_slot
            // 
            this.tx_slot.Location = new System.Drawing.Point(105, 240);
            this.tx_slot.Name = "tx_slot";
            this.tx_slot.Size = new System.Drawing.Size(134, 25);
            this.tx_slot.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F);
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(31, 240);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 20);
            this.label8.TabIndex = 11;
            this.label8.Text = "插槽号:";
            // 
            // tx_rack
            // 
            this.tx_rack.Location = new System.Drawing.Point(105, 199);
            this.tx_rack.Name = "tx_rack";
            this.tx_rack.Size = new System.Drawing.Size(134, 25);
            this.tx_rack.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F);
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(31, 199);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 20);
            this.label7.TabIndex = 9;
            this.label7.Text = "机架号:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F);
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(31, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "CPU类型:";
            // 
            // tx_Ip
            // 
            this.tx_Ip.Location = new System.Drawing.Point(72, 116);
            this.tx_Ip.Name = "tx_Ip";
            this.tx_Ip.Size = new System.Drawing.Size(167, 25);
            this.tx_Ip.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F);
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(31, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "IP:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(31, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "通信参数";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(45)))));
            this.panel1.Controls.Add(this.TopPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(594, 58);
            this.panel1.TabIndex = 1;
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(45)))));
            this.TopPanel.Controls.Add(this.lbl_exit);
            this.TopPanel.Controls.Add(this.label2);
            this.TopPanel.Controls.Add(this.pictureBox1);
            this.TopPanel.Controls.Add(this.label1);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(594, 58);
            this.TopPanel.TabIndex = 2;
            this.TopPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            this.TopPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseMove);
            // 
            // lbl_exit
            // 
            this.lbl_exit.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_exit.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_exit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_exit.Location = new System.Drawing.Point(532, 0);
            this.lbl_exit.Name = "lbl_exit";
            this.lbl_exit.Size = new System.Drawing.Size(62, 56);
            this.lbl_exit.TabIndex = 3;
            this.lbl_exit.Text = "X";
            this.lbl_exit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_exit.Click += new System.EventHandler(this.lbl_exit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(64, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "参数";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::TraditionalWaterPump.Properties.Resources.Param;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(54, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(0, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(594, 2);
            this.label1.TabIndex = 0;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(45)))));
            this.label15.Font = new System.Drawing.Font("宋体", 12F);
            this.label15.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label15.Location = new System.Drawing.Point(542, 160);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 20);
            this.label15.TabIndex = 29;
            this.label15.Text = "秒";
            // 
            // FrmParamSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(596, 347);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmParamSet";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmParamSet";
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_exit;
        private System.Windows.Forms.TextBox tx_Ip;
        private System.Windows.Forms.Button btn_PlcSet;
        private System.Windows.Forms.TextBox tx_slot;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tx_rack;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_PlcCancel;
        private System.Windows.Forms.Button btn_SysCancel;
        private System.Windows.Forms.Button btn_SysSet;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox xt_logoffTime;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox xt_screenTime;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox tx_cpu;
        private xbd.ControlLib.xbdToggle xt_autoStart;
        private System.Windows.Forms.ComboBox xt_cameraIndex;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
    }
}