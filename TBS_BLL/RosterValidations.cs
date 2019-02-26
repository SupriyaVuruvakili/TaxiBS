using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBS_Entity;
using TBS_Exception;
using TBS_DAL;
using System.Data;

namespace TBS_BLL
{
    public class RosterValidations
    {
        private bool ValiadateRoster(EmployeeRoster newRoster)
        {
            bool isValidRoster = true;
            StringBuilder sbClientError = new StringBuilder();
            if (newRoster.EmployeeID.Equals(string.Empty))//validation for blank LoginID
            {
                isValidRoster = false;
                sbClientError.Append("Employee ID cannot be empty!!:)" + Environment.NewLine);
            }
            //validation for blank Password
            if (newRoster.RosterID.Equals(string.Empty))
            {
                isValidRoster = false;
                sbClientError.Append("Roster ID  cannot be blank!!:)" + Environment.NewLine);
            }
            if (!isValidRoster)
            {
                throw new TaxiExceptions(sbClientError.ToString());
            }
            return isValidRoster;
        }
        public DataTable AddRoaster_BLL(EmployeeRoster robj)
        {
            DataTable addRoster = null;
            try
            {
                RoasterOperations pd = new RoasterOperations();
                if (ValiadateRoster(robj))
                {
                    addRoster=pd.AddRoaster_DAL(robj);
                    return addRoster;
                }
                else
                {
                    throw new EmployeeRosterException("Failed to add Roster");
                }
                
            }
            catch (EmployeeRosterException)
            {
                throw;
            }
        }
        public DataTable DisplayRoaster_BLL()
        {
            try
            {
                RoasterOperations pd = new RoasterOperations();
                return pd.DisplayRoaster_DAL();
            }
            catch (EmployeeRosterException)
            {
                throw;
            }
        }
    }
}
