
using System;

namespace AndroidCodeGenerate
{
	using System.Collections;
	using System.Windows.Forms;
	using System;
	using System.IO;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Xml.Linq;
	using System.Text.RegularExpressions;
	using Helper;
	 
	public static class AndroidExtensions
	{
		
		public static string FormatSortJavaField(string value)
		{
			var lines = value.Split(Environment.NewLine.ToArray(), StringSplitOptions.RemoveEmptyEntries).Select(i => i.Trim()).ToList();
			lines.Sort(delegate(String x, String y) {
			           	
				if (x.Contains('=') && y.Contains('=')) {
					var xd = x.Split('=').Last().Trim();
					var yd = y.Split('=').Last().Trim();
					if (xd == yd) {
						return x.Split('=').First().Trim().Split(' ').Last().CompareTo(y.Split('=').First().Trim().Split(' ').Last());
					} else {
						return xd.CompareTo(yd);
					}
				} else if ((x.Contains('=') && !y.Contains('=')) ||
				          (y.Contains('=') && !x.Contains('='))) {
					return x.Split('=').First().Trim().Split(' ').Last().CompareTo(y.Split('=').First().Trim().Split(' ').Last());
				
				} else if (x.Contains(':') && y.Contains(':')) {
					var xd = x.Split(':').Last().Trim();
					var yd = y.Split(':').Last().Trim();
					if (xd == yd) {
						return x.Split(':').First().Trim().Split(' ').Last().CompareTo(y.Split(':').First().Trim().Split(' ').Last());
					} else {
						return xd.CompareTo(yd);
					}
				} else if ((x.Contains(':') && !y.Contains(':')) ||
				           (y.Contains(':') && !x.Contains(':')) ||
				           (!y.Contains(':') && !x.Contains(':'))) {
					return x.Split(':').First().Trim().Split(' ').Last().CompareTo(y.Split(':').First().Trim().Split(' ').Last());
				
				}
				return x.CompareTo(y);
			});
//			lines = lines.OrderBy(i => i.Split('=').First().Split(':').First().Trim().Split(' ').Last())
//				.ThenBy((i)=>{
//				        	return i.Split(':').Last().Trim();
//				        }).ToArray();
			
			
			return string.Join(Environment.NewLine, lines);
			
		}
		
