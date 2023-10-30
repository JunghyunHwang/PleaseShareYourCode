using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace PleaseShareYouCode
{
    struct FileInfo
    {
        public string fileName;
        public string path;
    };
    public partial class PSYC : Form
    {
        private string directoryPath;
        private bool bIsMouseDown = false;
        private bool bIsDragAndDrop = false;
        private List<FileInfo> files;

        enum eLanguage
        {
            CS,
            JAVA,
            C,
            CPP,
            ASM
        }

        public PSYC()
        {
            InitializeComponent();
            Setup();
            files = new List<FileInfo>(64);
        }

        private void Setup()
        {
            string settingPath = Directory.GetCurrentDirectory() + "\\" + "setting.txt";
            string[] lines = File.ReadAllLines(settingPath);
            string languageSetting = lines[0].Split('=').Last();

            switch (languageSetting)
            {
                case "cs":
                    r_btnCS.Checked = true;
                    break;
                case "java":
                   r_btnJAVA.Checked = true;
                    break;
                case "c":
                    r_btnC.Checked = true;
                    break;
                case "cpp":
                    r_btnCPP.Checked = true;
                    break;
                case "asm":
                    r_btnAsm.Checked = true;
                    break;
                default:
                    Debug.Assert(false, "Unknown language");
                    break;
            }
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

            files.Clear();
            List<string> filePaths;

            if (r_btnCS.Checked)
            {
                filePaths = Directory.EnumerateFiles(directoryPath, "*.*", SearchOption.AllDirectories)
                    .Where(s => !s.EndsWith("Program.cs") 
                        && !s.EndsWith("AssemblyAttributes.cs") 
                        && !s.EndsWith("AssemblyInfo.cs") 
                        && s.EndsWith(".cs"))
                    .ToList();
            }
            else if (r_btnJAVA.Checked)
            {
                filePaths = Directory.EnumerateFiles(directoryPath, "*.*", SearchOption.AllDirectories)
                    .Where(s => !s.EndsWith("Program.java") 
                        && !s.EndsWith("App.java") 
                        && !s.EndsWith("Registry.java") 
                        && !s.EndsWith("Interface.java") 
                        && !s.EndsWith("InterfaceKey.java") 
                        && s.EndsWith(".java")) 
                    .ToList();
            }
            else if (r_btnC.Checked)
            {
                filePaths = Directory.EnumerateFiles(directoryPath, "*.*", SearchOption.AllDirectories)
                    .Where(s => s.EndsWith(".h") || s.EndsWith(".c") && !s.EndsWith("main.c")).ToList();
                reorderHeader(filePaths);
            }
            else if (r_btnCPP.Checked)
            {
                filePaths = Directory.EnumerateFiles(directoryPath, "*.*", SearchOption.AllDirectories)
                    .Where(s => s.EndsWith(".h") || s.EndsWith(".cpp") && !s.EndsWith("main.cpp")).ToList();
                reorderHeader(filePaths);
            }
            else
            {
                filePaths = Directory.EnumerateFiles(directoryPath, "*.*", SearchOption.AllDirectories)
                    .Where(s => !s.EndsWith("utils.asm") 
                        && !s.EndsWith("_main.asm") 
                        && s.EndsWith(".asm") || s.EndsWith(".inc"))
                    .ToList();
            }

            if (filePaths.Count == 0)
            {
                MessageBox.Show("해당 언어로 파일을 찾을 수 없습니다.", "Message");
                folderBrowserDialog1.SelectedPath = "";
                return;
            }

            labelProject.Text = directoryPath.Split('\\').Last();
            CbFileList.Items.Clear();
            BtnExport.Enabled = true;
            folderBrowserDialog1.SelectedPath = "";

            foreach (string path in filePaths)
            {
                string fileName = null;

                for (int i = path.Length - 1; i >= 0; --i)
                {
                    if (path[i] == '\\')
                    {
                        Debug.Assert(i + 1 < path.Length);
                        fileName = path.Substring(i + 1);
                        break;
                    }
                }

                Debug.Assert(fileName != null);

                FileInfo file;
                file.path = path;
                file.fileName = fileName;

                files.Add(file);

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

            BtnExport.Enabled = false;
            StringBuilder sbFilePath = new StringBuilder(256);
            StringBuilder sbComment = new StringBuilder(256);
            List<string> failFiles = new List<string>(CbFileList.Items.Count);

            const string DIVIDING_LINE = "----------------------";
            StreamWriter writer = new StreamWriter(File.Open(saveFileDialog1.FileName, FileMode.Create));
            string commentStartStr = r_btnAsm.Checked ? ";" : "//";

            for (int i = 0; i < CbFileList.Items.Count; ++i)
            {
                if (CbFileList.GetItemChecked(i))
                {
                    string fileName = CbFileList.Items[i].ToString();
                    
                    sbComment.Clear();
                    sbFilePath.Clear();

                    sbComment.Append(commentStartStr).Append(DIVIDING_LINE).Append(fileName).Append(DIVIDING_LINE);
                    sbFilePath.Append(files.Find(f => f.fileName == fileName).path);

                    try
                    {
                        using (StreamReader reader = new StreamReader(File.Open(sbFilePath.ToString(), FileMode.Open)))
                        {
                            writer.WriteLine(sbComment.ToString());
                            writer.WriteLine();

                            while (!reader.EndOfStream)
                            {
                                writer.WriteLine(reader.ReadLine());
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

            writer.Close();

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
                Process.Start(saveFileDialog1.FileName);
            }

            CbFileList.Items.Clear();
            labelProject.Text = "";
        }

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

        private void SetDefaultLanguageCS_Click(object sender, EventArgs e)
        {
            r_btnCS.Checked = true;
            SetDefaultLanguage(eLanguage.CS);
            MessageBox.Show("기본 언어가 C#로 설정되었습니다.", "Message");
        }

        private void SetDefaultLanguageJava_Click(object sender, EventArgs e)
        {
            r_btnJAVA.Checked = true;
            SetDefaultLanguage(eLanguage.JAVA);
            MessageBox.Show("기본 언어가 Java로 설정되었습니다.", "Message");
        }

        private void SetDefaultLanguageC_Click(object sender, EventArgs e)
        {
            r_btnC.Checked = true;
            SetDefaultLanguage(eLanguage.C);
            MessageBox.Show("기본 언어가 C로 설정되었습니다.", "Message");
        }

        private void SetDefaultLanguageCpp_Click(object sender, EventArgs e)
        {
            r_btnCPP.Checked = true;
            SetDefaultLanguage(eLanguage.CPP);
            MessageBox.Show("기본 언어가 C++로 설정되었습니다.", "Message");
        }

        private void SetDefaultLanguageAsm_Click(object sender, EventArgs e)
        {
            r_btnAsm.Checked = true;
            SetDefaultLanguage(eLanguage.ASM);
            MessageBox.Show("기본 언어가 Assembly로 설정되었습니다.", "Message");
        }

        private void SetDefaultLanguage(eLanguage language)
        {
            string settingPath = Directory.GetCurrentDirectory() + "\\" + "setting.txt";
            string defaultLanguage;

            switch (language)
            {
                case eLanguage.CS:
                    defaultLanguage = "Language=cs";
                    break;
                case eLanguage.JAVA:
                    defaultLanguage = "Language=java";
                    break;
                case eLanguage.C:
                    defaultLanguage = "Language=c";
                    break;
                case eLanguage.CPP:
                    defaultLanguage = "Language=cpp";
                    break;
                case eLanguage.ASM:
                    defaultLanguage = "Language=asm";
                    break;
                default:
                    Debug.Assert(false , "Unknown language");
                    return;
            }

            using (StreamWriter writer = new StreamWriter(File.Open(settingPath, FileMode.Truncate))) 
            {
                writer.WriteLine(defaultLanguage);
            }
        }

        private void reorderHeader(List<string> filePaths)
        {
            for (int i = 0; i < filePaths.Count - 1; ++i)
            {
                string fileName = null;
                string nextFileName = null;

                for (int j = filePaths[i].Length - 1; j >= 0; --j)
                {
                    if (filePaths[i][j] == '.')
                    {
                        Debug.Assert(j != 0);
                        fileName = filePaths[i].Substring(0, j);
                    }
                }

                for (int j = filePaths[i + 1].Length - 1; j >= 0; --j)
                {
                    if (filePaths[i + 1][j] == '.')
                    {
                        Debug.Assert(j != 0);
                        nextFileName = filePaths[i + 1].Substring(0, j);
                    }
                }

                Debug.Assert(fileName != null);
                Debug.Assert(nextFileName != null);

                if (fileName == nextFileName)
                {
                    string temp = filePaths[i];
                    filePaths[i] = filePaths[i + 1];
                    filePaths[i + 1] = temp;
                    ++i;
                }
            }
        }
    }
}
