using System;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem_DataAccess
{
    public class clsLibrarianData
    {
        public static bool GetLibrarianByID(int LibrarianID, ref int PersonID, ref string UserName, ref string PassWord, ref DateTime startDate, ref DateTime EndDate)
        {
            bool isFound = false;
            string query = "SELECT * FROM Librarians WHERE LibrarianID = @LibrarianID";
            try
            { 
              using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                 {         
                using(SqlCommand command = new SqlCommand(query, connection))
                    {
                    command.Parameters.AddWithValue("@LibrarianID", LibrarianID);        
                    connection.Open();
                     using (SqlDataReader reader = command.ExecuteReader())      
                          {
        
                        if(reader.Read())
                        {
                            isFound = true;
        
                        PersonID = (int)reader["PersonID"];
                        UserName = (string)reader["UserName"];
                        PassWord = (string)reader["PassWord"];

                    if(reader["startDate"] != DBNull.Value)
                        startDate = (DateTime)reader["startDate"];
                    else
                        startDate = DateTime.MinValue;


                    if(reader["EndDate"] != DBNull.Value)
                        EndDate = (DateTime)reader["EndDate"];
                    else
                        EndDate = DateTime.MinValue;

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
        public static int AddNewLibrarian(int PersonID, string UserName, string PassWord, DateTime startDate, DateTime EndDate)
        {
            int LibrarianID = -1;
             string query = @"INSERT INTO Librarians (PersonID, UserName, PassWord, startDate, EndDate)
                            VALUES (@PersonID, @UserName, @PassWord, @startDate, @EndDate)
                            SELECT SCOPE_IDENTITY();";
        try{
             using( SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {       
                   using (SqlCommand command = new SqlCommand(query, connection))
                    {

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@PassWord", PassWord);

            if(startDate != DateTime.MinValue)
                command.Parameters.AddWithValue("@startDate", startDate);
            else
                command.Parameters.AddWithValue("@startDate", DBNull.Value);

            if(EndDate != DateTime.MinValue)
                command.Parameters.AddWithValue("@EndDate", EndDate);
            else
                command.Parameters.AddWithValue("@EndDate", DBNull.Value);
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if(result != null && int.TryParse(result.ToString(), out int insertedID))
                      {
                    LibrarianID = insertedID;
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

            return LibrarianID;
        }
        public static bool UpdateLibrarian(int LibrarianID, int PersonID, string UserName, string PassWord, DateTime startDate, DateTime EndDate)
        {
            int rowsAffected = 0;
            string query = @"UPDATE Librarians  
                                        SET 
                                        PersonID = @PersonID, 
                            UserName = @UserName, 
                            PassWord = @PassWord, 
                            startDate = @startDate, 
                            EndDate = @EndDate
                            WHERE LibrarianID = @LibrarianID";
            try{
                   using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        using(SqlCommand command = new SqlCommand(query, connection))
                        {

            command.Parameters.AddWithValue("@LibrarianID", LibrarianID);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@PassWord", PassWord);
            command.Parameters.AddWithValue("@startDate", startDate);
            command.Parameters.AddWithValue("@EndDate", EndDate);
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
        public static bool DeleteLibrarian(int LibrarianID)
        {
            int rowsAffected = 0;
            string query = @"Delete Librarians 
                                where LibrarianID = @LibrarianID";
            try{
                 using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        using(SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@LibrarianID", LibrarianID);
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
        public static bool IsLibrarianExist(int LibrarianID)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM Librarians WHERE LibrarianID = @LibrarianID";
            try{
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                       {
                            using(SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@LibrarianID", LibrarianID);
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
        public static DataTable GetAllLibrarians()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM Librarians";
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
