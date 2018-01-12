namespace NoteHighlightAddin
{ 
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            NoteHighlightForm.Properties.Settings settings1 = new NoteHighlightForm.Properties.Settings();
            this.btnCodeHighLight = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbx_style = new System.Windows.Forms.ComboBox();
            this.cbx_Clipboard = new System.Windows.Forms.CheckBox();
            this.cbx_lineNumber = new System.Windows.Forms.CheckBox();
            this.txtCode = new ICSharpCode.TextEditor.TextEditorControl();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnBackground = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCodeHighLight
            // 
            this.btnCodeHighLight.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCodeHighLight.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCodeHighLight.Location = new System.Drawing.Point(413, 0);
            this.btnCodeHighLight.Name = "btnCodeHighLight";
            this.btnCodeHighLight.Size = new System.Drawing.Size(104, 50);
            this.btnCodeHighLight.TabIndex = 0;
            this.btnCodeHighLight.Text = "&OK";
            this.btnCodeHighLight.UseVisualStyleBackColor = true;
            this.btnCodeHighLight.Click += new System.EventHandler(this.btnCodeHighLight_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Style：";
            // 
            // cbx_style
            // 
            this.cbx_style.FormattingEnabled = true;
            this.cbx_style.Location = new System.Drawing.Point(74, 17);
            this.cbx_style.Name = "cbx_style";
            this.cbx_style.Size = new System.Drawing.Size(121, 21);
            this.cbx_style.TabIndex = 0;
            // 
            // cbx_Clipboard
            // 
            this.cbx_Clipboard.AutoSize = true;
            settings1.BackgroundColor = System.Drawing.Color.White;
            settings1.HighLightStyle = 0;
            settings1.SaveOnClipboard = false;
            settings1.SettingsKey = "";
            settings1.ShowLineNumber = true;
            this.cbx_Clipboard.Checked = settings1.SaveOnClipboard;
            this.cbx_Clipboard.DataBindings.Add(new System.Windows.Forms.Binding("Checked", settings1, "SaveOnClipboard", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbx_Clipboard.Location = new System.Drawing.Point(271, 20);
            this.cbx_Clipboard.Name = "cbx_Clipboard";
            this.cbx_Clipboard.Size = new System.Drawing.Size(122, 17);
            this.cbx_Clipboard.TabIndex = 1;
            this.cbx_Clipboard.Text = "Copy to Clipboard(&C)";
            this.cbx_Clipboard.UseVisualStyleBackColor = true;
            // 
            // cbx_lineNumber
            // 
            this.cbx_lineNumber.AutoSize = true;
            this.cbx_lineNumber.Checked = settings1.ShowLineNumber;
            this.cbx_lineNumber.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbx_lineNumber.DataBindings.Add(new System.Windows.Forms.Binding("Checked", settings1, "ShowLineNumber", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbx_lineNumber.Location = new System.Drawing.Point(405, 20);
            this.cbx_lineNumber.Name = "cbx_lineNumber";
            this.cbx_lineNumber.Size = new System.Drawing.Size(100, 17);
            this.cbx_lineNumber.TabIndex = 2;
            this.cbx_lineNumber.Text = "Line Number(&N)";
            this.cbx_lineNumber.UseVisualStyleBackColor = true;
            // 
            // txtCode
            // 
            this.txtCode.AutoScroll = true;
            this.txtCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCode.IsReadOnly = false;
            this.txtCode.Location = new System.Drawing.Point(0, 0);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(517, 380);
            this.txtCode.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbx_lineNumber);
            this.panel1.Controls.Add(this.cbx_Clipboard);
            this.panel1.Controls.Add(this.cbx_style);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(517, 53);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnBackground);
            this.panel2.Controls.Add(this.btnCodeHighLight);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 433);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(517, 50);
            this.panel2.TabIndex = 2;
            // 
            // btnBackground
            // 
            this.btnBackground.Location = new System.Drawing.Point(9, 2);
            this.btnBackground.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBackground.Name = "btnBackground";
            this.btnBackground.Size = new System.Drawing.Size(79, 41);
            this.btnBackground.TabIndex = 1;
            this.btnBackground.Text = "Box Color";
            this.btnBackground.UseVisualStyleBackColor = true;
            this.btnBackground.Click += new System.EventHandler(this.btnBackground_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtCode);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 53);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(517, 380);
            this.panel3.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnCodeHighLight;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 483);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NoteHighLight";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CodeForm_FormClosed);
            this.Load += new System.EventHandler(this.CodeForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCodeHighLight;
        private System.Windows.Forms.CheckBox cbx_lineNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbx_Clipboard;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ComboBox cbx_style;
        private ICSharpCode.TextEditor.TextEditorControl txtCode;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnBackground;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}