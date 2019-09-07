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
    /// Interaction logic for IzmenaKnjige.xaml
    /// </summary>
    public partial class IzmenaKnjige : Window
    {
        public IzmenaKnjige()
        {
            InitializeComponent();
        }

        SqlConnection konekcija = new SqlConnection(@"Data Source=DESKTOP-7PMP6IR\SQLEXPRESS;Initial Catalog=BibliotekaDb;Integrated Security=True");


        private void ButtonNazad_Click(object sender, RoutedEventArgs e)
        {

            this.Close();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Prikazi_knjige();
        }

        private void TextBoxPretragaIzmene_KeyUp(object sender, KeyEventArgs e)
        {
            if (konekcija.State == ConnectionState.Closed)
            {
                konekcija.Open();
            }

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Lista_knjiga WHERE ImeKnjige LIKE('%" + TextBoxPretragaIzmene.Text + "%')";
            cmd.Connection = konekcija;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Lista_knjiga");
            da.Fill(dt);


            DataGridListaKnjiga2.ItemsSource = dt.DefaultView;
        }

        private void DataGridListaKnjiga2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

                        
            DataGrid dg = (DataGrid)sender;
            DataRowView selectedRow = dg.SelectedItem as DataRowView;
            if (selectedRow != null)
            {
               

                TextBoxPromenaImenaKnjige.Text = selectedRow["ImeKnjige"].ToString();
                TextBoxPromenaAutora.Text = selectedRow["ImeAutora"].ToString();
                TextBoxIzmenaZanra.Text = selectedRow["ZanrKnjige"].ToString();
                TextBoxPromenaIzdavaca.Text = selectedRow["ImeIzdavackeKuce"].ToString();
                DatePicker1.SelectedDate = Convert.ToDateTime(selectedRow["GodinaIzdavanjaKnjige"].ToString());
                TextBoxPromenaCene.Text = selectedRow["CenaKnjige"].ToString();
                TextBoxPromenaKolicine.Text = selectedRow["KolicinaKnjiga"].ToString();

            }
        }

        private void ButtonIzmeni_Click(object sender, RoutedEventArgs e)
        {
                       


            DataRowView rowview = DataGridListaKnjiga2.SelectedItem as DataRowView;
            string id = rowview.Row[0].ToString();

            

            try
            {

                SqlCommand cmd = konekcija.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE Lista_knjiga SET ImeKnjige ='" + TextBoxPromenaImenaKnjige.Text + "', ImeAutora = '" + TextBoxPromenaAutora.Text + "', ImeIzdavackeKuce = '" + TextBoxPromenaIzdavaca.Text + "', GodinaIzdavanjaKnjige = '" + DatePicker1.Text + "', CenaKnjige = " + TextBoxPromenaCene.Text + ", KolicinaKnjiga = " + TextBoxPromenaKolicine.Text + " WHERE IdKnjige = '" + id + "'  ";
                cmd.ExecuteNonQuery();
                Prikazi_knjige();
                MessageBox.Show("Knjiga uspesno izmenjena!");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            

        }
        public void Prikazi_knjige()
        {

            if (konekcija.State == ConnectionState.Closed)
            {
                konekcija.Open();
            }

            TextBoxPretragaIzmene.Focus();

            SqlCommand komanda = new SqlCommand();
            komanda.CommandText = "SELECT * FROM Lista_knjiga";
            komanda.Connection = konekcija;
            SqlDataAdapter da = new SqlDataAdapter(komanda);
            DataTable dt = new DataTable("Lista_knjiga");
            da.Fill(dt);


            DataGridListaKnjiga2.ItemsSource = dt.DefaultView;

        }

        private void TextBoxPromenaCene_KeyDown(object sender, KeyEventArgs e)
        {
            if (!Char.IsDigit((char)KeyInterop.VirtualKeyFromKey(e.Key)) & e.Key != Key.Back)
            {
                e.Handled = true;
                MessageBox.Show("Morate uneti broj cenu", "Upozorenje!");
            }
        }

        private void TextBoxPromenaKolicine_KeyDown(object sender, KeyEventArgs e)
        {
            if (!Char.IsDigit((char)KeyInterop.VirtualKeyFromKey(e.Key)) & e.Key != Key.Back)
            {
                e.Handled = true;
                MessageBox.Show("Morate uneti broj kao kolicinu knjiga", "Upozorenje!");
            }
        }
    }
}
