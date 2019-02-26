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
using TBS_Entity;
using TBS_BLL;
using TBS_Exception;

namespace TBS_PL
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        public SignUp()
        {
            InitializeComponent();
        }

        //Sign Up for Customer
        private void Btn_SignUp_Click(object sender, RoutedEventArgs e)
        {
            Customer cust = new Customer();
            cust.CustomerName = txt_Name.Text.ToString();
            cust.EmailID = txt_Email.Text;
            cust.PhoneNumber = long.Parse(txt_PhoneNumber.Text);
            cust.Address = txt_Address.Text;
            Users users = new Users();
            users.LoginID = (txt_LoginID.Text);
            users.Password = txt_Password.Password.ToString();
            users.Role = "Customer";
            //users.EmployeeID = 0;

            CustomerValidations cv = new CustomerValidations();
            try
            {
                if (cv.AddCustomer_BLL(cust, users)!=0)
                {
                    MessageBox.Show("Customer Details are added");
                    CustomerHome ch = new CustomerHome();
                    ch.Show();
                    Close();
                }
                else { throw new CustomerException("Enter details are not correct"); }
            }
            catch(CustomerException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //Cancel 
        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            Close();
        }
    }
}
