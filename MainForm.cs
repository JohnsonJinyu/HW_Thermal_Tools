﻿using HW_Thermal_Tools.Forms;
using HW_Thermal_Tools.Forms.keithley2306;
using System.Windows.Forms;

namespace HW_Thermal_Tools
{
    public partial class MainForm : Form
    {

        //Fields
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;

        //定义一个字段用于保存设备连接检测对象
        private NiDeviceDetection detector;

        public MainForm()
        {
            InitializeComponent();
            random = new Random();
        }

        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new Font("Microsoft YaHei UI", 12.5F, FontStyle.Bold, GraphicsUnit.Point);
                    panelTitleBar.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);

                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDeskTopPanel.Controls.Add(childForm);
            this.panelDeskTopPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            //设置使用说明的相关格式
            richTextBoxIntroduction.ReadOnly = true;
            richTextBoxIntroduction.SelectedText = "使用说明：\n";
        }

        private void BtnForm1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.XmlToExcel(), sender);
        }

        private void BtnForm2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.ShellTempFitting(), sender);
        }


        private void BtnForm3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.ReadLog(), sender);
        }

        private void BtnForm4_Click(object sender, EventArgs e)
        {
            // 创建一个 NiVisaFunction 类型的对象
            NiVisaFunction niVisa = new NiVisaFunction();

            Keithley2306Form Form4 = new Keithley2306Form(niVisa);

            Form4.Activated += Form4.Keithley2306Form_Activated;

            OpenChildForm(Form4, sender);
        }


        private void panelLogo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void richTextBoxIntroduction_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnBackHome_Click(object sender, EventArgs e)
        {

            ShowMainForm(sender);


        }

        public void ShowMainForm(object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);
            this.Show();
            this.BringToFront();
            lblTitle.Text = "主页";
        }


    }
}
