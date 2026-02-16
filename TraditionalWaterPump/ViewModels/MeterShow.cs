using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TraditionalWaterPump
{
    public partial class MeterShow : UserControl
    {
        public MeterShow()
        {
            InitializeComponent();
        }

        private string paramName = "默认";

        [Browsable(true)]
        [Category("自定义")]
        [Description("设置名称")]
        public string ParamName
        {
            get { return paramName; }
            set { paramName = value;
                this.lbl_paramName.Text = paramName;
            }
        }

        private float paramValue = 0.0f;

        [Browsable(true)]
        [Category("自定义")]
        [Description("设置数值")]
        public float ParamValue
        {
            get { return paramValue; }
            set
            {
                if (paramValue != value)
                {
                    paramValue = value;
                    this.lbl_paramValue.Text = paramValue.ToString("f2") + " " + unit;
                }
            }
        }

        private string unit = "℃";

        [Browsable(true)]
        [Category("自定义")]
        [Description("设置单位")]
        public string Unit
        {
            get { return unit; }
            set
            {
                unit = value;
                this.lbl_paramValue.Text = paramValue.ToString("f2") + " " + unit;
            }
        }

        private float meterParamMax = 100.0f;

        [Browsable(true)]
        [Category("自定义")]
        [Description("设置仪表盘最大值")]
        public float MeterParamMax
        {
            get { return meterParamMax ; }
            set 
            {
                meterParamMax = value;
                this.meter_param.MaxValue = meterParamMax;
            }
        }


        private float meterParamMini = 0.0f;
        [Browsable(true)]
        [Category("自定义")]
        [Description("设置仪表盘最小值")]
        public float MeterParamMnin
        {
            get { return meterParamMini; }
            set
            {
                meterParamMini = value;
                this.meter_param.MinValue = meterParamMini;
            }
        }

    }
}
