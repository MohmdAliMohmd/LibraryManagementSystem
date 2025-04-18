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
        public static bool GetLibrarianByLibrarianID(int  LibrarianID , ref int PersonID, ref string UserName, ref string PassWord, ref DateTime startDate, ref DateTime EndDate)
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
        public static bool GetLibrarianByPersonID(ref int LibrarianID, int  PersonID , ref string UserName, ref string PassWord, ref DateTime startDate, ref DateTime EndDate)
        {
            bool isFound = false;
            string query = "SELECT * FROM Librarians WHERE PersonID = @PersonID";
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
        
                        LibrarianID = (int)reader["LibrarianID"];
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
        public static bool GetLibrarianByUserName(ref int LibrarianID, ref int PersonID, string  UserName , ref string PassWord, ref DateTime startDate, ref DateTime EndDate)
        {
            bool isFound = false;
            string query = "SELECT * FROM Librarians WHERE UserName = @UserName";
            try
            { 
              using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                 {         
                using(SqlCommand command = new SqlCommand(query, connection))
                    {
                    command.Parameters.AddWithValue("@UserName", UserName);        
                    connection.Open();
                     using (SqlDataReader reader = command.ExecuteReader())      
                          {
        
                        if(reader.Read())
                        {
                            isFound = true;
        
                        LibrarianID = (int)reader["LibrarianID"];
                        PersonID = (int)reader["PersonID"];
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
        public static bool GetLibrarianByPassWord(ref int LibrarianID, ref int PersonID, ref string UserName, string  PassWord , ref DateTime startDate, ref DateTime EndDate)
        {
            bool isFound = false;
            string query = "SELECT * FROM Librarians WHERE PassWord = @PassWord";
            try
            { 
              using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                 {         
                using(SqlCommand command = new SqlCommand(query, connection))
                    {
                    command.Parameters.AddWithValue("@PassWord", PassWord);        
                    connection.Open();
                     using (SqlDataReader reader = command.ExecuteReader())      
                          {
        
                        if(reader.Read())
                        {
                            isFound = true;
        
                        LibrarianID = (int)reader["LibrarianID"];
                        PersonID = (int)reader["PersonID"];
                        UserName = (string)reader["UserName"];

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
        public static bool GetLibrarianBystartDate(ref int LibrarianID, ref int PersonID, ref string UserName, ref string PassWord, DateTime  startDate , ref DateTime EndDate)
        {
            bool isFound = false;
            string query = "SELECT * FROM Librarians WHERE startDate = @startDate";
            try
            { 
              using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                 {         
                using(SqlCommand command = new SqlCommand(query, connection))
                    {
                    command.Parameters.AddWithValue("@startDate", startDate);        
                    connection.Open();
                     using (SqlDataReader reader = command.ExecuteReader())      
                          {
        
                        if(reader.Read())
                        {
                            isFound = true;
        
                        LibrarianID = (int)reader["LibrarianID"];
                        PersonID = (int)reader["PersonID"];
                        UserName = (string)reader["UserName"];
                        PassWord = (string)reader["PassWord"];

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
        public static bool GetLibrarianByEndDate(ref int LibrarianID, ref int PersonID, ref string UserName, ref string PassWord, ref DateTime startDate, DateTime  EndDate )
        {
            bool isFound = false;
            string query = "SELECT * FROM Librarians WHERE EndDate = @EndDate";
            try
            { 
              using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                 {         
                using(SqlCommand command = new SqlCommand(query, connection))
                    {
                    command.Parameters.AddWithValue("@EndDate", EndDate);        
                    connection.Open();
                     using (SqlDataReader reader = command.ExecuteReader())      
                          {
        
                        if(reader.Read())
                        {
                            isFound = true;
        
                        LibrarianID = (int)reader["LibrarianID"];
                        PersonID = (int)reader["PersonID"];
                        UserName = (string)reader["UserName"];
                        PassWord = (string)reader["PassWord"];

                    if(reader["startDate"] != DBNull.Value)
                        startDate = (DateTime)reader["startDate"];
                    else
                        startDate = DateTime.MinValue;

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
        public static bool IsLibrarianExistByLibrarianID(int LibrarianID)
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
        public static bool IsLibrarianExistByPersonID(int PersonID)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM Librarians WHERE PersonID = @PersonID";
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
        public static bool IsLibrarianExistByUserName(string UserName)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM Librarians WHERE UserName = @UserName";
            try{
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                       {
                            using(SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@UserName", UserName);
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
        public static bool IsLibrarianExistByPassWord(string PassWord)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM Librarians WHERE PassWord = @PassWord";
            try{
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                       {
                            using(SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@PassWord", PassWord);
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
        public static bool IsLibrarianExistBystartDate(DateTime startDate)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM Librarians WHERE startDate = @startDate";
            try{
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                       {
                            using(SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@startDate", startDate);
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
        public static bool IsLibrarianExistByEndDate(DateTime EndDate)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM Librarians WHERE EndDate = @EndDate";
            try{
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                       {
                            using(SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@EndDate", EndDate);
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
