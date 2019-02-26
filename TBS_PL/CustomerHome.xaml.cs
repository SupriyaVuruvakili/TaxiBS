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
using TBS_BLL;

namespace TBS_PL
{
    /// <summary>
    /// Interaction logic for CustomerHome.xaml
    /// </summary>
    public partial class CustomerHome : Window
    {
        public CustomerHome()
        {
            InitializeComponent();
        }

        
        //Search Menu Item Click

        private void SearchMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        //Sign Out Menu Item Click

        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            Close();
        }

        private void Btn_CheckBookings_Click(object sender, RoutedEventArgs e)
        {
            CheckBooking checkBooking = new CheckBooking();
            checkBooking.Show();
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Btn_BookTaxi_Click(object sender, RoutedEventArgs e)
        {
            Booking booking = new Booking();
            booking.Show();
        }

        private void Btn_RegisterEmployees_Click(object sender, RoutedEventArgs e)
        {
            RegisterEmployee register = new RegisterEmployee();
            register.Show();
        }

        private void Btn_AddRoster_Click(object sender, RoutedEventArgs e)
        {
            AddRoster ar = new AddRoster();
            ar.Show();
        }

        private void Btn_ManageUsers_Click(object sender, RoutedEventArgs e)
        {
            ManageUsers mu = new ManageUsers();
            mu.Show();
        }

        private void Btn_BookingStatus_Click(object sender, RoutedEventArgs e)
        {
            BookingStatus bs = new BookingStatus();
            bs.Show();
        }

        private void Btn_FareCalculator_Click(object sender, RoutedEventArgs e)
        {
            FareCaluclation fareCaluclation = new FareCaluclation();
            fareCaluclation.Show();
        }

        private void Btn_ChangePasswords_Click(object sender, RoutedEventArgs e)
        {
            ChangePassword change = new ChangePassword();
            change.Show();
        }

        private void Btn_CheckRoster_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
