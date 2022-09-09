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
using System.Windows.Controls;
using System.IO;
using System.Windows.Threading;
using System.Diagnostics;

namespace CatchAnimal
{
    /// <summary>
    /// Interaction logic for normal.xaml
    /// </summary>
    public partial class normal : Window
    {

        public int pos_X;
        public int pos_Y;
        public int size;
        public string animal_n;
        public string trud_n;

        public Stopwatch stopwatch = new Stopwatch();

        public bool won;

        public bool start_game = false;


        private int time = 3;
        private DispatcherTimer Timer;

        public normal(string animal, string trud)
        {
            InitializeComponent();

            Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Tick += Timer_Tick;

            switch (trud)
            {
                case "Łatwy":
                    size = 3;
                    break;

                case "Normalny":
                    size = 4;
                    break;

                case "Trudny":
                    size = 5;
                    break; 

            }

            animal_n = animal;
            trud_n = trud;
            

            hide_animal();

            create_board(animal_n, size, trud_n);

            czas.Text = string.Format("00:0{0}:{1}", time / 60, time % 60);


            //czas.Text = string.Format("00:0{0}:{1}", 3 / 60, 3 % 60);

        }

        void Timer_Tick(object sender, EventArgs e)
        {

            czas.Text = string.Format("00:0{0}:{1}", time / 60, time % 60);
            time = time - 1;

            if (time == 0)
            {
                Timer.Stop();

                won = false;
                hard results = new hard(animal_n, trud_n, won);
                results.ShowDialog();
                this.Close();

                
            }
        }

        private void hide_animal()
        {
            string animal_to_hide = "";




            switch(animal_n)
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


            Random rand_numb = new Random();

             pos_X = rand_numb.Next(0, size);
             pos_Y = rand_numb.Next(0, size);

            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            Image hide_animal = new Image();
            hide_animal.Width = 90;
            hide_animal.Height = 90;


            hide_animal.Source = new BitmapImage(new Uri(path + "\\animals\\" + animal_to_hide, UriKind.Absolute));   //do

           plansza.Children.Add(hide_animal);
            Grid.SetRow(hide_animal, pos_X);
            Grid.SetColumn(hide_animal, pos_Y);

        }


        private void create_board(string animal, int size,  string trud)
        {

            int board_size = size;

            /*
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            Image temp = new Image();
            temp.Width = 90;
            temp.Height = 90;

            temp.S = new BitmapImage(new Uri(path + "\\animals\\question.jpg", UriKind.Absolute));
            */

            for (int i = 0; i < board_size; i++)
            {
                for (int j = 0; j < board_size; j++)
                {
                    Rectangle myRect = new Rectangle();
                    switch (trud)
                    {
                        case "Łatwy":
                            myRect.Fill = Brushes.SpringGreen;
                            myRect.Stroke = Brushes.Black;
                            break;

                        case "Normalny":
                            myRect.Fill = Brushes.LightGoldenrodYellow;
                            myRect.Stroke = Brushes.Black;
                            break;

                        case "Trudny":
                            myRect.Fill = Brushes.MediumVioletRed;
                            myRect.Stroke = Brushes.Black;
                            break;
                          
                    }
                    myRect.HorizontalAlignment = HorizontalAlignment.Center;
                    myRect.VerticalAlignment = VerticalAlignment.Center;
                    myRect.Height = 90;
                    myRect.Width = 90;
                    myRect.MouseDown += check;
                    

                    plansza.Children.Add(myRect);
                    Grid.SetRow(myRect, i);
                    Grid.SetColumn(myRect, j);
                }
            }
        }

        private void check(object sender, MouseButtonEventArgs e)
        {

            if (start_game == false)
            {

                Timer.Start();

                start_game = true;
            }
                Rectangle check = e.Source as Rectangle;

            check.Visibility = Visibility.Hidden;

            

            if (Grid.GetRow(check) == pos_X && Grid.GetColumn(check) == pos_Y)
            {
                Timer.Stop();
                won = true;
                hard window = new hard(animal_n, trud_n, won);

                window.Show();
                this.Close();
            }

        }

    }
}
