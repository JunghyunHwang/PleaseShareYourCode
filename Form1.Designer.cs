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
            this.SuspendLayout();
            // 
            // BtnOpen
            // 
            this.BtnOpen.Location = new System.Drawing.Point(667, 167);
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
            this.BtnExport.Location = new System.Drawing.Point(667, 205);
            this.BtnExport.Name = "BtnExport";
            this.BtnExport.Size = new System.Drawing.Size(100, 32);
            this.BtnExport.TabIndex = 2;
            this.BtnExport.Text = "Export";
            this.BtnExport.UseVisualStyleBackColor = true;
            this.BtnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // CbFileList
            // 
            this.CbFileList.FormattingEnabled = true;
            this.CbFileList.Location = new System.Drawing.Point(111, 44);
            this.CbFileList.Name = "CbFileList";
            this.CbFileList.Size = new System.Drawing.Size(536, 324);
            this.CbFileList.TabIndex = 3;
            // 
            // PSYC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CbFileList);
            this.Controls.Add(this.BtnExport);
            this.Controls.Add(this.BtnOpen);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PSYC";
            this.Text = "PSYC";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BtnOpen;
        private System.Windows.Forms.Button BtnExport;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.CheckedListBox CbFileList;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

