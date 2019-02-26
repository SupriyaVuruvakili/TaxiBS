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
    public class EmployeeValidations
    {
        public int AddEmployee_BLL(Employee pobj,Users users)
        {
            try
            {
                EmployeeOperations pd = new EmployeeOperations();
                return pd.AddEmployee_DAL(pobj,users);
            }
            catch (TaxiExceptions)
            {
                throw;
            }
        }

        public bool UpdateEmployee_BLL(Employee pobj)
        {
            try
            {
                EmployeeOperations pd = new EmployeeOperations();
                return pd.UpdateEmployee_DAL(pobj);
            }
            catch (TaxiExceptions)
            {
                throw;
            }
        }

        public bool DeleteEmployee_BLL(int employeeID)
        {
            try
            {
                EmployeeOperations pd = new EmployeeOperations();
                return pd.DeleteEmployee_DAL(employeeID);
            }
            catch (TaxiExceptions)
            {
                throw;
            }
        }

        public Employee SearchEmployee_BLL(int employeeID)
        {
            try
            {
                EmployeeOperations pd = new EmployeeOperations();
                return pd.SearchEmployee_DAL(employeeID);
            }
            catch (TaxiExceptions)
            {
                throw;
            }
        }

        public DataTable DisplayEmployee_BLL()
        {
            try
            {
                EmployeeOperations pd = new EmployeeOperations();
                return pd.DisplayEmployee_DAL();
            }
            catch (TaxiExceptions)
            {
                throw;
            }
        }
    }
}
