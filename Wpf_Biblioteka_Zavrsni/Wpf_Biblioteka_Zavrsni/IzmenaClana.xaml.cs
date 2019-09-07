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
    /// Interaction logic for IzmenaClana.xaml
    /// </summary>
    public partial class IzmenaClana : Window
    {

        SqlConnection konekcija = new SqlConnection(@"Data Source=DESKTOP-7PMP6IR\SQLEXPRESS;Initial Catalog=BibliotekaDb;Integrated Security=True");

        public IzmenaClana()
        {
            InitializeComponent();
        }

        private void ButtonNazad_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonIzmeni_Click(object sender, RoutedEventArgs e)
        {


            DataRowView rowview = DataGridListaClanova.SelectedItem as DataRowView;
            string id = rowview.Row[0].ToString();



            try
            {

                SqlCommand cmd = konekcija.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE Clanovi SET ImeClana ='" + TextBoxPromenaImenaClana.Text + "', GodinaRodjenjaClana = '" + DatePickerPromena.Text + "', JMBGClana = " + TextBoxPromenaJMBG.Text + ", KontaktClana = '" + TextBoxPromenaKontakta.Text + "', EmailClana = '" + TextBoxPromenaEmail.Text + "' WHERE IdClana = '" + id + "'  ";
                cmd.ExecuteNonQuery();
                Prikazi_clanove();
                MessageBox.Show("Clan uspesno izmenjen!");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        private void TextBoxPretragaIzmeneClana_KeyUp(object sender, KeyEventArgs e)
        {

            if (konekcija.State == ConnectionState.Closed)
            {
                konekcija.Open();
            }

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Clanovi WHERE ImeClana LIKE('%" + TextBoxPretragaIzmeneClana.Text + "%')";
            cmd.Connection = konekcija;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Clanovi");
            da.Fill(dt);


            DataGridListaClanova.ItemsSource = dt.DefaultView;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Prikazi_clanove();
        }

        public void Prikazi_clanove()
        {

            if (konekcija.State == ConnectionState.Closed)
            {
                konekcija.Open();
            }

            TextBoxPretragaIzmeneClana.Focus();

            SqlCommand komanda = new SqlCommand();
            komanda.CommandText = "SELECT * FROM Clanovi";
            komanda.Connection = konekcija;
            SqlDataAdapter da = new SqlDataAdapter(komanda);
            DataTable dt = new DataTable("Clanovi");
            da.Fill(dt);


            DataGridListaClanova.ItemsSource = dt.DefaultView;

        }

        private void DataGridListaClanova_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            DataRowView selectedRow = dg.SelectedItem as DataRowView;
            if (selectedRow != null)
            {


                TextBoxPromenaImenaClana.Text = selectedRow["ImeClana"].ToString();
                DatePickerPromena.SelectedDate = Convert.ToDateTime(selectedRow["GodinaRodjenjaClana"].ToString());
                TextBoxPromenaJMBG.Text = selectedRow["JMBGClana"].ToString();
                TextBoxPromenaKontakta.Text = selectedRow["KontaktClana"].ToString();
                TextBoxPromenaEmail.Text = selectedRow["EmailClana"].ToString();

            }
        }

        private void TextBoxPromenaJMBG_KeyDown(object sender, KeyEventArgs e)
        {
            if (!Char.IsDigit((char)KeyInterop.VirtualKeyFromKey(e.Key)) & e.Key != Key.Back)
            {
                e.Handled = true;
                MessageBox.Show("Morate uneti broj kao JMBG", "Upozorenje!");
            }
        }
    }
}
