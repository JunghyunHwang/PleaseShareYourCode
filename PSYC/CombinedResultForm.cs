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
		public CombinedResultForm(string text)
		{
			InitializeComponent();
			Code_textBox.Text = text;
			Code_textBox.ScrollBars = ScrollBars.Both;
			Code_textBox.WordWrap = false;
		}

		private void Save_button_Click(object sender, EventArgs e)
		{
			string text = Code_textBox.Text;
			FileSaver.SaveCodeToTextFile(text);
		}

		private void CopyToClipboard_button_Click(object sender, EventArgs e)
		{
			string text = Code_textBox.Text;
			Clipboard.SetText(text);

			AutoCloseMessageBox box = new AutoCloseMessageBox("복사완료!", 1000, 3, 10);
			box.ShowDialog();
		}
	}
}
