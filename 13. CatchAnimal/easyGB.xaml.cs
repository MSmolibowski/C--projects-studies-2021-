using System;
using System.Collections.Generic;
using System.IO;
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

namespace CatchAnimal
{
    /// <summary>
    /// Interaction logic for easyGB.xaml
    /// </summary>
    public partial class easyGB : Window
    {

        string chosen_animal = "";
        private bool[] tab = { false, false, false, false };
        Object[] cards = new Object[4];


        public easyGB(string animal)
        {
            InitializeComponent();
            
            cards[0] = k0;
            cards[1] = k1;
            cards[2] = k2;
            cards[3] = k3;



            chosen_animal = animal;

            load_questtion();
           // random_kafele();

        }

        private void load_questtion()
        {
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

            foreach (Image im in cards)
            {
                im.Source = new BitmapImage(new Uri(path + "\\animals\\question.jpg", UriKind.Absolute));
            }



        }

        private void load_animal(int numb)
        {
            

            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;


            Image load_animal = new Image();

            load_animal = (Image)cards[numb];

            load_animal.Source = new BitmapImage(new Uri(path + "\\animals\\cat.jpg", UriKind.Absolute));
       
        }


        private void k1_MouseDown(object sender, MouseButtonEventArgs e)
        {

            MessageBox.Show("I was clicked");

        }

        private void k2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("I was clicked");

            load_animal(2);
        }
        private void k3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("I was clicked");

            
        }
        private void k0_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("I was clicked");
        }

    }

    
}
