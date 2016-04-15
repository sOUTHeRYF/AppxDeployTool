﻿namespace AppxDeployTool
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
            this.label1 = new System.Windows.Forms.Label();
            this.FileToDeployTextBox = new System.Windows.Forms.TextBox();
            this.ChooseFileBtn = new System.Windows.Forms.Button();
            this.ChooseAppxDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "准备部署的AppX Package:";
            // 
            // FileToDeployTextBox
            // 
            this.FileToDeployTextBox.Location = new System.Drawing.Point(32, 37);
            this.FileToDeployTextBox.Name = "FileToDeployTextBox";
            this.FileToDeployTextBox.Size = new System.Drawing.Size(544, 21);
            this.FileToDeployTextBox.TabIndex = 1;
            // 
            // ChooseFileBtn
            // 
            this.ChooseFileBtn.Location = new System.Drawing.Point(593, 37);
            this.ChooseFileBtn.Name = "ChooseFileBtn";
            this.ChooseFileBtn.Size = new System.Drawing.Size(75, 23);
            this.ChooseFileBtn.TabIndex = 2;
            this.ChooseFileBtn.Text = "浏览...";
            this.ChooseFileBtn.UseVisualStyleBackColor = true;
            this.ChooseFileBtn.Click += new System.EventHandler(this.ChooseFileBtn_Click);
            // 
            // ChooseAppxDialog
            // 
            this.ChooseAppxDialog.FileName = "appxFileName";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 311);
            this.Controls.Add(this.ChooseFileBtn);
            this.Controls.Add(this.FileToDeployTextBox);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "AppxDeployTool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FileToDeployTextBox;
        private System.Windows.Forms.Button ChooseFileBtn;
        private System.Windows.Forms.OpenFileDialog ChooseAppxDialog;
    }
}

