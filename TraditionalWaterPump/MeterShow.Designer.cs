namespace TraditionalWaterPump
{
    partial class MeterShow
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_paramName = new System.Windows.Forms.Label();
            this.lbl_paramValue = new System.Windows.Forms.Label();
            this.meter_param = new xbd.ControlLib.xbdAnalogMeter();
            this.SuspendLayout();
            // 
            // lbl_paramName
            // 
            this.lbl_paramName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_paramName.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_paramName.Location = new System.Drawing.Point(0, 0);
            this.lbl_paramName.Name = "lbl_paramName";
            this.lbl_paramName.Size = new System.Drawing.Size(147, 26);
            this.lbl_paramName.TabIndex = 0;
            this.lbl_paramName.Text = "默认";
            this.lbl_paramName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_paramValue
            // 
            this.lbl_paramValue.BackColor = System.Drawing.Color.MediumTurquoise;
            this.lbl_paramValue.Location = new System.Drawing.Point(24, 141);
            this.lbl_paramValue.Name = "lbl_paramValue";
            this.lbl_paramValue.Size = new System.Drawing.Size(99, 22);
            this.lbl_paramValue.TabIndex = 2;
            this.lbl_paramValue.Text = "0.00";
            this.lbl_paramValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // meter_param
            // 
            this.meter_param.BodyColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(45)))));
            this.meter_param.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.meter_param.Location = new System.Drawing.Point(4, 26);
            this.meter_param.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.meter_param.MaxValue = 10D;
            this.meter_param.MinValue = 0D;
            this.meter_param.Name = "meter_param";
            this.meter_param.NeedleColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.meter_param.Renderer = null;
            this.meter_param.ScaleColor = System.Drawing.Color.White;
            this.meter_param.ScaleDivisions = 11;
            this.meter_param.ScaleSubDivisions = 4;
            this.meter_param.Size = new System.Drawing.Size(145, 137);
            this.meter_param.TabIndex = 1;
            this.meter_param.Value = 0D;
            this.meter_param.ViewGlass = false;
            // 
            // MeterShow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(45)))));
            this.Controls.Add(this.lbl_paramValue);
            this.Controls.Add(this.meter_param);
            this.Controls.Add(this.lbl_paramName);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("宋体", 10F);
            this.Name = "MeterShow";
            this.Size = new System.Drawing.Size(147, 168);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_paramName;
        private xbd.ControlLib.xbdAnalogMeter meter_param;
        private System.Windows.Forms.Label lbl_paramValue;
    }
}
