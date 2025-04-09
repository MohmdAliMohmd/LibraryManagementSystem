using System;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem_DataAccess
{
    public class clsFineData
    {
        public static bool GetFineByID(int FineID, ref int MemberID, ref int LoanID, ref int LibrarianID, ref decimal FineFees, ref byte Status)
        {
            bool isFound = false;
            string query = "SELECT * FROM Fines WHERE FineID = @FineID";
            try
            { 
              using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                 {         
                using(SqlCommand command = new SqlCommand(query, connection))
                    {
                    command.Parameters.AddWithValue("@FineID", FineID);        
                    connection.Open();
                     using (SqlDataReader reader = command.ExecuteReader())      
                          {
        
                        if(reader.Read())
                        {
                            isFound = true;
        
                        MemberID = (int)reader["MemberID"];
                        LoanID = (int)reader["LoanID"];
                        LibrarianID = (int)reader["LibrarianID"];
                        FineFees = Convert.ToDecimal(reader["FineFees"]);
                        Status = (byte)reader["Status"];
                         }
                        else
                         {
                            isFound = false;
                         }

                  }
                }
              }
            }
            catch(Exception ex)
            {
                isFound = false;
            }
            finally
            {
               
            }

            return isFound;
        }
        public static int AddNewFine(int MemberID, int LoanID, int LibrarianID, decimal FineFees, byte Status)
        {
            int FineID = -1;
             string query = @"INSERT INTO Fines (MemberID, LoanID, LibrarianID, FineFees, Status)
                            VALUES (@MemberID, @LoanID, @LibrarianID, @FineFees, @Status)
                            SELECT SCOPE_IDENTITY();";
        try{
             using( SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {       
                   using (SqlCommand command = new SqlCommand(query, connection))
                    {

            command.Parameters.AddWithValue("@MemberID", MemberID);
            command.Parameters.AddWithValue("@LoanID", LoanID);
            command.Parameters.AddWithValue("@LibrarianID", LibrarianID);
            command.Parameters.AddWithValue("@FineFees", FineFees);
            command.Parameters.AddWithValue("@Status", Status);
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if(result != null && int.TryParse(result.ToString(), out int insertedID))
                      {
                    FineID = insertedID;
                       }
                    }
                 }
            }
            catch(Exception ex)
            {

            }
            finally
            {
               
            }

            return FineID;
        }
        public static bool UpdateFine(int FineID, int MemberID, int LoanID, int LibrarianID, decimal FineFees, byte Status)
        {
            int rowsAffected = 0;
            string query = @"UPDATE Fines  
                                        SET 
                                        MemberID = @MemberID, 
                            LoanID = @LoanID, 
                            LibrarianID = @LibrarianID, 
                            FineFees = @FineFees, 
                            Status = @Status
                            WHERE FineID = @FineID";
            try{
                   using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        using(SqlCommand command = new SqlCommand(query, connection))
                        {

            command.Parameters.AddWithValue("@FineID", FineID);
            command.Parameters.AddWithValue("@MemberID", MemberID);
            command.Parameters.AddWithValue("@LoanID", LoanID);
            command.Parameters.AddWithValue("@LibrarianID", LibrarianID);
            command.Parameters.AddWithValue("@FineFees", FineFees);
            command.Parameters.AddWithValue("@Status", Status);
                            connection.Open();
                            rowsAffected = command.ExecuteNonQuery();
                         }
                      }
                }
            catch(Exception ex)
            {
                return false;
            }

            finally
            {
                
            }

            return (rowsAffected > 0);
        }
        public static bool DeleteFine(int FineID)
        {
            int rowsAffected = 0;
            string query = @"Delete Fines 
                                where FineID = @FineID";
            try{
                 using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        using(SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@FineID", FineID);
                            connection.Open();
                            rowsAffected = command.ExecuteNonQuery();
                         }            
                    }
                 }
                catch(Exception ex)
                {
                }
                finally
                {
                
                }
            return (rowsAffected > 0);
        }
        public static bool IsFineExist(int FineID)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM Fines WHERE FineID = @FineID";
            try{
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                       {
                            using(SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@FineID", FineID);
                                connection.Open();
                                using(SqlDataReader reader = command.ExecuteReader())
                                    {
                                        isFound = reader.HasRows;
                                    }
                              }
                        }
                }
                 catch(Exception ex)
                {
                  isFound = false;
                 }
            finally
            {
               
            }

            return isFound;
        }
        public static DataTable GetAllFines()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM Fines";
            try{
                    using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        using(SqlCommand command = new SqlCommand(query, connection))
                        {
                            connection.Open();
                            using(SqlDataReader reader = command.ExecuteReader())
                                {
                                    if(reader.HasRows)
                                {
                                    dt.Load(reader);
                                }
                          }
                     }  
                   }
             }
            catch(Exception ex)
            {

            }
            finally
            {
                
            }

            return dt;
        }
    }
}
