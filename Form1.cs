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
        private string directoryPath;

        public PSYC()
        {
            InitializeComponent();
        }

        private string[] GetFilePaths(string path, List<string> extensions)
        {
            string[] allFiles = Directory.GetFiles(path);
            return allFiles.Where(f => extensions.Contains(f.Split('.').Last())).ToArray();
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();

            if (folderBrowserDialog1.SelectedPath == "")
            {
                return;
            }

            directoryPath = folderBrowserDialog1.SelectedPath;
            List<string> extensions = new List<string> { "h", "cpp" };

            string[] files = GetFilePaths(directoryPath, extensions);

            if (files.Length == 0)
            {
                return;
            }

            // Change order .h .cpp
            for (int i = 0; i < files.Length - 1; i++)
            {
                string fileName = files[i].Split('.').First();
                string nextFileName = files[i + 1].Split('.').First();

                if (fileName == nextFileName)
                {
                    string temp = files[i];
                    files[i] = files[i + 1];
                    files[i + 1] = temp;
                }
            }

            CbFileList.Items.Clear();
            BtnExport.Enabled = true;

            foreach (string file in files)
            {
                string fileName = file.Split('\\').Last();

                if (fileName == "main.cpp" || fileName == "Main.cpp")
                {
                    continue;
                }

                CbFileList.Items.Add(fileName, true);
            }
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "|*.txt";
            saveFileDialog1.Title = "Save";

            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            StringBuilder sbFilePath = new StringBuilder(256);
            StringBuilder sbComment = new StringBuilder(256);
            const string DIVIDING_LINE = "----------------------";

            for (int i = 0; i < CbFileList.Items.Count; ++i)
            {
                if (CbFileList.GetItemChecked(i) == true)
                {
                    string fileName = CbFileList.Items[i].ToString();

                    sbComment.Append("//").Append(DIVIDING_LINE).Append(fileName).Append(DIVIDING_LINE);
                    sbFilePath.Append(directoryPath).Append('\\').Append(fileName);

                    using (StreamReader reader = new StreamReader(File.Open(sbFilePath.ToString(), FileMode.Open)))
                    using (StreamWriter writer = new StreamWriter(File.Open(saveFileDialog1.FileName, FileMode.Append)))
                    {
                        writer.WriteLine(sbComment.ToString());
                        writer.WriteLine();

                        while (!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();

                            if (line.Length > 0 && line[0] == '#')
                            {
                                continue;
                            }

                            writer.WriteLine(line);
                        }

                        writer.WriteLine();
                        writer.WriteLine();
                    }
                }

                sbComment.Clear();
                sbFilePath.Clear();
            }

            MessageBox.Show("추출 완료!");
            BtnExport.Enabled = false;
        }
    }
}
