using System;
using System.IO;
using System.Windows.Forms;

namespace KaliGFX22
{
	public partial class HelpForm : Form
	{
		public HelpForm()
		{
			InitializeComponent();
		}
		
		void HelpFormLoad(object sender, EventArgs e)
		{
			StreamReader SR = new StreamReader("help.txt");
			textBox1.Text = SR.ReadToEnd(); //wczytuje caly plik pomocy
			textBox1.Select(0,0); //usuwa zaznaczenie z tekstu pliku pomocy
			SR.Close();			
		}
		
		void Button1Click(object sender, EventArgs e) //OK
		{
			this.DialogResult = DialogResult.OK;
		}
	}
}
