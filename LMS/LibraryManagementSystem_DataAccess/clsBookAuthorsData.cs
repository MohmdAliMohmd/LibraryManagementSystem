using System;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem_DataAccess
{
    public class clsBookAuthorsData
    {
        public static bool GetBookAuthorsByID(int BookAuthorsID, ref int BookID, ref int AuthorID)
        {
            bool isFound = false;
            string query = "SELECT * FROM BookAuthors WHERE BookAuthorsID = @BookAuthorsID";
            try
            { 
              using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                 {         
                using(SqlCommand command = new SqlCommand(query, connection))
                    {
                    command.Parameters.AddWithValue("@BookAuthorsID", BookAuthorsID);        
                    connection.Open();
                     using (SqlDataReader reader = command.ExecuteReader())      
                          {
        
                        if(reader.Read())
                        {
                            isFound = true;
        
                        BookID = (int)reader["BookID"];
                        AuthorID = (int)reader["AuthorID"];
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
        public static int AddNewBookAuthors(int BookID, int AuthorID)
        {
            int BookAuthorsID = -1;
             string query = @"INSERT INTO BookAuthors (BookID, AuthorID)
                            VALUES (@BookID, @AuthorID)
                            SELECT SCOPE_IDENTITY();";
        try{
             using( SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {       
                   using (SqlCommand command = new SqlCommand(query, connection))
                    {

            command.Parameters.AddWithValue("@BookID", BookID);
            command.Parameters.AddWithValue("@AuthorID", AuthorID);
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if(result != null && int.TryParse(result.ToString(), out int insertedID))
                      {
                    BookAuthorsID = insertedID;
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

            return BookAuthorsID;
        }
        public static bool UpdateBookAuthors(int BookAuthorsID, int BookID, int AuthorID)
        {
            int rowsAffected = 0;
            string query = @"UPDATE BookAuthors  
                                        SET 
                                        BookID = @BookID, 
                            AuthorID = @AuthorID
                            WHERE BookAuthorsID = @BookAuthorsID";
            try{
                   using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        using(SqlCommand command = new SqlCommand(query, connection))
                        {

            command.Parameters.AddWithValue("@BookAuthorsID", BookAuthorsID);
            command.Parameters.AddWithValue("@BookID", BookID);
            command.Parameters.AddWithValue("@AuthorID", AuthorID);
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
        public static bool DeleteBookAuthors(int BookAuthorsID)
        {
            int rowsAffected = 0;
            string query = @"Delete BookAuthors 
                                where BookAuthorsID = @BookAuthorsID";
            try{
                 using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        using(SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@BookAuthorsID", BookAuthorsID);
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
        public static bool IsBookAuthorsExist(int BookAuthorsID)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM BookAuthors WHERE BookAuthorsID = @BookAuthorsID";
            try{
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                       {
                            using(SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@BookAuthorsID", BookAuthorsID);
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
        public static DataTable GetAllBookAuthors()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM BookAuthors";
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
