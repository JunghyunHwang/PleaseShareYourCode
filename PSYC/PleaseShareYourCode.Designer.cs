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
			this.BtnCombine = new System.Windows.Forms.Button();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.CbFileList = new System.Windows.Forms.CheckedListBox();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.r_btnCS = new System.Windows.Forms.RadioButton();
			this.r_btnJAVA = new System.Windows.Forms.RadioButton();
			this.r_btnC = new System.Windows.Forms.RadioButton();
			this.r_btnCPP = new System.Windows.Forms.RadioButton();
			this.g_boxLanguage = new System.Windows.Forms.GroupBox();
			this.r_btnAsm = new System.Windows.Forms.RadioButton();
			this.labelProject = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.g_boxLanguage.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// BtnOpen
			// 
			this.BtnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnOpen.Location = new System.Drawing.Point(451, 317);
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
			this.BtnCombine.Location = new System.Drawing.Point(451, 347);
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
			this.CbFileList.Size = new System.Drawing.Size(408, 340);
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
			this.r_btnCS.Location = new System.Drawing.Point(25, 77);
			this.r_btnCS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.r_btnCS.Name = "r_btnCS";
			this.r_btnCS.Size = new System.Drawing.Size(38, 16);
			this.r_btnCS.TabIndex = 5;
			this.r_btnCS.TabStop = true;
			this.r_btnCS.Text = "C#";
			this.r_btnCS.UseVisualStyleBackColor = true;
			this.r_btnCS.CheckedChanged += new System.EventHandler(this.r_btn_CheckedChanged);
			// 
			// r_btnJAVA
			// 
			this.r_btnJAVA.AutoSize = true;
			this.r_btnJAVA.Location = new System.Drawing.Point(25, 97);
			this.r_btnJAVA.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.r_btnJAVA.Name = "r_btnJAVA";
			this.r_btnJAVA.Size = new System.Drawing.Size(49, 16);
			this.r_btnJAVA.TabIndex = 6;
			this.r_btnJAVA.Text = "Java";
			this.r_btnJAVA.UseVisualStyleBackColor = true;
			this.r_btnJAVA.CheckedChanged += new System.EventHandler(this.r_btn_CheckedChanged);
			// 
			// r_btnC
			// 
			this.r_btnC.AutoSize = true;
			this.r_btnC.Location = new System.Drawing.Point(25, 37);
			this.r_btnC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.r_btnC.Name = "r_btnC";
			this.r_btnC.Size = new System.Drawing.Size(32, 16);
			this.r_btnC.TabIndex = 7;
			this.r_btnC.Text = "C";
			this.r_btnC.UseVisualStyleBackColor = true;
			this.r_btnC.CheckedChanged += new System.EventHandler(this.r_btn_CheckedChanged);
			// 
			// r_btnCPP
			// 
			this.r_btnCPP.AutoSize = true;
			this.r_btnCPP.Location = new System.Drawing.Point(25, 57);
			this.r_btnCPP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.r_btnCPP.Name = "r_btnCPP";
			this.r_btnCPP.Size = new System.Drawing.Size(44, 16);
			this.r_btnCPP.TabIndex = 8;
			this.r_btnCPP.TabStop = true;
			this.r_btnCPP.Text = "C++";
			this.r_btnCPP.UseVisualStyleBackColor = true;
			this.r_btnCPP.CheckedChanged += new System.EventHandler(this.r_btn_CheckedChanged);
			// 
			// g_boxLanguage
			// 
			this.g_boxLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.g_boxLanguage.Controls.Add(this.r_btnAsm);
			this.g_boxLanguage.Controls.Add(this.r_btnJAVA);
			this.g_boxLanguage.Controls.Add(this.r_btnCPP);
			this.g_boxLanguage.Controls.Add(this.r_btnCS);
			this.g_boxLanguage.Controls.Add(this.r_btnC);
			this.g_boxLanguage.Location = new System.Drawing.Point(426, 26);
			this.g_boxLanguage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.g_boxLanguage.Name = "g_boxLanguage";
			this.g_boxLanguage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.g_boxLanguage.Size = new System.Drawing.Size(139, 155);
			this.g_boxLanguage.TabIndex = 9;
			this.g_boxLanguage.TabStop = false;
			this.g_boxLanguage.Text = "Language";
			// 
			// r_btnAsm
			// 
			this.r_btnAsm.AutoSize = true;
			this.r_btnAsm.Location = new System.Drawing.Point(25, 117);
			this.r_btnAsm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.r_btnAsm.Name = "r_btnAsm";
			this.r_btnAsm.Size = new System.Drawing.Size(80, 16);
			this.r_btnAsm.TabIndex = 9;
			this.r_btnAsm.TabStop = true;
			this.r_btnAsm.Text = "Assembly";
			this.r_btnAsm.UseVisualStyleBackColor = true;
			this.r_btnAsm.CheckedChanged += new System.EventHandler(this.r_btn_CheckedChanged);
			// 
			// labelProject
			// 
			this.labelProject.AutoSize = true;
			this.labelProject.Location = new System.Drawing.Point(70, 9);
			this.labelProject.Name = "labelProject";
			this.labelProject.Size = new System.Drawing.Size(0, 12);
			this.labelProject.TabIndex = 10;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.radioButton3);
			this.groupBox1.Controls.Add(this.radioButton2);
			this.groupBox1.Controls.Add(this.radioButton1);
			this.groupBox1.Location = new System.Drawing.Point(427, 187);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(138, 95);
			this.groupBox1.TabIndex = 12;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Encoding";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(52, 12);
			this.label1.TabIndex = 13;
			this.label1.Text = "Project :";
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Location = new System.Drawing.Point(24, 21);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(61, 16);
			this.radioButton1.TabIndex = 0;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "Default";
			this.radioButton1.UseVisualStyleBackColor = true;
			this.radioButton1.CheckedChanged += new System.EventHandler(this.Encoding_radioButton_CheckedChanged);
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Location = new System.Drawing.Point(24, 43);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(52, 16);
			this.radioButton2.TabIndex = 1;
			this.radioButton2.TabStop = true;
			this.radioButton2.Text = "UTF8";
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// radioButton3
			// 
			this.radioButton3.AutoSize = true;
			this.radioButton3.Location = new System.Drawing.Point(24, 65);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(54, 16);
			this.radioButton3.TabIndex = 2;
			this.radioButton3.TabStop = true;
			this.radioButton3.Text = "ASCII";
			this.radioButton3.UseVisualStyleBackColor = true;
			// 
			// PSYC
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(569, 384);
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
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnOpen;
        private System.Windows.Forms.Button BtnCombine;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.CheckedListBox CbFileList;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private RadioButton r_btnCS;
        private RadioButton r_btnJAVA;
        private RadioButton r_btnC;
        private RadioButton r_btnCPP;
        private GroupBox g_boxLanguage;
        private Label labelProject;
        private RadioButton r_btnAsm;
		private GroupBox groupBox1;
		private Label label1;
		private RadioButton radioButton3;
		private RadioButton radioButton2;
		private RadioButton radioButton1;
	}
}

