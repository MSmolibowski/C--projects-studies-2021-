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

namespace CatchAnimal
{
    /// <summary>
    /// Interaction logic for hard.xaml
    /// </summary>
    public partial class hard : Window
    {

        public string animal_c;
        public string trud_c;
        public bool won_c;



        public hard(string animal, string trud, bool won)
        {
            InitializeComponent();


            animal_c = animal;
            trud_c = trud;
            won_c = won;

            if(won_c == false)
            {
                lost();
            }
            else if(won_c == true)
            {
                won_game();

                if(animal_c == "Krokodyl")
                {
                    croc_los();
                }
            }


            show_animal();
        }




        private void lost()
        {
            congrat.Content = "You Lost!";

        }

        private void won_game()
        {
            congrat.Content = "You won!";
        }

        private void croc_los()
        {
            Random eat = new Random();

            int e = eat.Next(0, 2);

            if(e == 1)
            {
                congrat.Content = "You won, and survied!";
            }
            else
            {
                congrat.Content = "You have been eaten!";
            }

        }


        private void show_animal()
        {
            string animal_to_hide = "";


            switch (animal_c)
            {
                case "Kot":
                    animal_to_hide = "cat.jpg";
                    break;

                case "Ryba":
                    animal_to_hide = "fish.jpg";

                    break;

                case "Mysz":
                    animal_to_hide = "mouse.jpg";

                    break;

                case "Krokodyl":
                    animal_to_hide = "croc.jpg";

                    break;

            }


            string path = System.IO.Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            
            cought.Source = new BitmapImage(new Uri(path + "\\animals\\" + animal_to_hide, UriKind.Absolute));   //do


        }

        private void again_Click(object sender, RoutedEventArgs e)
        {

            MainWindow new_game = new MainWindow();

            this.Close();

            new_game.ShowDialog();


        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
