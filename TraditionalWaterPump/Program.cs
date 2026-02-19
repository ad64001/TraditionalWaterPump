using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using xbd.s7netplus;

namespace TraditionalWaterPump
{
    internal static class Program
    {
        //private static Plc plc;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string connStr = "Data Source="+Application.StartupPath+ "\\DataBase\\TraditionalWaterPumpDB;Pooling=true;FaillfMissing=false;";
            new SQLiteService().SetConnectString(connStr);

            Application.Run(new frmMain());
        }

        /// <summary>
        /// 锁屏时间戳
        /// </summary>
        public static int TickCount { get;set; }

        /// <summary>
        /// 当前登录用户
        /// </summary>
        public static SysAdmin CurrentUser;
    }
}
