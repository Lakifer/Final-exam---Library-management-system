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
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Windows.Resources;

namespace Wpf_Biblioteka_Zavrsni
{
    /// <summary>
    /// Interaction logic for NovaKnjiga.xaml
    /// </summary>
    public partial class NovaKnjiga : Window
    {
        public NovaKnjiga()
        {
            InitializeComponent();
        }

        SqlConnection konekcija = new SqlConnection(@"Data Source=DESKTOP-7PMP6IR\SQLEXPRESS;Initial Catalog=BibliotekaDb;Integrated Security=True");


        private void ButtonDodaj_Click(object sender, RoutedEventArgs e)
        {
            
            konekcija.Open();
            SqlCommand cmd = konekcija.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO Lista_knjiga VALUES('"+TextBoxNazivDodaj.Text+"','"+TextBoxAutorDodaj.Text+"','"+TextBoxZanrDodaj.Text+"','"+TextBoxKucaDodaj.Text+"','"+DatePickerDodaj.Text+"',"+TextBoxCenaDodaj.Text+","+TextBoxKolicinaDodaj.Text+ ", " + TextBoxKolicinaDodaj.Text + ")";
            cmd.ExecuteNonQuery();
            konekcija.Close();
            
            MessageBox.Show("Knjiga uspesno dodata!");
            this.Close();
            
        }

        private void ButtonOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextBoxCenaDodaj_KeyDown(object sender, KeyEventArgs e)
        {
            if (!Char.IsDigit((char)KeyInterop.VirtualKeyFromKey(e.Key)) & e.Key != Key.Back)
            {
                e.Handled = true;
                MessageBox.Show("Morate uneti broj kao cenu", "Upozorenje!");
            }
        }

        private void TextBoxKolicinaDodaj_KeyDown(object sender, KeyEventArgs e)
        {
            if (!Char.IsDigit((char)KeyInterop.VirtualKeyFromKey(e.Key)) & e.Key != Key.Back)
            {
                e.Handled = true;
                MessageBox.Show("Morate uneti broj kao kolicinu knjiga", "Upozorenje!");
            }
        }
    }
}
