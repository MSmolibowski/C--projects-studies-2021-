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
using System.Windows.Shapes;

namespace KartaPracyDyplomowej
{
    /// <summary>
    /// Interaction logic for start.xaml
    /// </summary>
    public partial class start : Window
    {   
        public int yesno = 0;

        public start()
        {
            InitializeComponent();

            loadorsave();

        }


        public void loadorsave()
        {
           // MainWindow temp2 = new MainWindow();
           // tekst_z_maina.Content = temp2.load_save_text;
        }

        private void Button_Click(object sender, RoutedEventArgs e) //tak
        {
            yesno = 1;

            //dodac przekazanie wartosci, ktora pojdzie do drugiego okna i wywoła if'a z wyborem ścieżki
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)   //nie
        {
            this.Close();
        }
    }
}
