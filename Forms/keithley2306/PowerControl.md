# ��Դ��
## NationalInstruments.VISA
��װ��������Լ������ͨ��������õ�����ط���
ͨ�Ź��ܴ���֤  
��֤git  
��֤git2

### ��ȡ�豸��ַ
ʹ��resourceManager.Find("USB?*::0x04B4::0x8613::INSTR")������GPIB-USB-HS�豸������0x04B4��0x8613��Cypress USBоƬ��Ĭ��VID��PID��


## ͨ���Լ�����ָ������
ͨ��GPIB-USB-HS�ӿ����ӵ�,�Ǿ���Ҫʹ��GpibSession�Ự��������Write����:
	IMessageBasedSession session = GetSession(); 

// ��sessionת��ΪGPIB�Ự
GpibSession gpibSession = session as GpibSession;

if(gpibSession != null)
{
  // ����GpibSession��Write����
  gpibSession.Write("INST:NSEL 1");
  
  gpibSession.Write("SOUR:VOLT 5");
  
  // ...��������
}