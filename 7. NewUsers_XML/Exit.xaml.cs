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

namespace NewUsers
{
    /// <summary>
    /// Interaction logic for Exit.xaml
    /// </summary>
    public partial class Exit : Window
    {
        public Exit()
        {
            InitializeComponent();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).save_Click_1(sender, e);

            Environment.Exit(0);
        }

        private void dont_save_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
