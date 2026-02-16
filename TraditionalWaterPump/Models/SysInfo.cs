using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xbd.s7netplus;

namespace TraditionalWaterPump
{
    public class SysInfo
    {
        public CpuType CpuType { get; set; }

        public string IpAddress { get; set; }

        /// <summary>
        /// 机架号
        /// </summary>
        public short Rack { get; set; }

        /// <summary>
        /// 插槽号
        /// </summary>
        public short Slot { get; set; }


        /// <summary>
        /// 开机自启
        /// </summary>
        public bool AutoStart { get; set; }

        /// <summary>
        /// 无操作熄屏时间
        /// </summary>
        public int ScreenTime { get; set; }

        /// <summary>
        /// 自动注销时间
        /// </summary>
        public int LogoffTime { get; set; }

        /// <summary>
        /// 摄像头索引
        /// </summary>
        public int CameraIndex { get; set; }
    }
}
