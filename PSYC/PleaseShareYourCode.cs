using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using PleaseShareYourCode.PSYC;

namespace PleaseShareYouCode
{
    public partial class PSYC : Form
    {
        private string directoryPath;
        private bool bIsMouseDown = false;
        private bool bIsDragAndDrop = false;
        private List<string> files;
		private CombinedResultForm mCombineResultForm;
		private Settings mSettings;

        public PSYC()
        {
            InitializeComponent();
            Setup();
            files = new List<string>(64);
        }

        private void Setup()
        {
			mSettings = new Settings();
			mSettings.DeserializeSettings();

            switch (mSettings.Language)
            {
                case ELanguage.C:
                    r_BtnC.Checked = true;
                    break;
                case ELanguage.CPP:
                    r_BtnCPP.Checked = true;
                    break;
                case ELanguage.CS:
                    r_BtnCS.Checked = true;
                    break;
                case ELanguage.JAVA:
                   r_BtnJAVA.Checked = true;
                    break;
                case ELanguage.ASM:
                    r_BtnASM.Checked = true;
                    break;
            }

			switch (mSettings.Encoding)
			{
				case EEncoding.Default:
					r_BtnDefault.Checked = true;
					break;
				case EEncoding.UTF8:
					r_BtnUTF8.Checked = true;
					break;
				case EEncoding.ASCII:
					r_BtnASCII.Checked = true;
					break;
			}

			textBoxDivideLine.Text = mSettings.DivideLine;
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

            if (r_BtnCS.Checked)
            {
                files.AddRange(Directory.EnumerateFiles(directoryPath, "*.*", SearchOption.AllDirectories)
                    .Where(s => !s.EndsWith("Program.cs") && !s.EndsWith("AssemblyAttributes.cs") && !s.EndsWith("AssemblyInfo.cs") && s.EndsWith(".cs")));
            }
            else if (r_BtnJAVA.Checked)
            {
                files.AddRange(Directory.EnumerateFiles(directoryPath, "*.*", SearchOption.AllDirectories)
                    .Where(s => !s.EndsWith("Program.java") && !s.EndsWith("App.java") && !s.EndsWith("Registry.java") && !s.EndsWith("Interface.java") && !s.EndsWith("InterfaceKey.java") && s.EndsWith(".java")));
            }
            else if (r_BtnC.Checked)
            {
                files.AddRange(Directory.EnumerateFiles(directoryPath, "*.*", SearchOption.AllDirectories)
                    .Where(s => s.EndsWith(".h") || s.EndsWith(".c") && !s.EndsWith("main.c")));
                ReorderHeader(files);
            }
            else if (r_BtnCPP.Checked)
            {
                files.AddRange(Directory.EnumerateFiles(directoryPath, "*.*", SearchOption.AllDirectories)
                    .Where(s => s.EndsWith(".h") || s.EndsWith(".cpp") && !s.EndsWith("main.cpp")));
                ReorderHeader(files);
            }
            else
            {
                files.AddRange(Directory.EnumerateFiles(directoryPath, "*.*", SearchOption.AllDirectories)
                    .Where(s => !s.EndsWith("utils.asm") && !s.EndsWith("_main.asm") && s.EndsWith(".asm") || s.EndsWith(".inc")));
            }

            if (files.Count == 0)
            {
                MessageBox.Show("해당 언어로 파일을 찾을 수 없습니다.", "Message");
                folderBrowserDialog1.SelectedPath = "";
                return;
            }

            labelProject.Text = directoryPath.Split('\\').Last();
            CbFileList.Items.Clear();
            BtnCombine.Enabled = true;
            folderBrowserDialog1.SelectedPath = "";

            foreach (string f in files)
            {
                string fileName = f.Split('\\').Last();

                CbFileList.Items.Add(fileName, true);
            }
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
            r_BtnCS.Checked = true;
            SetDefaultLanguage(ELanguage.CS);
            MessageBox.Show("기본 언어가 C#로 설정되었습니다.", "Message");
        }

        private void SetDefaultLanguageJava_Click(object sender, EventArgs e)
        {
            r_BtnJAVA.Checked = true;
            SetDefaultLanguage(ELanguage.JAVA);
            MessageBox.Show("기본 언어가 Java로 설정되었습니다.", "Message");
        }

        private void SetDefaultLanguageC_Click(object sender, EventArgs e)
        {
            r_BtnC.Checked = true;
            SetDefaultLanguage(ELanguage.C);
            MessageBox.Show("기본 언어가 C로 설정되었습니다.", "Message");
        }

        private void SetDefaultLanguageCpp_Click(object sender, EventArgs e)
        {
            r_BtnCPP.Checked = true;
            SetDefaultLanguage(ELanguage.CPP);
            MessageBox.Show("기본 언어가 C++로 설정되었습니다.", "Message");
        }

