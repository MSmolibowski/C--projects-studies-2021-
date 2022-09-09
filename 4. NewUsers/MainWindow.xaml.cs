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
using System.Xml;


namespace NewUsers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<User> dane = new List<User>();


        public string usr_name;
        public int usr_count;
        public int usr_id = 0;

        public MainWindow()
        {

            InitializeComponent();


        }

        public void add_Click(object sender, RoutedEventArgs e)
        {
            AddUserxaml AU_W = new AddUserxaml(usr_name, usr_count);
            AU_W.ShowDialog();

            usr_name = AU_W.name;
            usr_count = AU_W.count;
            usr_id = usr_id + 1;


            dane.Add(new User() { Name = usr_name, Count = usr_count, ID = usr_id });

            lvUsers.ItemsSource = dane;
        }

        public void show_Click(object sender, RoutedEventArgs e)
        {
            
            lvUsers.Items.Refresh();
        }

        public void save_Click_1(object sender, RoutedEventArgs e)
        {

            //  var path = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "\fileName.txt");

            // SaveFileDialog save_file = new SaveFileDialog();
            //save_file.Filter = "Text file (*.txt)|*.txt |CSV file (*.csv) |*.csv |All files (*.*)|*.*";

            // save_file.ShowDialog();

            // string savePathCSV = save_file.FileName;

            // string savePathCSV = path;

            /*
            string file = @"asdad.csv";

            FileInfo f = new FileInfo(file);

            string fullname = f.FullName;

            MessageBox.Show(fullname.ToString());

            using (var output = new StreamWriter(fullname))
            {
                foreach (User item in lvUsers.Items)
                {
                    output.WriteLine("{0};{1};{2}", item.Name, item.Count, item.ID);
                }



            }
            */


            string fullFileName = fi.FullName;
            Console.WriteLine("File Name: {0}", fullFileName);


           // XmlSerialize(dane, save_file.FileName);


        }

        public static void XmlSerialize<T>(T list_of_data, string file_path_xml)           //Serializacja obiektu
        {
            XmlSerializer xml_serial = new XmlSerializer(list_of_data.GetType());

            using (StreamWriter save = new StreamWriter(file_path_xml))             //zapis
            {
                xml_serial.Serialize(save, list_of_data);
            }
        }

        public class User
        {
            public string Name { get; set; }
            public int Count { get; set; }
            public int ID { get; set; }

        }

        public void load_Click(object sender, RoutedEventArgs e)
        {
            

            lvUsers.Items.Clear();

            dane.Clear();


            FileDialog load_file = new OpenFileDialog();
            load_file.ShowDialog();

            string inputPathCSV = load_file.FileName;
            string[] lines = File.ReadAllLines(inputPathCSV);


            foreach (var item in lines)
            {
                string[] data = item.Split(';');

                this.lvUsers.Items.Add(new User { Name = data[0], Count =  int.Parse(data[1]), ID = int.Parse(data[2]) });

                dane.Add(new User { Name = data[0], Count = int.Parse(data[1]), ID = int.Parse(data[2]) });
            }
        }

        public void sort_count_Click(object sender, RoutedEventArgs e)
        {
          //  lvUsers.Items.Clear();


            dane.Sort((x, y) => x.Count.CompareTo(y.Count));


            lvUsers.ItemsSource = dane;
            lvUsers.Items.Refresh();

        }

        private void name_Click(object sender, RoutedEventArgs e)
        {

            dane.Sort((x, y) => x.Name.CompareTo(y.Name));

            

            lvUsers.ItemsSource = dane;
            lvUsers.Items.Refresh();
        }

        private void before_sort_Click(object sender, RoutedEventArgs e)
        {
            lvUsers.Items.Clear();

        }
    }
}
