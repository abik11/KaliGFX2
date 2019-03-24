using System.Drawing;
using System.Drawing.Imaging;

namespace KaliGFX22
{
   public class Obraz
   {
      int szer = 2480, wys = 3508; //rozmiary obrazu
      Graphics gfx;
      Bitmap bmap;
      public Bitmap bitmap
      { 
         //odczyt bitmapy arkusza
         get { return bmap; }
      }
      bool usunMarginesy = true;
      float stalowka = 1;
      int interlinia = 1, kroj = 0, orient = 0, format = 0;

      Color kolor = Color.Black;
      int grubosc = 1;
      int copogrubic = 0;
      //zaawansowane opcje arkusza
      bool kgfx = false;
      bool dane = false;
      bool pomocnicze = false;
      bool domyslne = true;
      int kat = 0;

      public Obraz(float stalowka, int interlinia, int kroj, int orient, int format, bool usunMarginesy)
      {
         this.stalowka = stalowka; this.interlinia = interlinia;
         this.kroj = kroj; this.orient = orient; this.format = format;
         this.usunMarginesy = usunMarginesy;

         if (this.usunMarginesy) szer -= mmToPx(20); //odcinamy marginesy jesli trzeba
         if (this.orient == 1)
         {
            //odwracamy wymiary obrazu jesli
            int tmpszer = szer; //ma byc rysowany w pionie
            szer = wys;
            wys = tmpszer;
         }

         bmap = new Bitmap(szer, wys, PixelFormat.Format24bppRgb);
         gfx = Graphics.FromImage(bmap);
         gfx.Clear(Color.White);
      }

      public Obraz(float stalowka, int interlinia, int kroj, int orient, int format, bool usunMarginesy,
                  Color kolor, int grubosc, int copogrubic)
      {
         this.stalowka = stalowka; this.interlinia = interlinia;
         this.kroj = kroj; this.orient = orient; this.format = format;
         this.usunMarginesy = usunMarginesy;

         this.kolor = kolor; this.grubosc = grubosc; this.copogrubic = copogrubic;

         if (this.usunMarginesy) szer -= mmToPx(20); //odcinamy marginesy jesli trzeba
         if (this.orient == 1)
         {
            //odwracamy wymiary obrazu jesli
            int tmpszer = szer; //ma byc rysowany w pionie
            szer = wys;
            wys = tmpszer;
         }

         bmap = new Bitmap(szer, wys, PixelFormat.Format24bppRgb);
         gfx = Graphics.FromImage(bmap);
         gfx.Clear(Color.White);
      }

      public Obraz(float stalowka, int interlinia, int kroj, int orient, int format, bool usunMarginesy,
                  Color kolor, int grubosc, int copogrubic,
                  bool kgfx, bool dane, bool pomocnicze, bool domyslne, int kat)
      {
         this.stalowka = stalowka; this.interlinia = interlinia;
         this.kroj = kroj; this.orient = orient; this.format = format;
         this.usunMarginesy = usunMarginesy;

         this.kolor = kolor; this.grubosc = grubosc; this.copogrubic = copogrubic;

         this.kgfx = kgfx; this.dane = dane; this.pomocnicze = pomocnicze;
         this.domyslne = domyslne;
         if (domyslne)
         { 
            //ustawienie domyslnego kata linii pomocniczych
            if (kroj == 3 || kroj == 4) this.kat = 52; //pisanka angielska lub skrypt spenserski
            if (kroj == 2) this.kat = 85; //italika
            else this.kat = 0;
         }
         else this.kat = kat;

         if (this.usunMarginesy) szer -= mmToPx(20); //odcinamy marginesy jesli trzeba
         if (this.orient == 1)
         {
            //odwracamy wymiary obrazu jesli
            int tmpszer = szer; //ma byc rysowany w pionie
            szer = wys;
            wys = tmpszer;
         }

         bmap = new Bitmap(szer, wys, PixelFormat.Format24bppRgb);
         gfx = Graphics.FromImage(bmap);
         gfx.Clear(Color.White);
      }