        private void SetDefaultLanguageAsm_Click(object sender, EventArgs e)
        {
            r_BtnASM.Checked = true;
            SetDefaultLanguage(ELanguage.ASM);
            MessageBox.Show("기본 언어가 Assembly로 설정되었습니다.", "Message");
        }

        private void SetDefaultLanguage(ELanguage language)
        {
            string settingPath = Directory.GetCurrentDirectory() + "\\" + "setting.txt";
            string defaultLanguage = "";

            switch (language)
            {
                case ELanguage.CS:
                    defaultLanguage = "Language=cs";
                    break;
                case ELanguage.JAVA:
                    defaultLanguage = "Language=java";
                    break;
                case ELanguage.C:
                    defaultLanguage = "Language=c";
                    break;
                case ELanguage.CPP:
                    defaultLanguage = "Language=cpp";
                    break;
                case ELanguage.ASM:
                    defaultLanguage = "Language=asm";
                    break;
                default:
                    Debug.Assert(false , "Unknown language");
                    break;
            }

            using (StreamWriter writer = new StreamWriter(File.Open(settingPath, FileMode.Truncate))) 
            {
                writer.WriteLine(defaultLanguage);
            }
        }

        private void ReorderHeader(List<string> files)
        {
            for (int i = 0; i < files.Count - 1; i++)
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
        }

		private void BtnCombine_Click(object sender, EventArgs e)
		{
			if (CbFileList.CheckedItems.Count == 0)
			{
				MessageBox.Show("선택된 파일이 없습니다!");
				return;
			}

			BtnCombine.Enabled = false;
			StringBuilder sbFilePath = new StringBuilder(256);
			StringBuilder sbComment = new StringBuilder(256);
			StringBuilder combinedCode = new StringBuilder(16384);
			List<string> failFiles = new List<string>(CbFileList.Items.Count);

			const string DIVIDING_LINE = "----------------------";
			string commentStartStr = r_BtnASM.Checked ? ";" : "//";

			for (int i = 0; i < CbFileList.Items.Count; ++i)
			{
				if (CbFileList.GetItemChecked(i) == true)
				{
					string fileName = CbFileList.Items[i].ToString();

					sbComment.Clear();
					sbFilePath.Clear();

					sbComment.Append(commentStartStr).Append(DIVIDING_LINE).Append(fileName).Append(DIVIDING_LINE);
					sbFilePath.Append(files.Find(f => f.EndsWith(fileName)));

					try
					{
						using (StreamReader reader = new StreamReader(File.Open(sbFilePath.ToString(), FileMode.Open), Encoding.Default))
						{
							combinedCode.AppendLine(sbComment.ToString());
							combinedCode.AppendLine();
							var a = reader.CurrentEncoding;

							while (!reader.EndOfStream)
							{
								string line = reader.ReadLine();
								combinedCode.AppendLine(line);
							}

							combinedCode.AppendLine();
							combinedCode.AppendLine();
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

			//CbFileList.Items.Clear();
			//labelProject.Text = "";

			mCombineResultForm = new CombinedResultForm(combinedCode.ToString());
			mCombineResultForm.ShowDialog();
		}

		private void r_BtnLanguage_CheckedChanged(object sender, EventArgs e)
		{
			if (r_BtnC.Checked)
			{
				mSettings.Language = ELanguage.C;
			}
			else if (r_BtnCPP.Checked)
			{
				mSettings.Language = ELanguage.CPP;
			}
			else if (r_BtnCS.Checked)
			{
				mSettings.Language = ELanguage.CS;
			}
			else if (r_BtnJAVA.Checked)
			{
				mSettings.Language = ELanguage.JAVA;
			}
			else if (r_BtnASM.Checked)
			{
				mSettings.Language = ELanguage.ASM;
			}

			mSettings.SerializeSettings();
		}

		private void r_BtnEncoding_CheckedChanged(object sender, EventArgs e)
		{
			if (r_BtnDefault.Checked)
			{
				mSettings.Encoding = EEncoding.Default;
			}
			else if (r_BtnUTF8.Checked)
			{
				mSettings.Encoding = EEncoding.UTF8;
			}
			else if (r_BtnASCII.Checked)
			{
				mSettings.Encoding = EEncoding.ASCII;
			}

			mSettings.SerializeSettings();
		}

		private void textBoxDivideLine_TextChanged(object sender, EventArgs e)
		{
			string divideLine = textBoxDivideLine.Text;
			string final = "";
			string fileName = "Test.cpp";
			string nameVar = "%name";

			if (divideLine.Contains("%name"))
			{
				final = divideLine.Replace(nameVar, fileName);
			}
			else
			{
				final = divideLine + fileName;
			}

			final = "//" + final;
			labelDivideLine.Text = final;
			toolTip1.SetToolTip(labelDivideLine, final);

			mSettings.DivideLine = divideLine;
			mSettings.SerializeSettings();
		}

		private void BtnHelp_Click(object sender, EventArgs e)
		{

		}
	}
}
