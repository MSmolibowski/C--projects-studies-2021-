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
using System.Xml;
using Microsoft.Win32;
using System.IO;
using System.Xml.Serialization;
using System.Configuration;
using System.Collections.Specialized;


namespace libraryUsers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {

        public List<User> users_data = new List<User>();

        public List<Book> books_data = new List<Book>();

        public List<Taken> taken_data = new List<Taken>();


        public string usr_name = "";
        public  string usr_surr = "";
        public int id_nu = 0;


        public string book_title = "";
        public string book_author = "";
        public int id_nb = 0;
        public string wypo_n = "";

        public class User           // klasa dla czytelników
        {
            [XmlAttribute("imie")]
            public string Imie { get; set; }
            [XmlAttribute("nazwisko")]
            public string Nazwisko { get; set; }
            [XmlAttribute("id_u")]
            public int ID_U { get; set; }

        }

        public class Book           // klasa dla ksiazek w czytelni
        {
            [XmlAttribute("tytul")]
            public string Tytul { get; set; }
            [XmlAttribute("autor")]
            public string Autor { get; set; }
            [XmlAttribute("id_b")]
            public int ID_B { get; set; }

            [XmlAttribute("wypozyczona")]
            public string Wypozyczona { get; set; }

        }

        public class Taken
        {
            [XmlAttribute("taken_user")]
            public int Taken_User { get; set;}

            [XmlAttribute("taken_book")]
            public int Taken_Book { get; set; }

            
        }

        public MainWindow()
        {
            InitializeComponent();

            load();

            sort();

            taken_books();

            UserLV.ItemsSource = users_data;
            BooksLV.ItemsSource = books_data;
            //takenLv.ItemsSource = taken_data;

            
        }


        public static void XmlSerialize<T>(T list_of_data, string file_path_xml)           //Serializacja obiektu
        {
            XmlSerializer xml_serial = new XmlSerializer(list_of_data.GetType());

            using (StreamWriter save = new StreamWriter(file_path_xml))             //zapis
            {
                xml_serial.Serialize(save, list_of_data);
            }
        }
        /*
        public List<User> XmlDeserialization<List>(string file_path_xml)        //Deserializacja
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List));

            using (StreamReader DesXml = new StreamReader(file_path_xml))
            {  
                return (List<User>)serializer.Deserialize(DesXml);          //odczyt
            }
        }
        */
        
       
        

        void load()
        {

            string users_path = AppDomain.CurrentDomain.BaseDirectory + "\\users.xml";
            string books_paht = AppDomain.CurrentDomain.BaseDirectory + "\\books.xml";
            string taken_path = AppDomain.CurrentDomain.BaseDirectory + "\\taken.xml";

            XmlDocument user_temp = new XmlDocument();              //wczytanie bez serializacji
            XmlDocument books_temp = new XmlDocument();              //wczytanie bez serializacji
            XmlDocument taken_temp = new XmlDocument();

            user_temp.Load(users_path);

            books_temp.Load(books_paht);

            taken_temp.Load(taken_path);

            foreach (XmlNode node in user_temp.DocumentElement)
            {
                string name = node.Attributes[0].Value;
                string surr = node.Attributes[1].Value;
                int id_u = int.Parse(node.Attributes[2].Value);


                users_data.Add(new User { Imie = name, Nazwisko = surr, ID_U = id_u});
            }
            UserLV.Items.Refresh();

            
            foreach (XmlNode node in books_temp.DocumentElement)
            {
                string tyt = node.Attributes[0].Value;
                string aut = node.Attributes[1].Value;
                int id_b = int.Parse(node.Attributes[2].Value);
                string wypo = node.Attributes[3].Value;


                books_data.Add(new Book { Tytul = tyt, Autor = aut, ID_B = id_b, Wypozyczona = wypo });
            }

           
            BooksLV.Items.Refresh();
            
            foreach (XmlNode node in taken_temp.DocumentElement)
            {
                int taken_usid = int.Parse(node.Attributes[0].Value);
                int taken_bid = int.Parse(node.Attributes[1].Value);


                taken_data.Add(new Taken { Taken_User = taken_usid, Taken_Book = taken_bid });
            }

           

        }

       
        void sort()
        {

            books_data.Sort((b1, b2) => b1.ID_B.CompareTo(b2.ID_B));

            users_data.Sort((u1, u2) => u1.ID_U.CompareTo(u2.ID_U));

            taken_data.Sort((t1, t2) => t1.Taken_Book.CompareTo(t2.Taken_Book));


        }


