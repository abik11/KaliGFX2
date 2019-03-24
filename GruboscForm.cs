using System;
using System.Windows.Forms;

namespace KaliGFX22
{
	public partial class GruboscForm : Form
	{	
      //grubosc linii
		int myGrubosc = 1;
		public int grubosc{
			get{return myGrubosc;}
		}
		//jakie linie pogrubic: 0-bazowa, 1-srodkowe, 2-wszystkie
		int myCopogrubic = 0;
		public int copogrubic{
			get{return myCopogrubic;}
		}
		
		public GruboscForm()
		{
			InitializeComponent();
		}
		
		public GruboscForm(int grubosc, int coPogrubic)
		{
			InitializeComponent();			
			this.comboBox1.SelectedIndex = grubosc-1;
			this.comboBox2.SelectedIndex = coPogrubic;
		}
		
		void Button1Click(object sender, EventArgs e) //OK
		{
			this.DialogResult = DialogResult.OK;
			myGrubosc = comboBox1.SelectedIndex + 1; //grubosc +1 bo nie moze byc zerowa!
			myCopogrubic = comboBox2.SelectedIndex; //wybor tego co ma byc pogrubione
		}
		
		void ComboBox1SelectedIndexChanged(object sender, EventArgs e) //Wybor grubosci linii
		{
			if(comboBox1.SelectedIndex != 0){ comboBox2.Enabled = true; //wlaczamy mozliwosc wyboru
												label2.Enabled = true; } //tego co ma byc pogrubione
			if(comboBox1.SelectedIndex == 0){ comboBox2.Enabled = false; //wylaczamy mozliwosc wyboru
											 	label2.Enabled = false; } //tego co ma byc pogrubione
		}																 //bo grubosc 0 czyli brak pogrubienia
	}
}
