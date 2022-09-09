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
    /// Interaction logic for auta_marka.xaml
    /// </summary>
    public partial class auta_marka : Window
    {
        public auta_marka()
        {
            InitializeComponent();
            
        }

       // public int CM = Auta_Zmienne.cena_marka;
      //  public int CW = Auta_Zmienne.cena_wyposarzenia;

        int temp_marka = 0;
        int temp_wypo = 0;

        float temp_polisa = 0;

        float S_M = 0;

        private void Skoda_Checked(object sender, RoutedEventArgs e)
        {
            temp_marka = 500;
        }

        private void Fiat_Checked(object sender, RoutedEventArgs e)
        {
            temp_marka = 600;
            
        }

        private void Opel_Checked(object sender, RoutedEventArgs e)
        {
            temp_marka = 800;
        }

        private void Klimatyzacja_Checked(object sender, RoutedEventArgs e)
        {
            temp_wypo += 300;
        }

        private void Klima_Unchecked(object sender, RoutedEventArgs e)
        {
            temp_wypo -= 300;
        }


        private void skrzynia_checked(object sender, RoutedEventArgs e)
        {
            temp_wypo += 400;

        }

        private void skrzynia_unchecked(object sender, RoutedEventArgs e)
        {
            temp_wypo -= 400;
        }

        private void poduszki_checked(object sender, RoutedEventArgs e)
        {
            temp_wypo += 700;

        }

        private void poduszki_unchecked(object sender, RoutedEventArgs e)
        {
            temp_wypo -= 700;
        }

        private void marka_sumuj_Click(object sender, RoutedEventArgs e)
        {
            string polisa_temp = polisa_textbox.Text;                   //odczytanie stringa wartosci wpisanej polisy
            temp_polisa = float.Parse(polisa_temp);        //konwersja stringa polisy na float

            S_M = Auta_Zmienne.sumuj_marka(temp_marka, temp_wypo, temp_polisa);   //wywolanie funkcji do sumowania

            Auta_Zmienne.cena_marka_podsumowanie = S_M;

            lbl_pods_marka.Content = S_M.ToString();        //wyswietlenie sumy wybranych opcji
            


        }

        private void powrot_Click(object sender, RoutedEventArgs e)
        {
            Auta_Zmienne.auta_marka_przycisk_zamk = 1;
            this.Close();


        }


        /*
        private void reset_Click(object sender, RoutedEventArgs e)      //przycisk do resetu wartosci i przyciskow w momencie bledu
        {

            int temp_marka = 0;
            int temp_wypo = 0;
            float temp_polisa = 0;

            S_M = 0;

            lbl_pods_marka.Content = S_M.ToString();

            Klimatyzacja.IsChecked = false;
            Skrzynia.IsChecked = false;
            Poduszki.IsChecked = false;

            Skoda.IsChecked = false;
            Fiat.IsChecked = false;
            Opel.IsChecked = false;
        }
        */
    }
}
