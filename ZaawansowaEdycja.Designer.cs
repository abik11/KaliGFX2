namespace KaliGFX22
{
	partial class ZaawansowaEdycja
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
         this.checkBox1 = new System.Windows.Forms.CheckBox();
         this.checkBox2 = new System.Windows.Forms.CheckBox();
         this.label1 = new System.Windows.Forms.Label();
         this.radioButton1 = new System.Windows.Forms.RadioButton();
         this.textBox1 = new System.Windows.Forms.TextBox();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.radioButton2 = new System.Windows.Forms.RadioButton();
         this.checkBox3 = new System.Windows.Forms.CheckBox();
         this.button1 = new System.Windows.Forms.Button();
         this.button2 = new System.Windows.Forms.Button();
         this.groupBox1.SuspendLayout();
         this.SuspendLayout();
         // 
         // checkBox1
         // 
         this.checkBox1.Location = new System.Drawing.Point(12, 12);
         this.checkBox1.Name = "checkBox1";
         this.checkBox1.Size = new System.Drawing.Size(175, 24);
         this.checkBox1.TabIndex = 0;
         this.checkBox1.Text = "Wygeneruj dane o arkuszu";
         this.checkBox1.UseVisualStyleBackColor = true;
         // 
         // checkBox2
         // 
         this.checkBox2.Location = new System.Drawing.Point(6, 19);
         this.checkBox2.Name = "checkBox2";
         this.checkBox2.Size = new System.Drawing.Size(58, 20);
         this.checkBox2.TabIndex = 0;
         this.checkBox2.Text = "Włącz";
         this.checkBox2.UseVisualStyleBackColor = true;
         this.checkBox2.CheckedChanged += new System.EventHandler(this.CheckBox2CheckedChanged);
         // 
         // label1
         // 
         this.label1.Enabled = false;
         this.label1.Location = new System.Drawing.Point(6, 42);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(89, 15);
         this.label1.TabIndex = 1;
         this.label1.Text = "Kąt nachylenia:";
         // 
         // radioButton1
         // 
         this.radioButton1.Checked = true;
         this.radioButton1.Enabled = false;
         this.radioButton1.Location = new System.Drawing.Point(101, 38);
         this.radioButton1.Name = "radioButton1";
         this.radioButton1.Size = new System.Drawing.Size(68, 21);
         this.radioButton1.TabIndex = 2;
         this.radioButton1.TabStop = true;
         this.radioButton1.Text = "domyślny";
         this.radioButton1.UseVisualStyleBackColor = true;
         // 
         // textBox1
         // 
         this.textBox1.Enabled = false;
         this.textBox1.Location = new System.Drawing.Point(168, 66);
         this.textBox1.Name = "textBox1";
         this.textBox1.Size = new System.Drawing.Size(68, 20);
         this.textBox1.TabIndex = 3;
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.radioButton2);
         this.groupBox1.Controls.Add(this.checkBox2);
         this.groupBox1.Controls.Add(this.textBox1);
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Controls.Add(this.radioButton1);
         this.groupBox1.Location = new System.Drawing.Point(12, 42);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(250, 98);
         this.groupBox1.TabIndex = 4;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Skośne linie pomocnicze";
         // 
         // radioButton2
         // 
         this.radioButton2.Enabled = false;
         this.radioButton2.Location = new System.Drawing.Point(101, 62);
         this.radioButton2.Name = "radioButton2";
         this.radioButton2.Size = new System.Drawing.Size(68, 24);
         this.radioButton2.TabIndex = 4;
         this.radioButton2.Text = "własny:";
         this.radioButton2.UseVisualStyleBackColor = true;
         this.radioButton2.CheckedChanged += new System.EventHandler(this.RadioButton2CheckedChanged);
         // 
         // checkBox3
         // 
         this.checkBox3.Location = new System.Drawing.Point(12, 146);
         this.checkBox3.Name = "checkBox3";
         this.checkBox3.Size = new System.Drawing.Size(154, 24);
         this.checkBox3.TabIndex = 5;
         this.checkBox3.Text = "Wygeneruj napis KaliGFX";
         this.checkBox3.UseVisualStyleBackColor = true;
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(57, 176);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(75, 23);
         this.button1.TabIndex = 6;
         this.button1.Text = "Zastosuj";
         this.button1.UseVisualStyleBackColor = true;
         this.button1.Click += new System.EventHandler(this.Button1Click);
         // 
         // button2
         // 
         this.button2.Location = new System.Drawing.Point(138, 176);
         this.button2.Name = "button2";
         this.button2.Size = new System.Drawing.Size(75, 23);
         this.button2.TabIndex = 7;
         this.button2.Text = "Zamknij";
         this.button2.UseVisualStyleBackColor = true;
         this.button2.Click += new System.EventHandler(this.Button2Click);
         // 
         // ZaawansowaEdycja
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(273, 207);
         this.Controls.Add(this.button2);
         this.Controls.Add(this.button1);
         this.Controls.Add(this.checkBox3);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.checkBox1);
         this.MaximizeBox = false;
         this.MaximumSize = new System.Drawing.Size(289, 246);
         this.MinimumSize = new System.Drawing.Size(289, 246);
         this.Name = "ZaawansowaEdycja";
         this.ShowIcon = false;
         this.Text = "Zaawansowana edycja";
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.ResumeLayout(false);

		}
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.CheckBox checkBox3;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.CheckBox checkBox1;
	}
}
