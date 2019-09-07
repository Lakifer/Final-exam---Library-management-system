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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf_Biblioteka_Zavrsni
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            NovaKnjiga novaKnjiga = new NovaKnjiga();
            novaKnjiga.ShowDialog();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            ListaKnjiga ListaKnjiga = new ListaKnjiga();
            ListaKnjiga.ShowDialog();
            
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Dodaj_clana dodajClana = new Dodaj_clana();
            dodajClana.ShowDialog();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            ListaClanova listaClanova = new ListaClanova();
            listaClanova.Show();
            
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            IzdavanjeKnjiga izdavanjeKnjiga = new IzdavanjeKnjiga();
            izdavanjeKnjiga.ShowDialog();

        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            VracanjeKnjige vracanjeKnjige = new VracanjeKnjige();
            vracanjeKnjige.ShowDialog();
        }

        private void MenuKnjigovodstvo_Click(object sender, RoutedEventArgs e)
        {
            Knjigovodstvo knjigovodstvo = new Knjigovodstvo();
            knjigovodstvo.ShowDialog();
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            OProgramu oProgramu = new OProgramu();
            oProgramu.ShowDialog();
        }

        

        private void MenuItem_Click_8(object sender, RoutedEventArgs e)
        {
            this.Close();
            
        }
    }
}
