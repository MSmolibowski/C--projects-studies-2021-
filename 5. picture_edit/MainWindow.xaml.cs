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
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Interop;

//using System.Windows.Forms;



namespace picture_edit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        BitmapImage pic1;

        public static int click_count_mirror = 0;
        public static int click_count_rotate = 0;


        private void chose_Click(object sender, RoutedEventArgs e)
        {

            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                
                Uri fileUri = new Uri(openFileDialog.FileName);
                pic1 = new BitmapImage(fileUri);
               
                image.Source = pic1;
                
            }

            
        }

        private Bitmap BitmapImage2Bitmap(BitmapImage bitmapImage)  //konwersja bitmapImage do Bitmap
        {
            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapImage));
                enc.Save(outStream);
                Bitmap bitmap = new Bitmap(outStream);

                return new Bitmap(bitmap);
            }
        }

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);

        private BitmapImage Bitmap2BitmapImage(Bitmap bitmap)       //konwersaja Bitmap do BitmapImage
        {
            BitmapImage bitmapImage = new BitmapImage();
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                memory.Position = 0;
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
            }
            return bitmapImage;
        }


        private void obrot_Click(object sender, RoutedEventArgs e)
        {

            click_count_rotate++;

            var biOriginal = pic1;
             //(BitmapImage)image.Source;

            
                Bitmap rotate_pict = BitmapImage2Bitmap(pic1);

                rotate_pict.RotateFlip(RotateFlipType.Rotate90FlipNone);

                image.Source = Bitmap2BitmapImage(rotate_pict);
                pic1 = Bitmap2BitmapImage(rotate_pict);


        }

        private void negatyw_Click(object sender, RoutedEventArgs e)
        {

            

           Bitmap temp3 = BitmapImage2Bitmap(pic1);

           
            for(int i = 0; i < temp3.Height; i++)
            {
                for(int j = 0; j< temp3.Width; j++)
                {
                    System.Drawing.Color p = temp3.GetPixel(j, i);

                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;


                    r = 255 - p.R;
                    g = 255 - p.G;
                    b = 255 - p.B;

                    temp3.SetPixel(j, i, System.Drawing.Color.FromArgb(255, r, g, b));

                }
            }

            

            image.Source = Bitmap2BitmapImage(temp3);

            pic1 = Bitmap2BitmapImage(temp3);



        }

        private void zielony_Click(object sender, RoutedEventArgs e)
        {
            Bitmap green_pic = BitmapImage2Bitmap(pic1);

            for(int i = 0; i < green_pic.Height; i++)
            {
                for(int j  = 0; j < green_pic.Width; j++)
                {
                    System.Drawing.Color p = green_pic.GetPixel(j, i);
                    if (p.R < 50 & p.G < 150 & p.B < 50)    // jesli natezenie dla poszczegolnych kolorow jest mniejsze to ustaw na white
                    {
                        p = System.Drawing.Color.White;
                        green_pic.SetPixel(j, i, p);    //p tutaj to pixel color
                    }
                }
            }

            image.Source = Bitmap2BitmapImage(green_pic);
            pic1 = Bitmap2BitmapImage(green_pic);



        }

        private void lustro_Click(object sender, RoutedEventArgs e)
        {

            //lustrzane odbicie z powieleniem
            /*
            Bitmap temp4_mirror = BitmapImage2Bitmap(pic1);

            int width = temp4_mirror.Width;
            int height = temp4_mirror.Height;

            //mirror 

            Bitmap mirror_pic = new Bitmap(width * 2, height);

            for (int i = 0; i < height; i++)
            {
                for (int lx = 0, rx = width * 2 - 1; lx < width; lx++, rx--)
                {
                    System.Drawing.Color p = temp4_mirror.GetPixel(lx, i);

                    //ustawienie pixeli
                    mirror_pic.SetPixel(lx, i, p);
                    mirror_pic.SetPixel(rx, i, p);

                }
            }

            
            image.Source = Bitmap2BitmapImage(mirror_pic);
            pic1 = Bitmap2BitmapImage(mirror_pic);
            */

            //odbijanie obrazka bez duplikacji

            click_count_mirror++;
            

            if(click_count_mirror == 1)
            {
                ScaleTransform mirroc_pict = new ScaleTransform();
                mirroc_pict.ScaleX = -1;
                image.RenderTransform = mirroc_pict;
                pic1 = (BitmapImage)image.Source;
            }
            else if(click_count_mirror == 2)
            {
                ScaleTransform mirroc_pict = new ScaleTransform();
                mirroc_pict.ScaleX = 1;
                image.RenderTransform = mirroc_pict;
                pic1 = (BitmapImage)image.Source;

                click_count_mirror = 0;
            }
            
                
        }
    }
}
