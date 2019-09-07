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
    /// Interaction logic for IzdavanjeKnjiga.xaml
    /// </summary>
    public partial class IzdavanjeKnjiga : Window
    {

        SqlConnection konekcija = new SqlConnection(@"Data Source=DESKTOP-7PMP6IR\SQLEXPRESS;Initial Catalog=BibliotekaDb;Integrated Security=True");




        public IzdavanjeKnjiga()
        {
            InitializeComponent();
        }
        
        private void ButtonPretraziClanove_Click(object sender, RoutedEventArgs e)
        {
            int i = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Clanovi WHERE JMBGClana LIKE('" + TextBoxPretraziClanove.Text + "')";
            cmd.Connection = konekcija;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Clanovi");
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());

            if (i == 0)
            {
                MessageBox.Show("Clan nije pronadjen!");
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    TextBoxImeClana.Text = dr["ImeClana"].ToString();
                    TextBoxKontaktClana.Text = dr["KontaktClana"].ToString();
                    TextBoxEmailClana.Text = dr["EmailClana"].ToString();
                    

                }
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (konekcija.State == ConnectionState.Open)
            {
                konekcija.Close();
            }
            konekcija.Open();

        }

        private void TextBoxNazivKnjige_KeyUp(object sender, KeyEventArgs e)
        {
            int count = 0;

            if (e.Key != Key.Enter)
            {

                ListBoxListaKnjiga.Items.Clear();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Lista_knjiga WHERE ImeKnjige LIKE('%" + TextBoxNazivKnjige.Text + "%')";
                cmd.Connection = konekcija;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Lista_knjiga");
                da.Fill(dt);
                count = Convert.ToInt32(dt.Rows.Count.ToString());




                if (count > 0)
                {
                    ListBoxListaKnjiga.Visibility = Visibility.Visible;

                    foreach (DataRow dr in dt.Rows)
                    {
                        ListBoxListaKnjiga.Items.Add(dr["ImeKnjige"]).ToString();
                    }

                }

            }
        }

        private void TextBoxNazivKnjige_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                ListBoxListaKnjiga.Focus();
                ListBoxListaKnjiga.SelectedIndex = 0;
            }
        }

        private void ListBoxListaKnjiga_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                TextBoxNazivKnjige.Text = ListBoxListaKnjiga.SelectedItem.ToString();
                ListBoxListaKnjiga.Visibility = Visibility.Visible;
            }
        }

        private void ListBoxListaKnjiga_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBoxNazivKnjige.Text = ListBoxListaKnjiga.SelectedItem.ToString();
            ListBoxListaKnjiga.Visibility = Visibility.Visible;
        }

        private void ListBoxListaKnjiga_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                string odabranaKnjiga;
                odabranaKnjiga = ListBoxListaKnjiga.SelectedItem.ToString();

                TextBoxNazivKnjige.Text = odabranaKnjiga.ToString();
                ListBoxListaKnjiga.Visibility = Visibility.Hidden;
            }
            catch (Exception exc)
            {

                
            }
                
            

        }

        private void ButtonNazad_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }





        private void ButtonIzdaj_Click(object sender, RoutedEventArgs e)
        {



            try
            {
                
                using (SqlConnection kon = new SqlConnection(@"Data Source=DESKTOP-7PMP6IR\SQLEXPRESS;Initial Catalog=BibliotekaDb;Integrated Security=True"))
                
                {
                    using (SqlCommand cmd2 = new SqlCommand("SELECT DostupnostKnjiga  FROM Lista_knjiga WHERE ImeKnjige = @ImeKnjige", kon))
                    {
                        
                        cmd2.Parameters.Add("@ImeKnjige", SqlDbType.VarChar, 100).Value = TextBoxNazivKnjige.Text;
                        
                        kon.Open();
                        var returnVal = cmd2.ExecuteScalar() ?? 0;
                        if ((int)returnVal > 0)
                        {

                            SqlCommand cmd = konekcija.CreateCommand();
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "INSERT INTO Iznajmljivanje_knjige VALUES(" + TextBoxPretraziClanove.Text + ",'" + TextBoxImeClana.Text + "','" + TextBoxKontaktClana.Text + "','" + TextBoxEmailClana.Text + "','" + TextBoxNazivKnjige.Text + "', '" + DateTimePicker1.Text + "', '')";
                            cmd.ExecuteNonQuery();


                            SqlCommand cmd1 = konekcija.CreateCommand();
                            cmd1.CommandType = CommandType.Text;
                            cmd1.CommandText = "UPDATE Lista_knjiga SET DostupnostKnjiga = DostupnostKnjiga-1 WHERE ImeKnjige ='" + TextBoxNazivKnjige.Text + "'";
                            cmd1.ExecuteNonQuery();


                            MessageBox.Show("Knjiga uspesno izdata");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Rezervacija nije dostupna");
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Rezervacija nije dostupna");
                //MessageBox.Show(exc.ToString());
            }


        }
    }
}