      public void rysuj()
      {
         Pen pen; //obiekt zawierajacy wlasciwosci linii
         if (copogrubic == 2) pen = new Pen(kolor, grubosc); //pogrubianie wszystkich linii
         else pen = new Pen(kolor, 1);

         int pozycja; //pozycja gdzie ma byc narysowana linia			
         if (dane) //jesli maja byc wypisane dane w arkuszu
            pozycja = 120; //to jest troche nizsza na poczatku			
         else pozycja = 80;


         if (dane)
         { 
            //jesli maja byc wypisane dane w arkuszu
            int pozycjaDane = 0; //gdzie maja byc wypisane dane
            Font font = new Font("Arial", 80, FontStyle.Regular, GraphicsUnit.Pixel);
            SolidBrush brush = new SolidBrush(Color.Gray);
            string jakiKroj = "";
            switch (kroj)
            {
               case 0: jakiKroj = "KaliGFX"; pozycjaDane = 1880; break;
               case 1: jakiKroj = "Unicjała"; pozycjaDane = 1870; break;
               case 2: jakiKroj = "Italika"; pozycjaDane = 1920; break;
               case 3: jakiKroj = "Pisanka angielska"; pozycjaDane = 1510; break;
               case 4: jakiKroj = "Skrypt spenserski"; pozycjaDane = 1520; break;
            }
            if (usunMarginesy) pozycjaDane -= 200;
            if (orient == 1 && usunMarginesy) pozycjaDane += 1150; //jesli ma byc rysowane w pionie to przesuwamy troche wyzej
            if (orient == 1 && !usunMarginesy) pozycjaDane += 1000;
            gfx.DrawString(jakiKroj + " " + stalowka.ToString() + "mm",
                          font, brush, pozycjaDane, 20);
         }

         if (kgfx)
         { 
            //rysowanie duzego napisu KaliGFX
            Font font = new Font("Arial", 180, FontStyle.Regular, GraphicsUnit.Pixel);
            SolidBrush brush = new SolidBrush(Color.Gray);
            gfx.DrawString("KaliGFX", font, brush, 20, wys - 200); //rysowanie napisu w
         }                                          //dolnym lewym rogu

         //rysowanie linii-------------------------------------------------------------------
         if (kroj == 0)
         { 
            //KaliGFX
            int pas = mmToPx(1 * stalowka + 3 * stalowka + 5 * stalowka + 3 * stalowka + interlinia);
            for (int i = 0; i < (int)wys / pas; i++)
            {
               gfx.DrawLine(pen, 0, pozycja, szer, pozycja);
               pozycja += mmToPx(stalowka);
               gfx.DrawLine(pen, 0, pozycja, szer, pozycja);
               pozycja += mmToPx(stalowka) * 3;
               if (copogrubic == 1) pen.Width = grubosc;
               gfx.DrawLine(pen, 0, pozycja, szer, pozycja); //srodkowa
               pozycja += mmToPx(stalowka) * 5;
               if (copogrubic == 0 || copogrubic == 1) pen.Width = grubosc;
               gfx.DrawLine(pen, 0, pozycja, szer, pozycja); //srodkowa //bazowa
               if (copogrubic == 0 || copogrubic == 1) pen.Width = 1;
               pozycja += mmToPx(stalowka) * 3;
               gfx.DrawLine(pen, 0, pozycja, szer, pozycja);
               pozycja += mmToPx(interlinia); //interlinia
            }
         }
         if (kroj == 1)
         { 
            //Unicjala
            int pas = mmToPx(4 * stalowka + interlinia);
            for (int i = 0; i < (int)wys / pas; i++)
            {
               if (copogrubic == 1) pen.Width = grubosc;
               gfx.DrawLine(pen, 0, pozycja, szer, pozycja); //srodkowa
               pozycja += mmToPx(stalowka) * 4;
               if (copogrubic == 0 || copogrubic == 1) pen.Width = grubosc;
               gfx.DrawLine(pen, 0, pozycja, szer, pozycja); //srodkowa //bazowa
               pozycja += mmToPx(interlinia); //interlinia		
            }
         }
         if (kroj == 2)
         { 
            //Italika
            int pas = mmToPx(3 * stalowka + 5 * stalowka + 3 * stalowka + interlinia);
            for (int i = 0; i < (int)wys / pas; i++)
            {
               gfx.DrawLine(pen, 0, pozycja, szer, pozycja);
               pozycja += mmToPx(stalowka) * 3;
               if (copogrubic == 1) pen.Width = grubosc;
               gfx.DrawLine(pen, 0, pozycja, szer, pozycja); //srodkowa
               pozycja += mmToPx(stalowka) * 5;
               if (copogrubic == 0 || copogrubic == 1) pen.Width = grubosc;
               gfx.DrawLine(pen, 0, pozycja, szer, pozycja); //srodkowa //bazowa
               if (copogrubic == 0 || copogrubic == 1) pen.Width = 1;
               pozycja += mmToPx(stalowka) * 3;
               gfx.DrawLine(pen, 0, pozycja, szer, pozycja);
               pozycja += mmToPx(interlinia); //interlinia		
            }
         }
         if (kroj == 3)
         { 
            //Pisanka angielska
            int pas = mmToPx(4 * stalowka + 3 * stalowka + 4 * stalowka + interlinia);
            for (int i = 0; i < (int)wys / pas; i++)
            {
               gfx.DrawLine(pen, 0, pozycja, szer, pozycja);
               pozycja += mmToPx(stalowka) * 4;
               if (copogrubic == 1) pen.Width = grubosc;
               gfx.DrawLine(pen, 0, pozycja, szer, pozycja); //srodkowa
               pozycja += mmToPx(stalowka) * 3;
               if (copogrubic == 0 || copogrubic == 1) pen.Width = grubosc;
               gfx.DrawLine(pen, 0, pozycja, szer, pozycja); //srodkowa //bazowa
               if (copogrubic == 0 || copogrubic == 1) pen.Width = 1;
               pozycja += mmToPx(stalowka) * 4;
               gfx.DrawLine(pen, 0, pozycja, szer, pozycja);
               pozycja += mmToPx(interlinia); //interlinia	
            }
         }
         if (kroj == 4)
         { 
            //Skrypt spenserski
            int pas = mmToPx(5 * stalowka + interlinia);
            for (int i = 0; i < (int)wys / pas; i++)
            {
               gfx.DrawLine(pen, 0, pozycja, szer, pozycja);
               pozycja += mmToPx(stalowka);
               gfx.DrawLine(pen, 0, pozycja, szer, pozycja);
               pozycja += mmToPx(stalowka);
               if (copogrubic == 1) pen.Width = grubosc;
               gfx.DrawLine(pen, 0, pozycja, szer, pozycja);//srodkowa
               pozycja += mmToPx(stalowka);
               if (copogrubic == 0 || copogrubic == 1) pen.Width = grubosc;
               gfx.DrawLine(pen, 0, pozycja, szer, pozycja);//srodkowa //bazowa
               if (copogrubic == 0 || copogrubic == 1) pen.Width = 1;
               pozycja += mmToPx(stalowka);
               gfx.DrawLine(pen, 0, pozycja, szer, pozycja);
               pozycja += mmToPx(stalowka);
               gfx.DrawLine(pen, 0, pozycja, szer, pozycja);
               pozycja += mmToPx(interlinia); //interlinia
            }
         }

         if (pomocnicze)
         { 
            //rysowanie linii pomocnicznych-------------------------------------
            pen.Width = 1;
            if (domyslne)
            {
               switch (kroj)
               {
                  case 2: kat = 85; break;
                  case 3:
                  case 4: kat = 52; break;
                  default: kat = 45; break;
               }
            }
            int tmppoz = 0; //pozycja gdzie ma byc narysowana pojedyncza linia pomocnicza
            gfx.RotateTransform(90 - kat); //obliczenie kata linii pomocniczych
            for (int i = 0; i < (int)szer / stalowka; i++)
            { 
               //rysujemy linie na calym arkuszu
               tmppoz += mmToPx(stalowka); //przesuniecie pozycji 
               gfx.DrawLine(pen, tmppoz, wys, tmppoz, -3000);
            }
         }//koniec linii pomocniczych			
      }//END of rysuj

