using System;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem_DataAccess
{
    public class clsPublisherData
    {
        public static bool GetPublisherByID(int PublisherID, ref string PublisherName, ref string Address, ref string Phone, ref string Email, ref string WebSite)
        {
            bool isFound = false;
            string query = "SELECT * FROM PublishingHouses WHERE PublisherID = @PublisherID";
            try
            { 
              using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                 {         
                using(SqlCommand command = new SqlCommand(query, connection))
                    {
                    command.Parameters.AddWithValue("@PublisherID", PublisherID);        
                    connection.Open();
                     using (SqlDataReader reader = command.ExecuteReader())      
                          {
        
                        if(reader.Read())
                        {
                            isFound = true;
        
                        PublisherName = (string)reader["PublisherName"];

                    if(reader["Address"] != DBNull.Value)
                        Address = (string)reader["Address"];
                    else
                        Address = "";


                    if(reader["Phone"] != DBNull.Value)
                        Phone = (string)reader["Phone"];
                    else
                        Phone = "";


                    if(reader["Email"] != DBNull.Value)
                        Email = (string)reader["Email"];
                    else
                        Email = "";


                    if(reader["WebSite"] != DBNull.Value)
                        WebSite = (string)reader["WebSite"];
                    else
                        WebSite = "";

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
        public static int AddNewPublisher(string PublisherName, string Address, string Phone, string Email, string WebSite)
        {
            int PublisherID = -1;
             string query = @"INSERT INTO PublishingHouses (PublisherName, Address, Phone, Email, WebSite)
                            VALUES (@PublisherName, @Address, @Phone, @Email, @WebSite)
                            SELECT SCOPE_IDENTITY();";
        try{
             using( SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {       
                   using (SqlCommand command = new SqlCommand(query, connection))
                    {

            command.Parameters.AddWithValue("@PublisherName", PublisherName);

            if(Address != "")
                command.Parameters.AddWithValue("@Address", Address);
            else
                command.Parameters.AddWithValue("@Address", DBNull.Value);

            if(Phone != "")
                command.Parameters.AddWithValue("@Phone", Phone);
            else
                command.Parameters.AddWithValue("@Phone", DBNull.Value);

            if(Email != "")
                command.Parameters.AddWithValue("@Email", Email);
            else
                command.Parameters.AddWithValue("@Email", DBNull.Value);

            if(WebSite != "")
                command.Parameters.AddWithValue("@WebSite", WebSite);
            else
                command.Parameters.AddWithValue("@WebSite", DBNull.Value);
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if(result != null && int.TryParse(result.ToString(), out int insertedID))
                      {
                    PublisherID = insertedID;
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

            return PublisherID;
        }
        public static bool UpdatePublisher(int PublisherID, string PublisherName, string Address, string Phone, string Email, string WebSite)
        {
            int rowsAffected = 0;
            string query = @"UPDATE PublishingHouses  
                                        SET 
                                        PublisherName = @PublisherName, 
                            Address = @Address, 
                            Phone = @Phone, 
                            Email = @Email, 
                            WebSite = @WebSite
                            WHERE PublisherID = @PublisherID";
            try{
                   using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        using(SqlCommand command = new SqlCommand(query, connection))
                        {

            command.Parameters.AddWithValue("@PublisherID", PublisherID);
            command.Parameters.AddWithValue("@PublisherName", PublisherName);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@WebSite", WebSite);
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
        public static bool DeletePublisher(int PublisherID)
        {
            int rowsAffected = 0;
            string query = @"Delete PublishingHouses 
                                where PublisherID = @PublisherID";
            try{
                 using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        using(SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@PublisherID", PublisherID);
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
        public static bool IsPublisherExist(int PublisherID)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM PublishingHouses WHERE PublisherID = @PublisherID";
            try{
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                       {
                            using(SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@PublisherID", PublisherID);
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
        public static DataTable GetAllPublishingHouses()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM PublishingHouses";
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
