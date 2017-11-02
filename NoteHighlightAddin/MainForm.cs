using GenerateHighlightContent;
using Helper;
using ICSharpCode.TextEditor.Document;
using NoteHighLightForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteHighlightAddin
{
    public partial class MainForm : Form
    {
        #region -- Field and Property --
        private const string span = "</span>";

        //檔案類型
        private string _codeType;

        //檔案名稱
        private string _fileName;

        private HighLightParameter _parameters;

        //要HighLight的Code
        private string CodeContent { get { return this.txtCode.Text; } }

        //HighLight的樣式
        private string CodeStyle { get { return this.cbx_style.Text; } }

        //是否要行號
        private bool IsShowLineNumber { get { return this.cbx_lineNumber.Checked; } }

        //是否存到剪貼簿
        private bool IsClipboard { get { return this.cbx_Clipboard.Checked; } }

        private Color BackgroundColor { get { return this.btnBackground.BackColor; } }

        public HighLightParameter Parameters { get { return _parameters; } }

        #endregion

        #region -- Constructor --

        public MainForm(string codeType, string fileName, string selectedText)
        {
            _codeType = codeType;
            _fileName = fileName;
            InitializeComponent();
            LoadThemes();
            txtCode.Text = selectedText;

        }

        private void LoadThemes()
        {
            try
            {
                Configuration c = ConfigurationManager.OpenExeConfiguration(Assembly.GetCallingAssembly().Location);
                HighLightSection section = c.GetSection("HighLightSection") as HighLightSection;

                var workingDirectory = Path.Combine(ProcessHelper.GetDirectoryFromPath(Assembly.GetCallingAssembly().Location), section.FolderName, section.ThemeFolder);

                string[] files = Directory.GetFiles(workingDirectory, "*.theme");

                foreach (var item in files)
                {
                    cbx_style.Items.Add(Path.GetFileNameWithoutExtension(item));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception from MainForm.LoadThemes:" + e.Message);
                return;
            }

            
            
        }

        #endregion

        #region -- Event --

        /// <summary>
        /// Form Load
        /// </summary>
        private void CodeForm_Load(object sender, EventArgs e)
        {
            this.txtCode.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy(CodeTypeTransform(_codeType));
            this.txtCode.Encoding = Encoding.UTF8;
            this.cbx_style.SelectedIndex = NoteHighlightForm.Properties.Settings.Default.HighLightStyle;
            this.btnBackground.BackColor = NoteHighlightForm.Properties.Settings.Default.BackgroundColor;
            this.TopMost = true;
            this.TopMost = false;
        }

        /// <summary>
        /// Form Closed
        /// </summary>
        private void CodeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveSetting();
        }

        /// <summary>
        /// Generate HighLight File
        /// </summary>
        private void btnCodeHighLight_Click(object sender, EventArgs e)
        {
            IGenerateHighLight generate = new GenerateHighLight();

            string outputFileName = String.Empty;

            _parameters = new HighLightParameter()
            {
                FileName = _fileName,
                Content = CodeContent,
                CodeType = _codeType,
                HighLightStyle = CodeStyle,
                ShowLineNumber = IsShowLineNumber,
                HighlightColor = BackgroundColor
            };

            try
            {
                outputFileName = generate.GenerateHighLightCode(_parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                this.Dispose();
                this.Close();
                return;
            }

            if (IsClipboard && !String.IsNullOrEmpty(outputFileName))
                InsertToClipboard(outputFileName);

            SaveSetting();

            this.Dispose();
            this.Close();
        }

        #endregion

        /// <summary>
        /// Copy HighLight Code To Clipboard
        /// </summary>
        private void InsertToClipboard(string outputFileName)
        {
            StringBuilder sb = new StringBuilder();

            using (FileStream fs = new FileStream(outputFileName, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
                {
                    //Fix 存到剪貼簿空白不見的問題
                    while (sr.Peek() >= 0)
                    {
                        string line = sr.ReadLine();

                        line = line.Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;").Replace("&apos;", "'") + "<br />";

                        var charList = line.ToCharArray().ToList();

                        StringBuilder sbLine = new StringBuilder();
                        int index = 0;

                        if (IsShowLineNumber)
                        {
                            index = line.IndexOf(span) + span.Length;
                            sbLine.Append(line.Substring(0, index));
                        }

                        for (int i = index; i < charList.Count; i++)
                        {
                            if (charList[i] == ' ')
                            {
                                sbLine.Append("&nbsp;&nbsp;");
                            }
                            else
                            {
                                sbLine.Append(line.Substring(i));
                                break;
                            }
                        }
                        sb.AppendLine(sbLine.ToString());
                    }
                }
            }
            HtmlFragment.CopyToClipboard(sb.ToString());
            File.Delete(outputFileName);
        }

        /// <summary>
        /// Transfer ICSharpCode.TextEditor Control Use FileCode
        /// </summary>
        private string CodeTypeTransform(string codeType)
        {
            string result = string.Empty;
            switch (codeType.ToLower())
            {
                case "cs":
                    result = "C#";
                    break;
                case "vb":
                    result = "VBNET";
                    break;
                case "js":
                    result = "JavaScript";
                    break;
                case "xml":
                    result = "XML";
                    break;
                case "css":
                    result = "CSS";
                    break;
                case "html":
                    result = "HTML";
                    break;
                case "php":
                    result = "PHP";
                    break;
                case "java":
                    result = "Java";
                    break;
                case "c":
                    result = "C++.NET";
                    break;
                default:
                    result = "";
                    break;
            }
            return result;
        }

        /// <summary>
        /// Save User Setting
        /// </summary>
        private void SaveSetting()
        {
            var defaultSettings = NoteHighlightForm.Properties.Settings.Default;
            defaultSettings.ShowLineNumber = this.cbx_lineNumber.Checked;
            defaultSettings.SaveOnClipboard = this.cbx_Clipboard.Checked;
            defaultSettings.HighLightStyle = this.cbx_style.SelectedIndex;
            defaultSettings.BackgroundColor = this.btnBackground.BackColor;
            defaultSettings.Save();
        }

        private void btnBackground_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                btnBackground.BackColor = colorDialog1.Color;
            }
        }
    }
}
