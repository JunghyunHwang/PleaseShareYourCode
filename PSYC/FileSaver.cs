using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PleaseShareYourCode.PSYC
{
	internal class FileSaver
	{
		private static SaveFileDialog mSaveFileDialog;
		
		public static void InitFileSaver()
		{
			mSaveFileDialog = new SaveFileDialog()
			{
				InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
				Filter = "Text Files|*.txt",
				DefaultExt = "txt"
			};
		}

		public static void SaveCodeToTextFile(string text)
		{
			if (mSaveFileDialog == null)
			{
				InitFileSaver();
			}

			if (mSaveFileDialog.ShowDialog() != DialogResult.OK) return;

			Stream stream = mSaveFileDialog.OpenFile();
			using (StreamWriter sw = new StreamWriter(stream, Encoding.UTF8))
			{
				sw.Write(text);
			}
		}
	}
}
