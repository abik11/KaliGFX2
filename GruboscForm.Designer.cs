﻿namespace KaliGFX22
{
	partial class GruboscForm
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
         this.comboBox1 = new System.Windows.Forms.ComboBox();
         this.button1 = new System.Windows.Forms.Button();
         this.label2 = new System.Windows.Forms.Label();
         this.comboBox2 = new System.Windows.Forms.ComboBox();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.Location = new System.Drawing.Point(12, 9);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(73, 16);
         this.label1.TabIndex = 0;
         this.label1.Text = "Grubość linii:";
         // 
         // comboBox1
         // 
         this.comboBox1.FormattingEnabled = true;
         this.comboBox1.Items.AddRange(new object[] {
            "Normalna",
            "Pogrubiona",
            "Silnie pogrubiona",
            "Bardzo silnie pogrubiona"});
         this.comboBox1.Location = new System.Drawing.Point(91, 6);
         this.comboBox1.Name = "comboBox1";
         this.comboBox1.Size = new System.Drawing.Size(119, 21);
         this.comboBox1.TabIndex = 1;
         this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1SelectedIndexChanged);
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(73, 63);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(75, 23);
         this.button1.TabIndex = 6;
         this.button1.Text = "OK";
         this.button1.UseVisualStyleBackColor = true;
         this.button1.Click += new System.EventHandler(this.Button1Click);
         // 
         // label2
         // 
         this.label2.Enabled = false;
         this.label2.Location = new System.Drawing.Point(12, 36);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(73, 17);
         this.label2.TabIndex = 7;
         this.label2.Text = "Pogrub linie:";
         // 
         // comboBox2
         // 
         this.comboBox2.Enabled = false;
         this.comboBox2.FormattingEnabled = true;
         this.comboBox2.Items.AddRange(new object[] {
            "Tylko bazową",
            "Środkowe",
            "Wszystkie"});
         this.comboBox2.Location = new System.Drawing.Point(91, 36);
         this.comboBox2.Name = "comboBox2";
         this.comboBox2.Size = new System.Drawing.Size(119, 21);
         this.comboBox2.TabIndex = 8;
         // 
         // GruboscForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(224, 96);
         this.Controls.Add(this.comboBox2);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.button1);
         this.Controls.Add(this.comboBox1);
         this.Controls.Add(this.label1);
         this.MaximizeBox = false;
         this.MaximumSize = new System.Drawing.Size(240, 135);
         this.MinimumSize = new System.Drawing.Size(240, 135);
         this.Name = "GruboscForm";
         this.ShowIcon = false;
         this.Text = "Grubość linii";
         this.ResumeLayout(false);

		}
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label1;
	}
}
