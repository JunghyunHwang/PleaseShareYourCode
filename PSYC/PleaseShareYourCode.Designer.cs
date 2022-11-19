using PleaseShareYourCode.PSYC;
using System.Drawing;
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
            this.TbTitle = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BtnOpen
            // 
            this.BtnOpen.Location = new System.Drawing.Point(660, 170);
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
            this.BtnExport.Location = new System.Drawing.Point(660, 210);
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
            this.CbFileList.Location = new System.Drawing.Point(100, 50);
            this.CbFileList.Name = "CbFileList";
            this.CbFileList.Size = new System.Drawing.Size(525, 344);
            this.CbFileList.TabIndex = 3;
            this.CbFileList.DragDrop += new System.Windows.Forms.DragEventHandler(this.CbFileList_DragDrop);
            this.CbFileList.DragOver += new System.Windows.Forms.DragEventHandler(this.CbFileList_DragOver);
            this.CbFileList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CbFileList_MouseDown);
            this.CbFileList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CbFileList_MouseMove);
            this.CbFileList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CbFileList_MouseUp);
            // 
            // TbTitle
            // 
            this.TbTitle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.TbTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TbTitle.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TbTitle.Location = new System.Drawing.Point(111, 26);
            this.TbTitle.Name = "TbTitle";
            this.TbTitle.ReadOnly = true;
            this.TbTitle.Size = new System.Drawing.Size(100, 18);
            this.TbTitle.TabIndex = 4;
            // 
            // PSYC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TbTitle);
            this.Controls.Add(this.CbFileList);
            this.Controls.Add(this.BtnExport);
            this.Controls.Add(this.BtnOpen);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(500, 300);
            this.Name = "PSYC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "PSYC";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnOpen;
        private System.Windows.Forms.Button BtnExport;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.CheckedListBox CbFileList;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox TbTitle;
    }
}

