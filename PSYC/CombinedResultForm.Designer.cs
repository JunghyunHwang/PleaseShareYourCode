namespace PleaseShareYourCode.PSYC
{
	partial class CombinedResultForm
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
			this.Save_button = new System.Windows.Forms.Button();
			this.Code_textBox = new System.Windows.Forms.TextBox();
			this.CopyToClipboard_button = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// Save_button
			// 
			this.Save_button.Location = new System.Drawing.Point(12, 12);
			this.Save_button.Name = "Save_button";
			this.Save_button.Size = new System.Drawing.Size(103, 23);
			this.Save_button.TabIndex = 0;
			this.Save_button.Text = "파일로 저장";
			this.Save_button.UseVisualStyleBackColor = true;
			this.Save_button.Click += new System.EventHandler(this.Save_button_Click);
			// 
			// Code_textBox
			// 
			this.Code_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.Code_textBox.Location = new System.Drawing.Point(12, 41);
			this.Code_textBox.Multiline = true;
			this.Code_textBox.Name = "Code_textBox";
			this.Code_textBox.Size = new System.Drawing.Size(725, 552);
			this.Code_textBox.TabIndex = 1;
			// 
			// CopyToClipboard_button
			// 
			this.CopyToClipboard_button.Location = new System.Drawing.Point(121, 12);
			this.CopyToClipboard_button.Name = "CopyToClipboard_button";
			this.CopyToClipboard_button.Size = new System.Drawing.Size(123, 23);
			this.CopyToClipboard_button.TabIndex = 2;
			this.CopyToClipboard_button.Text = "클립보드로 복사";
			this.CopyToClipboard_button.UseVisualStyleBackColor = true;
			this.CopyToClipboard_button.Click += new System.EventHandler(this.CopyToClipboard_button_Click);
			// 
			// CombinedResultForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(749, 605);
			this.Controls.Add(this.CopyToClipboard_button);
			this.Controls.Add(this.Code_textBox);
			this.Controls.Add(this.Save_button);
			this.Name = "CombinedResultForm";
			this.Text = "Code View";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button Save_button;
		private System.Windows.Forms.TextBox Code_textBox;
		private System.Windows.Forms.Button CopyToClipboard_button;
	}
}