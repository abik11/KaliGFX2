namespace KaliGFX22
{
	partial class OpcjeForm
	{
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
         this.trackBar1 = new System.Windows.Forms.TrackBar();
         this.button1 = new System.Windows.Forms.Button();
         this.button2 = new System.Windows.Forms.Button();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.checkBox1 = new System.Windows.Forms.CheckBox();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.radioButton2 = new System.Windows.Forms.RadioButton();
         this.radioButton1 = new System.Windows.Forms.RadioButton();
         this.checkBox2 = new System.Windows.Forms.CheckBox();
         ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
         this.groupBox1.SuspendLayout();
         this.groupBox2.SuspendLayout();
         this.SuspendLayout();
         // 
         // trackBar1
         // 
         this.trackBar1.Location = new System.Drawing.Point(6, 17);
         this.trackBar1.Name = "trackBar1";
         this.trackBar1.Size = new System.Drawing.Size(168, 45);
         this.trackBar1.TabIndex = 0;
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(19, 236);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(75, 23);
         this.button1.TabIndex = 2;
         this.button1.Text = "Zastosuj";
         this.button1.UseVisualStyleBackColor = true;
         this.button1.Click += new System.EventHandler(this.Button1Click);
         // 
         // button2
         // 
         this.button2.Location = new System.Drawing.Point(111, 236);
         this.button2.Name = "button2";
         this.button2.Size = new System.Drawing.Size(75, 23);
         this.button2.TabIndex = 3;
         this.button2.Text = "Zamknij";
         this.button2.UseVisualStyleBackColor = true;
         this.button2.Click += new System.EventHandler(this.Button2Click);
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.checkBox1);
         this.groupBox1.Controls.Add(this.trackBar1);
         this.groupBox1.Location = new System.Drawing.Point(12, 12);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(182, 90);
         this.groupBox1.TabIndex = 5;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Przezroczystość";
         // 
         // checkBox1
         // 
         this.checkBox1.Location = new System.Drawing.Point(7, 56);
         this.checkBox1.Name = "checkBox1";
         this.checkBox1.Size = new System.Drawing.Size(167, 24);
         this.checkBox1.TabIndex = 1;
         this.checkBox1.Text = "Tylko dla okna głównego";
         this.checkBox1.UseVisualStyleBackColor = true;
         // 
         // groupBox2
         // 
         this.groupBox2.Controls.Add(this.radioButton2);
         this.groupBox2.Controls.Add(this.radioButton1);
         this.groupBox2.Location = new System.Drawing.Point(12, 108);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(182, 81);
         this.groupBox2.TabIndex = 6;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "Forma ostrzeżeń";
         // 
         // radioButton2
         // 
         this.radioButton2.Location = new System.Drawing.Point(6, 49);
         this.radioButton2.Name = "radioButton2";
         this.radioButton2.Size = new System.Drawing.Size(170, 24);
         this.radioButton2.TabIndex = 1;
         this.radioButton2.TabStop = true;
         this.radioButton2.Text = "Komunikaty w oknie głównym";
         this.radioButton2.UseVisualStyleBackColor = true;
         // 
         // radioButton1
         // 
         this.radioButton1.Location = new System.Drawing.Point(6, 19);
         this.radioButton1.Name = "radioButton1";
         this.radioButton1.Size = new System.Drawing.Size(146, 24);
         this.radioButton1.TabIndex = 0;
         this.radioButton1.TabStop = true;
         this.radioButton1.Text = "Wyskakujące okienka";
         this.radioButton1.UseVisualStyleBackColor = true;
         // 
         // checkBox2
         // 
         this.checkBox2.Location = new System.Drawing.Point(12, 195);
         this.checkBox2.Name = "checkBox2";
         this.checkBox2.Size = new System.Drawing.Size(182, 35);
         this.checkBox2.TabIndex = 7;
         this.checkBox2.Text = "Zachowaj ustawienia okien dialogowych";
         this.checkBox2.UseVisualStyleBackColor = true;
         // 
         // OpcjeForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(208, 271);
         this.Controls.Add(this.checkBox2);
         this.Controls.Add(this.groupBox2);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.button2);
         this.Controls.Add(this.button1);
         this.MaximizeBox = false;
         this.MaximumSize = new System.Drawing.Size(224, 310);
         this.MinimumSize = new System.Drawing.Size(224, 310);
         this.Name = "OpcjeForm";
         this.ShowIcon = false;
         this.Text = "Opcje widoku";
         this.Load += new System.EventHandler(this.OpcjeLoad);
         ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.groupBox2.ResumeLayout(false);
         this.ResumeLayout(false);

		}
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TrackBar trackBar1;
	}
}
