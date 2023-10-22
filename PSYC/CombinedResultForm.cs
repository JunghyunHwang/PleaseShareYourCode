using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PleaseShareYourCode.PSYC
{
	public partial class CombinedResultForm : Form
	{
		string mProjectName;
		public CombinedResultForm(string code, string projectName)
		{
			InitializeComponent();
			Code_textBox.Text = code;
			Code_textBox.ScrollBars = ScrollBars.Both;
			Code_textBox.WordWrap = false;
			mProjectName = projectName;
			this.Text = projectName;
        }

		private void Save_button_Click(object sender, EventArgs e)
		{
			string text = Code_textBox.Text;
			FileSaver.SaveCodeToTextFile(text, mProjectName + ".txt");
		}

		private void CopyToClipboard_button_Click(object sender, EventArgs e)
		{
			string text = Code_textBox.Text;
			Clipboard.SetText(text);

			AutoCloseMessageBox box = new AutoCloseMessageBox("복사완료!", 1000, 4, 10);
			box.ShowDialog(this);
		}
	}
}
