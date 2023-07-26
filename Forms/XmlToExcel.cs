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
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Excel = Microsoft.Office.Interop.Excel;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace HW_Thermal_Tools.Forms
{
    public partial class XmlToExcel : Form
    {

        //定义一个全局变量ExcelTitleList，用于保存Excel表格的标题
        List<string> ExcelTitleList = new List<string>();
        //定义一个Excel2DictList，用于保存遍历Excel得到的字典合集
        List<Dictionary<string, string>> Excel2DictList = new List<Dictionary<string, string>>();

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
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
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


            }
            catch (Exception ex)
            {
                // 显示转换失败的提示信息
                MessageBox.Show("转换失败，错误信息为：" + ex.Message);
            }

        }



        private void GetExcelTitle()
        {

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


            /*
            1、读取Excel文件；
            2、设置非商用许可证；
            3、遍历这个workbook中的每个worksheet页；
            4、然后遍历ExcelTitleList：
                4.1：获取名称为“CPU”的worksheet页，将第一行第二个单元格的内容插入到ExcelTitleList的“cpu”元素后面；
                4.2：获取名称为“GPU”的worksheet页，将第一行第二个单元格的内容插入到ExcelTitleList的“gpu”元素后面；
                4.3：获取名称为“温度档位”或者“温控档位”的worksheet页，将第一行第二个、第三个单元格的内容插入到ExcelTitleList的“tempGear”元素后面；
                4.4：获取名称为“亮度等级”的worksheet页，将第一行第二个单元格的内容插入到ExcelTitleList的“brightness”元素后面；
                4.5：获取名称为“ 充电电流”的worksheet页，将第一行第二个单元格的内容插入到ExcelTitleList的“charge”元素后面；
            5、返回ExcelTtileList 
            */
            //读取用户选择的配置表excel文件
            string path = TxtConfigFile.Text;
            //设置非商业用途的许可证
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            /*读取Excel文件，遍历每个worksheet页：
                获取名称为“CPU”的worksheet页，将第一行第二个单元格的内容插入到ExcelTitleList的“cpu”元素后面；
                获取名称为“GPU”的worksheet页，将第一行第二个单元格的内容插入到ExcelTitleList的“gpu”元素后面；
                获取名称为“温度档位”或者“温控档位”的worksheet页，将第一行第二个、第三个单元格的内容插入到ExcelTitleList的“tempGear”元素后面；
                获取名称为“亮度等级”的worksheet页，将第一行第二个单元格的内容插入到ExcelTitleList的“brightness”元素后面；
                获取名称为“ 充电电流”的worksheet页，将第一行第二个单元格的内容插入到ExcelTitleList的“charge”元素后面；
            */
            using (ExcelPackage package = new ExcelPackage(new FileInfo(path)))
            {
                //遍历每个worksheet页
                foreach (ExcelWorksheet worksheet in package.Workbook.Worksheets)
                {
                    //获取worksheet页的名称
                    string sheetName = worksheet.Name;
                    //获取worksheet页的第一行第二个单元格的内容
                    string cellValue = worksheet.Cells[1, 2].Value.ToString();
                    //判断worksheet页的名称
                    switch (sheetName)
                    {
                        case "CPU":
                            ExcelTitleList.Insert(ExcelTitleList.IndexOf("cpu") + 1, cellValue);
                            break;
                        case "GPU":
                            ExcelTitleList.Insert(ExcelTitleList.IndexOf("gpu") + 1, cellValue);
                            break;
                        case "温度档位":
                        case "温控档位":
                            ExcelTitleList.Insert(ExcelTitleList.IndexOf("tempGear") + 1, cellValue);
                            ExcelTitleList.Insert(ExcelTitleList.IndexOf("tempGear") + 2, cellValue);
                            break;
                        case "亮度等级":
                            ExcelTitleList.Insert(ExcelTitleList.IndexOf("brightness") + 1, cellValue);
                            break;
                        case "充电档位":
                            ExcelTitleList.Insert(ExcelTitleList.IndexOf("charge") + 1, cellValue);
                            break;
                    }
                }
            }



            //将ExcelTitleList打印出来
            foreach (string str in ExcelTitleList)
            {
                Console.WriteLine(str);
            }
            

            







        }




        /*
        1、定义一个方法LoadExcelToDic()，用于读取用户选择的配置表excel文件，遍历每个worksheet页；
        2、从TxtConfigFile.Text中获取用户选择的配置表excel文件路径；
        3、获取每个worksheet的名称，并分别生成对应名称的字典；
        4、遍历每个sheet页的内容，并将内容保存到一个字典中。
        5、设置非商业用途的许可证；
        6、返回字典，并在控制台打印；
        */
        private Dictionary<string, Dictionary<string, string>> LoadExcelToDic()
        {
            //从TxtConfigFile.Text中获取用户选择的配置表excel文件路径；
            string path = TxtConfigFile.Text;
            //定义一个字典，用于保存每个sheet页的内容
            Dictionary<string, Dictionary<string, string>> dic = new Dictionary<string, Dictionary<string, string>>();
            //设置非商业用途的许可证；
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            //读取Excel文件
            using (var package = new ExcelPackage(new System.IO.FileInfo(path)))
            {
                //遍历每个worksheet页
                foreach (var sheet in package.Workbook.Worksheets)
                {
                    //获取每个worksheet的名称，并分别生成对应名称的字典；
                    Dictionary<string, string> sheetDic = new Dictionary<string, string>();
                    //遍历每个sheet页的内容，并将内容保存到一个字典中。
                    for (int i = 1; i <= sheet.Dimension.End.Row; i++)
                    {
                        //获取第一列的值
                        string key = sheet.Cells[i, 1].Value.ToString();
                        //获取第二列的值
                        string value = sheet.Cells[i, 2].Value.ToString();
                        //将第一列和第二列的值保存到字典中
                        sheetDic.Add(key, value);
                    }
                    //将每个sheet页的字典保存到dic中
                    dic.Add(sheet.Name, sheetDic);
                }
            }
            //在控制台打印dic中的内容
            foreach (var item in dic)
            {
                Console.WriteLine(item.Key);
                foreach (var item2 in item.Value)
                {
                    Console.WriteLine(item2.Key + ":" + item2.Value);
                }
            }
            //返回dic
            return dic;
        }
    }
}
