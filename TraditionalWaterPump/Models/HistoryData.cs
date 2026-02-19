using MiniExcelLibs.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraditionalWaterPump.Models
{
    public class HistoryData
    {
        [ExcelColumnName("InsertTime")]
        [ExcelColumnWidth(180)]
        [ExcelFormat("yyyy-MM-dd HH:mm:ss")]
        public DateTime InsertTime { get; set; }
        public string PressureIn { get; set; } 
        public string PressureOut { get; set; } 
        public string TempIn1 { get; set; } 
        public string TempIn2 { get; set; } 
        public string TempOut { get; set; } 
        public string PressureTank1 { get; set; } 
        public string PressureTank2 { get; set; } 
        public string LevelTank1 { get; set; } 
        public string LevelTank2 { get; set; } 
        public string PressureTankOut { get; set; } 
    }
}
