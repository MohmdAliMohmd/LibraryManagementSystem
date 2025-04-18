using System;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem_DataAccess
{
    public class clsMemberData
    {
        public static bool GetMemberByID(int MemberID, ref int PersonID, ref DateTime RegistrationDate, ref int RegisteredBy)
        {
            bool isFound = false;
            string query = "SELECT * FROM Members WHERE MemberID = @MemberID";
            try
            { 
              using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                 {         
                using(SqlCommand command = new SqlCommand(query, connection))
                    {
                    command.Parameters.AddWithValue("@MemberID", MemberID);        
                    connection.Open();
                     using (SqlDataReader reader = command.ExecuteReader())      
                          {
        
                        if(reader.Read())
                        {
                            isFound = true;
        
                        PersonID = (int)reader["PersonID"];

                    if(reader["RegistrationDate"] != DBNull.Value)
                        RegistrationDate = (DateTime)reader["RegistrationDate"];
                    else
                        RegistrationDate = DateTime.MinValue;

                        RegisteredBy = (int)reader["RegisteredBy"];
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
        public static bool GetMemberByMemberID(int  MemberID , ref int PersonID, ref DateTime RegistrationDate, ref int RegisteredBy)
        {
            bool isFound = false;
            string query = "SELECT * FROM Members WHERE MemberID = @MemberID";
            try
            { 
              using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                 {         
                using(SqlCommand command = new SqlCommand(query, connection))
                    {
                    command.Parameters.AddWithValue("@MemberID", MemberID);        
                    connection.Open();
                     using (SqlDataReader reader = command.ExecuteReader())      
                          {
        
                        if(reader.Read())
                        {
                            isFound = true;
        
                        PersonID = (int)reader["PersonID"];

                    if(reader["RegistrationDate"] != DBNull.Value)
                        RegistrationDate = (DateTime)reader["RegistrationDate"];
                    else
                        RegistrationDate = DateTime.MinValue;

                        RegisteredBy = (int)reader["RegisteredBy"];
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
        public static bool GetMemberByPersonID(ref int MemberID, int  PersonID , ref DateTime RegistrationDate, ref int RegisteredBy)
        {
            bool isFound = false;
            string query = "SELECT * FROM Members WHERE PersonID = @PersonID";
            try
            { 
              using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                 {         
                using(SqlCommand command = new SqlCommand(query, connection))
                    {
                    command.Parameters.AddWithValue("@PersonID", PersonID);        
                    connection.Open();
                     using (SqlDataReader reader = command.ExecuteReader())      
                          {
        
                        if(reader.Read())
                        {
                            isFound = true;
        
                        MemberID = (int)reader["MemberID"];

                    if(reader["RegistrationDate"] != DBNull.Value)
                        RegistrationDate = (DateTime)reader["RegistrationDate"];
                    else
                        RegistrationDate = DateTime.MinValue;

                        RegisteredBy = (int)reader["RegisteredBy"];
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
        public static bool GetMemberByRegistrationDate(ref int MemberID, ref int PersonID, DateTime  RegistrationDate , ref int RegisteredBy)
        {
            bool isFound = false;
            string query = "SELECT * FROM Members WHERE RegistrationDate = @RegistrationDate";
            try
            { 
              using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                 {         
                using(SqlCommand command = new SqlCommand(query, connection))
                    {
                    command.Parameters.AddWithValue("@RegistrationDate", RegistrationDate);        
                    connection.Open();
                     using (SqlDataReader reader = command.ExecuteReader())      
                          {
        
                        if(reader.Read())
                        {
                            isFound = true;
        
                        MemberID = (int)reader["MemberID"];
                        PersonID = (int)reader["PersonID"];
                        RegisteredBy = (int)reader["RegisteredBy"];
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
        public static bool GetMemberByRegisteredBy(ref int MemberID, ref int PersonID, ref DateTime RegistrationDate, int  RegisteredBy )
        {
            bool isFound = false;
            string query = "SELECT * FROM Members WHERE RegisteredBy = @RegisteredBy";
            try
            { 
              using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                 {         
                using(SqlCommand command = new SqlCommand(query, connection))
                    {
                    command.Parameters.AddWithValue("@RegisteredBy", RegisteredBy);        
                    connection.Open();
                     using (SqlDataReader reader = command.ExecuteReader())      
                          {
        
                        if(reader.Read())
                        {
                            isFound = true;
        
                        MemberID = (int)reader["MemberID"];
                        PersonID = (int)reader["PersonID"];

                    if(reader["RegistrationDate"] != DBNull.Value)
                        RegistrationDate = (DateTime)reader["RegistrationDate"];
                    else
                        RegistrationDate = DateTime.MinValue;

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
        public static int AddNewMember(int PersonID, DateTime RegistrationDate, int RegisteredBy)
        {
            int MemberID = -1;
             string query = @"INSERT INTO Members (PersonID, RegistrationDate, RegisteredBy)
                            VALUES (@PersonID, @RegistrationDate, @RegisteredBy)
                            SELECT SCOPE_IDENTITY();";
        try{
             using( SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {       
                   using (SqlCommand command = new SqlCommand(query, connection))
                    {

            command.Parameters.AddWithValue("@PersonID", PersonID);

            if(RegistrationDate != DateTime.MinValue)
                command.Parameters.AddWithValue("@RegistrationDate", RegistrationDate);
            else
                command.Parameters.AddWithValue("@RegistrationDate", DBNull.Value);
            command.Parameters.AddWithValue("@RegisteredBy", RegisteredBy);
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if(result != null && int.TryParse(result.ToString(), out int insertedID))
                      {
                    MemberID = insertedID;
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

            return MemberID;
        }
        public static bool UpdateMember(int MemberID, int PersonID, DateTime RegistrationDate, int RegisteredBy)
        {
            int rowsAffected = 0;
            string query = @"UPDATE Members  
                                        SET 
                                        PersonID = @PersonID, 
                            RegistrationDate = @RegistrationDate, 
                            RegisteredBy = @RegisteredBy
                            WHERE MemberID = @MemberID";
            try{
                   using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        using(SqlCommand command = new SqlCommand(query, connection))
                        {

            command.Parameters.AddWithValue("@MemberID", MemberID);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@RegistrationDate", RegistrationDate);
            command.Parameters.AddWithValue("@RegisteredBy", RegisteredBy);
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
        public static bool DeleteMember(int MemberID)
        {
            int rowsAffected = 0;
            string query = @"Delete Members 
                                where MemberID = @MemberID";
            try{
                 using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        using(SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@MemberID", MemberID);
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
        public static bool IsMemberExist(int MemberID)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM Members WHERE MemberID = @MemberID";
            try{
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                       {
                            using(SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@MemberID", MemberID);
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
        public static bool IsMemberExistByMemberID(int MemberID)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM Members WHERE MemberID = @MemberID";
            try{
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                       {
                            using(SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@MemberID", MemberID);
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
        public static bool IsMemberExistByPersonID(int PersonID)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM Members WHERE PersonID = @PersonID";
            try{
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                       {
                            using(SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@PersonID", PersonID);
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
        public static bool IsMemberExistByRegistrationDate(DateTime RegistrationDate)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM Members WHERE RegistrationDate = @RegistrationDate";
            try{
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                       {
                            using(SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@RegistrationDate", RegistrationDate);
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
        public static bool IsMemberExistByRegisteredBy(int RegisteredBy)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM Members WHERE RegisteredBy = @RegisteredBy";
            try{
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                       {
                            using(SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@RegisteredBy", RegisteredBy);
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
        public static DataTable GetAllMembers()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM Members";
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
