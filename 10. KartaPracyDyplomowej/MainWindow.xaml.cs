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
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using System.Configuration;
using System.Collections.Specialized;
using System.Runtime.Serialization;
using System.Xml;
using System.Collections.Specialized;
using System.Reflection;
using Microsoft.Win32;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Interop;


namespace KartaPracyDyplomowej
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public class Licencjat
        {
            [XmlAttribute("uczelnia")]
            public string uczelnia;
            [XmlAttribute("kierunek")]
            public string kierunek { get; set; }
            [XmlAttribute("studia_zakres")]
            public string studia_zakres { get; set; }
            [XmlAttribute("profil")]
            public string profil { get; set; }
            [XmlAttribute("forma")]
            public string forma { get; set; }
            [XmlAttribute("poziom")]
            public string poziom { get; set; }
            [XmlAttribute("imie_nazwisko")]
            public string imie_nazwisko { get; set; }
            [XmlAttribute("nr_albumu")]
            public string nr_albumu { get; set; }
            [XmlAttribute("tytul_pracy")]
            public string tytuł_pracy { get; set; }
            [XmlAttribute("tytul_ang")]
            public string tytuł_ang { get; set; }
            [XmlAttribute("zakres_pracy")]
            public string zakres_pracy { get; set; }
            [XmlAttribute("termin_oddania")]
            public string termin_oddania { get; set; }
            [XmlAttribute("promotor")]
            public string promotor { get; set; }
            [XmlAttribute("jednostka_organizacyjna")]
            public string jednostka_organizacyjna { get; set; }


        }


        //POMOCNICZE ZMIENNE DO ZAPISU I WCZYTANIA

       
            public string h_uczelnia = " ";
            public string h_kierunek = " ";
            public string h_studia_zakres = " ";
            public string h_profil = " ";
            public string h_forma = " ";
            public string h_poziom = " ";
            public string h_imie_nazwisko = " ";
            public string h_nr_albumu = " ";
            public string h_tytuł_pracy = " ";
            public string h_tytuł_ang = " ";
            public string h_zakres_pracy = " ";
            public string h_termin_oddania = " ";
            public string h_promotor = " ";
            public string h_jednostka_organizacyjna = " ";



            public string text = "\t Zobowiązuję/zobowiązujemy się samodzielnie wykonać pracę w zakresie wyspecyfikowanym niżej. Wszystkie elementy (m.in. rysunki, tabele, cytaty,\n programy komputerowe, urządzenia itp.), które zostaną wykorzystane w pracy, a nie będą mojego/naszego autorstwa będą w odpowiedni sposób zaznaczone\n i będzie podane źródło ich pochodzenia.\n\n  Jeżeli w wyniku realizacji pracy zostanie dokonany wynalazek, wzór użytkowy, wzór przemysłowy, znak towarowy,\n prawa do rozwiązań przysługiwać będą Politechnice Poznańskiej.Prawo to zostanie uregulowane odrębną umową.\n" +
            "Oświadczam, iż o wyniku prac wskazanych powyżej, a także o innych, w tym tych, które mogą być przedmiotem tajemnicy\n Politechniki Poznańskiej, niezwłocznie powiadomię promotora pracy. Zobowiązuję się ponadto do zachowania w tajemnicy wszystkich informacji\n technicznych, technologicznych, organizacyjnych, uzyskanych w Politechnice Poznańskiej\n w okresie od daty rozpoczęcia realizacji prac do 5 lat od daty zakończenia wykonania prac. ";


         
        
        




        public Licencjat stud1 = new Licencjat();

        List<Licencjat> studenci = new List<Licencjat>();

        public MainWindow()
        {
            InitializeComponent();
            logo_load();

            label_zobowiazanie.Content = text;
            
            start temp1 = new start();

            temp1.ShowDialog();

            int load = temp1.yesno;
            if(load == 1)
            {
                StartLoad();
            }

            showSt();

        }

        public void logo_load()
        {
            BitmapImage logo_image;

            string image_path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

            Uri fileUri = new Uri(image_path + "\\logo.jpg");
            logo_image = new BitmapImage(fileUri);

            PPlogo.Source = logo_image;

        }

        public void showSt()
        {
            tbx_uczelnia.Text = stud1.uczelnia;
            tbx_kierunek.Text = stud1.kierunek;
            tbx_studiazakres.Text = stud1.studia_zakres;
            tbx_profil.Text = stud1.profil;
            tbx_forma.Text = stud1.forma;
            tbx_poziom.Text = stud1.poziom;
            tbx_imie_nazwisko.Text = stud1.imie_nazwisko;
            tbx_nr_albumu.Text = stud1.nr_albumu;
            tbx_tytulpracy.Text = stud1.tytuł_pracy;
            tbx_tytulang.Text = stud1.tytuł_ang;
            tbx_zakrespracy.Text = stud1.zakres_pracy;
            tbx_terminoddania.Text = stud1.termin_oddania;
            tbx_promotor.Text = stud1.promotor;
            tbx_jednostkapromotora.Text = stud1.jednostka_organizacyjna;
        }

        public void StartLoad()     //do zrobienia jak juz ogarne zapis i wtedy wczytac plik
        {

            OpenFileDialog load_file = new OpenFileDialog();


            if (load_file.ShowDialog() == true)
            {
                XmlDocument temp1 = new XmlDocument();              //tez dziala ale nie jest przez deserializacje
                temp1.Load(load_file.FileName);

                foreach (XmlNode node in temp1.DocumentElement)
                {
                    stud1.uczelnia = node.Attributes[0].Value;
                    stud1.kierunek = node.Attributes[1].Value;
                    stud1.studia_zakres = node.Attributes[2].Value;
                    stud1.profil = node.Attributes[3].Value;
                    stud1.forma = node.Attributes[4].Value;
                    stud1.poziom = node.Attributes[5].Value;
                    stud1.imie_nazwisko = node.Attributes[6].Value;
                    stud1.nr_albumu = node.Attributes[7].Value;
                    stud1.tytuł_pracy = node.Attributes[8].Value;
                    stud1.tytuł_ang = node.Attributes[9].Value;
                    stud1.zakres_pracy = node.Attributes[10].Value;
                    stud1.termin_oddania = node.Attributes[11].Value;
                    stud1.promotor = node.Attributes[12].Value;
                    stud1.jednostka_organizacyjna = node.Attributes[13].Value;


                    /*
                     
                    h_uczelnia = node.Attributes[0].Value;
                    h_kierunek = node.Attributes[1].Value;
                    h_studia_zakres = node.Attributes[2].Value;
                    h_profil = node.Attributes[3].Value;
                    h_forma = node.Attributes[4].Value;
                    h_poziom = node.Attributes[5].Value;
                    h_imie_nazwisko = node.Attributes[6].Value;
                    h_nr_albumu = node.Attributes[7].Value;
                    h_tytuł_pracy = node.Attributes[8].Value;
                    h_tytuł_ang = node.Attributes[9].Value;     //chyba można by zrobić liste argumentów i po nich iterować
                    h_zakres_pracy = node.Attributes[10].Value;
                    h_termin_oddania = node.Attributes[11].Value;
                    h_promotor = node.Attributes[12].Value;
                    h_jednostka_organizacyjna = node.Attributes[13].Value;



                    studenci.Add(new Licencjat { imie_nazwisko = })

                    dane.Add(new User { Name = n, Count = c, ID = i });


                    */

                    studenci.Add(stud1); // dodanie wczytanego studenta do listy (do zapisu sie przyda)

                }



            }
         
        }


        public static void XmlSerialize<T>(T list_of_data, string file_path_xml)           //Serializacja obiektu
        {
            XmlSerializer xml_serial = new XmlSerializer(list_of_data.GetType());


            using (StreamWriter save = new StreamWriter(file_path_xml))             //zapis
            {
                xml_serial.Serialize(save, list_of_data);
            }
        }




        public List<Licencjat> XmlDeserialization<List>(string file_path_xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List));

            using (StreamReader DesXml = new StreamReader(file_path_xml))
            {
                return (List<Licencjat>)serializer.Deserialize(DesXml);
            }
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {

            string save_text = "Czy chcesz zapisać projekt?";

            

            stud1.uczelnia = tbx_uczelnia.Text;
            stud1.kierunek = tbx_kierunek.Text;
            stud1.studia_zakres = tbx_studiazakres.Text;
            stud1.profil = tbx_profil.Text;
            stud1.forma = tbx_forma.Text;
            stud1.poziom = tbx_poziom.Text;
            stud1.imie_nazwisko = tbx_imie_nazwisko.Text;
            stud1.nr_albumu = tbx_nr_albumu.Text;
            stud1.tytuł_pracy = tbx_tytulpracy.Text;
            stud1.tytuł_ang = tbx_tytulang.Text;
            stud1.zakres_pracy = tbx_zakrespracy.Text;
            stud1.termin_oddania = tbx_terminoddania.Text;
            stud1.promotor = tbx_promotor.Text;
            stud1.jednostka_organizacyjna = tbx_jednostkapromotora.Text;


            studenci.Add(stud1);
            
            start temp3 = new start();

            temp3.tekst_z_maina.Content = save_text; //wyswietlenie zapisania o zapisie

            temp3.ShowDialog();

            int save = temp3.yesno;
            if (save == 1)
            {
                SaveFileDialog save_file = new SaveFileDialog();

                if (save_file.ShowDialog() == true)
                {

                    XmlSerialize(studenci, save_file.FileName);
                }
                else
                {
                    MessageBox.Show("Brak pliku.");
                }
            }
            else
            {
                this.Close();
            }
            
            



           



        }
    }
}
