using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Data;
using System.Xml;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace HW_Thermal_Tools.Forms
{
    public partial class XmlToExcel : Form
    {

        //定义一个全局变量ExcelTitleList，用于保存Excel表格的标题
        List<string> ExcelTitleList = new List<string>();

        //定义一个Excel2DictList，用于保存遍历Excel得到的字典合集,内层嵌套列表，用于存储多个value
        Dictionary<string, Dictionary<string, List<string>>> Excel2Dict = new Dictionary<string, Dictionary<string, List<string>>>();

        //定义一个DataTable用于存储XML读取以及匹配后的数据
        System.Data.DataTable XMLDataTable = new System.Data.DataTable();

        public XmlToExcel()
        {
            InitializeComponent();

        }




        private void XmlToExcel_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }

        private void LoadTheme()
        {

            //通过这种方式获取
            foreach (System.Windows.Forms.Control control in TabLayoutPanel_XmlToExcel.Controls)
            {
                if (control is System.Windows.Forms.Button)
                {
                    System.Windows.Forms.Button btn = (Button)control;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }

        }


        // 选择xml文件的点击事件

        private void BtnSelectXmlFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "XML File (*.xml)|*.xml";
            //显示对话框，让用户选择文件
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //获取用户选择的文件路径
                string path = ofd.FileName;
                //把文件路径显示到textbox中
                TxtXmlFilePath.Text = path;
            }


        }


        // 选择配置表按钮的点击事件
        private void BtnSelectConfigFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel File (*.xlsx)|*.xlsx";
            //显示对话框，让用户选择文件
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //获取用户选择的文件路径
                string path = ofd.FileName;
                //把文件路径显示到textbox中
                TxtConfigFile.Text = path;
            }

        }



        // 确认按钮的点击事件
        private void BtnXmlToExcelFile_Click(object sender, EventArgs e)
        {
            //判断用户是否都选择了文件
            if (TxtXmlFilePath.Text == string.Empty || TxtConfigFile.Text == string.Empty)
            {
                MessageBox.Show("请选择xml文件和配置表excel文件");
                return;
            }
            try
            {
                GetExcelTitle();
                LoadExcelToDic();
                MatchData();
                DataTableToExcel();
                GC.Collect();//主动触发 .NET 垃圾回收器执行垃圾回收操作
            }
            catch (Exception ex)
            {
                // 显示转换失败的提示信息
                MessageBox.Show("转换失败，错误信息为：" + ex.Message);
            }

        }

        private void DataTableToExcel()
        {
            /*
            1、使用EPPLUS插件，将XMLDataTable中的数据写入到Excel文件中；
                将Excel文件第一行全部居中 加粗，微软雅黑字体；
                将Excel文件第一列相同的内容合并单元格，并垂直居中，左对齐；
            2、将Excel文件保存到用户选择的路径中；
            3、提示用户转换成功；
             */
            // 创建一个Excel文件
            using (var p = new ExcelPackage())
            {
                // 创建一个工作表
                var workSheet = p.Workbook.Worksheets.Add("Sheet1");
                // 写入数据，包括表头
                workSheet.Cells["A1"].LoadFromDataTable(XMLDataTable, true);


                workSheet.Cells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; //设置所有单元格为水平居中

                //设置第一行的字体为微软雅黑，加粗，居中
                workSheet.Row(1).Style.Font.Name = "微软雅黑";
                workSheet.Row(1).Style.Font.Bold = true;
                workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



                //遍历第一列中的内容，将内容相同的单元格合并
                int fromRow = 2; //起始行索引
                int toRow = 2; //结束行索引
                string value = workSheet.Cells[2, 1].Value.ToString(); //起始单元格的值
                for (int i = 2; i <= workSheet.Dimension.Rows; i++)
                {
                    var nextValue = workSheet.Cells[i + 1, 1].Value?.ToString(); //下一个单元格的值
                    if (value != nextValue) //如果值不同，则合并之前的单元格
                    {
                        value = nextValue; //更新值
                        toRow = i; //更新结束行索引
                        workSheet.Cells[fromRow, 1, toRow, 1].Merge = true; //合并单元格
                        workSheet.Cells[fromRow, 1, toRow, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center; //垂直居中
                        fromRow = i + 1; //更新起始行索引
                    }
                    if (nextValue == null) //如果下一个单元格为空，则跳出循环
                    {
                        break;
                    }
                }

                workSheet.Cells["A2:A" + workSheet.Dimension.Rows].Style.WrapText = true; //设置第一列从第二行开始的单元格为自动换行
                workSheet.Cells["A2:A" + workSheet.Dimension.Rows].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left; //设置第一列从第二行开始的单元格为水平左对齐

                workSheet.Cells["B1:" + workSheet.Dimension.Address].AutoFitColumns(); //设置除第一列以外的其他列为自适应宽度
                //设置第一列的宽度为25
                workSheet.Column(1).Width = 25;

                //将整个excel中所有包含字符格式数字的单元格改为数字格式
                for (int i = 2; i <= workSheet.Dimension.Rows; i++)
                {
                    for (int j = 2; j <= workSheet.Dimension.Columns; j++)
                    {
                        var cellValue = workSheet.Cells[i, j].Value?.ToString(); //获取单元格的值
                        if (double.TryParse(cellValue, out double number)) //如果值是数字，则转换为常规格式
                        {
                            workSheet.Cells[i, j].Value = number;
                            workSheet.Cells[i, j].Style.Numberformat.Format = "General"; //设置单元格格式为常规
                        }
                    }
                }

                // 弹出保存对话框，让用户选择保存路径
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel文件|*.xlsx";
                saveFileDialog.Title = "保存Excel文件";
                saveFileDialog.FileName = "test.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // 保存文件到指定路径
                    p.SaveAs(new FileInfo(saveFileDialog.FileName));
                    MessageBox.Show("转换成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification); //提示用户转换成功，并设置宽度为自动
                }
            }
        }


        // 直接设定标题行， 而不是从文件中动态获取，提高普适性
        private void GetExcelTitle()
        {

            //直接设置ExcelTitle为 应用包名	tempGear	触发门限	回退门限	cpu	CPU频率	gpu	GPU频率	
            // restrict	restrict-说明	brightness	brightness-说明	charge	充电电流	modem	
            // modem-说明	disFlashlight	stopCameraVideo	cameraBrightness	disCamera	disWifiHotSpot	disTorch	
            // disFrameInsert	fps	refreshRate	disVideoSR	disOSIE	disHBMHB

            ExcelTitleList.AddRange(new List<string> { "场景名称", "tempGear", "触发门限", "回退门限", "cpu", "CPU频率", "gpu", "GPU频率", "restrict", "restrict-说明",
            "brightness","brightness-说明","speedChargeAdd","charge","充电电流","modem","modem-说明","disFlashlight","stopCameraVideo","cameraBrightness","disCamera","disWifiHotSpot",
                "disTorch","disFrameInsert","fps","refreshRate","disVideoSR","disOSIE","disHBMHB","heatoff_policy","cpuPower","ipaweight","boostBreak1","boostBreak2","wifi"});




            //将ExcelTitleList打印出来
            foreach (string str in ExcelTitleList)
            {
                Console.WriteLine(str);
            }

        }



        /*
        1、定义一个LoadExcelToDic方法；上面已经定义了Dictionary<string, Dictionary<string, List<string>>> Excel2Dict = new Dictionary<string, Dictionary<string, List<string>>>();
        2、读取Excel，遍历每个worksheet页：
            1、获取worksheet页的名称，作为Excel2Dict的key；
            2、获取每个worksheet页的内容，将第一列作为Excel2Dict的子字典的key，第二列开始作为子字典的value，
            3、将Excel2Dict添加到Excel2Dict中；
         */
        private void LoadExcelToDic()
        {
            string path = TxtConfigFile.Text;
            //设置非商业用途的许可证
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage ep = new ExcelPackage(new FileInfo(path)))
            {
                ExcelWorksheets sheets = ep.Workbook.Worksheets;
                foreach (ExcelWorksheet sheet in sheets)
                {
                    //获取worksheet页的名称，作为Excel2Dict的key；
                    string sheetName = sheet.Name;
                    //获取每个worksheet页的内容，将第一列作为Excel2Dict的子字典的key，第二列开始作为子字典的value，
                    Dictionary<string, List<string>> sheetDict = new Dictionary<string, List<string>>();
                    for (int i = 1; i <= sheet.Dimension.Rows; i++)
                    {
                        List<string> list = new List<string>();
                        for (int j = 2; j <= sheet.Dimension.Columns; j++)
                        {
                            list.Add(sheet.Cells[i, j].Value.ToString());
                        }
                        sheetDict.Add(sheet.Cells[i, 1].Value.ToString(), list);
                    }
                    //将Excel2Dict添加到Excel2Dict中；
                    Excel2Dict.Add(sheetName, sheetDict);
                }


            }
        }


        private void MatchData()
        {
            //将ExcelTitleList作为XMLDataTable的列的索引
            for (int i = 0; i < ExcelTitleList.Count; i++)
            {
                XMLDataTable.Columns.Add(ExcelTitleList[i]);
            }


            //获取XML文件，遍历文件中所有的"gear_config"节点的属性和值，同时，每次遍历一个gear_config的时候，获取父节点的名称，父节点没有属性，将获取到的名称作为场景名称
            XmlDocument doc = new XmlDocument();
            doc.Load(TxtXmlFilePath.Text);
            XmlNodeList nodeList = doc.SelectNodes("//gear_config");
            foreach (XmlNode node in nodeList)
            {
                //获取父节点的名称，将获取到的名称，添加到XMLDataTable的第一列
                string parentName = node.ParentNode.Name;

                //添加新的一行
                DataRow row = XMLDataTable.NewRow();

                // 预填充所有的默认值为"\"
                foreach (DataColumn column in XMLDataTable.Columns)
                {
                    row[column.ColumnName] = @"\";
                }


                //在新添加的一行里，将父节点的名称添加到列名为“场景名称”的列中
                row["场景名称"] = parentName;
                /*
                1、遍历gear_config节点的属性；
                2、根据属性的名称，与XMLDataTable的列的名称进行匹配，如果匹配成功，将属性的值添加到XMLDataTable的对应列中；
                 */
                foreach (XmlAttribute attr in node.Attributes)
                {

                    // 检查数据表中是否存在该列 
                    if (!XMLDataTable.Columns.Contains(attr.Name))
                    {
                        XMLDataTable.Columns.Add(attr.Name);
                    }

                    /*
                   1、如果属性名称是cpu、gpu、charge、brightness、tempGear：
                       则需要根据名称在Excel2DictList这个字典合集中查找对应的字典key；
                       再根据属性的值，在对应的子字典里面查找对应的对应的key以及value(描述)；
                       将描述插入到属性值的后面
                   2、如果属性名称不是cpu、gpu、charge、brightness、tempGear：
                       则直接将属性值插入到XMLDataTable中
                     */
                    switch (attr.Name)
                    {
                        case "tempGear":

                            //先将XML文件中的属性值插入到XMLDataTable中
                            row[attr.Name] = attr.Value;

                            //将attr.Name(TempGear)作为key，在Excel2Dict中查找对应的子字典
                            Dictionary<string, List<string>> TempDict;
                            Excel2Dict.TryGetValue("温度档位", out TempDict);

                            //将attr.Value作为key，在TempDict中查找对应的value
                            List<string> TempList;
                            TempDict.TryGetValue(attr.Value, out TempList);

                            //获取row[attr.Name]的索引
                            int TempIndex = XMLDataTable.Columns.IndexOf(attr.Name);
                            //以循环的方式按照索引将TempList内容添加到row[attr.Name]后；
                            for (int i = 1; i <= TempList.Count; i++)
                            {
                                row[TempIndex + i] = TempList[i - 1];
                            }
                            break;

                        case "charge":

                            //先将XML文件中的属性值插入到XMLDataTable中
                            row[attr.Name] = attr.Value;

                            //将attr.Name(Charge)作为key，在Excel2Dict中查找对应的子字典
                            Dictionary<string, List<string>> ChargeDict;
                            if (Excel2Dict.TryGetValue("充电档位", out ChargeDict))
                            {

                                //将attr.Value作为key，在ChargeDict中查找对应的value
                                List<string> ChargeList;
                                ChargeDict.TryGetValue(attr.Value, out ChargeList);

                                //获取row[attr.Name]的索引
                                int ChargeIndex = XMLDataTable.Columns.IndexOf(attr.Name);
                                //以循环的方式按照索引将ChargeList内容添加到row[attr.Name]后；
                                for (int i = 1; i <= ChargeList.Count; i++)
                                {
                                    row[ChargeIndex + i] = ChargeList[i - 1];
                                }

                            }

                            break;

                        case "cpu":
                        case "CPU":

                            row[attr.Name] = attr.Value;

                            //将attr.Name(CPU)作为key，在Excel2Dict中查找对应的子字典
                            Dictionary<string, List<string>> CPUDict;
                            if (Excel2Dict.TryGetValue("CPU", out CPUDict))
                            {

                                //将attr.Value作为key，在CPUDict中查找对应的value
                                List<string> CPUList;
                                CPUDict.TryGetValue(attr.Value, out CPUList);

                                //获取row[attr.Name]的索引
                                int CPUIndex = XMLDataTable.Columns.IndexOf(attr.Name);
                                //以循环的方式按照索引将CPUList内容添加到row[attr.Name]后；
                                for (int i = 1; i <= CPUList.Count; i++)
                                {
                                    row[CPUIndex + i] = CPUList[i - 1];
                                }
                            }



                            break;

                        case "gpu":
                        case "GPU":

                            row[attr.Name] = attr.Value;

                            //将attr.Name(GPU)作为key，在Excel2Dict中查找对应的子字典
                            Dictionary<string, List<string>> GPUDict;
                            if (Excel2Dict.TryGetValue("GPU", out GPUDict))
                            {
                                //将attr.Value作为key，在GPUDict中查找对应的value
                                List<string> GPUList;
                                GPUDict.TryGetValue(attr.Value, out GPUList);

                                //获取row[attr.Name]的索引
                                int GPUIndex = XMLDataTable.Columns.IndexOf(attr.Name);
                                //以循环的方式按照索引将GPUList内容添加到row[attr.Name]后；
                                for (int i = 1; i <= GPUList.Count; i++)
                                {
                                    row[GPUIndex + i] = GPUList[i - 1];
                                }
                            }



                            break;

                        case "brightness":

                            row[attr.Name] = attr.Value;

                            //将attr.Name(brightness)作为key，在Excel2Dict中查找对应的子字典
                            Dictionary<string, List<string>> BrightnessDict;
                            if (Excel2Dict.TryGetValue("亮度等级", out BrightnessDict))
                            {
                                List<string> BrightnessList;

                                //将attr.Value作为key，在BrightnessDict中查找对应的value
                                BrightnessDict.TryGetValue(attr.Value, out BrightnessList);

                                //获取row[attr.Name]的索引
                                int BrightnessIndex = XMLDataTable.Columns.IndexOf(attr.Name);
                                //以循环的方式按照索引将BrightnessList内容添加到row[attr.Name]后；
                                for (int i = 1; i <= BrightnessList.Count; i++)
                                {
                                    row[BrightnessIndex + i] = BrightnessList[i - 1];
                                }
                            }


                            break;

                        case "modem":

                            row[attr.Name] = attr.Value;

                            // 将attr.Name(modem)作为key,在在Excel2Dict中查找对应的子字典
                            Dictionary<string, List<string>> ModemDict;
                            if (Excel2Dict.TryGetValue("modem", out ModemDict))
                            {
                                List<string> ModemList;

                                // 将attr.Value作为key，在ModemDict中查找对应的value
                                if (ModemDict.TryGetValue(attr.Value, out ModemList))
                                {
                                    // 获取row[attr.Name]的索引
                                    int ModemIndex = XMLDataTable.Columns.IndexOf(attr.Name);
                                    // 以循环的方式按照索引将ModemList内容添加到row[attr.Name]后
                                    for (int i = 1; i <= ModemList.Count; i++)
                                    {
                                        row[ModemIndex + i] = ModemList[i - 1];
                                    }
                                }
                            }
                            break;





                        case "restrict":

                            row[attr.Name] = attr.Value;

                            // 将attr.Name(Restrict)作为key,在在Excel2Dict中查找对应的子字典
                            Dictionary<string, List<string>> RestrictDict;
                            // 需要先判断restrict属性值是否存在
                            if (Excel2Dict.TryGetValue("Restrict", out RestrictDict))
                            {
                                List<string> RestrictList;

                                // 将attr.Value作为key，在ModemDict中查找对应的value
                                if (RestrictDict.TryGetValue(attr.Value.ToString(), out RestrictList))
                                {
                                    // 获取row[attr.Name]的索引
                                    int RestrictIndex = XMLDataTable.Columns.IndexOf(attr.Name);
                                    // 以循环的方式按照索引将ModemList内容添加到row[attr.Name]后
                                    for (int i = 1; i <= RestrictList.Count; i++)
                                    {
                                        row[RestrictIndex + i] = RestrictList[i - 1];
                                    }
                                }

                            }
                            break;


                        default:
                            row[attr.Name] = attr.Value;
                            break;
                    }

                    /*
                    上面成功将XML的值获取并赋给XMLDataTable
                    另外将根据字典将cpu GPU、tempGear、charge、brightness的描述添加到dataTable中
                     */

                }

                // 添加行
                XMLDataTable.Rows.Add(row);

            }
            //释放XMLDocument占用的非托管资源
            doc = null;
        }
    }
}
