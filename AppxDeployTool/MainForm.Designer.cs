namespace AppxDeployTool
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.FileToDeployTextBox = new System.Windows.Forms.TextBox();
            this.ChooseFileBtn = new System.Windows.Forms.Button();
            this.ChooseAppxDialog = new System.Windows.Forms.OpenFileDialog();
            this.updateDeplyBtn = new System.Windows.Forms.Button();
            this.coverDeplyBtn = new System.Windows.Forms.Button();
            this.MoreMenuStrip = new System.Windows.Forms.MenuStrip();
            this.MoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.MoreMenuStrip.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "准备部署的AppX Package:";
            // 
            // FileToDeployTextBox
            // 
            this.FileToDeployTextBox.Location = new System.Drawing.Point(32, 51);
            this.FileToDeployTextBox.Name = "FileToDeployTextBox";
            this.FileToDeployTextBox.Size = new System.Drawing.Size(544, 21);
            this.FileToDeployTextBox.TabIndex = 1;
            this.FileToDeployTextBox.TextChanged += new System.EventHandler(this.FileToDeployTextBox_TextChanged);
            // 
            // ChooseFileBtn
            // 
            this.ChooseFileBtn.Location = new System.Drawing.Point(593, 51);
            this.ChooseFileBtn.Name = "ChooseFileBtn";
            this.ChooseFileBtn.Size = new System.Drawing.Size(75, 23);
            this.ChooseFileBtn.TabIndex = 2;
            this.ChooseFileBtn.Text = "浏览...";
            this.ChooseFileBtn.UseVisualStyleBackColor = true;
            this.ChooseFileBtn.Click += new System.EventHandler(this.ChooseFileBtn_Click);
            // 
            // ChooseAppxDialog
            // 
            this.ChooseAppxDialog.Filter = "程序包文件(*.appx)|*.appx|提交包文件(*.appxupload)|*.appxupload";
            this.ChooseAppxDialog.Multiselect = true;
            this.ChooseAppxDialog.RestoreDirectory = true;
            this.ChooseAppxDialog.SupportMultiDottedExtensions = true;
            this.ChooseAppxDialog.Title = "选择要进行部署的Appx包";
            // 
            // updateDeplyBtn
            // 
            this.updateDeplyBtn.Location = new System.Drawing.Point(460, 88);
            this.updateDeplyBtn.Name = "updateDeplyBtn";
            this.updateDeplyBtn.Size = new System.Drawing.Size(75, 23);
            this.updateDeplyBtn.TabIndex = 3;
            this.updateDeplyBtn.Text = "更新部署";
            this.updateDeplyBtn.UseVisualStyleBackColor = true;
            this.updateDeplyBtn.Click += new System.EventHandler(this.updateDeplyBtn_Click);
            // 
            // coverDeplyBtn
            // 
            this.coverDeplyBtn.Location = new System.Drawing.Point(573, 88);
            this.coverDeplyBtn.Name = "coverDeplyBtn";
            this.coverDeplyBtn.Size = new System.Drawing.Size(95, 23);
            this.coverDeplyBtn.TabIndex = 4;
            this.coverDeplyBtn.Text = "覆盖部署";
            this.coverDeplyBtn.UseVisualStyleBackColor = true;
            this.coverDeplyBtn.Click += new System.EventHandler(this.coverDeplyBtn_Click);
            // 
            // MoreMenuStrip
            // 
            this.MoreMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MoreToolStripMenuItem});
            this.MoreMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MoreMenuStrip.Name = "MoreMenuStrip";
            this.MoreMenuStrip.Size = new System.Drawing.Size(693, 24);
            this.MoreMenuStrip.TabIndex = 5;
            this.MoreMenuStrip.Text = "更多";
            // 
            // MoreToolStripMenuItem
            // 
            this.MoreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SettingToolStripMenuItem,
            this.AboutToolStripMenuItem});
            this.MoreToolStripMenuItem.Name = "MoreToolStripMenuItem";
            this.MoreToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.MoreToolStripMenuItem.Text = "更多";
            // 
            // SettingToolStripMenuItem
            // 
            this.SettingToolStripMenuItem.Name = "SettingToolStripMenuItem";
            this.SettingToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.SettingToolStripMenuItem.Text = "设置";
            this.SettingToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.AboutToolStripMenuItem.Text = "关于";
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.StatusStrip.Location = new System.Drawing.Point(0, 289);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(693, 22);
            this.StatusStrip.TabIndex = 6;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 311);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.coverDeplyBtn);
            this.Controls.Add(this.updateDeplyBtn);
            this.Controls.Add(this.ChooseFileBtn);
            this.Controls.Add(this.FileToDeployTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MoreMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MoreMenuStrip;
            this.Name = "MainForm";
            this.Text = "AppxDeployTool";
            this.MoreMenuStrip.ResumeLayout(false);
            this.MoreMenuStrip.PerformLayout();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FileToDeployTextBox;
        private System.Windows.Forms.Button ChooseFileBtn;
        private System.Windows.Forms.OpenFileDialog ChooseAppxDialog;
        private System.Windows.Forms.Button updateDeplyBtn;
        private System.Windows.Forms.Button coverDeplyBtn;
        private System.Windows.Forms.MenuStrip MoreMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem MoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}

