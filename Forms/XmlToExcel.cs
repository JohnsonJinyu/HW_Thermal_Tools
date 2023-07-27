using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using ExcelDataReader;
using ExcelWriter;
using HZH_Controls.Forms;
using Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using OfficeOpenXml.Style;
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
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(System.Windows.Forms.Button))
                {
                    System.Windows.Forms.Button btn = (System.Windows.Forms.Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
        }

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

        private void BtnXmlToExcelFile_Click(object sender, EventArgs e)
        {
            //判断用户是否都选择了文件
            if (TxtXmlFilePath.Text == "" || TxtConfigFile.Text == "")
            {
                MessageBox.Show("请选择xml文件和配置表excel文件");
                return;
            }
            try
            {
                GetExcelTitle();
                LoadExcelToDic();
                MatchData();

            }
            catch (Exception ex)
            {
                // 显示转换失败的提示信息
                MessageBox.Show("转换失败，错误信息为：" + ex.Message);
            }

        }

        private void GetExcelTitle()
        {
            //先将“场景名称”添加到ExcelTitleList中作为第一个元素
            ExcelTitleList.Add("场景名称");

            //读取用户选择的XML文件
            XmlDocument doc = new XmlDocument();
            doc.Load(TxtXmlFilePath.Text);
            /*
            1、首先用SelectNodes获取XML文件中所有的gear_config节点；
            2、gear_config没有子节点，信息保存在他的属性中；
            3、读取第一个gear_config节点的所有属性名称，保存到ExcelTitleList中；
            4、继续遍历其他的gear_config节点，读取每个节点的属性；如果有新的属性名称，则添加到ExcelTitleList中；如果没有，则不处理；
             */
            XmlNodeList nodeList = doc.SelectNodes("//gear_config");
            //List<string> ExcelTitleList = new List<string>();
            foreach (XmlNode node in nodeList)
            {
                XmlAttributeCollection attrCol = node.Attributes;
                foreach (XmlAttribute attr in attrCol)
                {
                    if (!ExcelTitleList.Contains(attr.Name))
                    {
                        ExcelTitleList.Add(attr.Name);
                    }
                }
            }


            //读取用户选择的配置表excel文件
            string path = TxtConfigFile.Text;
            //设置非商业用途的许可证
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            /*读取Excel文件，遍历每个worksheet页：
                获取名称为“CPU”的worksheet页，将第一行第二个单元格的内容插入到ExcelTitleList的“cpu”元素后面；
                获取名称为“GPU”的worksheet页，将第一行第二个单元格的内容插入到ExcelTitleList的“gpu”元素后面；
                获取名称为“温度档位”或者“温控档位”的worksheet页，将第一行第二个和第三个单元格的内容插入到ExcelTitleList的“tempGear”元素后面；
                获取名称为“亮度等级”的worksheet页，将第一行第二个单元格的内容插入到ExcelTitleList的“brightness”元素后面；
                获取名称为“ 充电电流”的worksheet页，将第一行第二个单元格的内容插入到ExcelTitleList的“charge”元素后面；
            */

            ExcelPackage ep = new ExcelPackage(new FileInfo(path));
            ExcelWorksheets sheets = ep.Workbook.Worksheets;
            foreach (ExcelWorksheet sheet in sheets)
            {
                if (sheet.Name == "CPU")
                {
                    ExcelTitleList.Insert(ExcelTitleList.IndexOf("cpu") + 1, sheet.Cells[1, 2].Value.ToString());
                }
                else if (sheet.Name == "GPU")
                {
                    ExcelTitleList.Insert(ExcelTitleList.IndexOf("gpu") + 1, sheet.Cells[1, 2].Value.ToString());
                }
                else if (sheet.Name == "温度档位" || sheet.Name == "温控档位")
                {
                    ExcelTitleList.Insert(ExcelTitleList.IndexOf("tempGear") + 1, sheet.Cells[1, 2].Value.ToString());
                    ExcelTitleList.Insert(ExcelTitleList.IndexOf("tempGear") + 2, sheet.Cells[1, 3].Value.ToString());
                }
                else if (sheet.Name == "亮度等级")
                {
                    ExcelTitleList.Insert(ExcelTitleList.IndexOf("brightness") + 1, sheet.Cells[1, 2].Value.ToString());
                }
                else if (sheet.Name == "充电电流" || sheet.Name == "充电档位")
                {
                    ExcelTitleList.Insert(ExcelTitleList.IndexOf("charge") + 1, sheet.Cells[1, 2].Value.ToString());
                }
            }

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
            ExcelPackage ep = new ExcelPackage(new FileInfo(path));
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

                            //将attr.Name(温度档位)作为key，在Excel2Dict中查找对应的子字典
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

                            //将attr.Name(充电档位)作为key，在Excel2Dict中查找对应的子字典
                            Dictionary<string, List<string>> ChargeDict;
                            Excel2Dict.TryGetValue("充电档位", out ChargeDict);

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

                            break;

                        case "cpu":
                        case "CPU":

                            row[attr.Name] = attr.Value;

                            //将attr.Name(CPU)作为key，在Excel2Dict中查找对应的子字典
                            Dictionary<string, List<string>> CPUDict;
                            Excel2Dict.TryGetValue("CPU", out CPUDict);

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

                            break;

                        case "gpu":
                        case "GPU":

                            row[attr.Name] = attr.Value;

                            //将attr.Name(GPU)作为key，在Excel2Dict中查找对应的子字典
                            Dictionary<string, List<string>> GPUDict;
                            Excel2Dict.TryGetValue("GPU", out GPUDict);

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

                            break;

                        case "brightness":

                            row[attr.Name] = attr.Value;

                            //将attr.Name(亮度等级)作为key，在Excel2Dict中查找对应的子字典
                            Dictionary<string, List<string>> BrightnessDict;
                            Excel2Dict.TryGetValue("亮度等级", out BrightnessDict);
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
        }
    }
}
