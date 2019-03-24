namespace KaliGFX22
{
	partial class WyborStalowki
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
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
         this.label1 = new System.Windows.Forms.Label();
         this.button1 = new System.Windows.Forms.Button();
         this.comboBox1 = new System.Windows.Forms.ComboBox();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.Location = new System.Drawing.Point(12, 9);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(90, 16);
         this.label1.TabIndex = 0;
         this.label1.Text = "Rodzaj stalówki:";
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(78, 31);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(75, 23);
         this.button1.TabIndex = 2;
         this.button1.Text = "OK";
         this.button1.UseVisualStyleBackColor = true;
         this.button1.Click += new System.EventHandler(this.Button1Click);
         // 
         // comboBox1
         // 
         this.comboBox1.FormattingEnabled = true;
         this.comboBox1.Items.AddRange(new object[] {
            "Mitchel Round",
            "Brause Cito Fein",
            "F (fine)",
            "XF (extra fine)"});
         this.comboBox1.Location = new System.Drawing.Point(96, 4);
         this.comboBox1.Name = "comboBox1";
         this.comboBox1.Size = new System.Drawing.Size(121, 21);
         this.comboBox1.TabIndex = 3;
         // 
         // WyborStalowki
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(230, 61);
         this.Controls.Add(this.comboBox1);
         this.Controls.Add(this.button1);
         this.Controls.Add(this.label1);
         this.MaximizeBox = false;
         this.MaximumSize = new System.Drawing.Size(246, 100);
         this.MinimumSize = new System.Drawing.Size(246, 100);
         this.Name = "WyborStalowki";
         this.ShowIcon = false;
         this.Text = "Wybor stalowki";
         this.ResumeLayout(false);

		}
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
	}
}
