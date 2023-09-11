using Microsoft.Extensions.Hosting;
using NationalInstruments.Visa;
using System;
using System.Linq;

namespace HW_Thermal_Tools.Forms.keithley2306
{
    public class DeviceDetectionService : BackgroundService
    {
        // 定义一个字符串变量，用于存储 GPIB 设备的地址
        string address = "GPIB?::6::INSTR";

        // 定义一个 ResourceManager 的实例，用于管理 VISA 资源
        private ResourceManager resourceManager = new ResourceManager();

        // 定义一个 CheckGPIBDevice 的方法，用于检测 GPIB 设备是否存在
        public bool CheckGPIBDevice(string address)
        {
            try
            {
                string[] resources = (string[])resourceManager.Find(address);
                if (resources.Length > 0)
                    return true;
                else
                    return false; //添加默认的返回情况，也就是 == 0的时候
            }
            catch (Exception e)
            {
                return false;
            }
        }

        // 定义一个 CancellationTokenSource 的实例，用于控制后台任务的取消
        private CancellationTokenSource cts = new CancellationTokenSource();

        // 重写 ExecuteAsync 方法，用于在后台线程上运行设备检测代码
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // 获取后台任务的取消令牌
            var token = cts.Token;

            // 在后台任务未被取消时循环执行
            while (!token.IsCancellationRequested)
            {
                // 调用检测设备的代码，传入设备地址，将 deviceDetection 替换为 this
                bool result = this.CheckGPIBDevice(address);

                // 调用 OnDeviceDetectionChanged 方法，并传入检测结果
                OnDeviceDetectionChanged(result);

                // 等待一段时间（例如 1 秒）再进行下一次检测
                await Task.Delay(1000, token);
            }
        }

        // 重写 StopAsync 方法，用于在 Form 关闭时停止后台任务
        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            // 请求取消后台任务
            cts.Cancel();

            // 等待后台任务完成或超时（例如 5 秒）
            await Task.WhenAny(base.StopAsync(stoppingToken), Task.Delay(5000));

            // 释放资源
            cts.Dispose();
        }

        // 定义一个自定义事件参数类，用于封装检测结果
        public class DeviceDetectionEventArgs : EventArgs
        {
            // 定义一个布尔属性，表示设备是否连接
            public bool IsConnected { get; set; }

            // 定义一个构造函数，用于初始化属性
            public DeviceDetectionEventArgs(bool isConnected)
            {
                IsConnected = isConnected;
            }
        }

        // 定义一个委托类型，用于声明事件处理器的签名
        public delegate void DeviceDetectionEventHandler(object sender, DeviceDetectionEventArgs e);

        // 定义一个自定义事件，用于在检测结果发生变化时通知订阅者
        public event DeviceDetectionEventHandler DeviceDetectionChanged;

        // 定义一个方法，用于触发自定义事件，并传递检测结果
        protected virtual void OnDeviceDetectionChanged(bool result)
        {
            // 如果有订阅者，触发自定义事件，并创建一个 DeviceDetectionEventArgs 实例作为事件参数
            DeviceDetectionChanged?.Invoke(this, new DeviceDetectionEventArgs(result));
        }
    }
}
