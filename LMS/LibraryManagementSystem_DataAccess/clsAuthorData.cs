using System;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem_DataAccess
{
    public class clsAuthorData
    {
        public static bool GetAuthorByID(int AuthorID, ref string AuthorName, ref bool IsDeleted)
        {
            bool isFound = false;
            string query = "SELECT * FROM Authors WHERE AuthorID = @AuthorID";
            try
            { 
              using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                 {         
                using(SqlCommand command = new SqlCommand(query, connection))
                    {
                    command.Parameters.AddWithValue("@AuthorID", AuthorID);        
                    connection.Open();
                     using (SqlDataReader reader = command.ExecuteReader())      
                          {
        
                        if(reader.Read())
                        {
                            isFound = true;
        
                        AuthorName = (string)reader["AuthorName"];

                    if(reader["IsDeleted"] != DBNull.Value)
                        IsDeleted = (bool)reader["IsDeleted"];
                    else
                        IsDeleted = false;

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
        public static int AddNewAuthor(string AuthorName, bool IsDeleted)
        {
            int AuthorID = -1;
             string query = @"INSERT INTO Authors (AuthorName, IsDeleted)
                            VALUES (@AuthorName, @IsDeleted)
                            SELECT SCOPE_IDENTITY();";
        try{
             using( SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {       
                   using (SqlCommand command = new SqlCommand(query, connection))
                    {

            command.Parameters.AddWithValue("@AuthorName", AuthorName);

            if(IsDeleted != false)
                command.Parameters.AddWithValue("@IsDeleted", IsDeleted);
            else
                command.Parameters.AddWithValue("@IsDeleted", DBNull.Value);
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if(result != null && int.TryParse(result.ToString(), out int insertedID))
                      {
                    AuthorID = insertedID;
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

            return AuthorID;
        }
        public static bool UpdateAuthor(int AuthorID, string AuthorName, bool IsDeleted)
        {
            int rowsAffected = 0;
            string query = @"UPDATE Authors  
                                        SET 
                                        AuthorName = @AuthorName, 
                            IsDeleted = @IsDeleted
                            WHERE AuthorID = @AuthorID";
            try{
                   using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        using(SqlCommand command = new SqlCommand(query, connection))
                        {

            command.Parameters.AddWithValue("@AuthorID", AuthorID);
            command.Parameters.AddWithValue("@AuthorName", AuthorName);
            command.Parameters.AddWithValue("@IsDeleted", IsDeleted);
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
        public static bool DeleteAuthor(int AuthorID)
        {
            int rowsAffected = 0;
            string query = @"Delete Authors 
                                where AuthorID = @AuthorID";
            try{
                 using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        using(SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@AuthorID", AuthorID);
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
        public static bool IsAuthorExist(int AuthorID)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM Authors WHERE AuthorID = @AuthorID";
            try{
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                       {
                            using(SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@AuthorID", AuthorID);
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
        public static DataTable GetAllAuthors()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM Authors";
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
