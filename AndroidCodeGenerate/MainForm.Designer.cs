/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2018/7/29
 * Time: 3:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AndroidCodeGenerate
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton menuItemToCodeButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton exeButton;
		private System.Windows.Forms.ToolStripButton sortFunctionButton;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.menuItemToCodeButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.exeButton = new System.Windows.Forms.ToolStripButton();
			this.sortFunctionButton = new System.Windows.Forms.ToolStripButton();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.sortFunctionButton,
			this.menuItemToCodeButton,
			this.toolStripSeparator1,
			this.exeButton});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(747, 25);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// menuItemToCodeButton
			// 
			this.menuItemToCodeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.menuItemToCodeButton.Image = ((System.Drawing.Image)(resources.GetObject("menuItemToCodeButton.Image")));
			this.menuItemToCodeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.menuItemToCodeButton.Name = "menuItemToCodeButton";
			this.menuItemToCodeButton.Size = new System.Drawing.Size(75, 22);
			this.menuItemToCodeButton.Text = "Menu Item";
			this.menuItemToCodeButton.Click += new System.EventHandler(this.MenuItemToCodeButtonClick);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// exeButton
			// 
			this.exeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.exeButton.Image = ((System.Drawing.Image)(resources.GetObject("exeButton.Image")));
			this.exeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.exeButton.Name = "exeButton";
			this.exeButton.Size = new System.Drawing.Size(34, 22);
			this.exeButton.Text = "EXE";
			this.exeButton.Click += new System.EventHandler(this.ExeButtonClick);
			// 
			// sortFunctionButton
			// 
			this.sortFunctionButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.sortFunctionButton.Image = ((System.Drawing.Image)(resources.GetObject("sortFunctionButton.Image")));
			this.sortFunctionButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.sortFunctionButton.Name = "sortFunctionButton";
			this.sortFunctionButton.Size = new System.Drawing.Size(60, 22);
			this.sortFunctionButton.Text = "Sort Fun";
			this.sortFunctionButton.Click += new System.EventHandler(this.SortFunctionButtonClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(747, 141);
			this.Controls.Add(this.toolStrip1);
			this.Name = "MainForm";
			this.Text = "AndroidCodeGenerate";
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
