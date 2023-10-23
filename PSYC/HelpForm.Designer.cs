namespace PleaseShareYourCode.PSYC
{
    partial class HelpForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpForm));
			this.BtnClose = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// BtnClose
			// 
			this.BtnClose.Location = new System.Drawing.Point(149, 244);
			this.BtnClose.Name = "BtnClose";
			this.BtnClose.Size = new System.Drawing.Size(75, 23);
			this.BtnClose.TabIndex = 0;
			this.BtnClose.Text = "Close";
			this.BtnClose.UseVisualStyleBackColor = true;
			this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(29, 31);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(71, 12);
			this.label1.TabIndex = 1;
			this.label1.Text = "1. 언어 선택";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(42, 54);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(293, 12);
			this.label2.TabIndex = 2;
			this.label2.Text = "폴더 내에서 선택된 언어의 모든 확장자를 불러옵니다";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(42, 77);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(299, 12);
			this.label3.TabIndex = 3;
			this.label3.Text = "각 언어의 메인 함수 파일은 제외됩니다. 예) main.cpp";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(29, 98);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(83, 12);
			this.label4.TabIndex = 4;
			this.label4.Text = "2. 인코딩 선택";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(42, 120);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(285, 12);
			this.label5.TabIndex = 5;
			this.label5.Text = "IDE 나 OS의 영향으로 인코딩이 달라질 수 있습니다";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(29, 166);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(73, 12);
			this.label6.TabIndex = 6;
			this.label6.Text = "3. Separator";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(42, 189);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(185, 12);
			this.label7.TabIndex = 7;
			this.label7.Text = "파일을 구분문자 포맷 설정입니다";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(42, 211);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(191, 12);
			this.label8.TabIndex = 8;
			this.label8.Text = "파일명은 %name 으로 표기합니다";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(42, 143);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(277, 12);
			this.label10.TabIndex = 10;
			this.label10.Text = "한글 폰트가 깨지면 다른 인코딩으로 시도해보세요";
			// 
			// HelpForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(373, 305);
			this.ControlBox = false;
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.BtnClose);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "HelpForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "HELP";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
    }
}