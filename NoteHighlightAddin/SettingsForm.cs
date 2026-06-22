using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class SettingsForm : Form
    {

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        private LanguageManager _languageManager;

        public SettingsForm()
        {
            InitializeComponent();

            fontDialog1.Font = new Font(NoteHighlightForm.Properties.Settings.Default.Font, NoteHighlightForm.Properties.Settings.Default.FontSize);
            btnFont.Text = "Font:" + fontDialog1.Font.Name + ", Size:" + fontDialog1.Font.Size;
            btnFont.Font = fontDialog1.Font;
            cbShowTableBorder.Checked = NoteHighlightForm.Properties.Settings.Default.ShowTableBorder;

            InitializeLanguageManager();
        }

        private void InitializeLanguageManager()
        {
            try
            {
                var assemblyDir = Path.GetDirectoryName(Assembly.GetCallingAssembly().Location);
                var ribbonXmlPath = Path.Combine(assemblyDir, "ribbon.xml");
                var langDefPath = Path.Combine(assemblyDir, "highlight", "langDefs");

                _languageManager = new LanguageManager(ribbonXmlPath, langDefPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing language manager: {ex.Message}");
            }
        }

        private void BtnFont_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = new Font(NoteHighlightForm.Properties.Settings.Default.Font, NoteHighlightForm.Properties.Settings.Default.FontSize);
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                btnFont.Text = "Font:" + fontDialog1.Font.Name + ", Size:" + fontDialog1.Font.Size;
                btnFont.Font = fontDialog1.Font;

                NoteHighlightForm.Properties.Settings.Default.Font = fontDialog1.Font.Name;
                NoteHighlightForm.Properties.Settings.Default.FontSize = (int)Math.Round(fontDialog1.Font.Size);

                NoteHighlightForm.Properties.Settings.Default.Save();
            }


        }

        private void ChShowTableBorder_CheckedChanged(object sender, EventArgs e)
        {
            NoteHighlightForm.Properties.Settings.Default.ShowTableBorder = cbShowTableBorder.Checked;

            NoteHighlightForm.Properties.Settings.Default.Save();
        }

        private void SettingsForm_Shown(object sender, EventArgs e)
        {
            // This is necessary in order for SetForegroundWindow to work consistently
            this.WindowState = FormWindowState.Minimized;
            this.WindowState = FormWindowState.Normal;

            SetForegroundWindow(this.Handle);

            RefreshLanguageList();
        }

        private void RefreshLanguageList()
        {
            if (_languageManager == null)
                return;

            try
            {
                // Clear and reload visible languages
                lbxLanguages.Items.Clear();
                var visibleLanguages = _languageManager.GetVisibleLanguages();
                foreach (var lang in visibleLanguages)
                {
                    lbxLanguages.Items.Add(lang);
                }

                // Clear and reload available languages
                cmbAvailableLanguages.Items.Clear();
                var availableLanguages = _languageManager.GetAvailableLanguages();
                var visibleTags = visibleLanguages.Select(l => l.Tag).ToList();

                // Only show languages that are not already visible
                foreach (var lang in availableLanguages)
                {
                    if (!visibleTags.Contains(lang.Tag))
                    {
                        cmbAvailableLanguages.Items.Add(lang);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing language list: {ex.Message}");
            }
        }

        private void BtnRemoveLanguage_Click(object sender, EventArgs e)
        {
            if (lbxLanguages.SelectedItem as LanguageInfo == null)
            {
                MessageBox.Show("Please select a language to remove.");
                return;
            }

            var selectedLanguage = lbxLanguages.SelectedItem as LanguageInfo;
            if (MessageBox.Show($"Remove '{selectedLanguage.Label}' from the ribbon?", "Confirm Removal", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_languageManager.RemoveLanguage(selectedLanguage.Tag))
                {
                    MessageBox.Show("Language removed. Please restart OneNote to see changes.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshLanguageList();
                }
                else
                {
                    MessageBox.Show("Failed to remove language.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnAddLanguage_Click(object sender, EventArgs e)
        {
            if (cmbAvailableLanguages.SelectedItem as LanguageInfo == null)
            {
                MessageBox.Show("Please select a language to add.");
                return;
            }

            var selectedLanguage = cmbAvailableLanguages.SelectedItem as LanguageInfo;
            if (_languageManager.AddLanguage(selectedLanguage.Tag, selectedLanguage.Label))
            {
                MessageBox.Show("Language added to ribbon. Please restart OneNote to see changes.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshLanguageList();
            }
            else
            {
                MessageBox.Show("Failed to add language.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
