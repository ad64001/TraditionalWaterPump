using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraditionalWaterPump
{
    public class SQLiteService
    {
        /// <summary>
        /// 设置连接字符串
        /// </summary>
        /// <param name="connectString"></param>
        public void SetConnectString(string connectString)
        {
            SQLiteHelper.ConnString = connectString;
        }
    }
}
