namespace TraditionalWaterPump.ViewModels
{
    partial class FrmValveControl
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
            this.btn_Confirm = new System.Windows.Forms.Button();
            this.lbl_Message = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TopPlanel = new System.Windows.Forms.Panel();
            this.lbl_exit = new System.Windows.Forms.Label();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.TopPlanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Confirm
            // 
            this.btn_Confirm.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Confirm.FlatAppearance.BorderSize = 0;
            this.btn_Confirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Confirm.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Confirm.Image = global::TraditionalWaterPump.Properties.Resources.Green;
            this.btn_Confirm.Location = new System.Drawing.Point(58, 177);
            this.btn_Confirm.Name = "btn_Confirm";
            this.btn_Confirm.Size = new System.Drawing.Size(91, 33);
            this.btn_Confirm.TabIndex = 41;
            this.btn_Confirm.Text = "确定";
            this.btn_Confirm.UseVisualStyleBackColor = true;
            this.btn_Confirm.Click += new System.EventHandler(this.btn_Confirm_Click);
            // 
            // lbl_Message
            // 
            this.lbl_Message.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Message.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_Message.Location = new System.Drawing.Point(0, 91);
            this.lbl_Message.Name = "lbl_Message";
            this.lbl_Message.Size = new System.Drawing.Size(331, 57);
            this.lbl_Message.TabIndex = 33;
            this.lbl_Message.Text = "默认3";
            this.lbl_Message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(45)))));
            this.panel1.Controls.Add(this.TopPlanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(329, 58);
            this.panel1.TabIndex = 32;
            // 
            // TopPlanel
            // 
            this.TopPlanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(45)))));
            this.TopPlanel.Controls.Add(this.lbl_exit);
            this.TopPlanel.Controls.Add(this.lbl_Title);
            this.TopPlanel.Controls.Add(this.pictureBox1);
            this.TopPlanel.Controls.Add(this.label1);
            this.TopPlanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TopPlanel.Location = new System.Drawing.Point(0, 0);
            this.TopPlanel.Name = "TopPlanel";
            this.TopPlanel.Size = new System.Drawing.Size(329, 58);
            this.TopPlanel.TabIndex = 2;
            this.TopPlanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            this.TopPlanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseMove);
            // 
            // lbl_exit
            // 
            this.lbl_exit.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_exit.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_exit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_exit.Location = new System.Drawing.Point(267, 0);
            this.lbl_exit.Name = "lbl_exit";
            this.lbl_exit.Size = new System.Drawing.Size(62, 56);
            this.lbl_exit.TabIndex = 3;
            this.lbl_exit.Text = "X";
            this.lbl_exit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_exit.Click += new System.EventHandler(this.lbl_exit_Click);
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Title.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_Title.Location = new System.Drawing.Point(64, 19);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(112, 25);
            this.lbl_Title.TabIndex = 2;
            this.lbl_Title.Text = "阀门控制";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::TraditionalWaterPump.Properties.Resources.Question;
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
            this.label1.Size = new System.Drawing.Size(329, 2);
            this.label1.TabIndex = 0;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Cancel.FlatAppearance.BorderSize = 0;
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancel.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Cancel.Image = global::TraditionalWaterPump.Properties.Resources.Pink;
            this.btn_Cancel.Location = new System.Drawing.Point(186, 177);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(91, 33);
            this.btn_Cancel.TabIndex = 42;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // FrmValveControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(331, 222);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Confirm);
            this.Controls.Add(this.lbl_Message);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmValveControl";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMsgNoAck";
            this.panel1.ResumeLayout(false);
            this.TopPlanel.ResumeLayout(false);
            this.TopPlanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Confirm;
        private System.Windows.Forms.Label lbl_Message;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel TopPlanel;
        private System.Windows.Forms.Label lbl_exit;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Cancel;
    }
}