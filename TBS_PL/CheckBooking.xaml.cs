using System;
using System.Collections.Generic;
using System.Data;
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
using TBS_BLL;

namespace TBS_PL
{
    /// <summary>
    /// Interaction logic for CheckBooking.xaml
    /// </summary>
    public partial class CheckBooking : Window
    {
        public CheckBooking()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //int EmpID = MainWindow.id;
            //BookingValiadtions bv = new BookingValiadtions();
            //dg_CheckBooking.ItemsSource=bv.CheckBooking(EmpID).DefaultView;
            BookingValiadtions bookingValiadtions = new BookingValiadtions();
            string custId = MainWindow.id;

            DataTable dt = bookingValiadtions.CheckBooking(custId);
            dg_CheckBooking.ItemsSource = dt.DefaultView;
        }
    }
}
