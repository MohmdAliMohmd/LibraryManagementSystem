using System;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem_DataAccess
{
    public class clsConfigData
    {
        public static bool GetConfigByID(int ConfigID, ref string ConfigKey, ref double ConfigValue, ref DateTime LastUpdate)
        {
            bool isFound = false;
            string query = "SELECT * FROM Configurations WHERE ConfigID = @ConfigID";
            try
            { 
              using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                 {         
                using(SqlCommand command = new SqlCommand(query, connection))
                    {
                    command.Parameters.AddWithValue("@ConfigID", ConfigID);        
                    connection.Open();
                     using (SqlDataReader reader = command.ExecuteReader())      
                          {
        
                        if(reader.Read())
                        {
                            isFound = true;
        
                        ConfigKey = (string)reader["ConfigKey"];
                        ConfigValue = (double)reader["ConfigValue"];

                    if(reader["LastUpdate"] != DBNull.Value)
                        LastUpdate = (DateTime)reader["LastUpdate"];
                    else
                        LastUpdate = DateTime.MinValue;

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
        public static int AddNewConfig(string ConfigKey, double ConfigValue, DateTime LastUpdate)
        {
            int ConfigID = -1;
             string query = @"INSERT INTO Configurations (ConfigKey, ConfigValue, LastUpdate)
                            VALUES (@ConfigKey, @ConfigValue, @LastUpdate)
                            SELECT SCOPE_IDENTITY();";
        try{
             using( SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {       
                   using (SqlCommand command = new SqlCommand(query, connection))
                    {

            command.Parameters.AddWithValue("@ConfigKey", ConfigKey);
            command.Parameters.AddWithValue("@ConfigValue", ConfigValue);

            if(LastUpdate != DateTime.MinValue)
                command.Parameters.AddWithValue("@LastUpdate", LastUpdate);
            else
                command.Parameters.AddWithValue("@LastUpdate", DBNull.Value);
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if(result != null && int.TryParse(result.ToString(), out int insertedID))
                      {
                    ConfigID = insertedID;
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

            return ConfigID;
        }
        public static bool UpdateConfig(int ConfigID, string ConfigKey, double ConfigValue, DateTime LastUpdate)
        {
            int rowsAffected = 0;
            string query = @"UPDATE Configurations  
                                        SET 
                                        ConfigKey = @ConfigKey, 
                            ConfigValue = @ConfigValue, 
                            LastUpdate = @LastUpdate
                            WHERE ConfigID = @ConfigID";
            try{
                   using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        using(SqlCommand command = new SqlCommand(query, connection))
                        {

            command.Parameters.AddWithValue("@ConfigID", ConfigID);
            command.Parameters.AddWithValue("@ConfigKey", ConfigKey);
            command.Parameters.AddWithValue("@ConfigValue", ConfigValue);
            command.Parameters.AddWithValue("@LastUpdate", LastUpdate);
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
        public static bool DeleteConfig(int ConfigID)
        {
            int rowsAffected = 0;
            string query = @"Delete Configurations 
                                where ConfigID = @ConfigID";
            try{
                 using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        using(SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@ConfigID", ConfigID);
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
        public static bool IsConfigExist(int ConfigID)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM Configurations WHERE ConfigID = @ConfigID";
            try{
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                       {
                            using(SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@ConfigID", ConfigID);
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
        public static DataTable GetAllConfigurations()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM Configurations";
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
