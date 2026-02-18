using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using xbd.DataConvertLib;
using xbd.s7netplus;

namespace TraditionalWaterPump
{
    /// <summary>
    /// 业务逻辑层从PLC读取数据并将其转换为PlcData对象供界面使用
    /// </summary>
    public class PlcDataService
    {
        /// <summary>
        /// 第一次扫描
        /// </summary>
        public bool IsFristScan { get; set; } = true;
        /// <summary>
        /// 当前通信状态
        /// </summary>
        public bool IsConnected { get; set; } = false;

        /// <summary>
        /// 错误次数，记录连续通信失败的次数，超过一定次数后可以触发报警或其他处理逻辑
        /// </summary>
        public int ErrorTimes { get; set; }

        /// <summary>
        /// 允许的最大错误次数
        /// </summary>
        public int AllowErrorTimes { get; set; } = 5;

        //s7netplus库的对象
        private S7NetLib _s7Net = null;

        /// <summary>
        /// Plc连接方法
        /// </summary>
        /// <param name="sysInfo"></param>
        /// <returns></returns>
        public OperateResult Connect(SysInfo sysInfo)
        {
            _s7Net = new S7NetLib(sysInfo.CpuType, sysInfo.IpAddress, sysInfo.Rack, sysInfo.Slot);
            return _s7Net.Connect();
        }

        /// <summary>
        /// PLC断开连接方法
        /// </summary>
        public void Disconnect()
        {
            if (_s7Net != null)
            {
                _s7Net.DisConnect();
            }
        }

        /// <summary>
        /// 数据读取方法，从PLC读取数据并转换为PlcData对象
        /// </summary>
        /// <returns></returns>
        public OperateResult<PlcData> ReadPlcData()
        {
            int byteCount = 44;
            var result = this._s7Net.ReadByteArray(xbd.s7netplus.DataType.DataBlock, 1, 0, byteCount);
            if (result.IsSuccess && result.Content.Length == byteCount)
            {
                PlcData plcData = new PlcData();
                
                plcData.InPump1State = BitLib.GetBitFromByteArray(result.Content,0,0);
                plcData.InPump2State = BitLib.GetBitFromByteArray(result.Content,0,1);
                plcData.CirclePump1State = BitLib.GetBitFromByteArray(result.Content,0,2);
                plcData.CirclePump2State = BitLib.GetBitFromByteArray(result.Content,0,3);
                plcData.ValveInState = BitLib.GetBitFromByteArray(result.Content,0,4);
                plcData.ValveOutState = BitLib.GetBitFromByteArray(result.Content,0,5);
                plcData.SysRunState = BitLib.GetBitFromByteArray(result.Content,0,6);
                plcData.SysAlarmState = BitLib.GetBitFromByteArray(result.Content,0,7);

                plcData.PressureIn = FloatLib.GetFloatFromByteArray(result.Content, 4);
                plcData.PressureOut = FloatLib.GetFloatFromByteArray(result.Content, 8);
                plcData.TempIn1 = FloatLib.GetFloatFromByteArray(result.Content, 12);
                plcData.TempIn2 = FloatLib.GetFloatFromByteArray(result.Content, 16);
                plcData.TempOut = FloatLib.GetFloatFromByteArray(result.Content, 20);
                plcData.PressureTank1 = FloatLib.GetFloatFromByteArray(result.Content, 24);
                plcData.PressureTank2 = FloatLib.GetFloatFromByteArray(result.Content, 28);
                plcData.LevelTank1 = FloatLib.GetFloatFromByteArray(result.Content, 32);
                plcData.LevelTank2 = FloatLib.GetFloatFromByteArray(result.Content, 36);
                plcData.PressureOut = FloatLib.GetFloatFromByteArray(result.Content, 40);

                return OperateResult.CreateSuccessResult(plcData);
            }
            else
            {
                return OperateResult.CreateFailResult<PlcData>(result.Message);
            }
        }

        /// <summary>
        /// 1号泵控制方法
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool InPump1Control(bool value)
        {
            string startAddress = "DB1.DBX100.0";
            string stopAddress = "DB1.DBX100.1";
            string controlAddress = value ? startAddress : stopAddress;
            bool result = this._s7Net.WriteVariable(controlAddress, true).IsSuccess;
            Thread.Sleep(50);
            result &= this._s7Net.WriteVariable(controlAddress, false).IsSuccess;
            return result;
        }

        /// <summary>
        /// 2号泵控制方法
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool InPump2Control(bool value)
        {
            string startAddress = "DB1.DBX100.2";
            string stopAddress = "DB1.DBX100.3";
            string controlAddress = value ? startAddress : stopAddress;
            bool result = this._s7Net.WriteVariable(controlAddress, true).IsSuccess;
            Thread.Sleep(50);
            result &= this._s7Net.WriteVariable(controlAddress, false).IsSuccess;
            return result;
        }

        /// <summary>
        /// 1号循环泵控制方法
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool InCirclePump1Control(bool value)
        {
            string startAddress = "DB1.DBX100.4";
            string stopAddress = "DB1.DBX100.5";
            string controlAddress = value ? startAddress : stopAddress;
            bool result = _s7Net.WriteVariable(controlAddress, true).IsSuccess;
            Thread.Sleep(50);
            result &= _s7Net.WriteVariable(controlAddress, false).IsSuccess;
            return result;
        }

        /// <summary>
        /// 2号循环泵控制方法
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool InCirclePump2Control(bool value)
        {
            string startAddress = "DB1.DBX100.6";
            string stopAddress = "DB1.DBX100.7";
            string controlAddress = value ? startAddress : stopAddress;
            bool result = _s7Net.WriteVariable(controlAddress, true).IsSuccess;
            Thread.Sleep(50);
            result &= _s7Net.WriteVariable(controlAddress, false).IsSuccess;
            return result;
        }

        /// <summary>
        /// 系统复位方法
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SysReset()
        {
            string controlAddress = "DB1.DBX101.4";
            bool result = _s7Net.WriteVariable(controlAddress, true).IsSuccess;
            Thread.Sleep(50);
            result &= _s7Net.WriteVariable(controlAddress, false).IsSuccess;
            return result;
        }

        /// <summary>
        /// 进水阀控制方法
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool ValveInControl(bool value)
        {
            string startAddress = "DB1.DBX101.0";
            string stopAddress = "DB1.DBX101.1";
            string controlAddress = value ? startAddress : stopAddress;
            bool result = _s7Net.WriteVariable(controlAddress, true).IsSuccess;
            Thread.Sleep(50);
            result &= _s7Net.WriteVariable(controlAddress, false).IsSuccess;
            return result;
        }

        /// <summary>
        /// 出水阀控制方法
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool ValveOutControl(bool value)
        {
            string startAddress = "DB1.DBX101.2";
            string stopAddress = "DB1.DBX101.3";
            string controlAddress = value ? startAddress : stopAddress;
            bool result = _s7Net.WriteVariable(controlAddress, true).IsSuccess;
            Thread.Sleep(50);
            result &= _s7Net.WriteVariable(controlAddress, false).IsSuccess;
            return result;
        }
    }
}
