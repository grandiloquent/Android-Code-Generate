
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Helper;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace AndroidCodeGenerate
{
	
	public partial class MainForm : Form
	{
		private string mLastDirectory;
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
		void SortButtonClick(object sender, EventArgs e)
		{
			Helpers.OnClipboardString(AndroidExtensions.FormatSingleLine);
	
		}
		void CodePreviewButtonClick(object sender, EventArgs e)
		{
			var dlg = new CodePreviewForm();
			dlg.Show();
	
		}
		void AddPrivateButtonClick(object sender, EventArgs e)
		{
			Helpers.OnClipboardString(AndroidExtensions.FormatAddPrivate);
		}
		void JavaStaticKotlinButtonClick(object sender, EventArgs e)
		{
	
			Helpers.OnClipboardString(AndroidExtensions.FormatJavaStaticFinalFieldToKotlin);
		}
		void JavaFieldButton1Click(object sender, EventArgs e)
		{
			Helpers.OnClipboardString(AndroidExtensions.FormatJavaFieldToKotlin);
	
		}
		void ParameterButtonClick(object sender, EventArgs e)
		{
			Helpers.OnClipboardString(AndroidExtensions.FormatJavaParameterToKotlin);
	
		}
		void ChangeHTMLCSSToolStripMenuItemClick(object sender, EventArgs e)
		{
	
			Helpers.OnClipboardFileSystem((path) => {
				if (Directory.Exists(path)) {
					var files = Directory.GetFiles(path, "*.html", SearchOption.AllDirectories);
					foreach (var element in files) {
						var str =	element.ReadAllText().Replace("<style type=\"text/css\">",
							          "<style type=\"text/css\">*{font-family:Consolas}");
						element.WriteAllText(str);
					}
				}
			                              	
			});
		}
		void CleanJavaFileToolStripMenuItemClick(object sender, EventArgs e)
		{
			Helpers.OnClipboardFileSystem((path) => {
				if (Directory.Exists(path)) {
					var files = Directory.GetFiles(path, "*.java", SearchOption.AllDirectories);
					foreach (var element in files) {
						var lines = element.ReadAllLines().ToArray();
						var should = true;
						foreach (var l in lines) {
							if (string.IsNullOrWhiteSpace(l))
								continue;
							if (l.Trim().StartsWith("package ")) {
								should = false;
							}
							break;
						}
						if (should) {
							should = false;		
							var outputLines = new List<string>();
							
							foreach (var l in lines) {
								if (l.Trim().StartsWith("package ")) {
									should = true;
								}
								if (should)
									outputLines.Add(l);
							}
							
							element.WriteAllText(string.Join("\n", outputLines));
						}
			                              			
					}
				}
			                              	
			});
		}
		void 替换文件中ToolStripMenuItemClick(object sender, EventArgs e)
		{
			Helpers.OnClipboardFileSystem((path) => {
				var find = toolStripComboBox1.Text;
			                              	
				if (path.IsDirectory() && find.IsReadable()) {
					var replace = toolStripComboBox2.Text;
					Helpers.ReplaceStringInDirectory(path, find, replace);
					mLastDirectory = path;
				}
			                              	
			});
		}
		void 压缩目录下Kotlin文件ToolStripMenuItemClick(object sender, EventArgs e)
		{
			Helpers.OnClipboardFileSystem((path) => {
				 
			                              	
				if (path.IsDirectory()) {
					 
					Helpers.ZipKotlinFiles(path);
				}
			                              	
			});
		}
		void 压缩安卓项目ToolStripMenuItemClick(object sender, EventArgs e)
		{
			Helpers.OnClipboardFileSystem((path) => {
				 
			                              	
				if (path.IsDirectory()) {
					 
					Helpers.ZipAndroidProject(path);
				}
			                              	
			});
		}
		void ReplaceButtonButtonClick(object sender, EventArgs e)
		{
			var find = toolStripComboBox1.Text;
			if (mLastDirectory.IsDirectory() && find.IsReadable()) {
				var replace = toolStripComboBox2.Text;
				Helpers.ReplaceStringInDirectory(mLastDirectory, find, replace);
					 
			}
		}
		void 复制目录结构ToolStripMenuItemClick(object sender, EventArgs e)
		{
			Helpers.OnClipboardFileSystem((path) => {
				 
			                              	
				if (path.IsDirectory()) {
					 
					path.CopyDirectoryTree();
				}
			                              	
			});
		}
		void 从配置文件替换ToolStripMenuItemClick(object sender, EventArgs e)
		{
			Helpers.OnClipboardFileSystem((path) => {
				 
			                              	
				if (File.Exists(path)) {
					 
					var lines = path.ReadAllText().Trim().Split(Environment.NewLine.ToArray(), StringSplitOptions.RemoveEmptyEntries);
			                              		
					var dir = lines[0];
					if (!dir.IsDirectory())
						return;
					
					var files = dir.ListFilesRecursively("java|kt|xml|txt|cs");
					
					foreach (var element in files) {
						
						var content = element.ReadAllText();
					
						var replaceArray = lines.Skip(1).ToArray();
						foreach (var l in replaceArray) {
							var splited = l.Split(new char[]{ '|' }, 2);
							content = content.Replace(splited[0], splited[1]);
						}
						element.WriteAllText(content);
					}
			                              		
				}
			                              	
			});
		}
		void 保留正则表达式ToolStripMenuItemClick(object sender, EventArgs e)
		{
			var find = toolStripComboBox1.Text;
			if (find.IsReadable() && textBox1.Text.IsReadable()) {
				var matches = textBox1.Text.KeepMatches(find).Select(i => i.Trim()).OrderBy(i => i);
				textBox1.Text = string.Join("\r\n", matches);
			}
		}
		void FileButtonButtonClick(object sender, EventArgs e)
		{
	
			Helpers.OnClipboardString((v) => {
				var filename = v.Trim().GetValidFileName();
			                          	
				var sb = new StringBuilder();
				sb.AppendLine("package psycho.euphoria.gallery");
				sb.AppendLine("import android.content.Context");
				sb.AppendLine("import android.util.AttributeSet");
				sb.AppendLine("import android.view.View");
				sb.AppendFormat("class {0} : View {{\r\n", filename);
				sb.AppendLine("constructor(context: Context) : super(context)");
				sb.AppendLine("constructor(context: Context, attrs: AttributeSet) : super(context, attrs)");
				sb.AppendLine("constructor(context: Context, attrs: AttributeSet, defStyle: Int) : super(context, attrs, defStyle)");
				sb.AppendLine("companion object {");
				sb.AppendFormat("private const val TAG = \"{0}\"\r\n", filename);
				sb.AppendLine("}");
				sb.AppendLine("}");

				(filename + ".kt").GetDesktopPath().WriteAllText(sb.ToString());
				return null;
			});
		}
		void CompileStripButtonClick(object sender, EventArgs e)
		{
			Helpers.OnClipboardFileSystem((v) => {
			
				if (File.Exists(v)) {
					Clipboard.SetText(AndroidExtensions.GenerateKotilinCompileCommand(v));
				}
			 
			});
		}
		void LogButtonClick(object sender, EventArgs e)
		{
			Helpers.OnClipboardString(AndroidExtensions.GenerateLog);
		}
		void 合并KT文件ToolStripMenuItemClick(object sender, EventArgs e)
		{
			Helpers.OnClipboardFileSystem((path) => {
				 
			                              	
				if (path.IsDirectory()) {
					 
					var files = path.ListFilesRecursively("kt|java");
					var sb = new StringBuilder();
					foreach (var element in files) {
						sb.AppendLine(element.ReadAllText()).AppendLine(Environment.NewLine);
					}
					
					(path + ".txt").WriteAllText(sb.ToString());
				}
			                              	
			});
		}
		void SqlStripButtonClick(object sender, EventArgs e)
		{
			Helpers.OnClipboardString(AndroidExtensions.FormatSQLToConst);
	
		}
		void ToolStrip1ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
	
		}
		void StringBuilderButtonClick(object sender, EventArgs e)
		{
			Helpers.OnClipboardString(AndroidExtensions.FormatStringBuilder);
	
		}
		void LogButtonButtonClick(object sender, EventArgs e)
		{
			Helpers.OnClipboardString(AndroidExtensions.FormatLog);
	
		}
		void 提取字段名ToolStripMenuItemClick(object sender, EventArgs e)
		{
			Helpers.OnClipboardString((v) => {
			                            
				textBox1.Text = AndroidExtensions.ExtractJavaField(v);
				return null;
			});
			                            
	
		}
		void 标准化字段名ToolStripMenuItemClick(object sender, EventArgs e)
		{
	
			Helpers.OnClipboardFileSystem((path) => {
				 
				if (File.Exists(path)) {
					var list = textBox1.Text.Split(Environment.NewLine.ToArray(), StringSplitOptions.RemoveEmptyEntries)
						.Select(i => i.Trim())
						.OrderBy(i => i)
						.Distinct().ToArray();
					var content = path.ReadAllText();
					 
					foreach (var element in list) {
						
						content = Regex.Replace(content, "\\b" + element + "\\b", "m" + element.Capitalize());
					}
					path.WriteAllText(content);
				}
			                              	
			});
		}
		void ToFloatToolStripMenuItemClick(object sender, EventArgs e)
		{
			Helpers.OnClipboardString(v => {
				var array = v.Split(",".ToArray(), StringSplitOptions.RemoveEmptyEntries);
			                          	
				return string.Join(",", array.Select(i => i.Trim() + ".toFloat()"));
			});
		}
		void 排序字段ToolStripMenuItemClick(object sender, EventArgs e)
		{
			Helpers.OnClipboardString(AndroidExtensions.FormatSortJavaField);
		}
		void 压缩子目录ToolStripMenuItemClick(object sender, EventArgs e)
		{
			Helpers.OnClipboardFileSystem((path) => {
				var directories = Directory.GetDirectories(path);
				foreach (var element in directories) {
					using (var zip = new Ionic.Zip.ZipFile(Encoding.GetEncoding("gbk"))) {
						zip.AddDirectory(element);
						zip.Save(element + ".zip");
					}
				}
			});
		}
		void 复制目录文件结构ToolStripMenuItemClick(object sender, EventArgs e)
		{
			Helpers.OnClipboardFileSystem((path) => {
				 
			                              	
				if (path.IsDirectory()) {
					 
					path.CopyFileSystemTree(textBox1.Text);
				}
			                              	
			});
		}
		void 排序indexhtmlToolStripMenuItemClick(object sender, EventArgs e)
		{
			Helpers.OnClipboardFileSystem((path) => {
				 
			                              	
				if (path.IsDirectory()) {
					 
					var files = Directory.GetFiles(path, "*.html", SearchOption.AllDirectories).Where(i => i.EndsWith("index.html"));
					foreach (var element in files) {
						element.WriteAllText(AndroidExtensions.FormatJetBrainExportHtml(element));
					}
				}
			                              	
			});
		
		}
		void TrackerToolStripMenuItemClick(object sender, EventArgs e)
		{
			Helpers.OnClipboardString(AndroidExtensions.FormatTracker);
		}
		void Tracker文件ToolStripMenuItemClick(object sender, EventArgs e)
		{
			Helpers.OnClipboardString(AndroidExtensions.GenerateTracker);
	
		}
		void 模板数组ToolStripMenuItemClick(object sender, EventArgs e)
		{
			var array=textBox1.Text.Trim().Split(Environment.NewLine.ToArray(),StringSplitOptions.RemoveEmptyEntries);
			var template=textBox2.Text.Trim();
			
			var list=new List<String>();
			
			foreach (var element in array) {
				var line=string.Format(template,element);
				line=line.Replace("{0}",string.Join("",element.Split('_').Select(i=>i.Capitalize())));
				list.Add(line);
			}
			  Clipboard.SetText(string.Join(Environment.NewLine,list));

		}
		void Sort_properClick(object sender, EventArgs e)
		{
	Helpers.OnClipboardString(AndroidExtensions.FormatProperties);
		}
		void SortDelegateButtonClick(object sender, EventArgs e)
		{
	Helpers.OnClipboardString(AndroidExtensions.FormatDelegate);
	
		}
	}
}
