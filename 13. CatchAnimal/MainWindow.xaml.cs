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

namespace CatchAnimal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string zwierz = "";
        string trud = "";

        public MainWindow()
        {
            InitializeComponent();

        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            zwierz = zwierze.Text;
            trud = trudnosc.Text;


            int los;

            normal normal = new normal(zwierz, trud);
            normal.ShowDialog();

            this.Close();

        }


        private int random_kafele(int numb)
        {
            Random random = new Random();

            int los_numb = random.Next(0, numb);


            return los_numb;
        }



    }
}
