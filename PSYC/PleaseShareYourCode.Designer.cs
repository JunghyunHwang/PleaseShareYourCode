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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PSYC));
			this.BtnOpen = new System.Windows.Forms.Button();
			this.BtnCombine = new System.Windows.Forms.Button();
			this.CbFileList = new System.Windows.Forms.CheckedListBox();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.r_BtnCS = new System.Windows.Forms.RadioButton();
			this.r_BtnJAVA = new System.Windows.Forms.RadioButton();
			this.r_BtnC = new System.Windows.Forms.RadioButton();
			this.r_BtnCPP = new System.Windows.Forms.RadioButton();
			this.g_boxLanguage = new System.Windows.Forms.GroupBox();
			this.r_BtnASM = new System.Windows.Forms.RadioButton();
			this.labelProject = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.r_BtnASCII = new System.Windows.Forms.RadioButton();
			this.r_BtnUTF8 = new System.Windows.Forms.RadioButton();
			this.r_BtnDefault = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.labelSeparator = new System.Windows.Forms.Label();
			this.textBoxSeparator = new System.Windows.Forms.TextBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.BtnHelp = new System.Windows.Forms.Button();
			this.g_boxLanguage.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// BtnOpen
			// 
			this.BtnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnOpen.Location = new System.Drawing.Point(438, 381);
			this.BtnOpen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.BtnOpen.Name = "BtnOpen";
			this.BtnOpen.Size = new System.Drawing.Size(88, 26);
			this.BtnOpen.TabIndex = 0;
			this.BtnOpen.Text = "Open";
			this.BtnOpen.UseVisualStyleBackColor = true;
			this.BtnOpen.Click += new System.EventHandler(this.BtnOpen_Click);
			// 
			// BtnCombine
			// 
			this.BtnCombine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnCombine.Enabled = false;
			this.BtnCombine.Location = new System.Drawing.Point(438, 411);
			this.BtnCombine.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.BtnCombine.Name = "BtnCombine";
			this.BtnCombine.Size = new System.Drawing.Size(88, 26);
			this.BtnCombine.TabIndex = 2;
			this.BtnCombine.Text = "Combine";
			this.BtnCombine.UseVisualStyleBackColor = true;
			this.BtnCombine.Click += new System.EventHandler(this.BtnCombine_Click);
			// 
			// CbFileList
			// 
			this.CbFileList.AllowDrop = true;
			this.CbFileList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CbFileList.CheckOnClick = true;
			this.CbFileList.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.CbFileList.FormattingEnabled = true;
			this.CbFileList.Location = new System.Drawing.Point(12, 33);
			this.CbFileList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.CbFileList.Name = "CbFileList";
			this.CbFileList.Size = new System.Drawing.Size(375, 404);
			this.CbFileList.TabIndex = 3;
			this.CbFileList.DragDrop += new System.Windows.Forms.DragEventHandler(this.CbFileList_DragDrop);
			this.CbFileList.DragOver += new System.Windows.Forms.DragEventHandler(this.CbFileList_DragOver);
			this.CbFileList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CbFileList_MouseDown);
			this.CbFileList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CbFileList_MouseMove);
			this.CbFileList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CbFileList_MouseUp);
			// 
			// r_BtnCS
			// 
			this.r_BtnCS.AutoSize = true;
			this.r_BtnCS.Location = new System.Drawing.Point(25, 58);
			this.r_BtnCS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.r_BtnCS.Name = "r_BtnCS";
			this.r_BtnCS.Size = new System.Drawing.Size(38, 16);
			this.r_BtnCS.TabIndex = 5;
			this.r_BtnCS.TabStop = true;
			this.r_BtnCS.Text = "C#";
			this.r_BtnCS.UseVisualStyleBackColor = true;
			this.r_BtnCS.CheckedChanged += new System.EventHandler(this.r_BtnLanguage_CheckedChanged);
			// 
			// r_BtnJAVA
			// 
			this.r_BtnJAVA.AutoSize = true;
			this.r_BtnJAVA.Location = new System.Drawing.Point(25, 78);
			this.r_BtnJAVA.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.r_BtnJAVA.Name = "r_BtnJAVA";
			this.r_BtnJAVA.Size = new System.Drawing.Size(49, 16);
			this.r_BtnJAVA.TabIndex = 6;
			this.r_BtnJAVA.Text = "Java";
			this.r_BtnJAVA.UseVisualStyleBackColor = true;
			this.r_BtnJAVA.CheckedChanged += new System.EventHandler(this.r_BtnLanguage_CheckedChanged);
			// 
			// r_BtnC
			// 
			this.r_BtnC.AutoSize = true;
			this.r_BtnC.Location = new System.Drawing.Point(25, 18);
			this.r_BtnC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.r_BtnC.Name = "r_BtnC";
			this.r_BtnC.Size = new System.Drawing.Size(32, 16);
			this.r_BtnC.TabIndex = 7;
			this.r_BtnC.Text = "C";
			this.r_BtnC.UseVisualStyleBackColor = true;
			this.r_BtnC.CheckedChanged += new System.EventHandler(this.r_BtnLanguage_CheckedChanged);
			// 
			// r_BtnCPP
			// 
			this.r_BtnCPP.AutoSize = true;
			this.r_BtnCPP.Location = new System.Drawing.Point(25, 38);
			this.r_BtnCPP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.r_BtnCPP.Name = "r_BtnCPP";
			this.r_BtnCPP.Size = new System.Drawing.Size(44, 16);
			this.r_BtnCPP.TabIndex = 8;
			this.r_BtnCPP.TabStop = true;
			this.r_BtnCPP.Text = "C++";
			this.r_BtnCPP.UseVisualStyleBackColor = true;
			this.r_BtnCPP.CheckedChanged += new System.EventHandler(this.r_BtnLanguage_CheckedChanged);
			// 
			// g_boxLanguage
			// 
			this.g_boxLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.g_boxLanguage.Controls.Add(this.r_BtnASM);
			this.g_boxLanguage.Controls.Add(this.r_BtnJAVA);
			this.g_boxLanguage.Controls.Add(this.r_BtnCPP);
			this.g_boxLanguage.Controls.Add(this.r_BtnCS);
			this.g_boxLanguage.Controls.Add(this.r_BtnC);
			this.g_boxLanguage.Location = new System.Drawing.Point(393, 26);
			this.g_boxLanguage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.g_boxLanguage.Name = "g_boxLanguage";
			this.g_boxLanguage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.g_boxLanguage.Size = new System.Drawing.Size(172, 124);
			this.g_boxLanguage.TabIndex = 9;
			this.g_boxLanguage.TabStop = false;
			this.g_boxLanguage.Text = "Language";
			// 
			// r_BtnASM
			// 
			this.r_BtnASM.AutoSize = true;
			this.r_BtnASM.Location = new System.Drawing.Point(25, 98);
			this.r_BtnASM.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.r_BtnASM.Name = "r_BtnASM";
			this.r_BtnASM.Size = new System.Drawing.Size(80, 16);
			this.r_BtnASM.TabIndex = 9;
			this.r_BtnASM.TabStop = true;
			this.r_BtnASM.Text = "Assembly";
			this.r_BtnASM.UseVisualStyleBackColor = true;
			this.r_BtnASM.CheckedChanged += new System.EventHandler(this.r_BtnLanguage_CheckedChanged);
			// 
			// labelProject
			// 
			this.labelProject.AutoSize = true;
			this.labelProject.Location = new System.Drawing.Point(63, 11);
			this.labelProject.Name = "labelProject";
			this.labelProject.Size = new System.Drawing.Size(21, 12);
			this.labelProject.TabIndex = 10;
			this.labelProject.Text = "AA";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.r_BtnASCII);
			this.groupBox1.Controls.Add(this.r_BtnUTF8);
			this.groupBox1.Controls.Add(this.r_BtnDefault);
			this.groupBox1.Location = new System.Drawing.Point(393, 155);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(172, 91);
			this.groupBox1.TabIndex = 12;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Encoding";
			// 
			// r_BtnASCII
			// 
			this.r_BtnASCII.AutoSize = true;
			this.r_BtnASCII.Location = new System.Drawing.Point(24, 65);
			this.r_BtnASCII.Name = "r_BtnASCII";
			this.r_BtnASCII.Size = new System.Drawing.Size(54, 16);
			this.r_BtnASCII.TabIndex = 2;
			this.r_BtnASCII.TabStop = true;
			this.r_BtnASCII.Text = "ASCII";
			this.r_BtnASCII.UseVisualStyleBackColor = true;
			this.r_BtnASCII.CheckedChanged += new System.EventHandler(this.r_BtnEncoding_CheckedChanged);
			// 
			// r_BtnUTF8
			// 
			this.r_BtnUTF8.AutoSize = true;
			this.r_BtnUTF8.Location = new System.Drawing.Point(24, 43);
			this.r_BtnUTF8.Name = "r_BtnUTF8";
			this.r_BtnUTF8.Size = new System.Drawing.Size(52, 16);
			this.r_BtnUTF8.TabIndex = 1;
			this.r_BtnUTF8.TabStop = true;
			this.r_BtnUTF8.Text = "UTF8";
			this.r_BtnUTF8.UseVisualStyleBackColor = true;
			this.r_BtnUTF8.CheckedChanged += new System.EventHandler(this.r_BtnEncoding_CheckedChanged);
			// 
			// r_BtnDefault
			// 
			this.r_BtnDefault.AutoSize = true;
			this.r_BtnDefault.Location = new System.Drawing.Point(24, 20);
			this.r_BtnDefault.Name = "r_BtnDefault";
			this.r_BtnDefault.Size = new System.Drawing.Size(61, 16);
			this.r_BtnDefault.TabIndex = 0;
			this.r_BtnDefault.TabStop = true;
			this.r_BtnDefault.Text = "Default";
			this.r_BtnDefault.UseVisualStyleBackColor = true;
			this.r_BtnDefault.CheckedChanged += new System.EventHandler(this.r_BtnEncoding_CheckedChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(10, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(52, 12);
			this.label1.TabIndex = 13;
			this.label1.Text = "Project :";
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.labelSeparator);
			this.groupBox2.Controls.Add(this.textBoxSeparator);
			this.groupBox2.Location = new System.Drawing.Point(393, 252);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(172, 83);
			this.groupBox2.TabIndex = 14;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Separator";
			// 
			// labelSeparator
			// 
			this.labelSeparator.AutoSize = true;
			this.labelSeparator.Location = new System.Drawing.Point(11, 53);
			this.labelSeparator.Name = "labelSeparator";
			this.labelSeparator.Size = new System.Drawing.Size(21, 12);
			this.labelSeparator.TabIndex = 1;
			this.labelSeparator.Text = "AA";
			// 
			// textBoxSeparator
			// 
			this.textBoxSeparator.Location = new System.Drawing.Point(13, 20);
			this.textBoxSeparator.Name = "textBoxSeparator";
			this.textBoxSeparator.Size = new System.Drawing.Size(151, 21);
			this.textBoxSeparator.TabIndex = 0;
			this.textBoxSeparator.TextChanged += new System.EventHandler(this.TextBoxSeparator_TextChanged);
			// 
			// BtnHelp
			// 
			this.BtnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnHelp.Location = new System.Drawing.Point(438, 350);
			this.BtnHelp.Name = "BtnHelp";
			this.BtnHelp.Size = new System.Drawing.Size(88, 26);
			this.BtnHelp.TabIndex = 15;
			this.BtnHelp.Text = "Help";
			this.BtnHelp.UseVisualStyleBackColor = true;
			this.BtnHelp.Click += new System.EventHandler(this.BtnHelp_Click);
			// 
			// PSYC
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(569, 466);
			this.Controls.Add(this.BtnHelp);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.labelProject);
			this.Controls.Add(this.g_boxLanguage);
			this.Controls.Add(this.CbFileList);
			this.Controls.Add(this.BtnCombine);
			this.Controls.Add(this.BtnOpen);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Location = new System.Drawing.Point(600, 300);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "PSYC";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "PSYC";
			this.g_boxLanguage.ResumeLayout(false);
			this.g_boxLanguage.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnOpen;
        private System.Windows.Forms.Button BtnCombine;
        private System.Windows.Forms.CheckedListBox CbFileList;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private RadioButton r_BtnCS;
        private RadioButton r_BtnJAVA;
        private RadioButton r_BtnC;
        private RadioButton r_BtnCPP;
        private GroupBox g_boxLanguage;
        private Label labelProject;
        private RadioButton r_BtnASM;
		private GroupBox groupBox1;
		private Label label1;
		private RadioButton r_BtnASCII;
		private RadioButton r_BtnUTF8;
		private RadioButton r_BtnDefault;
		private GroupBox groupBox2;
		private Label labelSeparator;
		private TextBox textBoxSeparator;
		private ToolTip toolTip1;
		private Button BtnHelp;
	}
}

