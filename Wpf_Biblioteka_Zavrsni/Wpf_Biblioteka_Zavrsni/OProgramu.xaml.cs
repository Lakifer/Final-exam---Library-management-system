﻿using System;
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

namespace Wpf_Biblioteka_Zavrsni
{
    /// <summary>
    /// Interaction logic for OProgramu.xaml
    /// </summary>
    public partial class OProgramu : Window
    {
        public OProgramu()
        {
            InitializeComponent();
        }

        private void ButtonNazad_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
