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
using System.Diagnostics;

namespace airport
{
    /// <summary>
    /// Interaction logic for details.xaml
    /// </summary>
    public partial class details : Window
    {
        public details()
        {
            InitializeComponent();

            var main_W = ((MainWindow)Application.Current.MainWindow);

            if(main_W.chosen_ICAO == true)
            {
                ICAO_lbl.Content = "ICAO: " + main_W.wybrane_lotnisko.ICAO;
            }
            if(main_W.chosen_IATA == true)
            {
                IATA_lbl.Content = "IATA: " + main_W.wybrane_lotnisko.IATA;
       
            }
            if (main_W.chosen_LiczbaPas == true)
            {
                pasazerowie_lbl.Content = "Liczba pasazerow: " + main_W.wybrane_lotnisko.LiczbaPasazerow;
            }
            if (main_W.chosen_Miasto == true)
            {
                miasto_lbl.Content = "Miasto: " +  main_W.wybrane_lotnisko.GlowneMiasto;


            }
            if (main_W.chosen_Wojew == true)
            {
                wojewodztwo_lbl.Content = "Wojewodztwo: " + main_W.wybrane_lotnisko.Wojewodztwo;


            }




        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