        private void add_user_Click(object sender, RoutedEventArgs e)
        {
            AddUsers AU_W = new AddUsers(usr_name, usr_surr);
            AU_W.ShowDialog();


            if(users_data.Count > 0)
            {
                id_nu = users_data.Count + 1;
            }
            else
            {
                id_nu = id_nu + 1;
            }

             usr_name = AU_W.ADU_usr_name;
             usr_surr = AU_W.ADU_usr_surr;

            //int u1 = Int32.Parse(AU_W.ADU_usr_name);
            //int u2 = Int32.Parse(AU_W.ADU_usr_surr);

            users_data.Add(new User { Imie = usr_name, Nazwisko = usr_surr, ID_U = id_nu });

           // taken_data.Add(new Taken { Taken_User = u1, Taken_Book = u2});

            


            UserLV.Items.Refresh();
        }

        private void add_book_Click(object sender, RoutedEventArgs e)
        {


            AddBook AB_W = new AddBook(book_title, book_author);
            AB_W.ShowDialog();

            if (books_data.Count > 0)
            {
                id_nb = books_data.Count + 1;
            }
            else
            {
                id_nb = id_nb + 1;
            }

            book_title = AB_W.ADB_title;
            book_author = AB_W.ADB_author;
            //id_nb = id_nb + 1;
            wypo_n = "--";


            books_data.Add(new Book { Tytul = book_title, Autor = book_author, ID_B = id_nb, Wypozyczona = wypo_n });

            BooksLV.Items.Refresh();
        }

        private void borrow_book_Click(object sender, RoutedEventArgs e)  //tu skonczylem nie wiadomo czemu przeszukiwanie sie wywala
        {
            int find_book = Int32.Parse(book_id_tbx.Text.ToString());

            int usr_who_want = Int32.Parse(usr_id_tbx.Text.ToString());

            bool jest = false;

            foreach (Taken temp1 in taken_data)
            {
                int check_id = temp1.Taken_Book; // id ksiazki z listy


                if(check_id == find_book)
                {
                    //MessageBox.Show(check_id.ToString());
                   // MessageBox.Show(find_book.ToString());

                    jest = true;

                    MessageBox.Show("Wypozyczona");

                    break;

                }
            }
            if(jest == false)
            {
                taken_data.Add(new Taken { Taken_User = usr_who_want, Taken_Book = find_book });
            }

            //takenLv.Items.Refresh();

            taken_books();


        }


        void taken_books()      //sprawdzanie, ktora ksiazka zostala wypozyczona
        {

                foreach(Taken search_book in taken_data)
                {

                    int taken_book = search_book.Taken_Book;

                    string owner = search_book.Taken_User.ToString();


                    var index = books_data.FindIndex(b => b.ID_B == taken_book);        //wyszukiwanie indexu ksiazki
                    
                    books_data[index].Wypozyczona = owner;                              //zmiana wartosci

                    //MessageBox.Show(index.ToString());

                }

            BooksLV.Items.Refresh();

        }

        private void return_book_Click(object sender, RoutedEventArgs e)
        {
            int book_return = Int32.Parse(book_id_tbx.Text.ToString());

            int usr_return = Int32.Parse(usr_id_tbx.Text.ToString());

            string temp1 = "--";

            
            var index_b= books_data.FindIndex(b => b.ID_B == book_return);     //wyszukanie indeksu dla books_data

            books_data[index_b].Wypozyczona = temp1;                              //zmiana wypozyczenia na dostepna ksiazke

            //ar index_taken_object = taken_data.FindIndex(x => x.Taken_Book== return_id);


            var index_t = taken_data.FindIndex(t => t.Taken_Book == book_return);     //wyszukanie indeksu dla taken_data

            taken_data.RemoveAt(index_t);   //usuniecie obiektu


            BooksLV.Items.Refresh();

            //takenLv.Items.Refresh();

        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            int yes_no = 0;

            if (users_data.Count() > 0)
            {
                ClosingWindow CW_W = new ClosingWindow();

                CW_W.ShowDialog();

                yes_no = CW_W.yes;

            }

            if (yes_no == 1)
            {
                string users_path = AppDomain.CurrentDomain.BaseDirectory + "\\users.xml";
                string books_paht = AppDomain.CurrentDomain.BaseDirectory + "\\books.xml";
                string taken_path = AppDomain.CurrentDomain.BaseDirectory + "\\taken.xml";



                XmlSerialize(users_data, users_path);  //zapis uzytkownikow

                XmlSerialize(books_data, books_paht);   //zapis książek

                XmlSerialize(taken_data, taken_path); //zapis listy z wypozyczonymi ksiazkami

                this.Close();
            }
        }
    }
}


