using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBS_DAL;
using TBS_Entity;
using TBS_Exception;

namespace TBS_BLL
{
    public class CustomerValidations
    {
        public int AddCustomer_BLL(Customer pobj,Users users)
        {
            try
            {
                CustomerOperations pd = new CustomerOperations();
                return pd.AddCustomer_DAL(pobj,users);
            }
            catch (TaxiExceptions)
            {
                throw;
            }
        }
        public bool UpdateCustomer_BLL(Customer pobj)
        {
            try
            {
                CustomerOperations co = new CustomerOperations();
                return co.UpdateCustomer_DAL(pobj);
            }
            catch (TaxiExceptions)
            {
                throw;
            }
        }
        public bool DeleteCustomer_BLL(int customerID)
        {
            try
            {
                CustomerOperations pd = new CustomerOperations();
                return pd.DeleteCustomer_DAL(customerID);
            }
            catch (TaxiExceptions)
            {
                throw;
            }
        }

        public Customer SearchCustomer_BLL(int customerID)
        {
            try
            {
                CustomerOperations pd = new CustomerOperations();
                return pd.SearchCustomer_DAL(customerID);
            }
            catch (TaxiExceptions)
            {
                throw;
            }
        }

        public DataTable DisplayCustomer_BLL()
        {
            try
            {
                CustomerOperations pd = new CustomerOperations();
                return pd.DisplayCustomer_DAL();
            }
            catch (TaxiExceptions)
            {
                throw;
            }
        }
    }
}
