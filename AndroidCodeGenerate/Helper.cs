namespace Helper
{
	using System.Windows.Forms;
	using System;
	using System.IO;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Xml;
	using System.Xml.Linq;
	using System.Reflection;
	using System.Diagnostics;
	using System.Text.RegularExpressions;
	using System.Globalization;
	using Ionic.Zip;
	
	public	static class Formatter
	{

		public static string RemoveComments(string value)
		{

			var blockComments = @"/\*(.*?)\*/";
			var lineComments = @"//(.*?)\r?\n";
			var strings = @"""((\\[^\n]|[^""\n])*)""";
			var verbatimStrings = @"@(""[^""]*"")+";
			string noComments = Regex.Replace(value,
				                    blockComments + "|" + lineComments + "|" + strings + "|" + verbatimStrings,
				                    me => {
					if (me.Value.StartsWith("/*") || me.Value.StartsWith("//"))
						return me.Value.StartsWith("//") ? Environment.NewLine : "";
					// Keep the literal strings
					return me.Value;
				},
				                    RegexOptions.Singleline);
			return Regex.Replace(noComments, "[\r\n]+", Environment.NewLine);
		}

		public const string ChineseZodiac = "鼠牛虎兔龙蛇马羊猴鸡狗猪";

		public static string FormatNginxConf(string value)
		{
			var sb = new StringBuilder();
			var count = 0;
			foreach (var item in value) {
				if (item == '{') {
					sb.AppendLine("{");
					count++;
				} else if (item == '}') {
					sb.AppendLine('\t'.Repeat(count) + "}");

					count--;
				} else if (item == ';') {
					sb.AppendLine(";");
					sb.Append('\t'.Repeat(count));
				} else if (item == '\r' || item == '\n' || item == '\t') {

					continue;
				} else {
					sb.Append(item);
				}

			}
			return sb.ToString();
		}
		public static string FormatBlockComment(string value)
		{
			var sb = new StringBuilder();
			var cacheSb = new StringBuilder();

			sb.Append("/*\r\n\r\n");
			foreach (var item in value.Split(new char[] { '\n' })) {
				if (item.IsReadable()) {
					foreach (var l in item.Split(' ')) {
						if (l.IsReadable()) {

							cacheSb.Append(l.Trim()).Append(' ');
							if (cacheSb.Length > 50) {
								sb.Append(cacheSb).AppendLine();
								cacheSb.Clear();
							}
						}
					}
					if (cacheSb.Length > 0) {
						sb.Append(cacheSb).AppendLine().AppendLine();
						cacheSb.Clear();
					}

				}
			}
			sb.Append("*/\r\n");
			return sb.ToString();
		}

		public static IEnumerable<string> FormatMethodList(string value)
		{
			var count = 0;
			var sb = new StringBuilder();
			var ls = new List<string>();
			for (int i = 0; i < value.Length; i++) {
				sb.Append(value[i]);

				if (value[i] == '{') {
					count++;
				} else if (value[i] == '}') {
					count--;
					if (count == 0) {
						ls.Add(sb.ToString());
						sb.Clear();
					}
				}

			}
			//if (ls.Any())
			//{
			//    var firstLine = ls[0];
			//    ls.RemoveAt(0);
			//    ls.Add(firstLine.)

			//}
			return ls;
			//return ls.Select(i => i.Split(new char[] { '{' }, 2).First().Trim() + ";").OrderBy(i => i.Trim());

		}

		public static string FormatStringBuilder(string value)
		{

			var sb = new StringBuilder();

			sb.AppendLine("var sb = new StringBuilder();");

			var ls = value.Split('\n').Where(i => i.IsReadable()).Select(i => i.Trim());

			foreach (var item in ls) {
				sb.AppendFormat("sb.AppendLine({0});\r\n", item.ToLiteral());
			}

			return sb.ToString();
		}
	}
	public static class Extensions
	{
		public static string Capitalize(this string value)
		{
			if (!string.IsNullOrEmpty(value) && char.IsLower(value[0])) {
				return value.Substring(0, 1).ToUpper() + value.Substring(1);
			}
			return value;
		}
		public static string GetDesktopPath(this string path)
		{
			return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), path);
		}
		public static string GetValidFileName(this string path, char replace = ' ')
		{
			
			if (path.Length > 100) {
				path = path.Substring(0, 100);
			}
			var chars = Path.GetInvalidFileNameChars();
			return new String(path.Select(i => chars.Contains(i) ? replace : i).ToArray());
		}
		
		public static IEnumerable<string> KeepMatches(this string value, string pattern)
		{
			return Regex.Matches(value, pattern).Cast<Match>().Select(i => i.Value);
		}
		public static void CopyDirectoryTree(this string path)
		{
			var directories = Directory.GetDirectories(path, "*", SearchOption.AllDirectories).OrderBy(i => i).ToArray();
			var targetDirectory = Path.Combine(path, "copy_directory_tree");
			if (!Directory.Exists(targetDirectory)) {
				Directory.CreateDirectory(targetDirectory);
			}
			foreach (var element in directories) {
			 
				Path.Combine(targetDirectory, element.Substring(path.Length + 1)).CreateDirectory();
			}
		}
		public static void CopyFileSystemTree(this string path,string content="")
		{
			var directories = Directory.GetFileSystemEntries(path, "*", SearchOption.AllDirectories);
			var targetDirectory = Path.Combine(path, "copy_directory_tree");
			if (!Directory.Exists(targetDirectory)) {
				Directory.CreateDirectory(targetDirectory);
			}
			foreach (var element in directories) {
				if (Directory.Exists(element)) {
					Path.Combine(targetDirectory, element.Substring(path.Length + 1)).CreateDirectory();
				   	
				} else {
					if(string.IsNullOrWhiteSpace(content))
					Path.Combine(targetDirectory, element.Substring(path.Length + 1)).WriteAllText(content+"\n\n\n\n\n\n");
					else{
						var dir=Path.Combine(targetDirectory, element.Substring(path.Length + 1));
						if(Path.GetDirectoryName(dir)!=targetDirectory)
							(Path.ChangeExtension(dir,".kt")).WriteAllText(content+"."+element.Substring(path.Length + 1).SubstringBeforeLast('\\').Replace("\\",".")+"\n\n\n\n\n\n");
						else
							(Path.ChangeExtension(dir,".kt")).WriteAllText(content+"\n\n\n");
							
					}
				}
			}
		}
		public static IEnumerable<String> ListFiles(this string path, string filter)
		{
			return Directory.GetFiles(path, "*").Where(i => Regex.IsMatch(i, string.Format("\\.(?:{0})$", filter)));
		}
		public static IEnumerable<String> ListFilesRecursively(this string path, string filter)
		{
			return Directory.GetFiles(path, "*", SearchOption.AllDirectories).Where(i => Regex.IsMatch(i, string.Format("\\.(?:{0})$", filter)));
		}
		public static Boolean IsDirectory(this string path)
		{
			return Directory.Exists(path);
		}
		public static void CreateDirectory(this string path)
		{
			if (!Directory.Exists(path)) {
				Directory.CreateDirectory(path);
			}
		}
		
		public static String ReadAllText(this String path)
		{
			// https://referencesource.microsoft.com/#mscorlib/system/io/file.cs,8a84c56a62fd8d45
			using (StreamReader sr = new StreamReader(path, new UTF8Encoding(false), true, 1024))
				return sr.ReadToEnd();
		}
		public static void WriteAllText(this String path, String contents)
		{
			using (StreamWriter sw = new StreamWriter(path, false, new UTF8Encoding(false), 1024))
				sw.Write(contents);
		}
		public static string SubstringAfterLast(this string value, char delimiter)
		{
			var index = value.LastIndexOf(delimiter);
			if (index == -1)
				return value;
			else
				return value.Substring(index + 1);
		}
		public static string SubstringBefore(this string value, char delimiter)
		{
			var index = value.IndexOf(delimiter);
			if (index == -1)
				return value;
			else
				return value.Substring(0, index);
		}
	
		public static IEnumerable<string> ReadAllLines(this string p)
		{

			String line;


			using (StreamReader sr = new StreamReader(p, new UTF8Encoding(false)))
				while ((line = sr.ReadLine()) != null)
					yield return line;


		}
		public static string SubstringBeforeLast(this string value, char delimiter)
		{
			var index = value.LastIndexOf(delimiter);
			if (index == -1)
				return value;
			else
				return value.Substring(0, index);
		}
		public static bool IsReadable(this string value)
		{
			return  !string.IsNullOrWhiteSpace(value);
		}
		public static string Repeat(this char c, int count)
		{
			return new String(c, count);
		}
		public static string ToLiteral(this string input)
		{
			var literal = new StringBuilder(input.Length + 2);
			literal.Append("\"");
			foreach (var c in input) {
				switch (c) {
					case '\'':
						literal.Append(@"\'");
						break;
					case '\"':
						literal.Append("\\\"");
						break;
					case '\\':
						literal.Append(@"\\");
						break;
					case '\0':
						literal.Append(@"\0");
						break;
					case '\a':
						literal.Append(@"\a");
						break;
					case '\b':
						literal.Append(@"\b");
						break;
					case '\f':
						literal.Append(@"\f");
						break;
					case '\n':
						literal.Append(@"\n");
						break;
					case '\r':
						literal.Append(@"\r");
						break;
					case '\t':
						literal.Append(@"\t");
						break;
					case '\v':
						literal.Append(@"\v");
						break;
					default:
						if (Char.GetUnicodeCategory(c) != UnicodeCategory.Control) {
							literal.Append(c);
						} else {
							literal.Append(@"\u");
							literal.Append(((ushort)c).ToString("x4"));
						}
						break;
				}
			}
			literal.Append("\"");
			return literal.ToString();
		}
		public static string GetCommandLinePath(this string fileName)
		{
			
			return Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), fileName);
		}
		
	}
	public static class Helpers
	{
		
		public static void ZipKotlinFiles(string dir)
		{
		
			var files = Directory.GetFiles(dir, "*.kt", SearchOption.AllDirectories);
			
			using (var zip = new ZipFile(Encoding.GetEncoding("gbk"))) {
			
				foreach (var element in files) {
					zip.AddFile(element, Path.GetDirectoryName(element).Substring(dir.Length));
				}
				var targetFileName = Path.Combine(dir, "Kotlin.zip");
				var count = 0;
				while (File.Exists(targetFileName)) {
					targetFileName = Path.Combine(dir, string.Format("Kotlin {0:000}.zip", ++count));
				}
				zip.Save(targetFileName);
			}
		}
		public static void ZipAndroidProject(string dir)
		{
			 
			using (var zip = new ZipFile(Encoding.GetEncoding("gbk"))) {

				zip.AddFiles(Directory.GetFiles(dir).Where(i => !i.EndsWith(".zip", StringComparison.InvariantCultureIgnoreCase)).ToArray(), "");
				zip.AddFiles(Directory.GetFiles(Path.Combine(dir, "app")), "app");
				zip.AddDirectory(Path.Combine(Path.Combine(dir, "app"), "src"), "app/src");

				var targetFileName = Path.Combine(dir, Path.GetFileName(dir) + ".zip");
				var count = 0;
				while (File.Exists(targetFileName)) {
					targetFileName = Path.Combine(dir, string.Format("{0} {1:000}.zip", Path.GetFileName(dir), ++count));
				}
				zip.Save(targetFileName);
			}
		}
		public static void ReplaceStringInDirectory(string directory, string find, string replace)
		{
			var files = Directory.GetFiles(directory, "*", SearchOption.AllDirectories)
				.Where(i => Regex.IsMatch(i, "\\.(?:java|kt|cs|css|txt|htm)$")).ToArray();
			foreach (var element in files) {
				element.WriteAllText(element.ReadAllText().Replace(find, replace));
			}
		}
		
		public static void OpenExecutableDirectory()
		{

			Process.Start("".GetCommandLinePath());
		}
		public static void OnClipboardString(Func<String,String> action)
		{
			
			try {
				var result =	action(Clipboard.GetText());
				if (!string.IsNullOrWhiteSpace(result))
					Clipboard.SetText(result);
			} catch (Exception ex) {
				
			}
		}
		
		public static void OnClipboardFileSystem(Action<String> action)
		{
			
			try {
				var path = Clipboard.GetText().Trim();
				if (Directory.Exists(path) || File.Exists(path))
					action(path);
				else {
					var collection = Clipboard.GetFileDropList();
					if (collection.Count > 0) {
						path = collection[0];
						action(path);
					}
				}
				
			} catch (Exception ex) {
				
			}
		}
	}
}