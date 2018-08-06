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
		private System.Windows.Forms.ToolStripButton sortButton;
		private System.Windows.Forms.ToolStripButton codePreviewButton;
		private System.Windows.Forms.ToolStripButton addPrivateButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStrip toolStrip2;
		private System.Windows.Forms.ToolStripButton JavaStaticKotlinButton;
		private System.Windows.Forms.ToolStripButton javaFieldButton1;
		private System.Windows.Forms.ToolStripButton parameterButton;
		private System.Windows.Forms.ToolStripSplitButton fileButton;
		private System.Windows.Forms.ToolStripMenuItem changeHTMLCSSToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cleanJavaFileToolStripMenuItem;
		private System.Windows.Forms.ToolStrip toolStrip3;
		private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
		private System.Windows.Forms.ToolStripComboBox toolStripComboBox2;
		private System.Windows.Forms.ToolStripSplitButton replaceButton;
		private System.Windows.Forms.ToolStripMenuItem 替换文件中ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 压缩目录下Kotlin文件ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 压缩安卓项目ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 复制目录结构ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 从配置文件替换ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 保留正则表达式ToolStripMenuItem;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.ToolStripButton compileStripButton;
		private System.Windows.Forms.ToolStripSplitButton logButton;
		private System.Windows.Forms.ToolStripMenuItem 合并KT文件ToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton sqlStripButton;
		private System.Windows.Forms.ToolStripButton stringBuilderButton;
		private System.Windows.Forms.ToolStripMenuItem log文件ToolStripMenuItem;
		
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
			this.sortButton = new System.Windows.Forms.ToolStripButton();
			this.sortFunctionButton = new System.Windows.Forms.ToolStripButton();
			this.menuItemToCodeButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.addPrivateButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.exeButton = new System.Windows.Forms.ToolStripButton();
			this.codePreviewButton = new System.Windows.Forms.ToolStripButton();
			this.toolStrip2 = new System.Windows.Forms.ToolStrip();
			this.parameterButton = new System.Windows.Forms.ToolStripButton();
			this.javaFieldButton1 = new System.Windows.Forms.ToolStripButton();
			this.JavaStaticKotlinButton = new System.Windows.Forms.ToolStripButton();
			this.fileButton = new System.Windows.Forms.ToolStripSplitButton();
			this.changeHTMLCSSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cleanJavaFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.压缩目录下Kotlin文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.压缩安卓项目ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.复制目录结构ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.合并KT文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.compileStripButton = new System.Windows.Forms.ToolStripButton();
			this.logButton = new System.Windows.Forms.ToolStripSplitButton();
			this.log文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sqlStripButton = new System.Windows.Forms.ToolStripButton();
			this.stringBuilderButton = new System.Windows.Forms.ToolStripButton();
			this.toolStrip3 = new System.Windows.Forms.ToolStrip();
			this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
			this.toolStripComboBox2 = new System.Windows.Forms.ToolStripComboBox();
			this.replaceButton = new System.Windows.Forms.ToolStripSplitButton();
			this.替换文件中ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.从配置文件替换ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.保留正则表达式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.toolStrip1.SuspendLayout();
			this.toolStrip2.SuspendLayout();
			this.toolStrip3.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.sortButton,
			this.sortFunctionButton,
			this.menuItemToCodeButton,
			this.toolStripSeparator1,
			this.addPrivateButton,
			this.toolStripSeparator2,
			this.exeButton,
			this.codePreviewButton});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(598, 25);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ToolStrip1ItemClicked);
			// 
			// sortButton
			// 
			this.sortButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.sortButton.Image = ((System.Drawing.Image)(resources.GetObject("sortButton.Image")));
			this.sortButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.sortButton.Name = "sortButton";
			this.sortButton.Size = new System.Drawing.Size(36, 22);
			this.sortButton.Text = "Sort";
			this.sortButton.Click += new System.EventHandler(this.SortButtonClick);
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
			// addPrivateButton
			// 
			this.addPrivateButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.addPrivateButton.Image = ((System.Drawing.Image)(resources.GetObject("addPrivateButton.Image")));
			this.addPrivateButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.addPrivateButton.Name = "addPrivateButton";
			this.addPrivateButton.Size = new System.Drawing.Size(79, 22);
			this.addPrivateButton.Text = "Add Private";
			this.addPrivateButton.Click += new System.EventHandler(this.AddPrivateButtonClick);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
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
			// codePreviewButton
			// 
			this.codePreviewButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.codePreviewButton.Image = ((System.Drawing.Image)(resources.GetObject("codePreviewButton.Image")));
			this.codePreviewButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.codePreviewButton.Name = "codePreviewButton";
			this.codePreviewButton.Size = new System.Drawing.Size(43, 22);
			this.codePreviewButton.Text = "Code";
			this.codePreviewButton.Click += new System.EventHandler(this.CodePreviewButtonClick);
			// 
			// toolStrip2
			// 
			this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.parameterButton,
			this.javaFieldButton1,
			this.JavaStaticKotlinButton,
			this.fileButton,
			this.compileStripButton,
			this.logButton,
			this.sqlStripButton,
			this.stringBuilderButton});
			this.toolStrip2.Location = new System.Drawing.Point(0, 25);
			this.toolStrip2.Name = "toolStrip2";
			this.toolStrip2.Size = new System.Drawing.Size(598, 25);
			this.toolStrip2.TabIndex = 1;
			this.toolStrip2.Text = "toolStrip2";
			// 
			// parameterButton
			// 
			this.parameterButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.parameterButton.Image = ((System.Drawing.Image)(resources.GetObject("parameterButton.Image")));
			this.parameterButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.parameterButton.Name = "parameterButton";
			this.parameterButton.Size = new System.Drawing.Size(101, 22);
			this.parameterButton.Text = "Java Parameter";
			this.parameterButton.Click += new System.EventHandler(this.ParameterButtonClick);
			// 
			// javaFieldButton1
			// 
			this.javaFieldButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.javaFieldButton1.Image = ((System.Drawing.Image)(resources.GetObject("javaFieldButton1.Image")));
			this.javaFieldButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.javaFieldButton1.Name = "javaFieldButton1";
			this.javaFieldButton1.Size = new System.Drawing.Size(68, 22);
			this.javaFieldButton1.Text = "Java Field";
			this.javaFieldButton1.Click += new System.EventHandler(this.JavaFieldButton1Click);
			// 
			// JavaStaticKotlinButton
			// 
			this.JavaStaticKotlinButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.JavaStaticKotlinButton.Image = ((System.Drawing.Image)(resources.GetObject("JavaStaticKotlinButton.Image")));
			this.JavaStaticKotlinButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.JavaStaticKotlinButton.Name = "JavaStaticKotlinButton";
			this.JavaStaticKotlinButton.Size = new System.Drawing.Size(80, 22);
			this.JavaStaticKotlinButton.Text = "Static Const";
			this.JavaStaticKotlinButton.Click += new System.EventHandler(this.JavaStaticKotlinButtonClick);
			// 
			// fileButton
			// 
			this.fileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.fileButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.changeHTMLCSSToolStripMenuItem,
			this.cleanJavaFileToolStripMenuItem,
			this.压缩目录下Kotlin文件ToolStripMenuItem,
			this.压缩安卓项目ToolStripMenuItem,
			this.复制目录结构ToolStripMenuItem,
			this.合并KT文件ToolStripMenuItem,
			this.toolStripSeparator3});
			this.fileButton.Image = ((System.Drawing.Image)(resources.GetObject("fileButton.Image")));
			this.fileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.fileButton.Name = "fileButton";
			this.fileButton.Size = new System.Drawing.Size(48, 22);
			this.fileButton.Text = "文件";
			this.fileButton.ButtonClick += new System.EventHandler(this.FileButtonButtonClick);
			// 
			// changeHTMLCSSToolStripMenuItem
			// 
			this.changeHTMLCSSToolStripMenuItem.Name = "changeHTMLCSSToolStripMenuItem";
			this.changeHTMLCSSToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
			this.changeHTMLCSSToolStripMenuItem.Text = "Change HTML CSS";
			this.changeHTMLCSSToolStripMenuItem.Click += new System.EventHandler(this.ChangeHTMLCSSToolStripMenuItemClick);
			// 
			// cleanJavaFileToolStripMenuItem
			// 
			this.cleanJavaFileToolStripMenuItem.Name = "cleanJavaFileToolStripMenuItem";
			this.cleanJavaFileToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
			this.cleanJavaFileToolStripMenuItem.Text = "Clean Java File";
			this.cleanJavaFileToolStripMenuItem.Click += new System.EventHandler(this.CleanJavaFileToolStripMenuItemClick);
			// 
			// 压缩目录下Kotlin文件ToolStripMenuItem
			// 
			this.压缩目录下Kotlin文件ToolStripMenuItem.Name = "压缩目录下Kotlin文件ToolStripMenuItem";
			this.压缩目录下Kotlin文件ToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
			this.压缩目录下Kotlin文件ToolStripMenuItem.Text = "压缩目录下Kotlin文件";
			this.压缩目录下Kotlin文件ToolStripMenuItem.Click += new System.EventHandler(this.压缩目录下Kotlin文件ToolStripMenuItemClick);
			// 
			// 压缩安卓项目ToolStripMenuItem
			// 
			this.压缩安卓项目ToolStripMenuItem.Name = "压缩安卓项目ToolStripMenuItem";
			this.压缩安卓项目ToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
			this.压缩安卓项目ToolStripMenuItem.Text = "压缩安卓项目";
			this.压缩安卓项目ToolStripMenuItem.Click += new System.EventHandler(this.压缩安卓项目ToolStripMenuItemClick);
			// 
			// 复制目录结构ToolStripMenuItem
			// 
			this.复制目录结构ToolStripMenuItem.Name = "复制目录结构ToolStripMenuItem";
			this.复制目录结构ToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
			this.复制目录结构ToolStripMenuItem.Text = "复制目录结构";
			this.复制目录结构ToolStripMenuItem.Click += new System.EventHandler(this.复制目录结构ToolStripMenuItemClick);
			// 
			// 合并KT文件ToolStripMenuItem
			// 
			this.合并KT文件ToolStripMenuItem.Name = "合并KT文件ToolStripMenuItem";
			this.合并KT文件ToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
			this.合并KT文件ToolStripMenuItem.Text = "合并KT文件";
			this.合并KT文件ToolStripMenuItem.Click += new System.EventHandler(this.合并KT文件ToolStripMenuItemClick);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(190, 6);
			// 
			// compileStripButton
			// 
			this.compileStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.compileStripButton.Image = ((System.Drawing.Image)(resources.GetObject("compileStripButton.Image")));
			this.compileStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.compileStripButton.Name = "compileStripButton";
			this.compileStripButton.Size = new System.Drawing.Size(36, 22);
			this.compileStripButton.Text = "编译";
			this.compileStripButton.Click += new System.EventHandler(this.CompileStripButtonClick);
			// 
			// logButton
			// 
			this.logButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.logButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.log文件ToolStripMenuItem});
			this.logButton.Image = ((System.Drawing.Image)(resources.GetObject("logButton.Image")));
			this.logButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.logButton.Name = "logButton";
			this.logButton.Size = new System.Drawing.Size(46, 22);
			this.logButton.Text = "Log";
			this.logButton.ButtonClick += new System.EventHandler(this.LogButtonButtonClick);
			// 
			// log文件ToolStripMenuItem
			// 
			this.log文件ToolStripMenuItem.Name = "log文件ToolStripMenuItem";
			this.log文件ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.log文件ToolStripMenuItem.Text = "Log文件";
			this.log文件ToolStripMenuItem.Click += new System.EventHandler(this.LogButtonClick);
			// 
			// sqlStripButton
			// 
			this.sqlStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.sqlStripButton.Image = ((System.Drawing.Image)(resources.GetObject("sqlStripButton.Image")));
			this.sqlStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.sqlStripButton.Name = "sqlStripButton";
			this.sqlStripButton.Size = new System.Drawing.Size(35, 22);
			this.sqlStripButton.Text = "SQL";
			this.sqlStripButton.Click += new System.EventHandler(this.SqlStripButtonClick);
			// 
			// stringBuilderButton
			// 
			this.stringBuilderButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.stringBuilderButton.Image = ((System.Drawing.Image)(resources.GetObject("stringBuilderButton.Image")));
			this.stringBuilderButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.stringBuilderButton.Name = "stringBuilderButton";
			this.stringBuilderButton.Size = new System.Drawing.Size(87, 22);
			this.stringBuilderButton.Text = "StringBuilder";
			this.stringBuilderButton.Click += new System.EventHandler(this.StringBuilderButtonClick);
			// 
			// toolStrip3
			// 
			this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.toolStripComboBox1,
			this.toolStripComboBox2,
			this.replaceButton});
			this.toolStrip3.Location = new System.Drawing.Point(0, 50);
			this.toolStrip3.Name = "toolStrip3";
			this.toolStrip3.Size = new System.Drawing.Size(598, 25);
			this.toolStrip3.TabIndex = 2;
			this.toolStrip3.Text = "toolStrip3";
			// 
			// toolStripComboBox1
			// 
			this.toolStripComboBox1.Items.AddRange(new object[] {
			"(?<=name\\=)\"[^\"]*?\"",
			"Log\\.[a-z]\\([^\\)]*\\)",
			"(?<!=// )Log\\.[a-z]\\([^\\)]*\\)",
			"(//\\s)*Tracker\\.[a-z]\\([^\\)]*\\)"});
			this.toolStripComboBox1.Name = "toolStripComboBox1";
			this.toolStripComboBox1.Size = new System.Drawing.Size(300, 25);
			// 
			// toolStripComboBox2
			// 
			this.toolStripComboBox2.Items.AddRange(new object[] {
			"// $0"});
			this.toolStripComboBox2.Name = "toolStripComboBox2";
			this.toolStripComboBox2.Size = new System.Drawing.Size(121, 25);
			// 
			// replaceButton
			// 
			this.replaceButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.replaceButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.替换文件中ToolStripMenuItem,
			this.从配置文件替换ToolStripMenuItem,
			this.保留正则表达式ToolStripMenuItem});
			this.replaceButton.Image = ((System.Drawing.Image)(resources.GetObject("replaceButton.Image")));
			this.replaceButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.replaceButton.Name = "replaceButton";
			this.replaceButton.Size = new System.Drawing.Size(48, 22);
			this.replaceButton.Text = "替换";
			this.replaceButton.ButtonClick += new System.EventHandler(this.ReplaceButtonButtonClick);
			// 
			// 替换文件中ToolStripMenuItem
			// 
			this.替换文件中ToolStripMenuItem.Name = "替换文件中ToolStripMenuItem";
			this.替换文件中ToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
			this.替换文件中ToolStripMenuItem.Text = "替换文件中";
			this.替换文件中ToolStripMenuItem.Click += new System.EventHandler(this.替换文件中ToolStripMenuItemClick);
			// 
			// 从配置文件替换ToolStripMenuItem
			// 
			this.从配置文件替换ToolStripMenuItem.Name = "从配置文件替换ToolStripMenuItem";
			this.从配置文件替换ToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
			this.从配置文件替换ToolStripMenuItem.Text = "从配置文件替换";
			this.从配置文件替换ToolStripMenuItem.Click += new System.EventHandler(this.从配置文件替换ToolStripMenuItemClick);
			// 
			// 保留正则表达式ToolStripMenuItem
			// 
			this.保留正则表达式ToolStripMenuItem.Name = "保留正则表达式ToolStripMenuItem";
			this.保留正则表达式ToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
			this.保留正则表达式ToolStripMenuItem.Text = "保留(正则表达式)";
			this.保留正则表达式ToolStripMenuItem.Click += new System.EventHandler(this.保留正则表达式ToolStripMenuItemClick);
			// 
			// textBox1
			// 
			this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox1.Location = new System.Drawing.Point(0, 75);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox1.Size = new System.Drawing.Size(598, 70);
			this.textBox1.TabIndex = 3;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(598, 145);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.toolStrip3);
			this.Controls.Add(this.toolStrip2);
			this.Controls.Add(this.toolStrip1);
			this.Name = "MainForm";
			this.Text = "AndroidCodeGenerate";
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.toolStrip2.ResumeLayout(false);
			this.toolStrip2.PerformLayout();
			this.toolStrip3.ResumeLayout(false);
			this.toolStrip3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
