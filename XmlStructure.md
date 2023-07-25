
# 温控XML文件数据结构



```

这是一个名为 sys_thermal_control_list 的XML文件。

它包含以下结构:

根元素:sys_thermal_control_list

子元素:
- version - 元素 
- filter-name - 元素
- featureConfigItem - 元素
    - feature_enable_item - 元素,booleanVal属性
    - feature_safety_test_enable_item - 元素,booleanVal属性 
    - safety_test_config_item - 元素,stringVal属性
    - category_msg_delay_item - 元素,intVal属性
    - ota_mode_item - 元素,intVal属性
    - racing_mode_item - 元素,intVal属性
    - normal_mode_item - 元素,intVal属性 
    - powersave_mode_item - 元素,intVal属性
    - game_high_perf_mode_item - 元素,intVal属性
    - game_powersave_mode_item - 元素,intVal属性
    - aging_thermal_control_enable_item - 元素,booleanVal属性 
    - aging_cpu_level_item - 元素,intVal属性
- thermalPolicyConfigItem - 元素
    - safetyTest - 元素
        - safety_test - 元素 
            - gear_config - 元素,多个属性
    - screenOff - 元素
        - screen_off - 元素
            - gear_config - 元素,多个属性
    - specific - 元素 
        - 多个特定应用的配置 - 元素
            - gear_config - 元素,多个属性
    - specificScene - 元素
        - 多个场景配置 - 元素
            - gear_config - 元素,多个属性
    - scene - 元素
        - 多个场景配置 - 元素
            - gear_config - 元素,多个属性
    - category - 元素
        - 多个类别配置 - 元素
            - gear_config - 元素,多个属性
    - default - 元素
        - common_config - 元素
            - gear_config - 元素,多个属性

总结:

- 元素:代表节点
- 属性:代表节点的属性
- 包含分层结构与节点组织
```

