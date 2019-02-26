using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBS_Entity;
using TBS_Exception;

namespace TBS_DAL
{
   public class BookingOperations
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pboj"></param>
        /// <returns></returns>
        static string conStr = string.Empty;
        SqlConnection con = null;
        SqlCommand cmd = null;



        static BookingOperations()
        {
            conStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

        }

        public BookingOperations()
        {
            con = new SqlConnection(conStr);

        }
        public int BookingTaxi_DAL(Booking pboj) {
            int pid = 0;
            try
            {
                //con = new SqlConnection();
                //con.ConnectionString = conStr; 
                cmd = new SqlCommand();
                cmd.CommandText = "Group4.udp_InsertBooking";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@EmployeeID", SqlDbType.Int);
                cmd.Parameters["@EmployeeID"].Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("@CustomerID", pboj.CustomerID);
                cmd.Parameters.AddWithValue("@BookingDate", pboj.BookingDate);
                cmd.Parameters.AddWithValue("@EndDate", pboj.EndDate);
                cmd.Parameters.AddWithValue("@StartDate", pboj.StartDate);
                cmd.Parameters.AddWithValue("@TaxiID", pboj.TaxiID);
                cmd.Parameters.AddWithValue("@TripDate", pboj.TripDate);
                cmd.Parameters.AddWithValue("@SourceAddress", pboj.SourceAddress);
                cmd.Parameters.AddWithValue("@DestinationAddress", pboj.DestinationAddress);
                con.Open();
                int noOfRowsAffected = cmd.ExecuteNonQuery();
                pid = int.Parse(cmd.Parameters["@EmployeeID"].Value.ToString());
            }
           
            catch (SqlException)
            {
                throw;
            }
            catch (SystemException)
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return pid;


        }

