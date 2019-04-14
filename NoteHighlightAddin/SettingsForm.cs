using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteHighlightAddin
{
    public partial class SettingsForm : Form
    {

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        public SettingsForm()
        {
            InitializeComponent();
            
            fontDialog1.Font = new Font(NoteHighlightForm.Properties.Settings.Default.Font, NoteHighlightForm.Properties.Settings.Default.FontSize);
            btnFont.Text = "Font:" + fontDialog1.Font.Name + ", Size:" + fontDialog1.Font.Size;
            btnFont.Font = fontDialog1.Font;
            cbShowTableBorder.Checked = NoteHighlightForm.Properties.Settings.Default.ShowTableBorder;
        }

        private void BtnFont_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = new Font(NoteHighlightForm.Properties.Settings.Default.Font, NoteHighlightForm.Properties.Settings.Default.FontSize);
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                btnFont.Text = "Font:"+fontDialog1.Font.Name + ", Size:" + fontDialog1.Font.Size;
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
        }
    }
}
