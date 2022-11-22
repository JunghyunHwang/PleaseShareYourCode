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
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.CompilerServices;

namespace PleaseShareYouCode
{
    public partial class PSYC : Form
    {
        private string directoryPath;
        private bool bIsMouseDown = false;
        private bool bIsDragAndDrop = false;

        public PSYC()
        {
            InitializeComponent();
#if DEBUG
            //SetFileList();
#endif
        }

        private string[] GetFilesOrNull()
        {
            List<string> allFiles = new List<string>(64);
            string[] extensions = new string[2];
            string ignoreFileName;
            StringBuilder path = new StringBuilder();
            bool bHasHeaderFile = false;

            path.Append(directoryPath);

            if (r_btnCS.Checked == true)
            {
                extensions[0] = "cs";
                path.Append("\\").Append(directoryPath.Split('\\').Last());
                ignoreFileName = "Program.cs";
            }
            else if (r_btnJAVA.Checked == true)
            {
                extensions[0] = "java";
                path.Append("\\").Append("src\\academy\\pocu\\comp2500\\").Append(directoryPath.Split('\\').Last().ToLower());
                ignoreFileName = "Program.java";
            }
            else if (r_btnC.Checked == true)
            {
                extensions[0] = "h";
                extensions[1] = "c";
                ignoreFileName = "main.c";
                bHasHeaderFile = true;
            }
            else
            {
                extensions[0] = "h";
                extensions[1] = "cpp";
                ignoreFileName = "main.cpp";
                bHasHeaderFile = true;
            }

            directoryPath = path.ToString();

            try
            {
                allFiles.AddRange(Directory.GetFiles(directoryPath));
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("해당 언어의 파일을 찾을 수 없거나 폴더가 비어있습니다.", "Message");
                return null;
            }

            foreach (var file in allFiles)
            {
                string fileName = file.Split('\\').Last();

                if (fileName == ignoreFileName)
                {
                    allFiles.Remove(file);
                    break;
                }
            }

            string[] result = allFiles.Where(f => extensions.Contains(f.Split('.').Last())).ToArray();

            if (result.Length == 0)
            {
                MessageBox.Show("해당 언어의 파일을 찾을 수 없거나 폴더가 비어있습니다.", "Message");
                return result;
            }

            if (bHasHeaderFile)
            {
                for (int i = 0; i < result.Length - 1; i++)
                {
                    string fileName = result[i].Split('.').First();
                    string nextFileName = result[i + 1].Split('.').First();

                    if (fileName == nextFileName)
                    {
                        string temp = result[i];
                        result[i] = result[i + 1];
                        result[i + 1] = temp;
                    }
                }
            }

            return result;
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();

            if (folderBrowserDialog1.SelectedPath == "")
            {
                return;
            }

            directoryPath = folderBrowserDialog1.SelectedPath;
            labelProject.Text = "";

            string[] files = GetFilesOrNull();

            if (files == null || files.Length == 0)
            {
                return;
            }

            labelProject.Text = directoryPath.Split('\\').Last();
            CbFileList.Items.Clear();
            BtnExport.Enabled = true;

            foreach (string f in files)
            {
                string fileName = f.Split('\\').Last();

                CbFileList.Items.Add(fileName, true);
            }
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "|*.txt";
            saveFileDialog1.Title = "Save";
            saveFileDialog1.FileName = labelProject.Text;

            if (CbFileList.CheckedItems.Count == 0)
            {
                MessageBox.Show("선택된 파일이 없습니다!");
                return;
            }
            else if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
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

            if (failFiles.Count > 0)
            {
                StringBuilder resultMessage = new StringBuilder(256);

                resultMessage.Append("실패한 파일 개수: ");
                resultMessage.AppendLine(failFiles.Count.ToString());

                var fail = failFiles.ToArray();

                for (uint i = 0; i < failFiles.Count; ++i)
                {
                    resultMessage.AppendLine(fail[i]);
                }

                MessageBox.Show(resultMessage.ToString(), "Message");
            }
            else
            {
                MessageBox.Show("추출 완료!", "Message");
                System.Diagnostics.Process.Start(saveFileDialog1.FileName);
            }


            CbFileList.Items.Clear();
            BtnExport.Enabled = false;
            labelProject.Text = "";
        }

#if DEBUG
        private void SetFileList()
        {
            directoryPath = "C:\\Users\\dmagk\\Desktop\\Ja_Hwang\\POCU\\C++\\Assignment2";
            labelProject.Text = directoryPath.Split('\\').Last();

            List<string> extensions = new List<string> { "h", "cpp" };

            string[] filesPath = GetFilesOrNull();

            if (filesPath.Length == 0)
            {
                return;
            }

            // Change order .h .cpp
            for (int i = 0; i < filesPath.Length - 1; ++i)
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
#endif

        private void CbFileList_MouseDown(object sender, MouseEventArgs e)
        {
            bIsMouseDown = true;
        }

        private void CbFileList_MouseUp(object sender, MouseEventArgs e)
        {
            bIsMouseDown = false;
            bIsDragAndDrop = false;
        }

        private void CbFileList_MouseMove(object sender, MouseEventArgs e)
        {
            if (CbFileList.SelectedItem == null)
            {
                return;
            }
            else if (!bIsMouseDown || bIsDragAndDrop)
            {
                return;
            }

            int index = CbFileList.IndexFromPoint(e.X, e.Y);

            if (index < 0)
            {
                index = CbFileList.Items.Count - 1;
            }

            string item = CbFileList.Items[index].ToString();
            bIsDragAndDrop = true;

            CbFileList.DoDragDrop(item, DragDropEffects.Move);
        }

        private void CbFileList_DragDrop(object sender, DragEventArgs e)
        {
            Point point = CbFileList.PointToClient(new Point(e.X , e.Y));
            point.Y = point.Y < 0 ? 0 : point.Y;

            int newIndex = CbFileList.IndexFromPoint(point);

            object data = e.Data.GetData(typeof(string));
            bool bIsChecked = CbFileList.GetItemChecked(CbFileList.SelectedIndex);

            newIndex = newIndex < 0 ? 0 : newIndex;

            CbFileList.Items.Remove(data);
            CbFileList.Items.Insert(newIndex, data);
            CbFileList.SetItemChecked(newIndex, bIsChecked);
            bIsDragAndDrop = false;
        }

        private void CbFileList_DragOver(object sender, DragEventArgs e)
        {
            Console.WriteLine("Start DragOver");
            e.Effect = DragDropEffects.Move;
        }
    }
}
