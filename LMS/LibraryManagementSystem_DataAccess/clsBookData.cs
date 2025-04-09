using System;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem_DataAccess
{
    public class clsBookData
    {
        public static bool GetBookByID(int BookID, ref string Title, ref string ISBN, ref int categoryID, ref int PublisherID, ref int PublicationYear, ref int CopiesAvailable)
        {
            bool isFound = false;
            string query = "SELECT * FROM Books WHERE BookID = @BookID";
            try
            { 
              using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                 {         
                using(SqlCommand command = new SqlCommand(query, connection))
                    {
                    command.Parameters.AddWithValue("@BookID", BookID);        
                    connection.Open();
                     using (SqlDataReader reader = command.ExecuteReader())      
                          {
        
                        if(reader.Read())
                        {
                            isFound = true;
        
                        Title = (string)reader["Title"];
                        ISBN = (string)reader["ISBN"];
                        categoryID = (int)reader["categoryID"];
                        PublisherID = (int)reader["PublisherID"];

                    if(reader["PublicationYear"] != DBNull.Value)
                        PublicationYear = (int)reader["PublicationYear"];
                    else
                        PublicationYear = -1;


                    if(reader["CopiesAvailable"] != DBNull.Value)
                        CopiesAvailable = (int)reader["CopiesAvailable"];
                    else
                        CopiesAvailable = -1;

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
        public static int AddNewBook(string Title, string ISBN, int categoryID, int PublisherID, int PublicationYear, int CopiesAvailable)
        {
            int BookID = -1;
             string query = @"INSERT INTO Books (Title, ISBN, categoryID, PublisherID, PublicationYear, CopiesAvailable)
                            VALUES (@Title, @ISBN, @categoryID, @PublisherID, @PublicationYear, @CopiesAvailable)
                            SELECT SCOPE_IDENTITY();";
        try{
             using( SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {       
                   using (SqlCommand command = new SqlCommand(query, connection))
                    {

            command.Parameters.AddWithValue("@Title", Title);
            command.Parameters.AddWithValue("@ISBN", ISBN);
            command.Parameters.AddWithValue("@categoryID", categoryID);
            command.Parameters.AddWithValue("@PublisherID", PublisherID);

            if(PublicationYear != -1)
                command.Parameters.AddWithValue("@PublicationYear", PublicationYear);
            else
                command.Parameters.AddWithValue("@PublicationYear", DBNull.Value);

            if(CopiesAvailable != -1)
                command.Parameters.AddWithValue("@CopiesAvailable", CopiesAvailable);
            else
                command.Parameters.AddWithValue("@CopiesAvailable", DBNull.Value);
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if(result != null && int.TryParse(result.ToString(), out int insertedID))
                      {
                    BookID = insertedID;
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

            return BookID;
        }
        public static bool UpdateBook(int BookID, string Title, string ISBN, int categoryID, int PublisherID, int PublicationYear, int CopiesAvailable)
        {
            int rowsAffected = 0;
            string query = @"UPDATE Books  
                                        SET 
                                        Title = @Title, 
                            ISBN = @ISBN, 
                            categoryID = @categoryID, 
                            PublisherID = @PublisherID, 
                            PublicationYear = @PublicationYear, 
                            CopiesAvailable = @CopiesAvailable
                            WHERE BookID = @BookID";
            try{
                   using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        using(SqlCommand command = new SqlCommand(query, connection))
                        {

            command.Parameters.AddWithValue("@BookID", BookID);
            command.Parameters.AddWithValue("@Title", Title);
            command.Parameters.AddWithValue("@ISBN", ISBN);
            command.Parameters.AddWithValue("@categoryID", categoryID);
            command.Parameters.AddWithValue("@PublisherID", PublisherID);
            command.Parameters.AddWithValue("@PublicationYear", PublicationYear);
            command.Parameters.AddWithValue("@CopiesAvailable", CopiesAvailable);
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
        public static bool DeleteBook(int BookID)
        {
            int rowsAffected = 0;
            string query = @"Delete Books 
                                where BookID = @BookID";
            try{
                 using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        using(SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@BookID", BookID);
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
        public static bool IsBookExist(int BookID)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM Books WHERE BookID = @BookID";
            try{
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                       {
                            using(SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@BookID", BookID);
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
        public static DataTable GetAllBooks()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM Books";
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
