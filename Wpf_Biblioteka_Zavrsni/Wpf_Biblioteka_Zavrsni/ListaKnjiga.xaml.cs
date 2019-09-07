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
    /// Interaction logic for ListaKnjiga.xaml
    /// </summary>
    public partial class ListaKnjiga : Window
    {

        SqlConnection konekcija = new SqlConnection(@"Data Source=DESKTOP-7PMP6IR\SQLEXPRESS;Initial Catalog=BibliotekaDb;Integrated Security=True");


        public ListaKnjiga()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            TextBoxPretragaKnjige.Focus();

            Prikazi_knjige();


        }









        private void ButtonNazad_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }

        private void ButtonIzmeni_Click(object sender, RoutedEventArgs e)
        {
            IzmenaKnjige izmenaKnjige = new IzmenaKnjige();
            izmenaKnjige.ShowDialog();

            

        }

        private void TextBoxPretragaKnjige_KeyUp(object sender, KeyEventArgs e)
        {

            if (konekcija.State == ConnectionState.Closed)
            {
                konekcija.Open();
            }



            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Lista_knjiga WHERE ImeKnjige LIKE('%"+TextBoxPretragaKnjige.Text+"%')";
            cmd.Connection = konekcija;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Lista_knjiga");
            Prikazi_knjige();
            da.Fill(dt);


            DataGridListaKnjiga.ItemsSource = dt.DefaultView;




        }

        private void TextBoxPretragaAutora_KeyUp(object sender, KeyEventArgs e)
        {
            if (konekcija.State == ConnectionState.Closed)
            {
                konekcija.Open();
            }

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Lista_knjiga WHERE ImeAutora LIKE('%"+TextBoxPretragaAutora.Text+"%')";
            cmd.Connection = konekcija;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Lista_knjiga");
            Prikazi_knjige();
            da.Fill(dt);


            DataGridListaKnjiga.ItemsSource = dt.DefaultView;
        }

        private void ButtonDodajKnjigu_Click(object sender, RoutedEventArgs e)
        {
            Prikazi_knjige();
            NovaKnjiga novaKnjiga = new NovaKnjiga();
            novaKnjiga.ShowDialog();
        }

        public void Prikazi_knjige()
        {

            if (konekcija.State == ConnectionState.Closed)
            {
                konekcija.Open();
            }

            SqlCommand komanda = new SqlCommand();
            komanda.CommandText = "SELECT * FROM Lista_knjiga";
            komanda.Connection = konekcija;
            SqlDataAdapter da = new SqlDataAdapter(komanda);
            DataTable dt = new DataTable("Lista_knjiga");
            da.Fill(dt);


            DataGridListaKnjiga.ItemsSource = dt.DefaultView;
        }

        private void Obrisi_Click(object sender, RoutedEventArgs e)
        {
            DataRowView rowview = DataGridListaKnjiga.SelectedItem as DataRowView;
            string id = rowview.Row[0].ToString();



            try
            {

                SqlCommand cmd = konekcija.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM Lista_knjiga WHERE IdKnjige LIKE('%" + id + "%')";
                cmd.ExecuteNonQuery();

                MessageBox.Show("Knjiga uspesno izbrisana!");
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                Prikazi_knjige();
            }
        }
    }
}
