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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Diagnostics;
using System.Timers;

namespace Clock
{
    /// <summary>
    /// Interaction logic for stopwatch_window.xaml
    /// </summary>
    public partial class stopwatch_window : Window
    {
        const string TimeDisplay = "00:00:00";
        private Stopwatch stopwatch;
        private Timer timer;

        public stopwatch_window()
        {
            InitializeComponent();
            startTimer.Text = TimeDisplay;

            stopwatch = new Stopwatch();
            timer = new Timer(interval: 1000);

            timer.Elapsed += OnTimerElapsed;

        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(() => startTimer.Text = stopwatch.Elapsed.ToString(format: @"hh\:mm\:ss"));
        }

        private void Start(object sender, RoutedEventArgs e)
        {
            stopwatch.Start();
            timer.Start();
            
        }

        private void Stop(object sender, RoutedEventArgs e)
        {
            stopwatch.Start();
            timer.Stop();
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            stopwatch.Reset();
            startTimer.Text = TimeDisplay;
        }
    }
}
