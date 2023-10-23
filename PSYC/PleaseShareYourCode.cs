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
        private string mDirectoryPath;
        private bool mbIsMouseDown = false;
        private bool mbIsDragAndDrop = false;
        private List<string> mFiles;
		private CombinedResultForm mCombineResultForm;
		static private Settings mSettings;
        static private HelpForm mHelpForm;
        private const string VAR_NAME = "%name";

        public PSYC()
        {
            InitializeComponent();
            Initialize();
            mFiles = new List<string>(64);
        }

        private void Initialize()
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

            labelProject.Text = "";
            textBoxSeparator.Text = mSettings.Separator;
		}

        private void CbFileList_MouseDown(object sender, MouseEventArgs e)
        {
            mbIsMouseDown = true;
        }

        private void CbFileList_MouseUp(object sender, MouseEventArgs e)
        {
            mbIsMouseDown = false;
            mbIsDragAndDrop = false;
        }

        private void CbFileList_MouseMove(object sender, MouseEventArgs e)
        {
            if (CbFileList.SelectedItem == null)
            {
                return;
            }
            else if (!mbIsMouseDown || mbIsDragAndDrop)
            {
                return;
            }

            int index = CbFileList.IndexFromPoint(e.X, e.Y);

            if (index < 0)
            {
                index = CbFileList.Items.Count - 1;
            }

            string item = CbFileList.Items[index].ToString();
            mbIsDragAndDrop = true;

            CbFileList.DoDragDrop(item, DragDropEffects.Move);
        }

        private void CbFileList_DragDrop(object sender, DragEventArgs e)
        {
            Point point = CbFileList.PointToClient(new Point(e.X, e.Y));
            point.Y = point.Y < 0 ? 0 : point.Y;

            int newIndex = CbFileList.IndexFromPoint(point);

            object data = e.Data.GetData(typeof(string));
            bool bIsChecked = CbFileList.GetItemChecked(CbFileList.SelectedIndex);

            newIndex = newIndex < 0 ? 0 : newIndex;

            CbFileList.Items.Remove(data);
            CbFileList.Items.Insert(newIndex, data);
            CbFileList.SetItemChecked(newIndex, bIsChecked);
            mbIsDragAndDrop = false;
        }

        private void CbFileList_DragOver(object sender, DragEventArgs e)
        {
            Console.WriteLine("Start DragOver");
            e.Effect = DragDropEffects.Move;
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

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog browser = new FolderBrowserDialog()
            {
                SelectedPath = mSettings.LastFolderPath
            };

			if (browser.ShowDialog() != DialogResult.OK) return;
			if (browser.SelectedPath == "") return;

            mDirectoryPath = browser.SelectedPath;
            labelProject.Text = "";

            mFiles.Clear();

            if (r_BtnCS.Checked)
            {
                mFiles.AddRange(Directory.EnumerateFiles(mDirectoryPath, "*.*", SearchOption.AllDirectories)
                    .Where(s => !s.EndsWith("Program.cs") && !s.EndsWith("AssemblyAttributes.cs") && !s.EndsWith("AssemblyInfo.cs") && s.EndsWith(".cs")));
            }
            else if (r_BtnJAVA.Checked)
            {
                mFiles.AddRange(Directory.EnumerateFiles(mDirectoryPath, "*.*", SearchOption.AllDirectories)
                    .Where(s => !s.EndsWith("Program.java") && !s.EndsWith("App.java") && !s.EndsWith("Registry.java") && !s.EndsWith("Interface.java") && !s.EndsWith("InterfaceKey.java") && s.EndsWith(".java")));
            }
            else if (r_BtnC.Checked)
            {
                mFiles.AddRange(Directory.EnumerateFiles(mDirectoryPath, "*.*", SearchOption.AllDirectories)
                    .Where(s => s.EndsWith(".h") || s.EndsWith(".c") && !s.EndsWith("main.c")));
                ReorderHeader(mFiles);
            }
            else if (r_BtnCPP.Checked)
            {
                mFiles.AddRange(Directory.EnumerateFiles(mDirectoryPath, "*.*", SearchOption.AllDirectories)
                    .Where(s => s.EndsWith(".h") || s.EndsWith(".cpp") && !s.EndsWith("main.cpp")));
                ReorderHeader(mFiles);
            }
            else if (r_BtnASM.Checked)
            {
                mFiles.AddRange(Directory.EnumerateFiles(mDirectoryPath, "*.*", SearchOption.AllDirectories)
                    .Where(s => !s.EndsWith("utils.asm") && !s.EndsWith("_main.asm") && s.EndsWith(".asm") || s.EndsWith(".inc")));
            }

            if (mFiles.Count == 0)
            {
                MessageBox.Show("해당 언어로 파일을 찾을 수 없습니다.", "Message");
                browser.SelectedPath = "";
                return;
            }

            labelProject.Text = mDirectoryPath.Split('\\').Last();
            CbFileList.Items.Clear();

            foreach (string f in mFiles)
            {
                string fileName = f.Split('\\').Last();

                CbFileList.Items.Add(fileName, true);
            }

            if (CbFileList.Items.Count != 0)
            {
                BtnCombine.Enabled = true;
            }

            mSettings.LastFolderPath = browser.SelectedPath;
            mSettings.SerializeSettings();
        }

		private void BtnCombine_Click(object sender, EventArgs e)
		{
            if (CbFileList.Items.Count == 0)
            {
                BtnCombine.Enabled = false;
                MessageBox.Show("선택된 파일이 없습니다!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

			if (CbFileList.CheckedItems.Count == 0)
			{
                MessageBox.Show("선택된 파일이 없습니다!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
			}

			StringBuilder combinedCode = new StringBuilder(16384);
			List<string> failFiles = new List<string>(CbFileList.Items.Count);

			string commentStartStr = r_BtnASM.Checked ? ";" : "//";

			for (int i = 0; i < CbFileList.Items.Count; ++i)
			{
				if (CbFileList.GetItemChecked(i) == true)
				{
					string fileName = CbFileList.Items[i].ToString();

                    string comment = BuildSeparator(textBoxSeparator.Text, fileName);
                    string sbComment = commentStartStr + comment;

                    //string sbFilePath = mFiles.Find(f => f.EndsWith(fileName)); //bug
                    string sbFilePath = mFiles.Find(f => f.Split('\\').Last() == fileName);

                    Encoding encoding = null;
                    switch (mSettings.Encoding)
                    {
                        case EEncoding.Default:
                            encoding = Encoding.Default;
                            break;
                        case EEncoding.UTF8:
                            encoding = Encoding.UTF8;
                            break;
                        case EEncoding.ASCII:
                            encoding = Encoding.ASCII;
                            break;
                    }

					try
					{
                        Debug.Assert(sbFilePath != null);
						using (StreamReader reader = new StreamReader(File.Open(sbFilePath, FileMode.Open), encoding))
						{
                            Debug.WriteLine(reader.CurrentEncoding);
							combinedCode.AppendLine(sbComment);
                            combinedCode.AppendLine();

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

			mCombineResultForm = new CombinedResultForm(combinedCode.ToString(), labelProject.Text);
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

		private void TextBoxSeparator_TextChanged(object sender, EventArgs e)
		{
			string fileName = "Test.cpp";
            string final = BuildSeparator(textBoxSeparator.Text, fileName);

			final = "//" + final;
			labelSeparator.Text = final;
			toolTip1.SetToolTip(labelSeparator, final);

			mSettings.Separator = textBoxSeparator.Text;
			mSettings.SerializeSettings();
		}

        private string BuildSeparator(string separator, string fileName)
        {
            string final = "";

            if (separator.Contains(VAR_NAME))
            {
                final = separator.Replace(VAR_NAME, fileName);
            }
            else
            {
                final = separator + fileName;
            }

            return final;
        }

		private void BtnHelp_Click(object sender, EventArgs e)
		{
            if (mHelpForm == null)
            {
                mHelpForm = new HelpForm();
            }

            mHelpForm.Show(this);
		}
	}
}
