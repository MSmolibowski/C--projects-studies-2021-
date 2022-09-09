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

namespace libraryUsers
{
    /// <summary>
    /// Interaction logic for ClosingWindow.xaml
    /// </summary>
    public partial class ClosingWindow : Window
    {
        public ClosingWindow()
        {
            InitializeComponent();
        }

        public int yes = 0;

        private void tak_Click(object sender, RoutedEventArgs e)
        {
            yes = 1;

            this.Close();

        }

        private void nie_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