        public DataTable CheckBooking(string EmpID)
        {
            SqlDataReader dr;
            SqlDataAdapter dr2;
            int TaxiID = 0;
            int EmpID1 = 0;
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            
            try
            {
                
                con.Open();
                SqlCommand cmd2 = new SqlCommand($"select EmployeeID from Group4.Users where LoginID='{EmpID}'", con);
                 dr = cmd2.ExecuteReader();
                if (dr.HasRows)
                {
                    dt.Load(dr);
                    EmpID1 = int.Parse(dt.Rows[0][0].ToString());
                    dr.Close();
                }

                //cmd = new SqlCommand($"select TaxiID from Group4.Taxi t INNER JOIN Group4.Employee e ON t.EmployeeID=e.EmployeeID where t.EmployeeID={EmpID1}", con);

                cmd = new SqlCommand("Group4.udpCheekBooking");
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeID", EmpID1);
                dr = cmd.ExecuteReader();
                if(dr.HasRows)
                {
                    dt1.Load(dr);
                    TaxiID = int.Parse(dt1.Rows[0][0].ToString());
                    dr.Close();
                }
                // SqlCommand cmd1 = new SqlCommand($"select * from Group4.Booking where TaxiID= {TaxiID}",con);
                if (TaxiID != 0)
                {
                    SqlCommand cmd1 = new SqlCommand("Group4.udpCheekBooking1");
                    cmd1.Connection = con;
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@TaxiID", TaxiID);

                    dr = cmd1.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dt2.Load(dr);
                        dr.Close();
                    }
                }

            }
            catch (SqlException)
            {
                throw;
            }
            catch (SystemException)
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                    
                }
            }
            return dt2;
        }

        public DataTable Book_Statusdal(string custId)
        {
            DataTable dt = new DataTable();
            try
            {

                cmd = new SqlCommand("group4.BookingStatus");
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlCommand cmd1 = new SqlCommand($"select CustomerID from group4.Users where LoginID={custId}", con);
                custId = (cmd1.ExecuteScalar().ToString());

                cmd.Parameters.AddWithValue("@CustomerID", custId);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {

                    dt.Load(dr);
                }
            }
            catch (SqlException)
            {
                throw;
            }
            catch (SystemException)
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }


            return dt;

        }
        #region UdateBooking//public bool UpdateBook_DAL(Booking pboj)
        //{
        //    bool result = false;
        //    try
        //    {
        //        // con = new SqlConnection();
        //        //   con.ConnectionString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        //        cmd = new SqlCommand();
        //        cmd.CommandText = "Group4.udp_UpdateEmployee";
        //        cmd.Connection = con;
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        cmd.Parameters.AddWithValue("@BookingID", pboj.BookingID);
        //        cmd.Parameters.AddWithValue("@CustomerID", pboj.CustomerID);
        //        cmd.Parameters.AddWithValue("@BookingDate", pboj.BookingDate);
        //        cmd.Parameters.AddWithValue("@EndDate", pboj.EndDate);
        //        cmd.Parameters.AddWithValue("@StartDate", pboj.StartDate);
        //        cmd.Parameters.AddWithValue("@TaxiID", pboj.TaxiID);
        //        cmd.Parameters.AddWithValue("@TripDate", pboj.TripDate);
        //        cmd.Parameters.AddWithValue("@SourceAddress", pboj.SourceAddress);
        //        cmd.Parameters.AddWithValue("@DestinationAddress", pboj.DestinationAddress);


        //        con.Open();
        //        int noOfRowsAffected = cmd.ExecuteNonQuery();
        //        if (noOfRowsAffected == 1)
        //        {
        //            result = true;
        //        }
        //    }

        //    catch (SqlException)
        //    {
        //        throw;
        //    }
        //    catch (SystemException)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        if (con.State == ConnectionState.Open)
        //        {
        //            con.Close();
        //        }
        //    }
        //    return result;
        //}
        #endregion
        #region DeleteBooking //public bool DeleteBook_DAL(int bookingID)
        //{

        //    bool result = false;
        //    try
        //    {
        //        //  con = new SqlConnection();
        //        // con.ConnectionString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        //        cmd = new SqlCommand();
        //        cmd.CommandText = "Geetha.uspDeleteProduct";
        //        cmd.Connection = con;
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        cmd.Parameters.AddWithValue("@pId", bookingID);

        //        con.Open();
        //        int noOfRowsAffected = cmd.ExecuteNonQuery();
        //        if (noOfRowsAffected == 1)
        //        {
        //            result = true;
        //        }
        //    }


        //    catch (SqlException)
        //    {
        //        throw;
        //    }
        //    catch (SystemException)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        if (con.State == ConnectionState.Open)
        //        {
        //            con.Close();
        //        }
        //    }
        //    return result;
        //}
        #endregion
        public DataTable DisplayBook_DAL()
        {
            DataTable dt = null;

            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "Group4.udp_DisplayBooking";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dt = new DataTable();
                    dt.Load(dr);
                }
            }
           
            catch (SqlException)
            {
                throw;
            }
            catch (SystemException)
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return dt;
        }
        public Booking SearchBook_DAL(int bookingID)
        {
            Booking p = null;

            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "Group4.udp_SearchBooking";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookingID", bookingID);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    p = new Booking
                    {
                        BookingID = int.Parse(dr["BookingID"].ToString()),
                        CustomerID = int.Parse(dr["CustomerID"].ToString()),
                        SourceAddress = dr["SourceAddress"].ToString(),
                        DestinationAddress = dr["DestinationAddress"].ToString(),
                        StartDate = DateTime.Parse(dr["StartDate"].ToString()),
                        EndDate = DateTime.Parse(dr["EndDate"].ToString()),
                        TaxiID = int.Parse(dr["TaxiID"].ToString()),
                        TripDate = DateTime.Parse(dr["TripDate"].ToString())
                    };
                    dr.Close();
                }
            }
            
            catch (SqlException)
            {
                throw;
            }
            catch (SystemException)
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return p;
        }
    }
}
