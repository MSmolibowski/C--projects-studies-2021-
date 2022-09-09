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
using Microsoft.Win32;
using System.IO;
using CsvHelper;
using System.Linq;
using System.Xml.Serialization;
using System.Configuration;
using System.Collections.Specialized;
using System.Runtime.Serialization;
using System.Xml;
using System.Collections.Specialized;
using System.Reflection;

namespace NewUsers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<User> dane = new List<User>();


        public string usr_name;
        public int usr_count;
        public int usr_id = 0;
        public string lastopen = "";


        public class User
        {
            [XmlAttribute("name")]
            public string Name { get; set; }
            [XmlAttribute("count")]
            public int Count { get; set; }
            [XmlAttribute("id")]
            public int ID { get; set; }

        }

        public MainWindow()
        {

            InitializeComponent();

            lvUsers.ItemsSource = dane;     //przeniesienie ItemSource do funkcji MainWindow, w innym wypadkuwystepuje problem z dodawaniem obiektu do wczytanego pliku
            
        }

        public void add_Click(object sender, RoutedEventArgs e)
        {
            

            AddUserxaml AU_W = new AddUserxaml(usr_name, usr_count);
            AU_W.ShowDialog();

            usr_name = AU_W.name;
            usr_count = AU_W.count;
            usr_id = usr_id + 1;


            dane.Add(new User() { Name = usr_name, Count = usr_count, ID = usr_id });

            lvUsers.Items.Refresh();

            

        }


        public void save_Click_1(object sender, RoutedEventArgs e)
        {

            

            SaveFileDialog save_file = new SaveFileDialog();


            //save_file.Filter = "CSV file (*.csv)|Text file (*.txt)|*.txt|*.csv|All files (*.*)|*.*";

            if (save_file.ShowDialog() == true)
            {
                //string file_path_to_xml = save_file.FileName;

                XmlSerialize(dane, save_file.FileName);
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

        
        public List<User> XmlDeserialization<List>(string file_path_xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List));

            using (StreamReader DesXml = new StreamReader(file_path_xml))
            {
                return (List<User>)serializer.Deserialize(DesXml);
            }
        }
        

        public void load_Click(object sender, RoutedEventArgs e)
        {
            

            /*
            XmlDocument temp1 = new XmlDocument();              //tez dziala ale nie jest przez deserializacje
            temp1.Load(load_file.FileName);

            foreach(XmlNode node in temp1.DocumentElement)
            {
                string n = node.Attributes[0].Value;
                int c = int.Parse(node.Attributes[1].Value);
                int i = int.Parse(node.Attributes[2].Value);

                dane.Add(new User { Name = n, Count = c, ID = i});
            }
            */
            List<User> loaded_data = new List<User>();
            OpenFileDialog load_file = new OpenFileDialog();
            

            if (load_file.ShowDialog() == true)
            {
                dane.Clear();
                loaded_data = XmlDeserialization<List<User>>(load_file.FileName);

                foreach (User el in loaded_data)
                {
                    lastopen = load_file.FileName;  //zapamietanie nazwy wczytanego ostatnio pliku

                    string n = el.Name;
                    string c_string = el.Count.ToString();
                    string i_string = el.ID.ToString();

                    dane.Add(new User { Name = n, Count = int.Parse(c_string), ID = int.Parse(i_string) });

                    usr_id = int.Parse(i_string);

                }
                
            }
            lvUsers.Items.Refresh();


           // remember_file(lastopen);
        }


        /*
        void remember_file(string filename)
        {

            
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
            configuration.AppSettings.Settings["lastopen"].Value = filename;
            configuration.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }
        */
        public void sort_count_Click(object sender, RoutedEventArgs e)
        {
            dane.Sort((x, y) => x.Count.CompareTo(y.Count));


            //lvUsers.ItemsSource = dane;
            lvUsers.Items.Refresh();

        }

        private void name_Click(object sender, RoutedEventArgs e)
        {

            dane.Sort((x, y) => x.Name.CompareTo(y.Name));

            //lvUsers.ItemsSource = dane;
            lvUsers.Items.Refresh();
        }

        private void search_button_Click(object sender, RoutedEventArgs e)
        {
            List<User> item_found = new List<User>();       // lista znalezionych obiektow
            item_found.Clear();         //wyczyszczenie listy znalezionych obiektów

            if(search_text.Text.All(char.IsLetter))     //sprawdzenie czy wprowadzone dane to liczby czy litery
            {
                string search_name = search_text.Text.ToString();
                search_name = search_name.ToLower();            



                foreach(User n_search in dane)
                {
                    string name_lower = n_search.Name.ToLower();

                    if (search_name == name_lower)
                    {

                        item_found.Add(new User { Name = n_search.Name, Count = n_search.Count, ID = n_search.ID });
                    }
                }


            }
            else
            {
                string search_count = search_text.Text.ToString();
                

                foreach (User c_search in dane)
                {
                    string count_to_string = c_search.Count.ToString();

                    if (search_count == count_to_string)
                    {

                        item_found.Add(new User { Name = c_search.Name, Count = c_search.Count, ID = c_search.ID });
                    }
                }
            }
            lvUsers.ItemsSource = item_found;
            
        }

        private void refresh_Click(object sender, RoutedEventArgs e)
        {
           // lvUsers.Items.Clear();
            lvUsers.ItemsSource = dane;
            lvUsers.Items.Refresh();
        }

        

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            if (dane.Count() > 0)
            {
                Exit popupExit = new Exit();
                popupExit.ShowDialog();
                
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}
