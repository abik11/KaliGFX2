using System;
using System.Windows.Forms;

namespace KaliGFX22
{
	public partial class WyborStalowki : Form
	{	
      //grubosc stalowki
		public float stalowka{
			get{return myStalowka;}
		} 
		float myStalowka = 0; 
		
		public WyborStalowki()
		{
			InitializeComponent();
		}
		
		void Button1Click(object sender, EventArgs e) //OK
		{
			this.DialogResult = DialogResult.OK;
			switch(comboBox1.SelectedIndex){
				case 0: myStalowka = 1; break; //Mitchel Round
				case 1: myStalowka = 0.3F; break; //Brause Cito Fein
				case 2: myStalowka = 2; break; //Fine
				case 3: myStalowka = 1.6666F; break; //Extra fine
				default: myStalowka = 1; break;
			}
		}
	}
}