		public static string ExtractJavaField(string value)
		{
			var ls = value.Split(Environment.NewLine.ToArray(), StringSplitOptions.RemoveEmptyEntries).Select(i => i.Trim()).Where(i => !i.StartsWith("//"));
		    	
			var list = new List<string>();
			foreach (var element in ls) {
				try {
					var	ex = element.Split(new char[]{ ';' }, 2).First();
					var tc = ex.Split(new char[]{ '=' }, 2).First().Trim().Split(' ');
					list.Add(tc[tc.Length - 1].Trim());
				} catch {
					
				}
			}
			return string.Join(Environment.NewLine, list.OrderBy(i => i));
		    	            
		
		}
		
		
		public static String GenerateLog(string value)
		{
			var lines = value.Split(Environment.NewLine.ToArray(), StringSplitOptions.RemoveEmptyEntries);
			var ls = new List<String>();
			foreach (var element in lines) {
				ls.Add(element);
				if (element.Contains("fun ") && element.Contains("(") && element.Contains("{")) {
					ls.Add(String.Format("Log.e(TAG,\"[{0}]\")", element.Split(new char[]{ '(' }, 2).First().Trim().Split(' ').Last()));
				}
			}
			return string.Join("\n", ls);
		}
			public static String GenerateTracker(string value)
		{
			var lines = value.Split(Environment.NewLine.ToArray(), StringSplitOptions.RemoveEmptyEntries);
			var ls = new List<String>();
			foreach (var element in lines) {
				ls.Add(element);
				if (element.Contains("fun ") && element.Contains("(") && element.Contains("{")) {
					ls.Add(String.Format("mTracker.e(\"[{0}]\")", element.Split(new char[]{ '(' }, 2).First().Trim().Split(' ').Last()));
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
		
		public static String FormatLog(string value)
		{
			var matches= Regex.Matches(Clipboard.GetText(), "\\b[a-zA-Z_0-9]+\\b").Cast<Match>().Select(i => i.Value).ToArray();
			var excludes=new []{"Int","it","until","TAG","null","in","Log","private","Boolean","let","var","val","fun","if","else","for","override","false","true","return","super"};
			var ls=new List<String>();
			foreach (var element in matches) {
				if(excludes.Contains(element)||ls.Contains(element)||Regex.IsMatch(element,"^[0-9]+$"))continue;
				ls.Add(element);
			}
			return string.Format("Log.e(TAG, \n{0}\n)",string.Join("\n+",ls.OrderBy(i=>i).Select(i=>string.Format("\"{0} ${{{0}}},\\n\"",i))));
//			var ls = Regex.Matches(Clipboard.GetText(), "(?<=var|val) +([0-9a-zA-Z_]+)").Cast<Match>().Select(i => i.Groups[1].Value);
//
//			ls = ls.Union(Regex.Matches(Clipboard.GetText(), "([0-9a-zA-Z_]+) *?(?:[%\\*\\-\\+/]*?\\=|\\:)").Cast<Match>().Select(i => i.Groups[1].Value)).Distinct();
//
//			var sb = new StringBuilder();
//			//sb.Append("Log.e(TAG,\"");
//			sb.Append("Log.e(TAG,\"");
////			sb.Append(Clipboard.GetText().Split(new[] { '(' }, 2).First().Split(' ').Last());
////			sb.Append("\",\"");
//
//			//
//			foreach (var item in ls) {
//				sb.Append(item + " => ${" + item + "} \\n");
//			}
//			sb.Append("\")");
//			return sb.ToString();
		}
		public static String FormatTracker(string value)
		{
			var ls = Regex.Matches(Clipboard.GetText(), "(?<=var|val) +([0-9a-zA-Z_]+)").Cast<Match>().Select(i => i.Groups[1].Value);

			ls = ls.Union(Regex.Matches(Clipboard.GetText(), "([0-9a-zA-Z_]+) *?(?:[%\\*\\-\\+/]*?\\=|\\:)").Cast<Match>().Select(i => i.Groups[1].Value)).Distinct();

			var sb = new StringBuilder();
			//sb.Append("Log.e(TAG,\"");
			sb.Append("mTracker.e(\"");
//			sb.Append(Clipboard.GetText().Split(new[] { '(' }, 2).First().Split(' ').Last());
//			sb.Append("\",\"");

			//
			foreach (var item in ls) {
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
					if (!x.StartsWith("m")) {
						x = "m" + x.Capitalize();
					}
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
					if (element.Contains(" final ")) {
						t = t.TrimEnd('?');
						
						
						list.Add(string.Format("private val {0}{1}", x, t));
						// list.Add(string.Format("private val {0}{1}", x, t.Split(':').First() + (string.IsNullOrWhiteSpace(t.Split(':').Last()) ? ":" + tc[tc.Length - 2].Trim().Capitalize() : "=" + t.Split(':').Last() + "()")));
						
						//list.Add(string.Format("private val {0}{1}", x, t.Split(':').First() + (string.IsNullOrWhiteSpace(t.Split(':').Last()) ? ":" + tc[tc.Length - 2].Trim().Capitalize() : "=" + t.Split(':').Last() + "()")));
					} else {
						//list.Add(string.Format("private val {0}{1}", x, t.TrimEnd('?')));
						
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
		public static String FormatJetBrainExportHtml(string fileName)
		{
			var hd = new HtmlAgilityPack.HtmlDocument();
			hd.LoadHtml(fileName.ReadAllText());
			var ls=	hd.DocumentNode.SelectNodes("//a").OrderBy(i=>{
			                                                   	if(i.GetAttributeValue("href","").EndsWith("index.html"))
			                                                   		return  ".";
			                                                   	else return i.GetAttributeValue("href","");
			                                                   }).Select(i=>i.OuterHtml+"<br>").ToArray();
			
			hd.DocumentNode.InnerHtml=string.Join(Environment.NewLine,ls);
			
			return hd.DocumentNode.OuterHtml;
				
		}
		public static string FormatStringBuilder(string value)
		{

			var listArray = new List<String>();
			var lsArray = new List<String>();
			
			listArray.Add("var sb = new StringBuilder();");

			var ls = value.Split('\n').Where(i => i.IsReadable());

			
			foreach (var item in ls) {
				listArray.Add(string.Format("sb.AppendLine({0});\r\n", (item + "\n").ToLiteral()));
				lsArray.Add(string.Format("sb.append({0});\r\n", (item + "\n").ToLiteral()));
			}

			return string.Join(Environment.NewLine, listArray) + Environment.NewLine + string.Join(Environment.NewLine, lsArray);
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
		
		public static String FormatProperties(string value){
		
            string[] lsr = null;
            var isFirst = false;
            if (Regex.IsMatch(value, "}\\s+(?:var|val)"))
            {
                isFirst = true;
                lsr = Regex.Split(value, "}\\s+(?=var\\s+|val\\s+)", RegexOptions.Multiline);

            }
            else
            {
                lsr = Regex.Split(value, "^\\s+(?=var\\s+|val\\s+)", RegexOptions.Multiline);
            }
            if (lsr.Any())
            {

                var result = lsr.Where(i => !string.IsNullOrWhiteSpace(i))
                    .OrderBy(i => i.Split(':').First().Split(' ').Last()).ToList();
                if (isFirst)
                {
                    result = result.Select(i => i + "}").ToList();
                }
                //.OrderBy(i => i.Trim().Split(new[] { ' ' }, 2).First()).Select(i =>
                // {
                //     i = i.Trim();
                //     if (!i.StartsWith("var ") && i.Contains("set("))
                //         return "var " + i;
                //     else if (!i.StartsWith("val ") && !i.Contains("set("))
                //         return "val " + i;
                //     else
                //         return i;
                // });

                return string.Join("\n", result);
            }

            return null;
		}
		public static String FormatDelegate(string value)
		{
			  
			var lines = value.Split(Environment.NewLine.ToArray(), StringSplitOptions.RemoveEmptyEntries);
			var singleItems = lines.Where(i => (i.StartsWith("val") || i.StartsWith("fun ") || i.StartsWith("private fun") || i.StartsWith("private val")) && i.Contains(") = ") && !i.EndsWith("{")).ToArray();
			var sss = lines.Except(singleItems).ToArray();
			var ls = Formatter.FormatMethodList(string.Join("\n", lines.Where(i => !singleItems.Contains(i)))).Select(i => i.Trim()).OrderBy(i => i.SubstringBefore("by").Trim().Split(' ').Last()).ToArray();

			return string.Join("\n", singleItems.OrderBy(i => i)) + "\n" + string.Join("\n", ls);
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
