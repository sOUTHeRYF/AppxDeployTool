using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MSDeploy = Microsoft.Tools.Deploy.Host.Cmd;
namespace AppxDeployTool
{
    public partial class MainForm : Form
    {
        delegate void SetTextCallback(string text, bool ifClear);
        private static MainForm Instance;
        private string[] chosenFiles = new string[0];
        public MainForm()
        {
            Instance = this;
            InitializeComponent();

            SettingManager.Instance.Init();
            MSDeploy.Program.Init((string str) =>
            {
                LogOut(str);
            });
        }

        private void ChooseFileBtn_Click(object sender, EventArgs e)
        {

            //    MSDeploy.Program.Main(null);

            if (DialogResult.OK == this.ChooseAppxDialog.ShowDialog())
            {
                if (this.ChooseAppxDialog.FileNames?.Length > 0)
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

        private void coverDeployBtn_Click(object sender, EventArgs e)
        {
            //  CMDInvoker.Instance.SetExe()
            StatusStrip.Text = "处理中...";
            StartDeploy(DeployMode.Cover);
        }
        private void updateDeployBtn_Click(object sender, EventArgs e)
        {
            StartDeploy(DeployMode.Update);
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

        private void StartDeploy(AppxDeployTool.DeployMode mode)
        {
            if (!string.IsNullOrWhiteSpace(this.FileToDeployTextBox.Text))
            {
                StatusStrip.Text = "处理中...";
                DeployManager.Instance.Clear();
                if (this.chosenFiles?.Length+0 <= 0)
                {
                    this.chosenFiles = new string[1] { this.FileToDeployTextBox.Text };
                }
                DeployManager.Instance.SetDeployFile(this.chosenFiles);
                DeployManager.Instance.StartDeployAppx((bool result, string message) =>
                {
                    this.StatusStrip.Text = message;
                });
            }
            else
            {
                MessageBox.Show("您尚未选择要部署的Appx文件", "尚未选择文件");
                return;
            }
        }

        public static void LogOut(string str, bool ifClear = false)
        {
            if (Instance.LogTextBox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(LogOut);
                Instance.Invoke(d, new object[] { str, ifClear });
           //     d.Invoke(str, ifClear);
            }
            else
            {
                if (!ifClear)
                {
                    Instance.LogTextBox.AppendText(str);
                }
                else
                {
                    Instance.LogTextBox.Text = str;
                }
            }
        }

    }
}
