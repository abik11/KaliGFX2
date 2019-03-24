using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;

namespace KaliGFX22
{
	public partial class MainForm : Form
	{	
		//opcje obrazu
		bool ok = true, usunMarginesy=true;
		int interlinia=0, kroj=0, orient=0, format=0;
				
		Obraz obraz;
		bool zapisany = true;
		Color kolor = Color.Black;
		int grubosc = 1;
		int copogrubic = 0;
		float stalowka=0;
		//zaawansowane opcje obrazu
		bool kgfx = false;
		bool dane = false;
		bool pomocnicze = false;
		bool domyslne = true;
		int kat = 0;
		
		//opcje okna
		bool opacityAll;// = false;
		bool msgOn;// = false;
		bool zachowajOpcje;// = true;
		
		public MainForm()
		{
			InitializeComponent();
		}
		
		void zapiszObraz() //zapisywanie obrazu
		{
			zapisany = true;
			saveFileDialog1.ShowDialog();
			string plik = saveFileDialog1.FileName;
			obraz.zapisz(plik);
		}
		
		void zapiszStary(string pytanie, string tytul) //sprawdzanie czy zaszly jakies zmiany
		{												//w obrazie od ostatniego zapisu
			if(!zapisany)
         {
				DialogResult odpowiedz = MessageBox.Show(pytanie, tytul, 
				                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
				if(odpowiedz == DialogResult.Yes)
					zapiszObraz();
				obraz.zakoncz();
			}			
		}
		
		void nowyObraz() //resetowanie interfejsu uzytkownika
		{
			zapiszStary("Chcesz zapisać aktualny obraz przed utworzeniem nowego?", "Utwórz nowy obraz");
			
			label5.Text = "";
			pictureBox1.Image = null;
			textBox2.Text = "";
			textBox1.Text = "";
			
			checkBox2.Enabled = false;
			button2.Enabled = false;				
			zapiszJakoToolStripMenuItem.Enabled = false;
			eksportujToolStripMenuItem.Enabled = false;
			drukujToolStripMenuItem.Enabled = false;			
			printToolStripButton.Enabled = false;
			saveToolStripButton.Enabled = false;	
			openToolStripButton.Enabled = false;
			comboBox1.SelectedIndex = 0;
			comboBox2.SelectedIndex = 0;
			comboBox3.SelectedIndex = 0;	
			checkBox1.Checked = true;
		}
		
		void importujObraz() //importowanie wlasciwosci arkusza z pliku KGFX
		{
			zapiszStary("Chcesz zapisać aktualny obraz przed zaimportowaniem nowego?", "Importuj obraz");
			
			checkBox2.Enabled = false;
			checkBox2.Checked = false;
			pictureBox1.Image = null;
			obraz = null;
			
			openFileDialog1.Filter = "KaliGFX (*.kgfx)|*.kgfx";
			openFileDialog1.FileName = "";
			openFileDialog1.ShowDialog();
			string plik = openFileDialog1.FileName;
			
			if(plik != String.Empty)
         {
				StreamReader SR = new StreamReader(plik);
				try{
					stalowka = Int32.Parse(SR.ReadLine());
					textBox1.Text = stalowka.ToString();
					
					interlinia = Int32.Parse(SR.ReadLine());
					textBox2.Text = interlinia.ToString();
					
					kroj = Int32.Parse(SR.ReadLine());
					if(kroj<0) kroj = 0;
					if(kroj>4) kroj = 4;
					comboBox3.SelectedIndex = kroj;
					
					orient = Int32.Parse(SR.ReadLine());
					if(orient<0) orient = 0;
					if(orient>1) orient = 1;
					comboBox1.SelectedIndex = orient;
					
					format = Int32.Parse(SR.ReadLine());
					if(format<0) format = 0;
					if(format>4) format = 4;
					comboBox2.SelectedIndex = format;
					
					usunMarginesy = (Int32.Parse(SR.ReadLine())==0 ? false : true);
					if(usunMarginesy) checkBox1.Checked = true;
					else checkBox1.Checked = false;
					
					kolor = Color.FromArgb(Int32.Parse(SR.ReadLine()));
					
					grubosc = Int32.Parse(SR.ReadLine());
					if(grubosc<1) grubosc = 1;
					if(grubosc>4) grubosc = 4;
					
					copogrubic = (Int32.Parse(SR.ReadLine()));
					if(copogrubic<0) copogrubic = 0;
					if(copogrubic>2) copogrubic = 2;
					
					kgfx = (Int32.Parse(SR.ReadLine())==0 ? false : true);
					dane = (Int32.Parse(SR.ReadLine())==0 ? false : true);
					pomocnicze = (Int32.Parse(SR.ReadLine())==0 ? false : true);
					domyslne = (Int32.Parse(SR.ReadLine())==0 ? false : true);
					
					kat = Int32.Parse(SR.ReadLine());
					if(kat<0) kat = 0;
					if(kat>360) kat = 360;
				} 
				catch(FormatException)
            {
					label5.ForeColor = Color.Red;
					if(!msgOn) label5.Text = "Plik KGFX jest uszkodzony, dane są niepełne! Nie można zaimportować pliku!";
					else MessageBox.Show("Plik KGFX jest uszkodzony, dane są niepełne! Nie można zaimportować pliku!", 
					                     "Uszkodzony plik", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
				catch(Exception)
            {
					label5.ForeColor = Color.Red;
					if(!msgOn) label5.Text = "Nie można otworzyć pliku KGFX! Najprawdopodobniej jest on uszkodzony, nieistnieje lub nie posiadasz uprawnień do jego odczytu.";
					else MessageBox.Show("Nie można otworzyć pliku KGFX! Najprawdopodobniej jest on uszkodzony, nieistnieje lub nie posiadasz uprawnień do jego odczytu.", 
					                     "Uszkodzony plik", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
				SR.Close();
			}
		}
		
		void eksportujObraz() //eksportowanie wlasciwosci pliku do pliku KGFX
		{
			saveFileDialog1.Filter = "KaliGFX (*.kgfx)|*.kgfx";
			saveFileDialog1.ShowDialog();
			string plik = saveFileDialog1.FileName;
			if(plik.Split('.').Length == 1) //sprawdzanie czy podano rozszerzenie
				plik+=".kgfx";				//w nazwie czy nie
			StreamWriter SW = File.CreateText(plik);
			SW.Write(obraz.pobierzDane());
			SW.Close();
		}
		
		void edycja()
      { 
         //wsywietlanie i obsluga okna dialogowe zaawansowanych opcji arkusza
			ZaawansowaEdycja zEdycja = null;
			if(zachowajOpcje) zEdycja = new ZaawansowaEdycja(kgfx, dane, pomocnicze, domyslne, kat);
			else zEdycja = new ZaawansowaEdycja();
			zEdycja.ShowDialog();
			this.kgfx = zEdycja.kgfx; this.dane = zEdycja.dane;
			this.pomocnicze = zEdycja.pomocnicze;
			this.domyslne = zEdycja.domyslne; this.kat = zEdycja.kat;
		}
		
		//zdarzenia--------------------------------------------------------------------------------
		void MainFormLoad(object sender, EventArgs e)
		{	
         //wyzerowanie wsystkich comboBoxow
			comboBox1.SelectedIndex = 0;
			comboBox2.SelectedIndex = 0;
			comboBox3.SelectedIndex = 0;
			
			//automatyczne wczytanie opcji z pliku kgfx.conf
			StreamReader SR = null;
			if(File.Exists("kgfx.conf")){
				SR = new StreamReader("kgfx.conf");
				try{
					msgOn = Int32.Parse(SR.ReadLine())==1 ? true : false;
					opacityAll = Int32.Parse(SR.ReadLine())==1 ? true : false;
					zachowajOpcje = Int32.Parse(SR.ReadLine())==1 ? true : false;
					this.Opacity = Int32.Parse(SR.ReadLine())*0.01;
				}
				catch(FormatException){
					msgOn = false; opacityAll = false; zachowajOpcje = false; this.Opacity = 1;
				}
				finally{
					SR.Close();
				}
			}
			
			if (msgOn) label5.Visible = false;
		}
		
		void Button1Click(object sender, EventArgs e) //GENERUJ
		{	//poczatkowe ustawenie interfejsu			
			label5.ForeColor = Color.Red;
			label5.Text = String.Empty;
			textBox1.BackColor = Color.White;
			textBox2.BackColor = Color.White;
			ok = true;
						
			//ustalanie grubosci stalowki---------------------------------------------
			if(textBox1.Text != String.Empty){ //jesli podano jakas wartosc stalowki
				try{
					stalowka =  float.Parse(textBox1.Text);
				} catch(System.FormatException){ //jesli stalowka nie jest liczba
					ok = false; //blokowanie generacji pliku
					if(!msgOn) label5.Text = "Szerokość stalówki musi być liczbą!";
					else MessageBox.Show("Szerokość stalówki musi być liczbą!", "Niepoprawna szerokość stalówki",
					                     MessageBoxButtons.OK, MessageBoxIcon.Warning);
					textBox1.BackColor = Color.OrangeRed;
				}
				if(stalowka<0){ //jesli stalowka ma wartosc mniejsza od zera
					ok=false; //blokowanie generacji pliku
					if(!msgOn){
						if(label5.Text==String.Empty)
							label5.Text = "Stalowka nie może mieć ujemnej szerokości!";
						else
							label5.Text += "\nStalowka nie może mieć ujemnej szerokości!";
						stalowka = 0;
					}
					else MessageBox.Show("Stalowka nie może mieć ujemnej szerokości!", "Niepoprawna szerokość stalówki",
					                     MessageBoxButtons.OK, MessageBoxIcon.Warning);
					textBox1.BackColor = Color.OrangeRed;
				}
			}
			else{ //jeslo nie podano zadnej wartosci stalowki
				ok = false; //blokowanie generacji pliku 
				if(!msgOn){
					if(label5.Text==String.Empty)
						label5.Text = "Nie podano grubości stalówki!";
					else
						label5.Text += "\nNie podano grubości stalówki!";
				}
				else MessageBox.Show("Nie podano grubości stalówki!", "Niepoprawna szerokość stalówki",
					                     MessageBoxButtons.OK, MessageBoxIcon.Warning);
				textBox1.BackColor = Color.OrangeRed;
			}
			
			//ustalanie grubosci interlinii----------------------------------------------
			if(textBox2.Text != String.Empty){ //jesli podano jakas wartosc interlinii
				try{
					interlinia = Int32.Parse(textBox2.Text);
				} catch(System.FormatException){ //jesli interlinia nie jest liczba
					ok = false; //blokada generacji pliku
					if(!msgOn) label5.Text = "Wielkość interlinii musi być liczbą!";
					else MessageBox.Show("Wielkość interlinii musi być liczbą!", "Niepoprawna wielkość interlinii",
					                     MessageBoxButtons.OK, MessageBoxIcon.Warning);
					textBox2.BackColor = Color.OrangeRed;
				}
				if(interlinia<0){ //jesli interlinia jest mniejsza od zera
					ok=false; //blokada generacji pliku
					if(!msgOn){
						if(label5.Text==String.Empty)
							label5.Text = "Interlinia nie może mieć ujemnej szerokości!";
						else
							label5.Text += "\nInterlinia nie może mieć ujemnej szerokości!";
						interlinia = 0;
					}
					else MessageBox.Show("Interlinia nie może mieć ujemnej szerokości!", "Niepoprawna wielkość interlinii",
					                     MessageBoxButtons.OK, MessageBoxIcon.Warning);
					textBox2.BackColor = Color.OrangeRed;
				}
			}
			else{ //jesli nie podano zadnej wartosci interlinii
				if(ok){
					if(comboBox3.SelectedIndex == 4) //jesli skrypt spenserski
						interlinia = (int) stalowka;
					else
						interlinia = 2*(int)stalowka; //jesli inny kroj
					textBox2.Text = interlinia.ToString();
					
					if(!msgOn){ 
						if(label5.Text==String.Empty)
							label5.Text = "Skorzystano z domyślnej wartości interlinii.";	
						else
							label5.Text += "\nSkorzystano z domyślnej wartości interlinii.";
					}
					else MessageBox.Show("Skorzystano z domyślnej wartości interlinii.", "Domyślna interlinia",
					                     MessageBoxButtons.OK, MessageBoxIcon.Information);
					textBox2.BackColor = Color.Azure;
				}
			}
			
			//usuwanie lub nie marginesow------------------------------------------------
			if(checkBox1.Checked) usunMarginesy = true;
			else usunMarginesy = false;
			
			//ustalenie kroju czcionki---------------------------------------------------
			switch(comboBox3.SelectedIndex)
			{
				case 0: kroj=0; break; //KaliGFX
				case 1: kroj=1; break; //Unicjala
				case 2: kroj=2; break; //Italika
				case 3: kroj=3; break; //Pisanka angielska
				case 4: kroj=4; break; //Skrypt spenserski
				default: kroj=0; break; //KaliGFX
			}
			
			//orientacja linii------------------------------------------------------------
			if(comboBox1.SelectedIndex==0) orient = 0; //linie poziome
			else orient=1; //linie pionowe
			
			//format generowanego pliku---------------------------------------------------
			switch(comboBox2.SelectedIndex){
				case 0: format=0; break; //BMP
				case 1: format=1; break; //PNG
				case 2: format=2; break; //JPG
				case 3: format=3; break; //TIFF
				case 4: format=4; break; //GIF
				default: format=0; break; //BMP
			}
			
			//utworzenie obrazu i wszelkie aktywacje przyciskow---------------------------
			if(ok){
				zapisany = false; //zaznaczenie ze zaszly zmiany
				
				panel1.Enabled = true; //odblokwanie wszystkich 
				button2.Enabled = true;	//opcji zwiazanych z wygenerowanym obrazem	
				checkBox2.Enabled = true;				
				zapiszJakoToolStripMenuItem.Enabled = true;
				eksportujToolStripMenuItem.Enabled = true;
				drukujToolStripMenuItem.Enabled = true;
				printToolStripButton.Enabled = true;
				saveToolStripButton.Enabled = true;	
				openToolStripButton.Enabled = true;		
				
				label5.ForeColor = Color.Green;
				if(!msgOn){
					if(label5.Text==String.Empty)
						label5.Text = "Poprawnie wygenerowano obraz.";
					else
						label5.Text += "\nPoprawnie wygenerowano obraz.";
				}
				else MessageBox.Show("Poprawnie wygenerowano obraz.", "Wygenerwoano obraz",
					                     MessageBoxButtons.OK, MessageBoxIcon.Information);
				//tu dopiero zabawa z obrazem--------------------------------------------
				obraz = new Obraz(stalowka, interlinia, kroj, orient, format, usunMarginesy, 
				                 kolor, grubosc, copogrubic, kgfx, dane, pomocnicze, domyslne, kat);
				obraz.rysuj();
				if(orient==1) obraz.bitmap.RotateFlip(RotateFlipType.Rotate90FlipXY); //obracamy obraz jesli trzeba
				if(checkBox2.Checked) pictureBox1.Image = obraz.bitmap; //zalodwanie obrazu do podgladu
				obraz.zakoncz();
			} 
		}//End of GENERUJ

		void ComboBox3SelectedIndexChanged(object sender, EventArgs e) 
		{	//wyswietlanie podpowiedzi do wybranego kroju
			switch(comboBox3.SelectedIndex){
				case 0: lblOpisKroju.Text = "1:3:5:3:i"; break; //KaliGFX
				case 1: lblOpisKroju.Text = "4:i"; break; //Unicjala
				case 2: lblOpisKroju.Text = "3:5:3:i"; break; //Italika
				case 3: lblOpisKroju.Text = "4:3:4:i"; break; //Pisanka angielska
				case 4: lblOpisKroju.Text = "1:1:1:1:1:i"; break; //Skrypt spenserski
				default: lblOpisKroju.Text = ""; break; //KaliGFX
			}
		}
		
		void ComboBox1SelectedIndexChanged(object sender, EventArgs e)
		{	//wyswietlanie podpowiedzi do orientacji linii
			if(comboBox1.SelectedIndex == 0) lblOrient.Text = "--"; //poziom
			else if(comboBox1.SelectedIndex == 1) lblOrient.Text = "|"; //pion
		}
		
		void CheckBox2CheckedChanged(object sender, EventArgs e) 
		{	//wlaczanie i wylaczanie podgladu
			if(checkBox2.Checked) pictureBox1.Image = obraz.bitmap;
			else pictureBox1.Image = null;
		}
			
		void ZakończToolStripMenuItemClick(object sender, EventArgs e)
		{	//wylaczanie programu
			zapiszStary("Chcesz zapisać obraz przed wyjściem?", "Zakończ KaliGFX");
			Environment.Exit(0);
		}
		
		void ToolStripButton1Click(object sender, EventArgs e)
		{	//wybieranie koloru linii
			colorDialog1.AllowFullOpen = true;
			colorDialog1.ShowDialog();
			kolor = colorDialog1.Color;
		}
		
		void ToolStripButton2Click(object sender, EventArgs e)
		{	//ustalanie grubosci linii
			GruboscForm gruboscForm = null;
			if(zachowajOpcje) gruboscForm =	new GruboscForm(grubosc, copogrubic);
			else gruboscForm = new GruboscForm();
			if(opacityAll) gruboscForm.Opacity = this.Opacity;
			gruboscForm.ShowDialog();
			this.grubosc = gruboscForm.grubosc;
			this.copogrubic = gruboscForm.copogrubic;			
		}
		
		void Button3Click(object sender, EventArgs e)
		{	//automatyczny wybor stalowki
			WyborStalowki wyborStalowki = new WyborStalowki();
			if(opacityAll) wyborStalowki.Opacity = this.Opacity;
			wyborStalowki.ShowDialog();
			this.stalowka = wyborStalowki.stalowka;	
			textBox1.Text = stalowka.ToString();
		}
		
		void ZaawansowanaEdycjaToolStripMenuItemClick(object sender, EventArgs e)
		{	
			edycja();
		}
		
		void ToolStripButton4Click(object sender, EventArgs e)
		{
			edycja();
		}
		
		//pomoc i ustawienia--------------------------------------------------------------
		void OpcjeToolStripMenuItemClick(object sender, EventArgs e)
		{	//opcje programu
			OpcjeForm opcjeForm = null;
			if(zachowajOpcje) opcjeForm = new OpcjeForm(msgOn, opacityAll, zachowajOpcje, (int)(this.Opacity*100));
			else opcjeForm = new OpcjeForm();
			if(opacityAll) opcjeForm.Opacity = this.Opacity;
			opcjeForm.ShowDialog();
			
			this.Opacity = opcjeForm.Opacity;
			this.opacityAll = opcjeForm.opacityAll;
			this.msgOn = opcjeForm.msgOn;
			this.zachowajOpcje = opcjeForm.zachowajOpcje;
			
			if(msgOn)
				label5.Visible = false;
			else
				label5.Visible = true;
		}
		
		void HelpToolStripButtonClick(object sender, EventArgs e)
		{	//plik pomocy
			HelpForm helpForm = new HelpForm();
			if(opacityAll) helpForm.Opacity = this.Opacity;
			helpForm.ShowDialog();
		}	
		
		void PomocOfflineToolStripMenuItemClick(object sender, EventArgs e)
		{	//plik pomocy
			HelpForm helpForm = new HelpForm();
			if(opacityAll) helpForm.Opacity = this.Opacity;
			helpForm.ShowDialog();
		}
		
		void PomocOnlineToolStripMenuItemClick(object sender, EventArgs e)
		{	//pomoc online
			System.Diagnostics.Process.Start("www.burning-brushes.pl");
		}
			
		//zapis, import, eksport ---------------------------------------------------
		void Button2Click(object sender, EventArgs e)
		{
			zapiszObraz();
		}
		
		void SaveToolStripButtonClick(object sender, EventArgs e)
		{
			zapiszObraz();
		}
		
		void ZapiszJakoToolStripMenuItemClick(object sender, EventArgs e)
		{
			zapiszObraz();
		}
		
		void NowyToolStripMenuItemClick(object sender, EventArgs e)
		{
			nowyObraz();
		}
		
		void NewToolStripButtonClick(object sender, EventArgs e)
		{
			nowyObraz();
		}
		
		void ToolStripButton3Click(object sender, EventArgs e)
		{
			importujObraz();
		}
		
		void OtwórzToolStripMenuItemClick(object sender, EventArgs e)
		{
			importujObraz();
		}
		
		void OpenToolStripButtonClick(object sender, EventArgs e)
		{
			eksportujObraz();
		}
		
		void EksportujToolStripMenuItemClick(object sender, EventArgs e)
		{
			eksportujObraz();
		}

		//drukowanie----------------------------------------------------------------------------
		void PrintDocument1PrintPage(object sender, PrintPageEventArgs e)
		{
			e.Graphics.DrawImage(obraz.bitmap, e.Graphics.VisibleClipBounds);
			e.HasMorePages = false;
		}
		
		void PrintToolStripButtonClick(object sender, EventArgs e)
		{
			printDocument1.Print();
		}
		
		void DrukujToolStripMenuItemClick(object sender, EventArgs e)
		{
			printDocument1.Print();
		}
		
		//zoom in, zoom out---------------------------------------------------------------------
		void Button4Click(object sender, EventArgs e) //IN
		{
			pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
		}
		
		void Button5Click(object sender, EventArgs e) //OUT
		{
			pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
		}
	}
}