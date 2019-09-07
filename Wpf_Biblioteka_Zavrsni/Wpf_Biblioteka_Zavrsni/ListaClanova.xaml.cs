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

namespace Wpf_Biblioteka_Zavrsni
{
    /// <summary>
    /// Interaction logic for ListaClanova.xaml
    /// </summary>
    public partial class ListaClanova : Window
    {
        public ListaClanova()
        {
            InitializeComponent();
        }

        SqlConnection konekcija = new SqlConnection(@"Data Source=DESKTOP-7PMP6IR\SQLEXPRESS;Initial Catalog=BibliotekaDb;Integrated Security=True");


        private void ButtonNazad_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }

        private void ButtonIzmeniClana_Click(object sender, RoutedEventArgs e)
        {
            IzmenaClana izmenaClana = new IzmenaClana();
            izmenaClana.ShowDialog();


        }

        private void ButtonDodajClana_Click(object sender, RoutedEventArgs e)
        {
            Dodaj_clana DodajClana = new Dodaj_clana();
            DodajClana.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TextBoxPretragaClana.Focus();

            if (konekcija.State == ConnectionState.Closed)
            {
                konekcija.Open();
            }

            SqlCommand komanda = new SqlCommand();
            komanda.CommandText = "SELECT * FROM Clanovi";
            komanda.Connection = konekcija;
            SqlDataAdapter da = new SqlDataAdapter(komanda);
            DataTable dt = new DataTable("Clanovi");
            da.Fill(dt);


            DataGridListaClanova.ItemsSource = dt.DefaultView;

        }

        private void TextBoxPretragaClana_KeyUp(object sender, KeyEventArgs e)
        {

            if (konekcija.State == ConnectionState.Closed)
            {
                konekcija.Open();
            }

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Clanovi WHERE ImeClana LIKE('%" + TextBoxPretragaClana.Text + "%')";
            cmd.Connection = konekcija;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Clanovi");
            da.Fill(dt);


            DataGridListaClanova.ItemsSource = dt.DefaultView;
        }

        private void TextBoxPretragaJmbg_KeyUp(object sender, KeyEventArgs e)
        {
            if (konekcija.State == ConnectionState.Closed)
            {
                konekcija.Open();
            }

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Clanovi WHERE JMBGClana LIKE('%" + TextBoxPretragaJmbg.Text + "%')";
            cmd.Connection = konekcija;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Clanovi");
            da.Fill(dt);


            DataGridListaClanova.ItemsSource = dt.DefaultView;
        }

        private void ObrisiClana_Click(object sender, RoutedEventArgs e)
        {
            DataRowView rowview = DataGridListaClanova.SelectedItem as DataRowView;
            string id = rowview.Row[0].ToString();



            try
            {

                SqlCommand cmd = konekcija.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM Clanovi WHERE IdClana LIKE('%" + id + "%')";
                cmd.ExecuteNonQuery();
                
                MessageBox.Show("Clan uspesno izbrisan!");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                Prikazi_clanove();
            }
        }

        public void Prikazi_clanove()
        {
            if (konekcija.State == ConnectionState.Closed)
            {
                konekcija.Open();
            }

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Clanovi";
            cmd.Connection = konekcija;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Clanovi");
            da.Fill(dt);

            DataGridListaClanova.ItemsSource = dt.DefaultView;
        }

        private void TextBoxPretragaJmbg_KeyDown(object sender, KeyEventArgs e)
        {
            if (!Char.IsDigit((char)KeyInterop.VirtualKeyFromKey(e.Key)) & e.Key != Key.Back)
            {
                e.Handled = true;
                MessageBox.Show("Morate uneti broj kao JMBG", "Upozorenje!");
            }
        }
    }
}
