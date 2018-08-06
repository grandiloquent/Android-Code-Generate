/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2018/7/30
 * Time: 2:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CodePreview
{
	partial class CodePreviewForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TextBox textBox1;
		
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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox1.Font = new System.Drawing.Font("Consolas", 11F);
			this.textBox1.Location = new System.Drawing.Point(0, 0);
			this.textBox1.MaxLength = 32767000;
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox1.Size = new System.Drawing.Size(918, 294);
			this.textBox1.TabIndex = 0;
			this.textBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TextBox1MouseDoubleClick);
			// 
			// CodePreviewForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(918, 294);
			this.Controls.Add(this.textBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "CodePreviewForm";
			this.Text = "CodePreviewForm";
			this.TopMost = true;
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
