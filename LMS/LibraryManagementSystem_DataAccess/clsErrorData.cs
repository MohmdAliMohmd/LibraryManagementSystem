using System;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem_DataAccess
{
    public class clsErrorData
    {
        public static bool GetErrorByID(int ErrorID, ref string ErrorMessage, ref string StackTrace, ref DateTime Timestamp, ref string Severity, ref string AdditionalInfo)
        {
            bool isFound = false;
            string query = "SELECT * FROM ErrorLog WHERE ErrorID = @ErrorID";
            try
            { 
              using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                 {         
                using(SqlCommand command = new SqlCommand(query, connection))
                    {
                    command.Parameters.AddWithValue("@ErrorID", ErrorID);        
                    connection.Open();
                     using (SqlDataReader reader = command.ExecuteReader())      
                          {
        
                        if(reader.Read())
                        {
                            isFound = true;
        
                        ErrorMessage = (string)reader["ErrorMessage"];

                    if(reader["StackTrace"] != DBNull.Value)
                        StackTrace = (string)reader["StackTrace"];
                    else
                        StackTrace = "";


                    if(reader["Timestamp"] != DBNull.Value)
                        Timestamp = (DateTime)reader["Timestamp"];
                    else
                        Timestamp = DateTime.MinValue;


                    if(reader["Severity"] != DBNull.Value)
                        Severity = (string)reader["Severity"];
                    else
                        Severity = "";


                    if(reader["AdditionalInfo"] != DBNull.Value)
                        AdditionalInfo = (string)reader["AdditionalInfo"];
                    else
                        AdditionalInfo = "";

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
        public static bool GetErrorByErrorID(int  ErrorID , ref string ErrorMessage, ref string StackTrace, ref DateTime Timestamp, ref string Severity, ref string AdditionalInfo)
        {
            bool isFound = false;
            string query = "SELECT * FROM ErrorLog WHERE ErrorID = @ErrorID";
            try
            { 
              using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                 {         
                using(SqlCommand command = new SqlCommand(query, connection))
                    {
                    command.Parameters.AddWithValue("@ErrorID", ErrorID);        
                    connection.Open();
                     using (SqlDataReader reader = command.ExecuteReader())      
                          {
        
                        if(reader.Read())
                        {
                            isFound = true;
        
                        ErrorMessage = (string)reader["ErrorMessage"];

                    if(reader["StackTrace"] != DBNull.Value)
                        StackTrace = (string)reader["StackTrace"];
                    else
                        StackTrace = "";


                    if(reader["Timestamp"] != DBNull.Value)
                        Timestamp = (DateTime)reader["Timestamp"];
                    else
                        Timestamp = DateTime.MinValue;


                    if(reader["Severity"] != DBNull.Value)
                        Severity = (string)reader["Severity"];
                    else
                        Severity = "";


                    if(reader["AdditionalInfo"] != DBNull.Value)
                        AdditionalInfo = (string)reader["AdditionalInfo"];
                    else
                        AdditionalInfo = "";

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
        public static bool GetErrorByErrorMessage(ref int ErrorID, string  ErrorMessage , ref string StackTrace, ref DateTime Timestamp, ref string Severity, ref string AdditionalInfo)
        {
            bool isFound = false;
            string query = "SELECT * FROM ErrorLog WHERE ErrorMessage = @ErrorMessage";
            try
            { 
              using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                 {         
                using(SqlCommand command = new SqlCommand(query, connection))
                    {
                    command.Parameters.AddWithValue("@ErrorMessage", ErrorMessage);        
                    connection.Open();
                     using (SqlDataReader reader = command.ExecuteReader())      
                          {
        
                        if(reader.Read())
                        {
                            isFound = true;
        
                        ErrorID = (int)reader["ErrorID"];

                    if(reader["StackTrace"] != DBNull.Value)
                        StackTrace = (string)reader["StackTrace"];
                    else
                        StackTrace = "";


                    if(reader["Timestamp"] != DBNull.Value)
                        Timestamp = (DateTime)reader["Timestamp"];
                    else
                        Timestamp = DateTime.MinValue;


                    if(reader["Severity"] != DBNull.Value)
                        Severity = (string)reader["Severity"];
                    else
                        Severity = "";


                    if(reader["AdditionalInfo"] != DBNull.Value)
                        AdditionalInfo = (string)reader["AdditionalInfo"];
                    else
                        AdditionalInfo = "";

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
        public static bool GetErrorByStackTrace(ref int ErrorID, ref string ErrorMessage, string  StackTrace , ref DateTime Timestamp, ref string Severity, ref string AdditionalInfo)
        {
            bool isFound = false;
            string query = "SELECT * FROM ErrorLog WHERE StackTrace = @StackTrace";
            try
            { 
              using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                 {         
                using(SqlCommand command = new SqlCommand(query, connection))
                    {
                    command.Parameters.AddWithValue("@StackTrace", StackTrace);        
                    connection.Open();
                     using (SqlDataReader reader = command.ExecuteReader())      
                          {
        
                        if(reader.Read())
                        {
                            isFound = true;
        
                        ErrorID = (int)reader["ErrorID"];
                        ErrorMessage = (string)reader["ErrorMessage"];

                    if(reader["Timestamp"] != DBNull.Value)
                        Timestamp = (DateTime)reader["Timestamp"];
                    else
                        Timestamp = DateTime.MinValue;


                    if(reader["Severity"] != DBNull.Value)
                        Severity = (string)reader["Severity"];
                    else
                        Severity = "";


                    if(reader["AdditionalInfo"] != DBNull.Value)
                        AdditionalInfo = (string)reader["AdditionalInfo"];
                    else
                        AdditionalInfo = "";

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
        public static bool GetErrorByTimestamp(ref int ErrorID, ref string ErrorMessage, ref string StackTrace, DateTime  Timestamp , ref string Severity, ref string AdditionalInfo)
        {
            bool isFound = false;
            string query = "SELECT * FROM ErrorLog WHERE Timestamp = @Timestamp";
            try
            { 
              using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                 {         
                using(SqlCommand command = new SqlCommand(query, connection))
                    {
                    command.Parameters.AddWithValue("@Timestamp", Timestamp);        
                    connection.Open();
                     using (SqlDataReader reader = command.ExecuteReader())      
                          {
        
                        if(reader.Read())
                        {
                            isFound = true;
        
                        ErrorID = (int)reader["ErrorID"];
                        ErrorMessage = (string)reader["ErrorMessage"];

                    if(reader["StackTrace"] != DBNull.Value)
                        StackTrace = (string)reader["StackTrace"];
                    else
                        StackTrace = "";


                    if(reader["Severity"] != DBNull.Value)
                        Severity = (string)reader["Severity"];
                    else
                        Severity = "";


                    if(reader["AdditionalInfo"] != DBNull.Value)
                        AdditionalInfo = (string)reader["AdditionalInfo"];
                    else
                        AdditionalInfo = "";

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
        public static bool GetErrorBySeverity(ref int ErrorID, ref string ErrorMessage, ref string StackTrace, ref DateTime Timestamp, string  Severity , ref string AdditionalInfo)
        {
            bool isFound = false;
            string query = "SELECT * FROM ErrorLog WHERE Severity = @Severity";
            try
            { 
              using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                 {         
                using(SqlCommand command = new SqlCommand(query, connection))
                    {
                    command.Parameters.AddWithValue("@Severity", Severity);        
                    connection.Open();
                     using (SqlDataReader reader = command.ExecuteReader())      
                          {
        
                        if(reader.Read())
                        {
                            isFound = true;
        
                        ErrorID = (int)reader["ErrorID"];
                        ErrorMessage = (string)reader["ErrorMessage"];

                    if(reader["StackTrace"] != DBNull.Value)
                        StackTrace = (string)reader["StackTrace"];
                    else
                        StackTrace = "";


                    if(reader["Timestamp"] != DBNull.Value)
                        Timestamp = (DateTime)reader["Timestamp"];
                    else
                        Timestamp = DateTime.MinValue;


                    if(reader["AdditionalInfo"] != DBNull.Value)
                        AdditionalInfo = (string)reader["AdditionalInfo"];
                    else
                        AdditionalInfo = "";

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
        public static bool GetErrorByAdditionalInfo(ref int ErrorID, ref string ErrorMessage, ref string StackTrace, ref DateTime Timestamp, ref string Severity, string  AdditionalInfo )
        {
            bool isFound = false;
            string query = "SELECT * FROM ErrorLog WHERE AdditionalInfo = @AdditionalInfo";
            try
            { 
              using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                 {         
                using(SqlCommand command = new SqlCommand(query, connection))
                    {
                    command.Parameters.AddWithValue("@AdditionalInfo", AdditionalInfo);        
                    connection.Open();
                     using (SqlDataReader reader = command.ExecuteReader())      
                          {
        
                        if(reader.Read())
                        {
                            isFound = true;
        
                        ErrorID = (int)reader["ErrorID"];
                        ErrorMessage = (string)reader["ErrorMessage"];

                    if(reader["StackTrace"] != DBNull.Value)
                        StackTrace = (string)reader["StackTrace"];
                    else
                        StackTrace = "";


                    if(reader["Timestamp"] != DBNull.Value)
                        Timestamp = (DateTime)reader["Timestamp"];
                    else
                        Timestamp = DateTime.MinValue;


                    if(reader["Severity"] != DBNull.Value)
                        Severity = (string)reader["Severity"];
                    else
                        Severity = "";

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
        public static int AddNewError(string ErrorMessage, string StackTrace, DateTime Timestamp, string Severity, string AdditionalInfo)
        {
            int ErrorID = -1;
             string query = @"INSERT INTO ErrorLog (ErrorMessage, StackTrace, Timestamp, Severity, AdditionalInfo)
                            VALUES (@ErrorMessage, @StackTrace, @Timestamp, @Severity, @AdditionalInfo)
                            SELECT SCOPE_IDENTITY();";
        try{
             using( SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {       
                   using (SqlCommand command = new SqlCommand(query, connection))
                    {

            command.Parameters.AddWithValue("@ErrorMessage", ErrorMessage);

            if(StackTrace != "")
                command.Parameters.AddWithValue("@StackTrace", StackTrace);
            else
                command.Parameters.AddWithValue("@StackTrace", DBNull.Value);

            if(Timestamp != DateTime.MinValue)
                command.Parameters.AddWithValue("@Timestamp", Timestamp);
            else
                command.Parameters.AddWithValue("@Timestamp", DBNull.Value);

            if(Severity != "")
                command.Parameters.AddWithValue("@Severity", Severity);
            else
                command.Parameters.AddWithValue("@Severity", DBNull.Value);

            if(AdditionalInfo != "")
                command.Parameters.AddWithValue("@AdditionalInfo", AdditionalInfo);
            else
                command.Parameters.AddWithValue("@AdditionalInfo", DBNull.Value);
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if(result != null && int.TryParse(result.ToString(), out int insertedID))
                      {
                    ErrorID = insertedID;
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

            return ErrorID;
        }
        public static bool UpdateError(int ErrorID, string ErrorMessage, string StackTrace, DateTime Timestamp, string Severity, string AdditionalInfo)
        {
            int rowsAffected = 0;
            string query = @"UPDATE ErrorLog  
                                        SET 
                                        ErrorMessage = @ErrorMessage, 
                            StackTrace = @StackTrace, 
                            Timestamp = @Timestamp, 
                            Severity = @Severity, 
                            AdditionalInfo = @AdditionalInfo
                            WHERE ErrorID = @ErrorID";
            try{
                   using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        using(SqlCommand command = new SqlCommand(query, connection))
                        {

            command.Parameters.AddWithValue("@ErrorID", ErrorID);
            command.Parameters.AddWithValue("@ErrorMessage", ErrorMessage);
            command.Parameters.AddWithValue("@StackTrace", StackTrace);
            command.Parameters.AddWithValue("@Timestamp", Timestamp);
            command.Parameters.AddWithValue("@Severity", Severity);
            command.Parameters.AddWithValue("@AdditionalInfo", AdditionalInfo);
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
        public static bool DeleteError(int ErrorID)
        {
            int rowsAffected = 0;
            string query = @"Delete ErrorLog 
                                where ErrorID = @ErrorID";
            try{
                 using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        using(SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@ErrorID", ErrorID);
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
        public static bool IsErrorExist(int ErrorID)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM ErrorLog WHERE ErrorID = @ErrorID";
            try{
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                       {
                            using(SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@ErrorID", ErrorID);
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
        public static bool IsErrorExistByErrorID(int ErrorID)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM ErrorLog WHERE ErrorID = @ErrorID";
            try{
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                       {
                            using(SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@ErrorID", ErrorID);
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
        public static bool IsErrorExistByErrorMessage(string ErrorMessage)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM ErrorLog WHERE ErrorMessage = @ErrorMessage";
            try{
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                       {
                            using(SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@ErrorMessage", ErrorMessage);
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
        public static bool IsErrorExistByStackTrace(string StackTrace)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM ErrorLog WHERE StackTrace = @StackTrace";
            try{
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                       {
                            using(SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@StackTrace", StackTrace);
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
        public static bool IsErrorExistByTimestamp(DateTime Timestamp)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM ErrorLog WHERE Timestamp = @Timestamp";
            try{
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                       {
                            using(SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@Timestamp", Timestamp);
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
        public static bool IsErrorExistBySeverity(string Severity)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM ErrorLog WHERE Severity = @Severity";
            try{
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                       {
                            using(SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@Severity", Severity);
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
        public static bool IsErrorExistByAdditionalInfo(string AdditionalInfo)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM ErrorLog WHERE AdditionalInfo = @AdditionalInfo";
            try{
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                       {
                            using(SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@AdditionalInfo", AdditionalInfo);
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
        public static DataTable GetAllErrorLog()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM ErrorLog";
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
