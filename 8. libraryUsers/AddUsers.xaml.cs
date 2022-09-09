using System;
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
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUsers : Window
    {
        public string ADU_usr_name = "";
        public string ADU_usr_surr = "S";


        public AddUsers(string us_nam, string us_srr)
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            ADU_usr_name = name_tbx.Text;

            ADU_usr_surr = surr_txb.Text;

            this.Close();

        }

        


    }
}
