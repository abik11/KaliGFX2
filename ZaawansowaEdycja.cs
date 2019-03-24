using System;
using System.Windows.Forms;

namespace KaliGFX22
{
	public partial class ZaawansowaEdycja : Form
	{	
      //czy wypisac duzy napis KaliGFX na arkuszu
		bool myKgfx; 
		public bool kgfx{
			get{return myKgfx;}
		}
		//czy wypisac konfiguracje arkusza na nim samym
		bool myDane; 
		public bool dane{
			get{return myDane;}
		}
		//czy rysowac skosne linie pomocnicze
		bool myPomocnicze; 
		public bool pomocnicze{
			get{return myPomocnicze;}
		}
		//czy linie pomocnicze maja miec domyslny kat nachylenia
		bool myDomyslne; 
		public bool domyslne{
			get{return myDomyslne;}
		}
		//jaki kat maja miec linie pomocnicze (jesli inny niz domyslny)	
		int myKat;
		public int kat{
			get{return myKat;}
		}
				
		public ZaawansowaEdycja()
		{
			InitializeComponent();
		}
		
		public ZaawansowaEdycja(bool kgfx, bool dane, bool pomocnicze, bool domyslne, int kat)
		{
			InitializeComponent();
			if(kgfx) checkBox3.Checked = true;
			else checkBox3.Checked = false;
			
			if(dane) checkBox1.Checked = true;
			else checkBox1.Checked = false;
			
			if(pomocnicze) checkBox2.Checked = true;
			else checkBox2.Checked = false;
			
			if(domyslne) radioButton1.Checked = true;
			else radioButton2.Checked = true;
						
			textBox1.Text = kat.ToString();
		}
		
		void CheckBox2CheckedChanged(object sender, EventArgs e) //wlaczanie linii pomocniczych
		{
			if(checkBox2.Checked){ //odblokowanie opcji linii pomocniczych
				label1.Enabled = true;
				radioButton1.Enabled = true;
				radioButton2.Enabled = true;
			}			
			if(!checkBox2.Checked){ //zablokowanie opcji linii pomocniczych
				label1.Enabled = false;
				radioButton1.Enabled = false;
				radioButton2.Enabled = false;
			}
			
		}
		
		void Button2Click(object sender, EventArgs e) //Anuluj
		{
			this.DialogResult = DialogResult.Cancel;
		}
		
		void Button1Click(object sender, EventArgs e) //Zastosuj
		{
			this.DialogResult = DialogResult.OK;
			if(checkBox1.Checked) myDane = true;
			else myDane = false;
			if(checkBox3.Checked) myKgfx = true;
			else myKgfx = false;
			if(checkBox2.Checked) myPomocnicze = true;
			else myPomocnicze = false;
			if(radioButton1.Checked) myDomyslne = true;
			else{ 
				myDomyslne = false;
				if(textBox1.Text != String.Empty){
					try{
						myKat = Int32.Parse(textBox1.Text); //pobranie wartosci kata
					}
					catch(FormatException){
						MessageBox.Show("Błędna wartość kąta nachylenia!", "Błędna wartość", 
						                MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
					if(myKat<0 || myKat>360){
						MessageBox.Show("Kąt należy podać w stopniach od 0 do 360!", "Błędna wartość",
						                MessageBoxButtons.OK, MessageBoxIcon.Warning);
						myDomyslne = true;
					}
				}
				else
					myDomyslne = true;
			}
		}
		
		void RadioButton2CheckedChanged(object sender, EventArgs e) //kat domyslny lub wlasny
		{
			if(radioButton2.Checked) textBox1.Enabled = true; //wlasny
			if(!radioButton2.Checked) textBox1.Enabled = false; //domyslny
		}
	}
}
