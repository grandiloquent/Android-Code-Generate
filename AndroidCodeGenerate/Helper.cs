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
	public static class AndroidExtensions
	{
		public static String GenerateLog(string value)
		{
			var lines = value.Split(Environment.NewLine.ToArray(), StringSplitOptions.RemoveEmptyEntries);
			var ls = new List<String>();
			foreach (var element in lines) {
				ls.Add(element);
				if (element.Contains("fun ") && element.Contains("(") && element.Contains("{")) {
					ls.Add(String.Format("Log.e(TAG,\"{0}\")", element.Split(new char[]{ '(' }, 2).First().Trim().Split(' ').Last()));
				}
			}
			return string.Join("\n", ls);
		}
		public static string GenerateKotilinCompileCommand(string path)
		{
			var kotlin = @"C:\Program Files\Android\Android Studio\plugins\Kotlin\kotlinc\bin\kotlinc.bat";
			
			var jar = Directory.GetFiles(Path.GetDirectoryName(path), "*.jar");
			var sb = new List<String>();
			foreach (var element in jar) {
				sb.Add(Path.GetFileName(element));
			}
			
			return string.Format("\"{0}\" \"{1}\" -classpath \"{2}\" -include-runtime -d k.jar && java -jar k.jar", kotlin, path, string.Join(":", sb));
		}
		public static string FormatJavaParameterToKotlin(string value)
		{
			var parameters = value.Split(',').Select(i => i.Trim());
			var ls = new List<String>();
			foreach (var element in parameters) {
				var p = element.SubstringAfterLast(' ');
				var x = element.SubstringBeforeLast(' ');
				x = x.Split(' ').Last();
				if (x == "float") {
					x = "Float";
				} else if (x == "int") {
					x = "Int";
				} else if (x == "boolean") {
					x = "Boolean";
				}
				ls.Add(string.Format("{0}:{1}", p, x));
			    			
			}
			return string.Join(",", ls);
			    	
		}
		
		public static String FormatLog(string value){
			 var ls = Regex.Matches(Clipboard.GetText(), "(?<=var|val) +([0-9a-zA-Z_]+)").Cast<Match>().Select(i => i.Groups[1].Value);

            ls = ls.Union(Regex.Matches(Clipboard.GetText(), "([0-9a-zA-Z_]+) *?(?:[%\\*\\-\\+/]*?\\=|\\:)").Cast<Match>().Select(i => i.Groups[1].Value)).Distinct();

            var sb = new StringBuilder();
            //sb.Append("Log.e(TAG,\"");
            sb.Append("Log.e(\"");
            sb.Append(Clipboard.GetText().Split(new[] { '(' }, 2).First().Split(' ').Last());
            sb.Append("\",\"");

            //
            foreach (var item in ls)
            {
                sb.Append(item + " => ${" + item + "} \\n");
            }
            sb.Append("\")");
            return sb.ToString();
		}
		
		public static string FormatJavaFieldToKotlin(string value)
		{
			var ls = value.Split(Environment.NewLine.ToArray(), StringSplitOptions.RemoveEmptyEntries).Select(i => i.Trim()).Where(i => !i.StartsWith("//"));
		    	
			var list = new List<string>();
			foreach (var element in ls) {
				try {
					var	ex = element.Split(new char[]{ ';' }, 2).First();
					var tc = ex.Split(new char[]{ '=' }, 2).First().Trim().Split(' ');
					var t = tc[tc.Length - 2].Trim();
					var x = tc[tc.Length - 1].Trim();
					var v = "";
					if (ex.Contains("=")) {
						v = ex.Split(new char[]{ '=' }, 2).Last().Trim();
					} 
					if (t == "boolean") {
						v = "false";
						t = "";
					} else if (t == "int") {
						v = "0";
						t = "";
					} else if (t == "float") {
						v = "0.0f";
						t = "";
					} else if (t == "long") {
						v = "0L";
						t = "";
					} else if (t == "double") {
						v = "0D";
						t = "";
					}
		    		 
					if (string.IsNullOrWhiteSpace(v)) {
						v = "null";
					}
					if (!string.IsNullOrWhiteSpace(t)) {
						t = ":" + t + "?";
					}
					if (v.StartsWith("new ")) {
						v = v.Substring(4);
						t = "";
						list.Add(string.Format("private val {0}{1} = {2}", x, t, v));
						continue;
					}
					if (element.Contains(" final "))
						list.Add(string.Format("private val {0}{1}", x, t));
					else {
						list.Add(string.Format("private val {0}{1}", x, t.TrimEnd('?')));
						
						list.Add(string.Format("private var {0}{1} = {2}", x, t, v));
					}
				} catch {
				}
			}
			return string.Join(Environment.NewLine, list.OrderBy(i => i));
		    	            
		    		
//            var ls = value.Split(Environment.NewLine.ToArray(), StringSplitOptions.RemoveEmptyEntries).Where(i => !string.IsNullOrWhiteSpace(i));
//            var strings = new List<string>();
//            var declareStrings = new List<string>();
//
//            foreach (var item in ls)
//            {
//                var splited = item.Split('=').First().Trim().Split(' ');
//                var type = splited[splited.Length - 2];
//                type = type[0].ToString().ToUpper() + type.Substring(1);
//                var declare = splited.Last().TrimEnd(';');
//                if (declare[0] == 'm')
//                {
//                    declare = declare.Substring(1);
//                }
//                declare = declare[0].ToString().ToLower() + declare.Substring(1);
//                strings.Add(string.Format("var {0}:{1}?=null",declare,type));
//                declareStrings.Add(string.Format("var {0}:{1}?=null \n private set",declare,type));
//
//            }
//            return string.Join(",\n", strings.OrderBy(i => i)) + Environment.NewLine + Environment.NewLine + string.Join("\n", declareStrings.OrderBy(i => i));

		}
		public static string FormatStringBuilder(string value)
		{

			var listArray = new List<String>();
			var lsArray=new List<String>();
			
			listArray.Add("var sb = new StringBuilder();");

			var ls = value.Split('\n').Where(i=>i.IsReadable());

			
			foreach (var item in ls) {
				listArray.Add(string.Format("sb.AppendLine({0});\r\n", (item+"\n").ToLiteral()));
				lsArray.Add(string.Format("sb.append({0});\r\n", (item+"\n").ToLiteral()));
			}

			return string.Join(Environment.NewLine, listArray)+Environment.NewLine+string.Join(Environment.NewLine, lsArray);
		}
		public static String FormatJavaStaticFinalFieldToKotlin(string value)
		{
			var ls = Regex.Matches(value, "(?<=private|public|protected)([^\\=\n\r]*?)\\=([^;]*?);").Cast<Match>().ToList();
			var strings = new List<string>();

			foreach (var item in ls) {
				var name = item.Groups[1].Value.TrimEnd().Split(' ').Last();
				var v = item.Groups[2].Value;
				//var m="private";
				 
				strings.Add(string.Format("const val {0}={1}", name, v));
			}
			return string.Join("\n", strings.OrderBy(i => i));
		}
		public static String FormatSingleLine(string value)
		{
			return string.Join(Environment.NewLine,
				value.Split(Environment.NewLine.ToArray(), StringSplitOptions.RemoveEmptyEntries)
				.Select(i => i.Trim())
				.Distinct()
				.OrderBy(i => i));
				
		}
		public static String FormatSQLToConst(string value)
		{
			var tableName = value.Split(new char[]{ '(' }, 2).First().Trim().Split(' ').Last().Trim("`\"".ToArray());
			var fields = value.Split(new char[]{ '(' }, 2).Last().Split(new char[]{ ',' })
				.Select(i => i.Trim().Split(new char[]{ ' ' }, 2).First().Trim().Trim('`'));
			var ls = new List<String>();
			ls.Add(string.Format("private const val TABLE_NAME_{0} =\"{1}\"", tableName.ToUpper(), tableName));
			var parameter = "";
			foreach (var element in fields) {
				var declareName = "COLUMN_" + element.TrimStart('_').ToUpper();
				ls.Add(string.Format("private const val {0} =\"{1}\"", declareName, element));
				ls.Add(string.Format("contentValues.put({0}, {1})", declareName, element));
				parameter += element + ":String,";
			}
			return string.Join("\n", ls.OrderBy(i => i)) + "\n" + parameter;
		}
		public static String FormatAddPrivate(string value)
		{
			var lines = value.Split(Environment.NewLine.ToArray(), StringSplitOptions.RemoveEmptyEntries);
			var ls = new List<String>();
			foreach (var item in lines) {
				if (Regex.IsMatch(item.TrimStart(), "(?<=private|public)\\s+")) {
					ls.Add(item.Trim());
				} else {
					ls.Add("private " + item.Trim());
				}

			}
			return string.Join("\n", ls.OrderBy(i => i));
		}
		public static String FormatMenuItemToCode(string value)
		{
			
			var xd = XDocument.Parse(value);
			
			var items = xd.Descendants().Where(i => i.Name.LocalName == "item").ToArray();
			var ls1 = new List<String>();
			var ls2 = new List<String>();
			var ls3 = new List<String>();
			
			for (int i = 0; i < items.Length; i++) {
				var id = items[i].Attributes().First(iv => iv.Name.LocalName == "id").Value.Split('/').Last();
				ls1.Add(string.Format("findItem(R.id.{0}).isVisible = {1}", id, "false"));
				ls2.Add(string.Format("findItem(R.id.{0}).isVisible = {1}", id, "true"));
				
				ls3.Add(string.Format("R.id.{0} -> ", id));
			}
			
		 
			
			var sb = new StringBuilder();
			
			sb.AppendLine(string.Join(Environment.NewLine, ls1.OrderBy(i => i)));
			sb.AppendLine(string.Join(Environment.NewLine, ls2.OrderBy(i => i)));
			sb.AppendLine(string.Join(Environment.NewLine, ls3.OrderBy(i => i)));
			
			
			return sb.ToString();
			
		}
		
		public static String FormatFun(string value)
		{
			  
			var lines = value.Split(Environment.NewLine.ToArray(), StringSplitOptions.RemoveEmptyEntries);
			var singleItems = lines.Where(i => (i.StartsWith("val") || i.StartsWith("fun ") || i.StartsWith("private fun") || i.StartsWith("private val")) && i.Contains(") = ") && !i.EndsWith("{")).ToArray();
			var sss = lines.Except(singleItems).ToArray();
			var ls = Formatter.FormatMethodList(string.Join("\n", lines.Where(i => !singleItems.Contains(i)))).Select(i => i.Trim()).OrderBy(i => Regex.Match(i, "fun ([^\\(]*?)(?:\\()").Groups[1].Value).ToArray();

			return string.Join("\n", singleItems.OrderBy(i => i)) + "\n" + string.Join("\n", ls);
		}
	}
}