
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CodePreview
{

	public partial class CodePreviewForm : Form
	{
		public CodePreviewForm()
		{
			
			InitializeComponent();
			
		}
		void TextBox1MouseDoubleClick(object sender, MouseEventArgs e)
		{
	  textBox1.SelectAll();
            textBox1.Paste();
            var blockComments = @"/\*(.*?)\*/";
            var lineComments = @"//(.*?)\r?\n";
            var strings = @"""((\\[^\n]|[^""\n])*)""";
            var verbatimStrings = @"@(""[^""]*"")+";
   
            string noComments = Regex.Replace(textBox1.Text,
    blockComments + "|" + lineComments + "|" + strings + "|" + verbatimStrings,
    me =>
    {
        if (me.Value.StartsWith("/*") || me.Value.StartsWith("//"))
            return me.Value.StartsWith("//") ? Environment.NewLine : "";
        // Keep the literal strings
        return me.Value;
    },
    RegexOptions.Singleline);
            textBox1.Text = Regex.Replace(noComments, "[\r\n]+", Environment.NewLine);
		}
	}
}
