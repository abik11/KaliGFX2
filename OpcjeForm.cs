using System;
using System.Windows.Forms;
using System.IO;

namespace KaliGFX22
{
	public partial class OpcjeForm : Form
	{	
      //czy wlaczyc message boxy
		bool myMsgon;
		public bool msgOn{
			get{return myMsgon;}
		}
		//czy ustawic opacity dla wszystkich okien czy tylko dla glownego
		bool myOpacityall; 
		public bool opacityAll{
			get{return myOpacityall;}
		}
		//czy opcje okien dialogowych maja byc zachowywane
		bool myZachowajopcje;
		public bool zachowajOpcje{
			get{return myZachowajopcje;}
		}
		
		int tmpopacity=100;
		
		public OpcjeForm()
		{
			InitializeComponent();
		}
		
		public OpcjeForm(bool msgOn, bool opacityAll, bool zachowajOpcje, int tmpopacity)
		{
			InitializeComponent();
			this.tmpopacity = tmpopacity;
			
			if(msgOn) radioButton1.Checked = true;
			else radioButton2.Checked = true;
			
			if(opacityAll) checkBox1.Checked = true;
			else checkBox1.Checked = false;
			
			if(zachowajOpcje) checkBox2.Checked = true;
			else checkBox2.Checked = false;
		}
		
		//zdarzenia----------------------------------------------------------------------------------
		void OpcjeLoad(object sender, EventArgs e)
		{	
         //odpowiednie ustawienie interfejsu
			trackBar1.Maximum = 100; //maksymalna wartosc trackBara
			trackBar1.Minimum = 30; //nie od 0 zeby okno nie zniklo
			trackBar1.Value = tmpopacity;
		}
		
		void Button2Click(object sender, EventArgs e) //anuluj
		{
			this.DialogResult = DialogResult.Cancel;
		}
		
		void Button1Click(object sender, EventArgs e) //zastosuj
		{
			this.DialogResult = DialogResult.OK;
			this.Opacity = trackBar1.Value * 0.01; //opacity moze miec wartosc od 0 do 1
			
			if(radioButton1.Checked) myMsgon = true;
			else myMsgon = false;
			if(checkBox1.Checked) myOpacityall = false;
			else myOpacityall = true;
			if(checkBox2.Checked) myZachowajopcje = true;
			else myZachowajopcje = false;
			
			//automatyczny zapis opcji do pliku kgfx.conf
			StreamWriter SW = null;
			try{
				SW = new StreamWriter("kgfx.conf");
				SW.WriteLine(myMsgon ? "1" : "0");
				SW.WriteLine(myOpacityall ? "1" : "0");
				SW.WriteLine(myZachowajopcje ? "1" : "0");
				SW.WriteLine((this.Opacity*100).ToString());
			}
			catch(IOException){
				MessageBox.Show("Nie można uzyskać dostępu do pliku kgfx.conf");
			}
			finally{
				SW.Close();
			}
		}
	}
}