      //inne wazne funkcje--------------------------------------------------------------------
      public void zapisz(string plik)
      {
         if (plik.Split('.').Length == 1)
         { 
            //jesli nie podano rozszerzenia to je dodajemy
            switch (format)
            {
               case 0: bmap.Save(plik + ".bmp", ImageFormat.Bmp); break;
               case 1: bmap.Save(plik + ".png", ImageFormat.Png); break;
               case 2: bmap.Save(plik + ".jpg", ImageFormat.Jpeg); break;
               case 3: bmap.Save(plik + ".tiff", ImageFormat.Tiff); break;
               case 4: bmap.Save(plik + ".gif", ImageFormat.Gif); break;
            }
         }
         else
         {
            switch (format)
            {
               case 0: bmap.Save(plik, ImageFormat.Bmp); break;
               case 1: bmap.Save(plik, ImageFormat.Png); break;
               case 2: bmap.Save(plik, ImageFormat.Jpeg); break;
               case 3: bmap.Save(plik, ImageFormat.Tiff); break;
               case 4: bmap.Save(plik, ImageFormat.Gif); break;
            }
         }
      }

      public string pobierzDane()
      { 
         //zapisanie wlasciwosci arkusza w jednym lancuchu
         return stalowka.ToString() + "\n" + interlinia.ToString() + "\n" +
            kroj.ToString() + "\n" + orient.ToString() + "\n" + format.ToString() + "\n" +
            (usunMarginesy ? "1" : "0") + "\n" + kolor.ToArgb().ToString() + "\n" +
            grubosc.ToString() + "\n" + copogrubic.ToString() + "\n" +
            (kgfx ? "1" : "0") + "\n" + (dane ? "1" : "0") + "\n" + (pomocnicze ? "1" : "0") + "\n" +
            (domyslne ? "1" : "0") + "\n" + kat.ToString();
      }

      public void zakoncz()
      {
         gfx.Dispose();
      }

      private int mmToPx(double mm)
      {
         //przeliczenie milimetrow na piksele
         return (int)(mm * 11.8);
      }
   }
}
