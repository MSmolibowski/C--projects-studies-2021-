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
using System.Windows.Threading;

namespace Clock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            startclock();
        }

        private void startclock()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += tickerevent;
            timer.Start();
        }

        private void tickerevent(object sender, EventArgs e)
        {
            datelb.Text = DateTime.Now.ToString(@"h\:m\:ss");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            stopwatch_window sw = new stopwatch_window();
            sw.Show();
        }
    }
}
