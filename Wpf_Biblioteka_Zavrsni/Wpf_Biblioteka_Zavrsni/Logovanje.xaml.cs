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
using System.Data.Sql;
using System.Data;

namespace Wpf_Biblioteka_Zavrsni
{
    /// <summary>
    /// Interaction logic for Logovanje.xaml
    /// </summary>
    public partial class Logovanje : Window
    {
        public Logovanje()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TextBoxKorisnickoIme.Focus();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection konekcija = new SqlConnection(@"Data Source=DESKTOP-7PMP6IR\SQLEXPRESS;Initial Catalog=BibliotekaDb;Integrated Security=True");

            try
            {
                if (konekcija.State == ConnectionState.Closed)
                {
                    konekcija.Open();
                }
            

            string upit = "SELECT COUNT(1) FROM Login_korisnici WHERE Username=@Username AND Password=@Password";
            SqlCommand sqlCmd = new SqlCommand(upit, konekcija);
            sqlCmd.Parameters.AddWithValue("@Username", TextBoxKorisnickoIme.Text);
            sqlCmd.Parameters.AddWithValue("@Password", TextBoxPassword.Password);
            int count = Convert.ToInt32(sqlCmd.ExecuteScalar());

            if (count == 1)
            {
                MainWindow glavniProzor = new MainWindow();
                glavniProzor.Show();
                this.Close();
            }


            else
            {
                MessageBox.Show("Korisnicko ime ili lozinka nisu pravilno uneseni.");
            }
        }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                konekcija.Close();
            }

        }
    }
}
