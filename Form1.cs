using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PleaseShareYouCode
{
    public partial class PSYC : Form
    {
        public PSYC()
        {
            InitializeComponent();
        }

        private string[] GetFilePath(string path, List<string> extensions)
        {
            string[] allFiles = Directory.GetFiles(path);
            return allFiles.Where(f => extensions.Contains(f.Split('.').Last())).ToArray();
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            List<string> extensions = new List<string> { "h", "cpp" };

            string[] files = GetFilePath(folderBrowserDialog1.SelectedPath, extensions);
            CbFileList.Items.Clear();

            foreach (string file in files)
            {
                CbFileList.Items.Add(file.Split('\\').Last(), true);
            }
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();

            for (int i = 0; i < CbFileList.Items.Count; ++i)
            {
                if (CbFileList.GetItemChecked(i) == true)
                {
                    string s = CbFileList.Items[i].ToString();
                    Console.WriteLine(s);
                }
            }
        }
    }
}
