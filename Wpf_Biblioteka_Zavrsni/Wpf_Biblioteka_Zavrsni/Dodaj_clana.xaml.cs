using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using Microsoft.Win32;

namespace Wpf_Biblioteka_Zavrsni
{
    /// <summary>
    /// Interaction logic for Dodaj_clana.xaml
    /// </summary>
    public partial class Dodaj_clana : Window
    {
        SqlConnection konekcija = new SqlConnection(@"Data Source=DESKTOP-7PMP6IR\SQLEXPRESS;Initial Catalog=BibliotekaDb;Integrated Security=True");


        public Dodaj_clana()
        {
            InitializeComponent();
        }

        private void ButtonOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonDodajClana_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                SqlCommand cmd = konekcija.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Clanovi VALUES('" + TextBoxImeClana.Text + "','" + DatePicker1.Text + "'," + TextBoxJMBG.Text + ",'" + TextBoxKontakt.Text + "','" + TextBoxEmail.Text + "')";
                cmd.ExecuteNonQuery();
                konekcija.Close();

                MessageBox.Show("Clan uspesno dodat!");
                this.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private void TextBoxJMBG_KeyDown(object sender, KeyEventArgs e)
        {

            if (!Char.IsDigit((char)KeyInterop.VirtualKeyFromKey(e.Key)) & e.Key != Key.Back)
            {
                e.Handled = true;
                MessageBox.Show("Morate uneti broj kao JMBG", "Upozorenje!");
            }
        }
    }
    
}
