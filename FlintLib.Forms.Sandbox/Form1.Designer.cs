namespace FlintLib.Forms.Sandbox
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.integerTextBox1 = new FlintLib.Forms.IntegerTextBox();
			this.numericTextBox1 = new FlintLib.Forms.NumericTextBox();
			this.SuspendLayout();
			// 
			// integerTextBox1
			// 
			this.integerTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(156)))));
			this.integerTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(101)))), ((int)(((byte)(0)))));
			this.integerTextBox1.Location = new System.Drawing.Point(12, 12);
			this.integerTextBox1.Name = "integerTextBox1";
			this.integerTextBox1.Size = new System.Drawing.Size(100, 20);
			this.integerTextBox1.TabIndex = 0;
			this.integerTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.integerTextBox1.ValidateWhen = FlintLib.Forms.ValidationTriggers.FocusLost;
			// 
			// numericTextBox1
			// 
			this.numericTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(156)))));
			this.numericTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(101)))), ((int)(((byte)(0)))));
			this.numericTextBox1.Location = new System.Drawing.Point(12, 38);
			this.numericTextBox1.Name = "numericTextBox1";
			this.numericTextBox1.Size = new System.Drawing.Size(100, 20);
			this.numericTextBox1.TabIndex = 1;
			this.numericTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numericTextBox1.ValidateWhen = FlintLib.Forms.ValidationTriggers.FocusLost;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(288, 262);
			this.Controls.Add(this.numericTextBox1);
			this.Controls.Add(this.integerTextBox1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private IntegerTextBox integerTextBox1;
		private NumericTextBox numericTextBox1;
	}
}

