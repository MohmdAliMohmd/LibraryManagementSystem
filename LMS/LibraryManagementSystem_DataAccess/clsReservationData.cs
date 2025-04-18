using System;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem_DataAccess
{
    public class clsReservationData
    {
        public static bool GetReservationByID(int ReservationID, ref int BookID, ref int MemberID, ref int LibrarianID, ref DateTime ReservationDate, ref byte Status)
        {
            bool isFound = false;
            string query = "SELECT * FROM Reservations WHERE ReservationID = @ReservationID";
            try
            { 
              using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                 {         
                using(SqlCommand command = new SqlCommand(query, connection))
                    {
                    command.Parameters.AddWithValue("@ReservationID", ReservationID);        
                    connection.Open();
                     using (SqlDataReader reader = command.ExecuteReader())      
                          {
        
                        if(reader.Read())
                        {
                            isFound = true;
        
                        BookID = (int)reader["BookID"];
                        MemberID = (int)reader["MemberID"];
                        LibrarianID = (int)reader["LibrarianID"];

                    if(reader["ReservationDate"] != DBNull.Value)
                        ReservationDate = (DateTime)reader["ReservationDate"];
                    else
                        ReservationDate = DateTime.MinValue;

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
        public static bool GetReservationByReservationID(int  ReservationID , ref int BookID, ref int MemberID, ref int LibrarianID, ref DateTime ReservationDate, ref byte Status)
        {
            bool isFound = false;
            string query = "SELECT * FROM Reservations WHERE ReservationID = @ReservationID";
            try
            { 
              using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                 {         
                using(SqlCommand command = new SqlCommand(query, connection))
                    {
                    command.Parameters.AddWithValue("@ReservationID", ReservationID);        
                    connection.Open();
                     using (SqlDataReader reader = command.ExecuteReader())      
                          {
        
                        if(reader.Read())
                        {
                            isFound = true;
        
                        BookID = (int)reader["BookID"];
                        MemberID = (int)reader["MemberID"];
                        LibrarianID = (int)reader["LibrarianID"];

                    if(reader["ReservationDate"] != DBNull.Value)
                        ReservationDate = (DateTime)reader["ReservationDate"];
                    else
                        ReservationDate = DateTime.MinValue;

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
        public static bool GetReservationByBookID(ref int ReservationID, int  BookID , ref int MemberID, ref int LibrarianID, ref DateTime ReservationDate, ref byte Status)
        {
            bool isFound = false;
            string query = "SELECT * FROM Reservations WHERE BookID = @BookID";
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
        
                        ReservationID = (int)reader["ReservationID"];
                        MemberID = (int)reader["MemberID"];
                        LibrarianID = (int)reader["LibrarianID"];

                    if(reader["ReservationDate"] != DBNull.Value)
                        ReservationDate = (DateTime)reader["ReservationDate"];
                    else
                        ReservationDate = DateTime.MinValue;

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
        public static bool GetReservationByMemberID(ref int ReservationID, ref int BookID, int  MemberID , ref int LibrarianID, ref DateTime ReservationDate, ref byte Status)
        {
            bool isFound = false;
            string query = "SELECT * FROM Reservations WHERE MemberID = @MemberID";
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
        
                        ReservationID = (int)reader["ReservationID"];
                        BookID = (int)reader["BookID"];
                        LibrarianID = (int)reader["LibrarianID"];

                    if(reader["ReservationDate"] != DBNull.Value)
                        ReservationDate = (DateTime)reader["ReservationDate"];
                    else
                        ReservationDate = DateTime.MinValue;

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
        public static bool GetReservationByLibrarianID(ref int ReservationID, ref int BookID, ref int MemberID, int  LibrarianID , ref DateTime ReservationDate, ref byte Status)
        {
            bool isFound = false;
            string query = "SELECT * FROM Reservations WHERE LibrarianID = @LibrarianID";
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
        
                        ReservationID = (int)reader["ReservationID"];
                        BookID = (int)reader["BookID"];
                        MemberID = (int)reader["MemberID"];

                    if(reader["ReservationDate"] != DBNull.Value)
                        ReservationDate = (DateTime)reader["ReservationDate"];
                    else
                        ReservationDate = DateTime.MinValue;

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
        public static bool GetReservationByReservationDate(ref int ReservationID, ref int BookID, ref int MemberID, ref int LibrarianID, DateTime  ReservationDate , ref byte Status)
        {
            bool isFound = false;
            string query = "SELECT * FROM Reservations WHERE ReservationDate = @ReservationDate";
            try
            { 
              using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                 {         
                using(SqlCommand command = new SqlCommand(query, connection))
                    {
                    command.Parameters.AddWithValue("@ReservationDate", ReservationDate);        
                    connection.Open();
                     using (SqlDataReader reader = command.ExecuteReader())      
                          {
        
                        if(reader.Read())
                        {
                            isFound = true;
        
                        ReservationID = (int)reader["ReservationID"];
                        BookID = (int)reader["BookID"];
                        MemberID = (int)reader["MemberID"];
                        LibrarianID = (int)reader["LibrarianID"];
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
        public static bool GetReservationByStatus(ref int ReservationID, ref int BookID, ref int MemberID, ref int LibrarianID, ref DateTime ReservationDate, byte  Status )
        {
            bool isFound = false;
            string query = "SELECT * FROM Reservations WHERE Status = @Status";
            try
            { 
              using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                 {         
                using(SqlCommand command = new SqlCommand(query, connection))
                    {
                    command.Parameters.AddWithValue("@Status", Status);        
                    connection.Open();
                     using (SqlDataReader reader = command.ExecuteReader())      
                          {
        
                        if(reader.Read())
                        {
                            isFound = true;
        
                        ReservationID = (int)reader["ReservationID"];
                        BookID = (int)reader["BookID"];
                        MemberID = (int)reader["MemberID"];
                        LibrarianID = (int)reader["LibrarianID"];

                    if(reader["ReservationDate"] != DBNull.Value)
                        ReservationDate = (DateTime)reader["ReservationDate"];
                    else
                        ReservationDate = DateTime.MinValue;

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
        public static int AddNewReservation(int BookID, int MemberID, int LibrarianID, DateTime ReservationDate, byte Status)
        {
            int ReservationID = -1;
             string query = @"INSERT INTO Reservations (BookID, MemberID, LibrarianID, ReservationDate, Status)
                            VALUES (@BookID, @MemberID, @LibrarianID, @ReservationDate, @Status)
                            SELECT SCOPE_IDENTITY();";
        try{
             using( SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {       
                   using (SqlCommand command = new SqlCommand(query, connection))
                    {

            command.Parameters.AddWithValue("@BookID", BookID);
            command.Parameters.AddWithValue("@MemberID", MemberID);
            command.Parameters.AddWithValue("@LibrarianID", LibrarianID);

            if(ReservationDate != DateTime.MinValue)
                command.Parameters.AddWithValue("@ReservationDate", ReservationDate);
            else
                command.Parameters.AddWithValue("@ReservationDate", DBNull.Value);
            command.Parameters.AddWithValue("@Status", Status);
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if(result != null && int.TryParse(result.ToString(), out int insertedID))
                      {
                    ReservationID = insertedID;
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

            return ReservationID;
        }
        public static bool UpdateReservation(int ReservationID, int BookID, int MemberID, int LibrarianID, DateTime ReservationDate, byte Status)
        {
            int rowsAffected = 0;
            string query = @"UPDATE Reservations  
                                        SET 
                                        BookID = @BookID, 
                            MemberID = @MemberID, 
                            LibrarianID = @LibrarianID, 
                            ReservationDate = @ReservationDate, 
                            Status = @Status
                            WHERE ReservationID = @ReservationID";
            try{
                   using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        using(SqlCommand command = new SqlCommand(query, connection))
                        {

            command.Parameters.AddWithValue("@ReservationID", ReservationID);
            command.Parameters.AddWithValue("@BookID", BookID);
            command.Parameters.AddWithValue("@MemberID", MemberID);
            command.Parameters.AddWithValue("@LibrarianID", LibrarianID);
            command.Parameters.AddWithValue("@ReservationDate", ReservationDate);
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
        public static bool DeleteReservation(int ReservationID)
        {
            int rowsAffected = 0;
            string query = @"Delete Reservations 
                                where ReservationID = @ReservationID";
            try{
                 using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        using(SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@ReservationID", ReservationID);
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
        public static bool IsReservationExist(int ReservationID)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM Reservations WHERE ReservationID = @ReservationID";
            try{
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                       {
                            using(SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@ReservationID", ReservationID);
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
        public static bool IsReservationExistByReservationID(int ReservationID)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM Reservations WHERE ReservationID = @ReservationID";
            try{
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                       {
                            using(SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@ReservationID", ReservationID);
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
        public static bool IsReservationExistByBookID(int BookID)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM Reservations WHERE BookID = @BookID";
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
        public static bool IsReservationExistByMemberID(int MemberID)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM Reservations WHERE MemberID = @MemberID";
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
        public static bool IsReservationExistByLibrarianID(int LibrarianID)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM Reservations WHERE LibrarianID = @LibrarianID";
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
        public static bool IsReservationExistByReservationDate(DateTime ReservationDate)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM Reservations WHERE ReservationDate = @ReservationDate";
            try{
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                       {
                            using(SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@ReservationDate", ReservationDate);
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
        public static bool IsReservationExistByStatus(byte Status)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM Reservations WHERE Status = @Status";
            try{
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                       {
                            using(SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@Status", Status);
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
        public static DataTable GetAllReservations()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM Reservations";
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
