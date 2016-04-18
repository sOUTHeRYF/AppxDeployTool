using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppxDeployTool
{
    public partial class MainForm : Form
    {
        private string[] chosenFiles;
        public MainForm()
        {
            InitializeComponent();

            SettingManager.Instance.Init();
        }

        private void ChooseFileBtn_Click(object sender, EventArgs e)
        {
            if(DialogResult.OK == this.ChooseAppxDialog.ShowDialog())
            {
                if(this.ChooseAppxDialog.FileNames?.Length >0 )
                {
                    this.FileToDeployTextBox.Text = this.ChooseAppxDialog.FileNames[0];
                    if (this.ChooseAppxDialog.FileNames.Length > 1)
                    {
                        this.FileToDeployTextBox.Text += "...等多个文件";
                    }
                    this.StatusStrip.Text = "选择了" + this.ChooseAppxDialog.FileNames.Length + "个包文件";
                    this.chosenFiles = this.ChooseAppxDialog.FileNames;
                }
            }
        }

        private void coverDeplyBtn_Click(object sender, EventArgs e)
        {
            //  CMDInvoker.Instance.SetExe()
            StatusStrip.Text = "处理中...";
            StartDeply(DeplyMode.Cover);
        }
        private void updateDeplyBtn_Click(object sender, EventArgs e)
        {
            StartDeply(DeplyMode.Update);
        }
        private void SettingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }



        private void FileToDeployTextBox_TextChanged(object sender, EventArgs e)
        {

        }


        private void StartDeply(AppxDeployTool.DeplyMode mode)
        {
            if (!string.IsNullOrWhiteSpace(this.FileToDeployTextBox.Text))
            {
                StatusStrip.Text = "处理中...";
                DeplyManager.Instance.Clear();
                if (this.chosenFiles?.Length <= 0)
                {
                    this.chosenFiles = new string[1] { this.FileToDeployTextBox.Text };
                }
                DeplyManager.Instance.SetDeplyFile(this.chosenFiles);
                DeplyManager.Instance.StartDeplyAppx((bool result,string message)=> {
                    this.StatusStrip.Text = message;
                });
            }
            else
            {
                MessageBox.Show("您尚未选择要部署的Appx文件", "尚未选择文件");
                return;
            }
        }
    }
}
