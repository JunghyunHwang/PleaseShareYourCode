using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PleaseShareYouCode
{
    partial class PSYC
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PSYC));
            this.BtnOpen = new System.Windows.Forms.Button();
            this.BtnExport = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.CbFileList = new System.Windows.Forms.CheckedListBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.r_btnCS = new System.Windows.Forms.RadioButton();
            this.r_btnJAVA = new System.Windows.Forms.RadioButton();
            this.r_btnC = new System.Windows.Forms.RadioButton();
            this.r_btnCPP = new System.Windows.Forms.RadioButton();
            this.g_boxLanguage = new System.Windows.Forms.GroupBox();
            this.labelProject = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.setting = new System.Windows.Forms.ToolStripMenuItem();
            this.DefaultLanguageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.csToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.javaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.g_boxLanguage.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnOpen
            // 
            this.BtnOpen.Location = new System.Drawing.Point(487, 324);
            this.BtnOpen.Name = "BtnOpen";
            this.BtnOpen.Size = new System.Drawing.Size(100, 32);
            this.BtnOpen.TabIndex = 0;
            this.BtnOpen.Text = "Open";
            this.BtnOpen.UseVisualStyleBackColor = true;
            this.BtnOpen.Click += new System.EventHandler(this.BtnOpen_Click);
            // 
            // BtnExport
            // 
            this.BtnExport.Enabled = false;
            this.BtnExport.Location = new System.Drawing.Point(487, 364);
            this.BtnExport.Name = "BtnExport";
            this.BtnExport.Size = new System.Drawing.Size(100, 32);
            this.BtnExport.TabIndex = 2;
            this.BtnExport.Text = "Export";
            this.BtnExport.UseVisualStyleBackColor = true;
            this.BtnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // CbFileList
            // 
            this.CbFileList.AllowDrop = true;
            this.CbFileList.CheckOnClick = true;
            this.CbFileList.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.CbFileList.FormattingEnabled = true;
            this.CbFileList.Location = new System.Drawing.Point(33, 66);
            this.CbFileList.Name = "CbFileList";
            this.CbFileList.Size = new System.Drawing.Size(396, 364);
            this.CbFileList.TabIndex = 3;
            this.CbFileList.DragDrop += new System.Windows.Forms.DragEventHandler(this.CbFileList_DragDrop);
            this.CbFileList.DragOver += new System.Windows.Forms.DragEventHandler(this.CbFileList_DragOver);
            this.CbFileList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CbFileList_MouseDown);
            this.CbFileList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CbFileList_MouseMove);
            this.CbFileList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CbFileList_MouseUp);
            // 
            // r_btnCS
            // 
            this.r_btnCS.AutoSize = true;
            this.r_btnCS.Location = new System.Drawing.Point(29, 53);
            this.r_btnCS.Name = "r_btnCS";
            this.r_btnCS.Size = new System.Drawing.Size(46, 19);
            this.r_btnCS.TabIndex = 5;
            this.r_btnCS.TabStop = true;
            this.r_btnCS.Text = "C#";
            this.r_btnCS.UseVisualStyleBackColor = true;
            // 
            // r_btnJAVA
            // 
            this.r_btnJAVA.AutoSize = true;
            this.r_btnJAVA.Location = new System.Drawing.Point(29, 78);
            this.r_btnJAVA.Name = "r_btnJAVA";
            this.r_btnJAVA.Size = new System.Drawing.Size(58, 19);
            this.r_btnJAVA.TabIndex = 6;
            this.r_btnJAVA.Text = "Java";
            this.r_btnJAVA.UseVisualStyleBackColor = true;
            // 
            // r_btnC
            // 
            this.r_btnC.AutoSize = true;
            this.r_btnC.Location = new System.Drawing.Point(29, 103);
            this.r_btnC.Name = "r_btnC";
            this.r_btnC.Size = new System.Drawing.Size(38, 19);
            this.r_btnC.TabIndex = 7;
            this.r_btnC.Text = "C";
            this.r_btnC.UseVisualStyleBackColor = true;
            // 
            // r_btnCPP
            // 
            this.r_btnCPP.AutoSize = true;
            this.r_btnCPP.Location = new System.Drawing.Point(29, 128);
            this.r_btnCPP.Name = "r_btnCPP";
            this.r_btnCPP.Size = new System.Drawing.Size(54, 19);
            this.r_btnCPP.TabIndex = 8;
            this.r_btnCPP.TabStop = true;
            this.r_btnCPP.Text = "C++";
            this.r_btnCPP.UseVisualStyleBackColor = true;
            // 
            // g_boxLanguage
            // 
            this.g_boxLanguage.Controls.Add(this.r_btnJAVA);
            this.g_boxLanguage.Controls.Add(this.r_btnCPP);
            this.g_boxLanguage.Controls.Add(this.r_btnCS);
            this.g_boxLanguage.Controls.Add(this.r_btnC);
            this.g_boxLanguage.Location = new System.Drawing.Point(458, 66);
            this.g_boxLanguage.Name = "g_boxLanguage";
            this.g_boxLanguage.Size = new System.Drawing.Size(159, 190);
            this.g_boxLanguage.TabIndex = 9;
            this.g_boxLanguage.TabStop = false;
            this.g_boxLanguage.Text = "Language";
            // 
            // labelProject
            // 
            this.labelProject.AutoSize = true;
            this.labelProject.Location = new System.Drawing.Point(39, 48);
            this.labelProject.Name = "labelProject";
            this.labelProject.Size = new System.Drawing.Size(0, 15);
            this.labelProject.TabIndex = 10;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setting});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(650, 28);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // setting
            // 
            this.setting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DefaultLanguageToolStripMenuItem});
            this.setting.Name = "setting";
            this.setting.Size = new System.Drawing.Size(53, 24);
            this.setting.Text = "설정";
            // 
            // DefaultLanguageToolStripMenuItem
            // 
            this.DefaultLanguageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.csToolStripMenuItem,
            this.javaToolStripMenuItem,
            this.cToolStripMenuItem,
            this.cppToolStripMenuItem});
            this.DefaultLanguageToolStripMenuItem.Name = "DefaultLanguageToolStripMenuItem";
            this.DefaultLanguageToolStripMenuItem.Size = new System.Drawing.Size(192, 26);
            this.DefaultLanguageToolStripMenuItem.Text = "기본 언어 설정";
            // 
            // csToolStripMenuItem
            // 
            this.csToolStripMenuItem.Name = "csToolStripMenuItem";
            this.csToolStripMenuItem.Size = new System.Drawing.Size(124, 26);
            this.csToolStripMenuItem.Text = "C#";
            this.csToolStripMenuItem.Click += new System.EventHandler(this.SetDefaultLanguageCS_Click);
            // 
            // javaToolStripMenuItem
            // 
            this.javaToolStripMenuItem.Name = "javaToolStripMenuItem";
            this.javaToolStripMenuItem.Size = new System.Drawing.Size(124, 26);
            this.javaToolStripMenuItem.Text = "Java";
            this.javaToolStripMenuItem.Click += new System.EventHandler(this.SetDefaultLanguageJava_Click);
            // 
            // cToolStripMenuItem
            // 
            this.cToolStripMenuItem.Name = "cToolStripMenuItem";
            this.cToolStripMenuItem.Size = new System.Drawing.Size(124, 26);
            this.cToolStripMenuItem.Text = "C";
            this.cToolStripMenuItem.Click += new System.EventHandler(this.SetDefaultLanguageC_Click);
            // 
            // cppToolStripMenuItem
            // 
            this.cppToolStripMenuItem.Name = "cppToolStripMenuItem";
            this.cppToolStripMenuItem.Size = new System.Drawing.Size(124, 26);
            this.cppToolStripMenuItem.Text = "C++";
            this.cppToolStripMenuItem.Click += new System.EventHandler(this.SetDefaultLanguageCpp_Click);
            // 
            // PSYC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 480);
            this.Controls.Add(this.labelProject);
            this.Controls.Add(this.g_boxLanguage);
            this.Controls.Add(this.CbFileList);
            this.Controls.Add(this.BtnExport);
            this.Controls.Add(this.BtnOpen);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(600, 300);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PSYC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "PSYC";
            this.g_boxLanguage.ResumeLayout(false);
            this.g_boxLanguage.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnOpen;
        private System.Windows.Forms.Button BtnExport;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.CheckedListBox CbFileList;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private RadioButton r_btnCS;
        private RadioButton r_btnJAVA;
        private RadioButton r_btnC;
        private RadioButton r_btnCPP;
        private GroupBox g_boxLanguage;
        private Label labelProject;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem setting;
        private ToolStripMenuItem DefaultLanguageToolStripMenuItem;
        private ToolStripMenuItem csToolStripMenuItem;
        private ToolStripMenuItem javaToolStripMenuItem;
        private ToolStripMenuItem cToolStripMenuItem;
        private ToolStripMenuItem cppToolStripMenuItem;
    }
}

