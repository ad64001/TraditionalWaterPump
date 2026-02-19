using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraditionalWaterPump
{
    public class SysAdminService
    {
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public List<SysAdmin> QuerySysAdmin()
        {
            string sql = "select LoginId, LoginName, LoginPwd, RoleName from SysAdmin";
            SQLiteDataReader reader = SQLiteHelper.ExecuteReader(sql);
            List<SysAdmin> list = new List<SysAdmin>();
            while (reader.Read())
            {
                list.Add(new SysAdmin()
                {
                    LoginId = Convert.ToInt32(reader["LoginId"]),
                    LoginName = reader["LoginName"].ToString(),
                    LoginPwd = reader["LoginPwd"].ToString(),
                    RoleName = (RoleName)Enum.Parse(typeof(RoleName), reader["RoleName"].ToString())

                });
            }

            reader.Close();
            return list;
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="sysAdmin"></param>
        /// <returns></returns>
        public SysAdmin AdminLogin(SysAdmin sysAdmin)
        {
            string sql = "select LoginId, LoginName, LoginPwd, RoleName from SysAdmin where LoginName=@LoginName and LoginPwd=@LoginPwd";
            SQLiteParameter[] parameters = new SQLiteParameter[]
            {
                new SQLiteParameter("@LoginName", sysAdmin.LoginName),
                new SQLiteParameter("@LoginPwd", sysAdmin.LoginPwd)
            };
            SQLiteDataReader dataReader = SQLiteHelper.ExecuteReader(sql, parameters);
            if (dataReader.Read())
            {
                sysAdmin.LoginId = Convert.ToInt32(dataReader["LoginId"]);
                sysAdmin.RoleName = (RoleName)Enum.Parse(typeof(RoleName), dataReader["RoleName"].ToString());
            }
            else
            {
                sysAdmin = null;
            }
            dataReader.Close();
            return sysAdmin;
        }
    }
}
