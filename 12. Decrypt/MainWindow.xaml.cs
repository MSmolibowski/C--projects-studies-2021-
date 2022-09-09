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
using System.Security.Cryptography;
using System.Text;


namespace decrypt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

      

        public MainWindow()
        {
            InitializeComponent();

            temp1 = new Decryptor();
        }

        Decryptor temp1;

        private void zaszyfruj_Click(object sender, RoutedEventArgs e)
        {
            wynik.Text = temp1.encrypt(dane.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void odszyfruj_Click(object sender, RoutedEventArgs e)
        {
            wynik.Text = temp1.decrypt(dane.Text);
        }
    }
}
