namespace NoteHighlightAddin
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.btnFont = new System.Windows.Forms.Button();
            this.cbShowTableBorder = new System.Windows.Forms.CheckBox();
            this.lblLanguages = new System.Windows.Forms.Label();
            this.lbxLanguages = new System.Windows.Forms.ListBox();
            this.btnRemoveLanguage = new System.Windows.Forms.Button();
            this.lblAddLanguage = new System.Windows.Forms.Label();
            this.cmbAvailableLanguages = new System.Windows.Forms.ComboBox();
            this.btnAddLanguage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fontDialog1
            // 
            this.fontDialog1.AllowScriptChange = false;
            this.fontDialog1.AllowSimulations = false;
            this.fontDialog1.AllowVerticalFonts = false;
            this.fontDialog1.FontMustExist = true;
            this.fontDialog1.ShowEffects = false;
            // 
            // btnFont
            // 
            this.btnFont.Location = new System.Drawing.Point(34, 20);
            this.btnFont.Name = "btnFont";
            this.btnFont.Size = new System.Drawing.Size(339, 23);
            this.btnFont.TabIndex = 1;
            this.btnFont.Text = "Font";
            this.btnFont.UseVisualStyleBackColor = true;
            this.btnFont.Click += new System.EventHandler(this.BtnFont_Click);
            // 
            // cbShowTableBorder
            // 
            this.cbShowTableBorder.AutoSize = true;
            this.cbShowTableBorder.Location = new System.Drawing.Point(34, 70);
            this.cbShowTableBorder.Name = "cbShowTableBorder";
            this.cbShowTableBorder.Size = new System.Drawing.Size(117, 17);
            this.cbShowTableBorder.TabIndex = 2;
            this.cbShowTableBorder.Text = "Show Table Border";
            this.cbShowTableBorder.UseVisualStyleBackColor = true;
            this.cbShowTableBorder.CheckedChanged += new System.EventHandler(this.ChShowTableBorder_CheckedChanged);
            // 
            // lblLanguages
            // 
            this.lblLanguages.AutoSize = true;
            this.lblLanguages.Location = new System.Drawing.Point(34, 110);
            this.lblLanguages.Name = "lblLanguages";
            this.lblLanguages.Size = new System.Drawing.Size(96, 13);
            this.lblLanguages.TabIndex = 3;
            this.lblLanguages.Text = "Active Languages:";
            // 
            // lbxLanguages
            // 
            this.lbxLanguages.FormattingEnabled = true;
            this.lbxLanguages.Location = new System.Drawing.Point(34, 130);
            this.lbxLanguages.Name = "lbxLanguages";
            this.lbxLanguages.Size = new System.Drawing.Size(213, 95);
            this.lbxLanguages.TabIndex = 4;
            // 
            // btnRemoveLanguage
            // 
            this.btnRemoveLanguage.Location = new System.Drawing.Point(253, 130);
            this.btnRemoveLanguage.Name = "btnRemoveLanguage";
            this.btnRemoveLanguage.Size = new System.Drawing.Size(120, 36);
            this.btnRemoveLanguage.TabIndex = 5;
            this.btnRemoveLanguage.Text = "Remove Selected Language";
            this.btnRemoveLanguage.UseVisualStyleBackColor = true;
            this.btnRemoveLanguage.Click += new System.EventHandler(this.BtnRemoveLanguage_Click);
            // 
            // lblAddLanguage
            // 
            this.lblAddLanguage.AutoSize = true;
            this.lblAddLanguage.Location = new System.Drawing.Point(34, 246);
            this.lblAddLanguage.Name = "lblAddLanguage";
            this.lblAddLanguage.Size = new System.Drawing.Size(105, 13);
            this.lblAddLanguage.TabIndex = 6;
            this.lblAddLanguage.Text = "Add New Language:";
            this.lblAddLanguage.Click += new System.EventHandler(this.lblAddLanguage_Click);
            // 
            // cmbAvailableLanguages
            // 
            this.cmbAvailableLanguages.FormattingEnabled = true;
            this.cmbAvailableLanguages.Location = new System.Drawing.Point(34, 262);
            this.cmbAvailableLanguages.Name = "cmbAvailableLanguages";
            this.cmbAvailableLanguages.Size = new System.Drawing.Size(213, 21);
            this.cmbAvailableLanguages.TabIndex = 7;
            // 
            // btnAddLanguage
            // 
            this.btnAddLanguage.Location = new System.Drawing.Point(253, 246);
            this.btnAddLanguage.Name = "btnAddLanguage";
            this.btnAddLanguage.Size = new System.Drawing.Size(120, 37);
            this.btnAddLanguage.TabIndex = 8;
            this.btnAddLanguage.Text = "Add Language to Ribbon";
            this.btnAddLanguage.UseVisualStyleBackColor = true;
            this.btnAddLanguage.Click += new System.EventHandler(this.BtnAddLanguage_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 365);
            this.Controls.Add(this.btnAddLanguage);
            this.Controls.Add(this.cmbAvailableLanguages);
            this.Controls.Add(this.lblAddLanguage);
            this.Controls.Add(this.btnRemoveLanguage);
            this.Controls.Add(this.lbxLanguages);
            this.Controls.Add(this.lblLanguages);
            this.Controls.Add(this.cbShowTableBorder);
            this.Controls.Add(this.btnFont);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.Shown += new System.EventHandler(this.SettingsForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button btnFont;
        private System.Windows.Forms.CheckBox cbShowTableBorder;
        private System.Windows.Forms.Label lblLanguages;
        private System.Windows.Forms.ListBox lbxLanguages;
        private System.Windows.Forms.Button btnRemoveLanguage;
        private System.Windows.Forms.Label lblAddLanguage;
        private System.Windows.Forms.ComboBox cmbAvailableLanguages;
        private System.Windows.Forms.Button btnAddLanguage;
    }
}
