/*
 *  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.OneNote;
using Application = Microsoft.Office.Interop.OneNote.Application;  // Conflicts with System.Windows.Forms

namespace MyApplication.VanillaAddIn
{
	public partial class MainForm : Form
	{
		private Application onenoteApplication;

		public MainForm(Application application)
		{
			InitializeComponent();
			this.onenoteApplication = application;
			this.Load += MainForm_Load;
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			// Note: skipping error checking here, it's possible for there to not be a current page, for example.

			var pageId = this.onenoteApplication.Windows.CurrentWindow.CurrentPageId;
			string xml;
			this.onenoteApplication.GetPageContent(pageId, out xml);
			this.xmlTextBox.Text = xml;

            this.onenoteApplication.GetHierarchy(null, HierarchyScope.hsPages, out xml);
            this.hierarchyXmlTextBox.Text = xml;
        }
    }
}
