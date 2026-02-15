using System;
using xbd.DataConvertLib;
using xbd.s7netplus;
using DataType = xbd.s7netplus.DataType;

namespace TraditionalWaterPump
{
    /// <summary>
    /// 通信封装类
    /// </summary>
    public class S7NetLib
    {
        private Plc slemens;

        public S7NetLib()
        {
        }

        public CpuType CpuType { get; set; }
        public string IpAddress { get; set; }
        public short Rack { get; set; }
        public short Slot { get; set; }

        public S7NetLib(CpuType cpuType, string ipAddress, short rack, short slot)
        {
            this.CpuType = cpuType;
            this.IpAddress = ipAddress;
            this.Rack = rack;
            this.Slot = slot;
        }

        /// <summary>
        /// 锁
        /// </summary>
        private static object lockObj = new object();

        /// <summary>
        /// 连接
        /// </summary>
        /// <returns></returns>
        public OperateResult Connect()
        {
            try
            {
                if (this.slemens!=null&&this.slemens.IsConnected)
                {
                    this.slemens.Close();
                }
                this.slemens = new Plc(this.CpuType, this.IpAddress, this.Rack, this.Slot);
                this.slemens.Open();
                return OperateResult.CreateSuccessResult();
            }
            catch (Exception ex)
            {
                return OperateResult.CreateFailResult(ex.Message);
            }
        }

        /// <summary>
        /// 断开连接
        /// </summary>
        /// <returns></returns>
        public void DisConnect()
        {
            if (this.slemens != null && this.slemens.IsConnected)
            {
                this.slemens.Close();
            }
        }

        /// <summary>
        /// 读字符数组
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="db"></param>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public OperateResult<byte[]> ReadByteArray(DataType dataType,int db,int start,int count) 
        {
            if (this.slemens!=null&&this.slemens.IsConnected)
            {
                try
                {
                    lock (lockObj)
                    {
                        return OperateResult.CreateSuccessResult(slemens.ReadBytes(dataType, db, start, count));
                    }
                }
                catch (Exception ex)
                {
                    return OperateResult.CreateFailResult<byte[]>("读取失败:"+ ex.Message);
                }
            }
            else
            {
                return OperateResult.CreateFailResult<byte[]>("PLC未连接");
            }
        }

        /// <summary>
        /// 读变量
        /// </summary>
        /// <param name="varAddress"></param>
        /// <returns></returns>
        public OperateResult<object> ReadVariable(string varAddress)
        {
            if (this.slemens != null && this.slemens.IsConnected)
            {
                try
                {
                    lock (lockObj)
                    {
                        return OperateResult.CreateSuccessResult(slemens.Read(varAddress));
                    }
                }
                catch (Exception ex)
                {
                    return OperateResult.CreateFailResult<object>("读取失败:" + ex.Message);
                }
            }
            else
            {
                return OperateResult.CreateFailResult<object>("PLC未连接");
            }
        }

        /// <summary>
        /// 读类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="db"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        public OperateResult<T> ReadClass<T>(int db,int start) where T: class
        {
            if (this.slemens != null && this.slemens.IsConnected)
            {
                try
                {
                    lock (lockObj)
                    {
                        return OperateResult.CreateSuccessResult(slemens.ReadClass<T>(db,start));
                    }
                }
                catch (Exception ex)
                {
                    return OperateResult.CreateFailResult<T>("读取失败:" + ex.Message);
                }
            }
            else
            {
                return OperateResult.CreateFailResult<T>("PLC未连接");
            }
        }

        /// <summary>
        /// 变量写入
        /// </summary>
        /// <param name="varAddress"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public OperateResult WriteVariable(string varAddress,object value) 
        { 
            if (this.slemens != null && this.slemens.IsConnected)
            {
                try
                {
                    lock (lockObj)
                    {
                        slemens.Write(varAddress, value);
                        return OperateResult.CreateSuccessResult();
                    }
                }
                catch (Exception ex)
                {
                    return OperateResult.CreateFailResult("读取失败:" + ex.Message);
                }
            }
            else
            {
                return OperateResult.CreateFailResult("PLC未连接");
            }
        }

    }
}
