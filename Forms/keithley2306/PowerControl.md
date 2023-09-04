# 资源库
## NationalInstruments.VISA
安装相关驱动以及软件，通过添加引用调用相关方法
通信功能待验证  
验证git  
验证git2

### 获取设备地址
使用resourceManager.Find("USB?*::0x04B4::0x8613::INSTR")来查找GPIB-USB-HS设备，其中0x04B4和0x8613是Cypress USB芯片的默认VID和PID。


## 通信以及发送指令设置
通过GPIB-USB-HS接口连接的,那就需要使用GpibSession会话类来调用Write方法:
	IMessageBasedSession session = GetSession(); 

// 将session转换为GPIB会话
GpibSession gpibSession = session as GpibSession;

if(gpibSession != null)
{
  // 调用GpibSession的Write方法
  gpibSession.Write("INST:NSEL 1");
  
  gpibSession.Write("SOUR:VOLT 5");
  
  // ...其他命令
}