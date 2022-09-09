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
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Linq;
using System.Text;

namespace NewUsers
{
    /// <summary>
    /// Interaction logic for AddUserxaml.xaml
    /// </summary>
    public partial class AddUserxaml : Window
    {
        public string name = "N";
        public int count = 0;
        

        public AddUserxaml(string usr_name, int usr_count)
        {
            InitializeComponent();
            

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //MainWindow temp1 = new MainWindow();

            // string add_name = new_usr_name.Text;
            //  string add_count = new_usr_count.Text;
            name = new_usr_name.Text;
            count = int.Parse(new_usr_count.Text);

            this.Close();


        }

    }
}
