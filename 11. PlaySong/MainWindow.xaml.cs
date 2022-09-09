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

namespace PlaySong
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public    OpenFileDialog openFile = new OpenFileDialog();
        public ListBox songs;

        public MainWindow()
        {
            InitializeComponent();

        }

        private void open_btn_Click(object sender, RoutedEventArgs e)
        {
            

            if(openFile.ShowDialog() == true)
            {
                LetsPlay.Source = new Uri(openFile.FileName);

            }




        }

        private void play_btn_Click(object sender, RoutedEventArgs e)
        {
            LetsPlay.Play();

            string name = openFile.FileName.Split('\\').Last();

            played_song.Content = name;

        }

        private void stop_btn_Click(object sender, RoutedEventArgs e)
        {
            LetsPlay.Stop();
        }
    }
}
