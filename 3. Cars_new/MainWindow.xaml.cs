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

namespace Cars_new
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

        private void Marka_Click(object sender, RoutedEventArgs e)
        {
            auta_marka AM_w = new auta_marka();
            Auta_Zmienne.auta_marka_przycisk_otw = 1;
            AM_w.ShowDialog();

            
        }

        private void Silnik_Click(object sender, RoutedEventArgs e)
        {
            auta_silnik AS_w = new auta_silnik();
            Auta_Zmienne.auta_silnik_przycisk_otw = 1;
            AS_w.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            float suma_auto = Auta_Zmienne.sumuj_auto(Auta_Zmienne.cena_marka_podsumowanie, Auta_Zmienne.cena_silnik_podsumowanie);
            
            lbl_suma_main_marka.Content = Auta_Zmienne.cena_marka_podsumowanie;
            lbl_suma_main_poj.Content = Auta_Zmienne.cena_silnik_podsumowanie;

            bool marka_good = false;
            bool silnik_good = false;

            if(Auta_Zmienne.auta_marka_przycisk_otw == 1 && Auta_Zmienne.auta_marka_przycisk_zamk == 1)
            {
                marka_good = true;
            }
            if (Auta_Zmienne.auta_silnik_przycisk_otw == 1 && Auta_Zmienne.auta_silnik_przycisk_zamk == 1)
            {
                silnik_good = true;
            }



           if(silnik_good == true && marka_good == true)
            {
                if ((Auta_Zmienne.cena_marka_podsumowanie > 0 && Auta_Zmienne.cena_silnik_podsumowanie > 0))
                {
                    Podsumowanie_Auto.Background = Brushes.Green;

                }
                if ((Auta_Zmienne.cena_marka_podsumowanie > 0 && Auta_Zmienne.cena_silnik_podsumowanie == 0) || (Auta_Zmienne.cena_marka_podsumowanie == 0 && Auta_Zmienne.cena_silnik_podsumowanie > 0))
                {
                    Podsumowanie_Auto.Background = Brushes.Yellow;
                }
            }
           
           if(silnik_good == true && Auta_Zmienne.auta_marka_przycisk_otw == 0)
            {
                Podsumowanie_Auto.Background = Brushes.Yellow;

            }
            if(marka_good == true && Auta_Zmienne.auta_silnik_przycisk_otw == 0)
            {
                Podsumowanie_Auto.Background = Brushes.Yellow;

            }
            if (marka_good == true && Auta_Zmienne.auta_silnik_przycisk_otw == 1)
            {
                if (Auta_Zmienne.auta_silnik_przycisk_zamk == 0)
                {
                    Podsumowanie_Auto.Background = Brushes.Red;

                }
            }
            if (silnik_good == true && Auta_Zmienne.auta_marka_przycisk_otw == 1)
            {
                if (Auta_Zmienne.auta_marka_przycisk_zamk == 0)
                {
                    Podsumowanie_Auto.Background = Brushes.Red;

                }
            }





            Podsumowanie_Auto.Content = Auta_Zmienne.cena_marka_podsumowanie + Auta_Zmienne.cena_silnik_podsumowanie;


        }


        //Podsumowanie2.Content = ;
    }
    }

