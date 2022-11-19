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
using PleaseShareYourCode.PSYC;

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
            SetFileList();
#endif
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
            TbTitle.Text = directoryPath.Split('\\').Last();

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
            saveFileDialog1.FileName = TbTitle.Text;

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
                MessageBox.Show("추출 완료!");
            }


            CbFileList.Items.Clear();
            BtnExport.Enabled = false;
            TbTitle.Text = "";
        }

#if DEBUG
        private void PrintMouseHandle()
        {
            Console.WriteLine($"Mouse down: {bIsMouseDown}");
            Console.WriteLine($"Drag and drop down: {bIsDragAndDrop}");
        }
#endif

#if DEBUG
        private void SetFileList()
        {
            directoryPath = "C:\\Users\\dmagk\\Desktop\\Ja_Hwang\\POCU\\C++\\Assignment2";
            TbTitle.Text = directoryPath.Split('\\').Last();
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
#endif

        private void CbFileList_MouseDown(object sender, MouseEventArgs e)
        {
#if DEBUG
            Console.WriteLine("Start down");
            PrintMouseHandle();
#endif
            bIsMouseDown = true;
        }

        private void CbFileList_MouseUp(object sender, MouseEventArgs e)
        {
#if DEBUG
            Console.WriteLine("Start up");
            PrintMouseHandle();
#endif
            bIsMouseDown = false;
            bIsDragAndDrop = false;
        }

        private void CbFileList_MouseMove(object sender, MouseEventArgs e)
        {
#if DEBUG
            Console.WriteLine("Start move");
            PrintMouseHandle();
#endif
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
#if DEBUG
            Console.WriteLine("Start drag drop");
            PrintMouseHandle();
#endif
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
