using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraditionalWaterPump.Models;
using xbd.DataConvertLib;

namespace TraditionalWaterPump.Services
{
    public class HistoryDataService
    {
        /// <summary>
        /// 插入历史数据到数据库
        /// </summary>
        /// <param name="historyData"></param>
        /// <returns></returns>
        public bool AddHistoryData(HistoryData historyData)
        {
            string sql = "insert into HistoryData(InsertTime, PressureIn, PressureOut, TempIn1, " +
            "TempIn2, TempOut, PressureTank1, PressureTank2, LevelTank1, LevelTank2, PressureTankOut) " +
            "values(@InsertTime, @PressureIn, @PressureOut, " +
            "@TempIn1, @TempIn2, @TempOut, @PressureTank1, @PressureTank2, @LevelTank1, @LevelTank2, @PressureTankOut)";

            // 2. 构建SQLite参数（一一对应表字段和实体属性）
            SQLiteParameter[] parameters = new SQLiteParameter[]
            {
                new SQLiteParameter("@InsertTime", historyData.InsertTime.ToString("yyyy-MM-dd HH:mm:ss")),
                new SQLiteParameter("@PressureIn", historyData.PressureIn),
                new SQLiteParameter("@PressureOut", historyData.PressureOut),
                new SQLiteParameter("@TempIn1", historyData.TempIn1),
                new SQLiteParameter("@TempIn2", historyData.TempIn2),
                new SQLiteParameter("@TempOut", historyData.TempOut),
                new SQLiteParameter("@PressureTank1", historyData.PressureTank1),
                new SQLiteParameter("@PressureTank2", historyData.PressureTank2),
                new SQLiteParameter("@LevelTank1", historyData.LevelTank1),
                new SQLiteParameter("@LevelTank2", historyData.LevelTank2),
                new SQLiteParameter("@PressureTankOut",historyData.PressureTankOut)
            };

            return SQLiteHelper.ExecuteNonQuery(sql, parameters) == 1;
        }
        
        public OperateResult<List<HistoryData>> GetHistoryDataByTime(DateTime start,DateTime end)
        {
            string sql = "select InsertTime, PressureIn, PressureOut, TempIn1, TempIn2, TempOut, PressureTank1, PressureTank2, LevelTank1, LevelTank2, PressureTankOut " +
                "from HistoryData where InsertTime between @Start and @End order by InsertTime desc";

            SQLiteParameter[] parameters = new SQLiteParameter[]
            {
                new SQLiteParameter("@Start", start),
                new SQLiteParameter("@End", end)
            };

            try
            {
                SQLiteDataReader dataReader = SQLiteHelper.ExecuteReader(sql,parameters);
                List<HistoryData> historyDataList = new List<HistoryData>();
                while (dataReader.Read())
                {
                    historyDataList.Add(new HistoryData()
                    {
                        InsertTime = Convert.ToDateTime(dataReader["InsertTime"]),
                        PressureIn = dataReader["PressureIn"].ToString(),
                        PressureOut = dataReader["PressureOut"].ToString(),
                        TempIn1 = dataReader["TempIn1"].ToString(),
                        TempIn2 = dataReader["TempIn2"].ToString(),
                        TempOut = dataReader["TempOut"].ToString(),
                        PressureTank1 = dataReader["PressureTank1"].ToString(),
                        PressureTank2 = dataReader["PressureTank2"].ToString(),
                        LevelTank1 = dataReader["LevelTank1"].ToString(),
                        LevelTank2 = dataReader["LevelTank2"].ToString(),
                        PressureTankOut = dataReader["PressureTankOut"].ToString()
                    });
                }
                dataReader.Close();
                return OperateResult.CreateSuccessResult(historyDataList);
            }
            catch (Exception ex)
            {
                return OperateResult.CreateFailResult<List<HistoryData>>(ex.Message);
            }
        }

        /// <summary>
        /// 单个区间查询数据，返回DataTable格式，方便报表展示
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="condition"></param>
        /// <param name="datatableName"></param>
        /// <returns></returns>
        public OperateResult<DataTable> GetReportDataByCondition(string start,string end,List<string> condition,string datatableName)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("select ");
            stringBuilder.Append(string.Join(",", condition));
            stringBuilder.Append(" from HistoryData where InsertTime between @Start and @End order by InsertTime desc");

            SQLiteParameter[] parameters = new SQLiteParameter[]
            {
                new SQLiteParameter("@Start", start),
                new SQLiteParameter("@End", end)
            };

            try
            {
                DataSet dataSet = SQLiteHelper.GetDataSet(stringBuilder.ToString(), parameters,datatableName);
                if (dataSet.Tables.Count > 0)
                {
                    return OperateResult.CreateSuccessResult(dataSet.Tables[0]);
                }
                else
                {
                    return OperateResult.CreateFailResult<DataTable>("没有查询到数据");
                }

            }
            catch (Exception ex)
            {
                return OperateResult.CreateFailResult<DataTable>(ex.Message);
            }
        }
    }
}
