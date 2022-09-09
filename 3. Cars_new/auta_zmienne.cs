using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars_new
{
    static class Auta_Zmienne
    {
        //zmienne do sprawdzenie czy zamknieto przyciskiem

        public static int auta_marka_przycisk_otw = 0;
        public static int auta_marka_przycisk_zamk = 0;


        public static int auta_silnik_przycisk_otw = 0;
        public static int auta_silnik_przycisk_zamk = 0;


        //zmienna podsumowujaca wszystkie wybory
        public static float cena_auto_podsumowanie = 0;

        //zmienne do wyboru auta_marka
        public static float cena_marka_podsumowanie = 0;

        public static int cena_marka = 0;
        public static int cena_wyposarzenia = 0;
        public static float cena_polisy = 0;
        //zmienne do auta_silnik
        public static int cena_silnik_podsumowanie;

        public static int cena_pojemnosc = 0;
        public static int cena_silnika = 0;

        internal static float sumuj_marka(int m, int w, float p)
        {
            float SM = m + w + p;

            return SM;
        }

        internal static int sumuj_silnik(int s, int poj)
        {
            int SS = cena_silnika + cena_pojemnosc;

            return SS;
        }


        internal static float sumuj_auto(float cmp, int csp)
        {
            float SA = cena_marka_podsumowanie + cena_silnik_podsumowanie;

            return SA;
        }


    }
}
