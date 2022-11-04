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
using PleaseShareYourCode;

namespace PleaseShareYouCode
{
    public partial class PSYC : Form
    {
        private string directoryPath;

        public PSYC()
        {
            InitializeComponent();
        }

        private string[] GetFilesPath(string path, List<string> extensions)
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

            string[] filesPath = GetFilesPath(directoryPath, extensions);

            if (filesPath.Length == 0)
            {
                return;
            }

            // Change order .h .cpp
            for (int i = 0; i < filesPath.Length - 1; i++)
            {
                string fileName = filesPath[i].Split('.').First();
                string nextFileName = filesPath[i + 1].Split('.').First();

                if (fileName == nextFileName)
                {
                    string temp = filesPath[i];
                    filesPath[i] = filesPath[i + 1];
                    filesPath[i + 1] = temp;
                }
            }

            CbFileList.Items.Clear();
            BtnExport.Enabled = true;

            foreach (string file in filesPath)
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
            List<string> failFiles = new List<string>(CbFileList.Items.Count);

            const string DIVIDING_LINE = "----------------------";

            for (int i = 0; i < CbFileList.Items.Count; ++i)
            {
                if (CbFileList.GetItemChecked(i) == true)
                {
                    string fileName = CbFileList.Items[i].ToString();

                    sbComment.Clear();
                    sbFilePath.Clear();

                    sbComment.Append("//").Append(DIVIDING_LINE).Append(fileName).Append(DIVIDING_LINE);
                    sbFilePath.Append(directoryPath).Append('\\').Append(fileName);

                    try
                    {
                        using (StreamReader reader = new StreamReader(File.Open(sbFilePath.ToString(), FileMode.Open)))
                        using (StreamWriter writer = new StreamWriter(File.Open(saveFileDialog1.FileName, FileMode.Append)))
                        {
                            writer.WriteLine(sbComment.ToString());
                            writer.WriteLine();

                            while (!reader.EndOfStream)
                            {
                                string line = reader.ReadLine();

                                writer.WriteLine(line);
                            }

                            writer.WriteLine();
                            writer.WriteLine();
                        }
                    }
                    catch (FileNotFoundException)
                    {
                        failFiles.Add(fileName);
                        continue;
                    }
                }
            }

            StringBuilder resultMessage = new StringBuilder(256);

            if (failFiles.Count == 0)
            {
                resultMessage.AppendLine("실패한 파일 없음");
            }
            else
            {
                resultMessage.Append("실패한 파일 개수: ");
                resultMessage.AppendLine(failFiles.Count.ToString());
            }

            var fail = failFiles.ToArray();

            for (uint i = 0; i < failFiles.Count; ++i)
            {
                resultMessage.AppendLine(fail[i]);
            }

            resultMessage.AppendLine();
            resultMessage.Append("추출 완료!");

            MessageBox.Show(resultMessage.ToString(), "Message");
            BtnExport.Enabled = false;
        }
    }
}
