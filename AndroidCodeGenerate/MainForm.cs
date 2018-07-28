
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Helper;

namespace AndroidCodeGenerate
{
	
	public partial class MainForm : Form
	{
		public MainForm()
		{
			
			InitializeComponent();
			
		}
		void MenuItemToCodeButtonClick(object sender, EventArgs e)
		{
			Helpers.OnClipboardString(AndroidExtensions.FormatMenuItemToCode);
			
		}
		void ExeButtonClick(object sender, EventArgs e)
		{
			Helpers.OpenExecutableDirectory();
		}
		void SortFunctionButtonClick(object sender, EventArgs e)
		{
			Helpers.OnClipboardString(AndroidExtensions.FormatFun);
		}
	}
}
