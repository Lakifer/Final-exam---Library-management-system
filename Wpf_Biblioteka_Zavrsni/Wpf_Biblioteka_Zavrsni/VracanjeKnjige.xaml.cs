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
using System.Data.SqlClient;
using System.Data;


namespace Wpf_Biblioteka_Zavrsni
{
    /// <summary>
    /// Interaction logic for VracanjeKnjige.xaml
    /// </summary>
    public partial class VracanjeKnjige : Window
    {
        public VracanjeKnjige()
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
        }

        public void ispuni_listu(string jmbg)
        {
            TextBoxJMBGPretraga.Focus();

            int i = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Iznajmljivanje_knjige WHERE JMBGClana LIKE('" + TextBoxJMBGPretraga.Text + "') AND DatumVracanjaKnjige=''";
            cmd.Connection = konekcija;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Iznajmljivanje_knjige");
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());

            if (i == 0)
            {
                MessageBox.Show("Clan nije pronadjen!");
            }
            else
            { 

            DataGridVracanja.ItemsSource = dt.DefaultView;


            DataGridVracanja.ItemsSource = dt.DefaultView;
            }
        }

        private void ButtonPretraziJMBG_Click(object sender, RoutedEventArgs e)
        {
            ispuni_listu(TextBoxJMBGPretraga.Text);


        }

        private void DataGridVracanja_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            DataRowView selectedRow = dg.SelectedItem as DataRowView;
            if (selectedRow != null)
            {


                TextBoxNazivKnjige.Text = selectedRow["ImeKnjige"].ToString();
                TextBoxDatumIzdavanja.Text = selectedRow["DatumIznajmljivanja"].ToString();
                

            }
        }

        private void ButtonOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void ButtonVratiKnjigu_Click(object sender, RoutedEventArgs e)
        {

          

            try
            {

                using (SqlConnection kon = new SqlConnection(@"Data Source=DESKTOP-7PMP6IR\SQLEXPRESS;Initial Catalog=BibliotekaDb;Integrated Security=True"))

                {
                    using (SqlCommand cmd2 = new SqlCommand("SELECT DostupnostKnjiga  FROM Lista_knjiga WHERE ImeKnjige = @ImeKnjige", kon))
                    {

                        cmd2.Parameters.Add("@ImeKnjige", SqlDbType.VarChar, 100).Value = TextBoxNazivKnjige.Text;

                        kon.Open();
                        

                            SqlCommand cmd = konekcija.CreateCommand();
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "UPDATE Iznajmljivanje_knjige SET DatumVracanjaKnjige ='" + DatePickerVracanje.ToString() + "',  ImeKnjige ='" + TextBoxNazivKnjige.Text + "'";
                            cmd.ExecuteNonQuery();


                            SqlCommand cmd1 = konekcija.CreateCommand();
                            cmd1.CommandType = CommandType.Text;
                            cmd1.CommandText = "UPDATE Lista_knjiga SET DostupnostKnjiga = DostupnostKnjiga+1 WHERE ImeKnjige ='" + TextBoxNazivKnjige.Text + "'";
                            cmd1.ExecuteNonQuery();


                        MessageBox.Show("Knjiga uspesno vracena");
                        this.Close();
                        
                       
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Uspesno vracena");
                //MessageBox.Show(exc.ToString());
            }










        }

        private void TextBoxJMBGPretraga_KeyDown(object sender, KeyEventArgs e)
        {
            if (!Char.IsDigit((char)KeyInterop.VirtualKeyFromKey(e.Key)) & e.Key != Key.Back)
            {
                e.Handled = true;
                MessageBox.Show("Morate uneti broj kao JMBG", "Upozorenje!");
            }
        }
    }
}
