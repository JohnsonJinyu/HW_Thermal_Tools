
# �¿�XML�ļ����ݽṹ



```

����һ����Ϊ sys_thermal_control_list ��XML�ļ���

���������½ṹ:

��Ԫ��:sys_thermal_control_list

��Ԫ��:
- version - Ԫ�� 
- filter-name - Ԫ��
- featureConfigItem - Ԫ��
    - feature_enable_item - Ԫ��,booleanVal����
    - feature_safety_test_enable_item - Ԫ��,booleanVal���� 
    - safety_test_config_item - Ԫ��,stringVal����
    - category_msg_delay_item - Ԫ��,intVal����
    - ota_mode_item - Ԫ��,intVal����
    - racing_mode_item - Ԫ��,intVal����
    - normal_mode_item - Ԫ��,intVal���� 
    - powersave_mode_item - Ԫ��,intVal����
    - game_high_perf_mode_item - Ԫ��,intVal����
    - game_powersave_mode_item - Ԫ��,intVal����
    - aging_thermal_control_enable_item - Ԫ��,booleanVal���� 
    - aging_cpu_level_item - Ԫ��,intVal����
- thermalPolicyConfigItem - Ԫ��
    - safetyTest - Ԫ��
        - safety_test - Ԫ�� 
            - gear_config - Ԫ��,�������
    - screenOff - Ԫ��
        - screen_off - Ԫ��
            - gear_config - Ԫ��,�������
    - specific - Ԫ�� 
        - ����ض�Ӧ�õ����� - Ԫ��
            - gear_config - Ԫ��,�������
    - specificScene - Ԫ��
        - ����������� - Ԫ��
            - gear_config - Ԫ��,�������
    - scene - Ԫ��
        - ����������� - Ԫ��
            - gear_config - Ԫ��,�������
    - category - Ԫ��
        - ���������� - Ԫ��
            - gear_config - Ԫ��,�������
    - default - Ԫ��
        - common_config - Ԫ��
            - gear_config - Ԫ��,�������

�ܽ�:

- Ԫ��:����ڵ�
- ����:����ڵ������
- �����ֲ�ṹ��ڵ���֯
```

# XmlToExcel����˼·
## �߼�
- ��ȡXML�ļ�
  - ��ȡXML���е�"gear_config"�ڵ㣬�����������ƣ�
- ��ȡExcel�ļ�
  - �����е�worksheet���ݱ���Ϊ�ֵ�
  - ��ȡÿ��worksheetҳ��һ�е�����
- ����XML��Excel��ȡ�������ݣ�����dataTable���µı�����
  - ����XML�����е�gear_config�ڵ������ֵ�������������ƣ�ƥ��dict����ֵ����databel
  - ͬ����ȡÿ��gear_config�ڵ�ĸ��ڵ㣬��ӵ�dataTable������ֵͬһ�еĵ�һ�У���Ϊ�������ƣ�



# ��Ԫ���Իع�ķ��� 


- **Math.NET Numerics**������һ����Դ����ѧ��ͳ�ƿ⣬���ṩ��һЩ������ִ�� **��Ԫ���Իع�**�����ҿ��Զ�д **Excel** �ļ�
- **Accord.NET Framework**������һ������ѧϰ�������ھ�Ŀ⣬��Ҳ�ṩ��һЩ������ִ�� **��Ԫ���Իع�**�����ҿ��Զ�д **Excel** �ļ���
- **EPPlus** �� **Accord.Statistics**������һ����Ϸ�����ʹ�� **EPPlus** ����д **Excel** �ļ���ʹ�� **Accord.Statistics** ��ִ�� **��Ԫ���Իع�**��


# ������ϵķ���
> ��Ȼ�Ƿ����Թ�ϵ,����Ҫ�ۺ϶�����������¶���Ԥ���豸�����¶�,�һ��Ƽ����¼��ַ���:
> 1. ������ - ���Խ���һ�����ǰ����������߾��������,�����Ƕ�����������¶�,������豸������¶ȡ���������Ժܺõ���ϸ��ӵķ����Ժ�����

> 2. ��˹���̻ع� - ͬ�����԰Ѷ���������¶���Ϊ����,�����豸�����¶ȵĸ�˹����ģ�͡���˹���̿��Ը���Ԥ�����������,��������������ϸ��ɽ��͡�

> 3. ֧��������(SVM) - ���ú˼���,���Խ���һ�������Իع�ģ��,�ۺ϶���������¶�Ԥ���豸�����¶ȡ�������������,����ѵ������,������Ҳ���ɽ��͡�

> 4. ������ɭ�� - ���Խ������������,ÿ���������Դ������¶�Ϊ����,Ԥ���豸�¶ȡ���϶����������Ԥ��������׼ȷ��,Ҳ�ܴ�������Թ�ϵ��

> ��Щ������������Ч��ģ���ӵķ����Թ�ϵ����Ҫ������������ѵ��ʱ���ʵ������ѡ�����ʺϵķ�����һ���������SVM�������ȿ��ǵ�ѡ��