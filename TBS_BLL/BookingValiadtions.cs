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
    public class BookingValiadtions
    {
        private bool ValidateBooking(Booking newBooking)
        {
            bool isValidBooking = true;
            StringBuilder sbClientError = new StringBuilder();
            DateTime xTwoHours= DateTime.Now.AddHours(2);
            if (newBooking.TripDate.Equals(string.Empty))//validation for blank name
            {
                isValidBooking = false;
                sbClientError.Append("Trip date cannot be empty)" + Environment.NewLine);
            }
            if (newBooking.TripDate<xTwoHours)//validation for blank name
            {
                isValidBooking = false;
                sbClientError.Append("Trip date should be atleast two hours from now)" + Environment.NewLine);
            }
            return isValidBooking;
        }

        public DataTable CheckBooking(string EmpID)
        {
            BookingOperations bo = new BookingOperations();
            return bo.CheckBooking(EmpID);
        }
    

        public int BookingTaxi_BLL(Booking pobj)
        {
            try
            {
                BookingOperations pd = new BookingOperations();
                return pd.BookingTaxi_DAL(pobj);
            }
            catch (TaxiExceptions)
            {
                throw;
            }
        }
        public DataTable BookStatus(string custId)
        {
            BookingOperations bookingOperations = new BookingOperations();
            return bookingOperations.Book_Statusdal(custId);
        }
        public Booking SearchBooking_BLL(int bookingID)
        {
            try
            {
                BookingOperations pd = new BookingOperations();
                return pd.SearchBook_DAL(bookingID);
            }
            catch (TaxiExceptions)
            {
                throw;
            }
        }

        public DataTable DisplayBooking_BLL()
        {
            try
            {
                BookingOperations pd = new BookingOperations();
                return pd.DisplayBook_DAL();
            }
            catch (TaxiExceptions)
            {
                throw;
            }
        }
    }
}
