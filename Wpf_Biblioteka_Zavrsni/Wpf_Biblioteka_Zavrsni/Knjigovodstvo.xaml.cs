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
    /// Interaction logic for Knjigovodstvo.xaml
    /// </summary>
    public partial class Knjigovodstvo : Window
    {
        public Knjigovodstvo()
        {
            InitializeComponent();
        }

        SqlConnection konekcija = new SqlConnection(@"Data Source=DESKTOP-7PMP6IR\SQLEXPRESS;Initial Catalog=BibliotekaDb;Integrated Security=True");


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            if (konekcija.State == ConnectionState.Open)
            {
                konekcija.Close();
            }
            konekcija.Open();

            knjigovodstvo_ucitaj();



        }

        public void knjigovodstvo_ucitaj()
        {


            SqlCommand komanda = new SqlCommand();
            komanda.CommandText = "SELECT ImeKnjige, ImeAutora, KolicinaKnjiga, DostupnostKnjiga FROM Lista_knjiga";
            komanda.Connection = konekcija;
            SqlDataAdapter da = new SqlDataAdapter(komanda);
            DataTable dt = new DataTable("Lista_knjiga");
            da.Fill(dt);


            DataGridKnjigovodstvo.ItemsSource = dt.DefaultView;

            

        }

        private void DataGridKnjigovodstvo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            DataRowView dataRow = (DataRowView)DataGridKnjigovodstvo.SelectedItem;
            int index = DataGridKnjigovodstvo.CurrentCell.Column.DisplayIndex;
            
            
            string cellValue = dataRow.Row.ItemArray[index].ToString();
            
           
            SqlCommand komanda = new SqlCommand();
            komanda.CommandText = "SELECT * FROM Iznajmljivanje_knjige WHERE ImeKnjige='"+ cellValue.ToString()+"' AND DatumVracanjaKnjige='' ";
            komanda.Connection = konekcija;
            SqlDataAdapter da = new SqlDataAdapter(komanda);
            DataTable dt = new DataTable("Iznajmljivanje_knjige");
            da.Fill(dt);


            DataGridKnjigovodstvo2.ItemsSource = dt.DefaultView;





        }

        private void TextBoxPretraga_KeyUp(object sender, KeyEventArgs e)
        {

            SqlCommand komanda = new SqlCommand();
            komanda.CommandText = "SELECT ImeKnjige, ImeAutora, KolicinaKnjiga, DostupnostKnjiga FROM Lista_knjiga WHERE ImeKnjige LIKE('%"+TextBoxPretraga.Text+"%')";
            komanda.Connection = konekcija;
            SqlDataAdapter da = new SqlDataAdapter(komanda);
            DataTable dt = new DataTable("Lista_knjiga");
            da.Fill(dt);


            DataGridKnjigovodstvo.ItemsSource = dt.DefaultView;
        }

        private void ButtonNazad_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
