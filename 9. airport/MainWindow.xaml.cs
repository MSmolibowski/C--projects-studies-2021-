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
using Microsoft.VisualBasic.FileIO;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;
using System.IO;
using System.Xml.Serialization;
using System.Configuration;
using System.Collections.Specialized;
using System.Reflection;
using System.Diagnostics;
using Microsoft.VisualBasic.FileIO;


namespace airport
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class Airport //klasa dla lotniska
        {

            public Airport(string GlowneMiasto, string Wojewodztwo, string ICAO, string IATA, string PortLotniczy, string LiczbaPasazerow, string Zmiana)
            {
                this.GlowneMiasto = GlowneMiasto;
                this.Wojewodztwo = Wojewodztwo;
                this.ICAO = ICAO;
                this.IATA = IATA;
                this.PortLotniczy = PortLotniczy;
                this.LiczbaPasazerow = LiczbaPasazerow;
                this.Zmiana = Zmiana;
            }

            public string GlowneMiasto { get; set; }

            public string Wojewodztwo { get; set; }

            public string ICAO { get; set; }

            public string IATA { get; set; }

            public string PortLotniczy { get; set; }

            public string LiczbaPasazerow { get; set; }

            public string Zmiana { get; set; }

        }

        public bool chosen_ICAO = false;
        public bool chosen_IATA = false;
        public bool chosen_LiczbaPas = false;
        public bool chosen_Wojew = false;
        public bool chosen_Miasto = false;





        public string elko = "elko";

 

        public List<Airport> Airports_List = new List<Airport>(); //przechowanie wczytanych lotnisk i ich inf.

        public string szukane_lotnisko = "";
        public Airport wybrane_lotnisko;

        public MainWindow()
        {
            InitializeComponent();
            Load();

            AirportLV.ItemsSource = Airports_List;
            AirportLV.Items.Refresh();


        }

        void Load()
        {
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

            using (TextFieldParser readCSV = new TextFieldParser(path + "\\Test_Data.csv"))
            {
                readCSV.SetDelimiters(new string[] { "," });
                readCSV.HasFieldsEnclosedInQuotes = true;

                readCSV.ReadLine();         //z poj. readline nie działa
                readCSV.ReadLine();

                while (!readCSV.EndOfData)
                {
                    string[] fields = readCSV.ReadFields();

                    /*
                    string GlowneMiasto = fields[0];
                    string Wojewodztwo = fields[1];
                    string ICAO = fields[2];
                    string IATA = fields[3];
                    string PortLotniczy = fields[4];
                    string LiczbaPasazerow = fields[5];
                    string Zmiana = fields[6];


                    Airport newAirport = new Airport(GlowneMiasto,Wojewodztwo,ICAO,IATA,PortLotniczy,LiczbaPasazerow,Zmiana);
                   /*
                    string GlowneMiasto = fields[0];
                    string Wojewodztwo = fields[1];
                    string ICAO = fields[2];
                    string IATA = fields[3];
                    string PortLotniczy = fields[4];
                    string LiczbaPasazerow = fields[5];
                    string Zmiana = fields[6];
                   */


                    Airport newAirport = new Airport(fields[0], fields[1], fields[2], fields[3], fields[4], fields[5], fields[6]); // dodawanie elementów do klasy
                    Airports_List.Add(newAirport);  //dodawanie obiektu do listy

                    //obie metody wczytania działają
                }

            }

        }

    private void AirportLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

           Airport temp1 = (Airport)AirportLV.SelectedItems[0]; //wybranie elementu

           szukane_lotnisko = temp1.PortLotniczy.ToString();   //zapisanie wybranej nazwy lotniska



             //MessageBox.Show(temp1.PortLotniczy.ToString());

           
        }


  

        private void ICAO_Checked(object sender, RoutedEventArgs e)
        {
            chosen_ICAO = true;
        }

        private void ICAO_unChecked(object sender, RoutedEventArgs e)
        {
            chosen_ICAO = false;
        }

        private void IATA_Checked(object sender, RoutedEventArgs e)
        {
            chosen_IATA = true;
        }

        private void IATA_unChecked(object sender, RoutedEventArgs e)
        {
            chosen_IATA = false;
        }

        private void pasazerowie_Checked(object sender, RoutedEventArgs e)
        {
            chosen_LiczbaPas = true;
        }

        private void pasazerowie_unChecked(object sender, RoutedEventArgs e)
        {
            chosen_LiczbaPas = false;
        }

        private void wojewodztwo_Checked(object sender, RoutedEventArgs e)
        {
            chosen_Wojew = true;
        }

        private void wojewodztwo_unChecked(object sender, RoutedEventArgs e)
        {
            chosen_Wojew = false;
        }

        private void miasto_Checked(object sender, RoutedEventArgs e)
        {
            chosen_Miasto = true;
        }

        private void miasto_unChecked(object sender, RoutedEventArgs e)
        {
            chosen_Miasto = false;
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            foreach (Airport find_A in Airports_List)
            {
                if (find_A.PortLotniczy == szukane_lotnisko)
                {
                    wybrane_lotnisko = find_A;
                }
            }

            details D_W = new details();
            D_W.ShowDialog();


            
        }
    }
}
