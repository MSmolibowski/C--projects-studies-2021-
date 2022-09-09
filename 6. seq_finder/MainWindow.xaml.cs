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
using Microsoft.Win32;
using System.Diagnostics;
//using System.Windows.Forms;

namespace seq_finder
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

        public string sequence = "";
        public string chosen_kmer = "";
        public List<string> kmer_array = new List<string>();



        private void wybierze_seq_Click(object sender, RoutedEventArgs e)       //zaladowanie i wczytanie seq do programu (wczytanie do ritchtextbox)
        {

            OpenFileDialog seq_path = new OpenFileDialog();
            if(seq_path.ShowDialog() == true)
            {
                sequence = File.ReadAllText(seq_path.FileName);
                sequence = sequence.Replace("\r", "");
                sequence = sequence.Replace("\n", "");

                seq_view.Document.Blocks.Add(new Paragraph(new Run(sequence)));


            }

        }
        /*
        private void add_kmer_Click(object sender, RoutedEventArgs e)
        {
            string kmer = new_kmer.Text.ToString();

            if(kmer.Length != 4)
            {
                MessageBox.Show("Błędny k-mer. Podaj k-mer o długości 4nt.");
            }
            else
            {
                kmer_chose.Items.Add(kmer);
              chosen_kmer = kmer_chose.SelectionBoxItem.ToString();
            }

            
        }
        */
        private void znajdz_wzor_Click(object sender, RoutedEventArgs e)
        {

            int k = 4;      //bo 4nt kmery
            FinderAlorythm find = new FinderAlorythm(); 

            find.Finder(sequence, k);
                    
           

        }

        public void kmer_chose_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //string chosen_kmer = ((ComboBoxItem)(((ComboBox)sender).SelectedItem)).Content.ToString();

            

            //MessageBox.Show(chosen_kmer.ToString());


            


            //int index = sequence.IndexOf(temp_string);


            /*
            TextRange tr = new TextRange(seq_view.Document.ContentEnd, seq_view.Document.ContentEnd);

            tr.Text = temp_string;
            tr.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Red);

            // MessageBox.Show(temp_string.ToString());
            */
            


            chosen_kmer = kmer_chose.SelectedValue.ToString();
            string chosen_kamer_search = chosen_kmer.Substring(0, 4);

            TextRange seq_length = new TextRange(seq_view.Document.ContentStart, seq_view.Document.ContentEnd);
            string seq_length_TXT = seq_length.Text;

            TextPointer end_pointer = seq_view.Document.ContentEnd;
            TextPointer start_pointer = seq_view.Document.ContentStart;

            seq_length.ApplyPropertyValue(TextElement.BackgroundProperty, new SolidColorBrush(Colors.White)); // wyczyszczenie zmian


            for (TextPointer start = seq_view.Document.ContentStart; start.CompareTo(seq_view.Document.ContentEnd) <= 0; start = start.GetNextContextPosition(LogicalDirection.Forward)) //rozpoczecie od poczatku pliku
            {
                if(start.CompareTo(end_pointer) == 0)
                {
                    break;
                }

                string temp1 = start.GetTextInRun(LogicalDirection.Forward);

                int index = temp1.IndexOf(chosen_kamer_search); //lokalizacja indeksu 

                if (index >= 0)
                {
                    start = start.GetPositionAtOffset(index);
                    if (start != null)
                    {
                        TextPointer temp2_point = start.GetPositionAtOffset(chosen_kamer_search.Length);
                        TextRange match = new TextRange(start, temp2_point);
                        match.ApplyPropertyValue(TextElement.BackgroundProperty, new SolidColorBrush(Colors.Green));
                    }
                }
            }




        }
    }
    public class FinderAlorythm
    {
        public void Finder(string sequence, int c)
        {
            List<(string, int)> FoundedPatterns = new List<(string, int)>();

            string seq_to_compare = "";
            
            int smoller_seq_length = sequence.Length - 4;
            int[] Count = new int[smoller_seq_length]; //liczenie wystapien kmerów

            for(int i = 0; i < smoller_seq_length; i++ )
            {
                seq_to_compare = sequence.Substring(i, 4);  //ciecie seq na podstringi od msc 0 do 4;

                Count[i] = count(sequence, seq_to_compare); //zliczenie i zapisanie wartosci do tablicy

                bool ok = FoundedPatterns.Contains((seq_to_compare, Count[i])); // sprawdzenie czy w liście nie ma juz takiego kmer'u

                if (Count[i] > 1 && ok != true) 
                {
                    FoundedPatterns.Add((seq_to_compare, Count[i])); // dodanie znalezionego fragmentu i liczby wystapien
                }


            }

           
            
            foreach (var item in FoundedPatterns)
            {
               
                ((MainWindow)Application.Current.MainWindow).kmer_chose.Items.Add(item.Item1 + '-' + item.Item2);
            }

        }

        public int count(string sequence, string seq_to_compare)
        {
            int count = 0;
            
            for (int i = 0; i < sequence.Length - seq_to_compare.Length; i++)
            {
                if (sequence.Substring(i, seq_to_compare.Length) == seq_to_compare)
                {
                    count++;

                }
            }
            return count;

        }
    }
}
