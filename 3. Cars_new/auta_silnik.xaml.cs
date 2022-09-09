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

namespace Cars_new
{
    /// <summary>
    /// Interaction logic for auta_silnik.xaml
    /// </summary>
    public partial class auta_silnik : Window
    {
        string chose_poj;       //zmienna do zapamietania wybranej pojemnosci
        string[] silnik_poj = new string[] { "1.4", "1.6", "1.9", "2.2" };  //tablica dostepnych pojemnosci

        public auta_silnik()
        {
            InitializeComponent();
        }

        private void Gaz_Checked(object sender, RoutedEventArgs e)
        {
            Auta_Zmienne.cena_silnika = 4000;
        }

        private void Diesel_Checked(object sender, RoutedEventArgs e)
        {
            Auta_Zmienne.cena_silnika = 3000;

        }

        private void Benzyna_Checked(object sender, RoutedEventArgs e)
        {
            Auta_Zmienne.cena_silnika = 2000;

        }

        private void Hybryda_Checked(object sender, RoutedEventArgs e)
        {
            Auta_Zmienne.cena_silnika = 10000;

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            chose_poj = ((ComboBoxItem)(((ComboBox)sender).SelectedItem)).Content.ToString();

        }

        private void silnik_sumuj_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < silnik_poj.Length; i++)             //petla do sprawdzenia wyboru pojemnosci
            {

                if (chose_poj == silnik_poj[0])
                {
                    Auta_Zmienne.cena_pojemnosc = 3000;
                }
                if (chose_poj == silnik_poj[1])
                {
                    Auta_Zmienne.cena_pojemnosc = 4000;
                }
                if (chose_poj == silnik_poj[2])
                {
                    Auta_Zmienne.cena_pojemnosc = 6000;
                }
                if (chose_poj == silnik_poj[3])
                {
                    Auta_Zmienne.cena_pojemnosc = 22000;
                }
            }

            int silnik_temp = Auta_Zmienne.cena_silnika;
            int poj_temp = Auta_Zmienne.cena_pojemnosc;

            int CS = Auta_Zmienne.sumuj_silnik(silnik_temp, poj_temp);

            Auta_Zmienne.cena_silnik_podsumowanie = CS;

            lbl_pods_silnik.Content = CS.ToString();
        }

        private void powrot_silnik_Click(object sender, RoutedEventArgs e)
        {
            Auta_Zmienne.auta_silnik_przycisk_zamk = 1;
            this.Close();
        }
    }
}
