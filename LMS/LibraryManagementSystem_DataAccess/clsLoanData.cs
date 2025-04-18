using System;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem_DataAccess
{
    public class clsLoanData
    {
        public static bool GetLoanByID(int LoanID, ref int BookID, ref int MemberID, ref int LibrarianID, ref DateTime LoanDate, ref DateTime DueDate, ref DateTime ReturnDate)
        {
            bool isFound = false;
            string query = "SELECT * FROM Loans WHERE LoanID = @LoanID";
            try
            { 
              using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                 {         
                using(SqlCommand command = new SqlCommand(query, connection))
                    {
                    command.Parameters.AddWithValue("@LoanID", LoanID);        
                    connection.Open();
                     using (SqlDataReader reader = command.ExecuteReader())      
                          {
        
                        if(reader.Read())
                        {
                            isFound = true;
        
                        BookID = (int)reader["BookID"];
                        MemberID = (int)reader["MemberID"];
                        LibrarianID = (int)reader["LibrarianID"];

                    if(reader["LoanDate"] != DBNull.Value)
                        LoanDate = (DateTime)reader["LoanDate"];
                    else
                        LoanDate = DateTime.MinValue;


                    if(reader["DueDate"] != DBNull.Value)
                        DueDate = (DateTime)reader["DueDate"];
                    else
                        DueDate = DateTime.MinValue;


                    if(reader["ReturnDate"] != DBNull.Value)
                        ReturnDate = (DateTime)reader["ReturnDate"];
                    else
                        ReturnDate = DateTime.MinValue;

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
        public static bool GetLoanByLoanID(int  LoanID , ref int BookID, ref int MemberID, ref int LibrarianID, ref DateTime LoanDate, ref DateTime DueDate, ref DateTime ReturnDate)
        {
            bool isFound = false;
            string query = "SELECT * FROM Loans WHERE LoanID = @LoanID";
            try
            { 
              using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                 {         
                using(SqlCommand command = new SqlCommand(query, connection))
                    {
                    command.Parameters.AddWithValue("@LoanID", LoanID);        
                    connection.Open();
                     using (SqlDataReader reader = command.ExecuteReader())      
                          {
        
                        if(reader.Read())
                        {
                            isFound = true;
        
                        BookID = (int)reader["BookID"];
                        MemberID = (int)reader["MemberID"];
                        LibrarianID = (int)reader["LibrarianID"];

                    if(reader["LoanDate"] != DBNull.Value)
                        LoanDate = (DateTime)reader["LoanDate"];
                    else
                        LoanDate = DateTime.MinValue;


                    if(reader["DueDate"] != DBNull.Value)
                        DueDate = (DateTime)reader["DueDate"];
                    else
                        DueDate = DateTime.MinValue;


                    if(reader["ReturnDate"] != DBNull.Value)
                        ReturnDate = (DateTime)reader["ReturnDate"];
                    else
                        ReturnDate = DateTime.MinValue;

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
        public static bool GetLoanByBookID(ref int LoanID, int  BookID , ref int MemberID, ref int LibrarianID, ref DateTime LoanDate, ref DateTime DueDate, ref DateTime ReturnDate)
        {
            bool isFound = false;
            string query = "SELECT * FROM Loans WHERE BookID = @BookID";
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
        
                        LoanID = (int)reader["LoanID"];
                        MemberID = (int)reader["MemberID"];
                        LibrarianID = (int)reader["LibrarianID"];

                    if(reader["LoanDate"] != DBNull.Value)
                        LoanDate = (DateTime)reader["LoanDate"];
                    else
                        LoanDate = DateTime.MinValue;


                    if(reader["DueDate"] != DBNull.Value)
                        DueDate = (DateTime)reader["DueDate"];
                    else
                        DueDate = DateTime.MinValue;


                    if(reader["ReturnDate"] != DBNull.Value)
                        ReturnDate = (DateTime)reader["ReturnDate"];
                    else
                        ReturnDate = DateTime.MinValue;

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
        public static bool GetLoanByMemberID(ref int LoanID, ref int BookID, int  MemberID , ref int LibrarianID, ref DateTime LoanDate, ref DateTime DueDate, ref DateTime ReturnDate)
        {
            bool isFound = false;
            string query = "SELECT * FROM Loans WHERE MemberID = @MemberID";
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
        
                        LoanID = (int)reader["LoanID"];
                        BookID = (int)reader["BookID"];
                        LibrarianID = (int)reader["LibrarianID"];

                    if(reader["LoanDate"] != DBNull.Value)
                        LoanDate = (DateTime)reader["LoanDate"];
                    else
                        LoanDate = DateTime.MinValue;


                    if(reader["DueDate"] != DBNull.Value)
                        DueDate = (DateTime)reader["DueDate"];
                    else
                        DueDate = DateTime.MinValue;


                    if(reader["ReturnDate"] != DBNull.Value)
                        ReturnDate = (DateTime)reader["ReturnDate"];
                    else
                        ReturnDate = DateTime.MinValue;

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
        public static bool GetLoanByLibrarianID(ref int LoanID, ref int BookID, ref int MemberID, int  LibrarianID , ref DateTime LoanDate, ref DateTime DueDate, ref DateTime ReturnDate)
        {
            bool isFound = false;
            string query = "SELECT * FROM Loans WHERE LibrarianID = @LibrarianID";
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
        
                        LoanID = (int)reader["LoanID"];
                        BookID = (int)reader["BookID"];
                        MemberID = (int)reader["MemberID"];

                    if(reader["LoanDate"] != DBNull.Value)
                        LoanDate = (DateTime)reader["LoanDate"];
                    else
                        LoanDate = DateTime.MinValue;


                    if(reader["DueDate"] != DBNull.Value)
                        DueDate = (DateTime)reader["DueDate"];
                    else
                        DueDate = DateTime.MinValue;


                    if(reader["ReturnDate"] != DBNull.Value)
                        ReturnDate = (DateTime)reader["ReturnDate"];
                    else
                        ReturnDate = DateTime.MinValue;

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
        public static bool GetLoanByLoanDate(ref int LoanID, ref int BookID, ref int MemberID, ref int LibrarianID, DateTime  LoanDate , ref DateTime DueDate, ref DateTime ReturnDate)
        {
            bool isFound = false;
            string query = "SELECT * FROM Loans WHERE LoanDate = @LoanDate";
            try
            { 
              using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                 {         
                using(SqlCommand command = new SqlCommand(query, connection))
                    {
                    command.Parameters.AddWithValue("@LoanDate", LoanDate);        
                    connection.Open();
                     using (SqlDataReader reader = command.ExecuteReader())      
                          {
        
                        if(reader.Read())
                        {
                            isFound = true;
        
                        LoanID = (int)reader["LoanID"];
                        BookID = (int)reader["BookID"];
                        MemberID = (int)reader["MemberID"];
                        LibrarianID = (int)reader["LibrarianID"];

                    if(reader["DueDate"] != DBNull.Value)
                        DueDate = (DateTime)reader["DueDate"];
                    else
                        DueDate = DateTime.MinValue;


                    if(reader["ReturnDate"] != DBNull.Value)
                        ReturnDate = (DateTime)reader["ReturnDate"];
                    else
                        ReturnDate = DateTime.MinValue;

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
        public static bool GetLoanByDueDate(ref int LoanID, ref int BookID, ref int MemberID, ref int LibrarianID, ref DateTime LoanDate, DateTime  DueDate , ref DateTime ReturnDate)
        {
            bool isFound = false;
            string query = "SELECT * FROM Loans WHERE DueDate = @DueDate";
            try
            { 
              using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                 {         
                using(SqlCommand command = new SqlCommand(query, connection))
                    {
                    command.Parameters.AddWithValue("@DueDate", DueDate);        
                    connection.Open();
                     using (SqlDataReader reader = command.ExecuteReader())      
                          {
        
                        if(reader.Read())
                        {
                            isFound = true;
        
                        LoanID = (int)reader["LoanID"];
                        BookID = (int)reader["BookID"];
                        MemberID = (int)reader["MemberID"];
                        LibrarianID = (int)reader["LibrarianID"];

                    if(reader["LoanDate"] != DBNull.Value)
                        LoanDate = (DateTime)reader["LoanDate"];
                    else
                        LoanDate = DateTime.MinValue;


                    if(reader["ReturnDate"] != DBNull.Value)
                        ReturnDate = (DateTime)reader["ReturnDate"];
                    else
                        ReturnDate = DateTime.MinValue;

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
        public static bool GetLoanByReturnDate(ref int LoanID, ref int BookID, ref int MemberID, ref int LibrarianID, ref DateTime LoanDate, ref DateTime DueDate, DateTime  ReturnDate )
        {
            bool isFound = false;
            string query = "SELECT * FROM Loans WHERE ReturnDate = @ReturnDate";
            try
            { 
              using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                 {         
                using(SqlCommand command = new SqlCommand(query, connection))
                    {
                    command.Parameters.AddWithValue("@ReturnDate", ReturnDate);        
                    connection.Open();
                     using (SqlDataReader reader = command.ExecuteReader())      
                          {
        
                        if(reader.Read())
                        {
                            isFound = true;
        
                        LoanID = (int)reader["LoanID"];
                        BookID = (int)reader["BookID"];
                        MemberID = (int)reader["MemberID"];
                        LibrarianID = (int)reader["LibrarianID"];

                    if(reader["LoanDate"] != DBNull.Value)
                        LoanDate = (DateTime)reader["LoanDate"];
                    else
                        LoanDate = DateTime.MinValue;


                    if(reader["DueDate"] != DBNull.Value)
                        DueDate = (DateTime)reader["DueDate"];
                    else
                        DueDate = DateTime.MinValue;

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
        public static int AddNewLoan(int BookID, int MemberID, int LibrarianID, DateTime LoanDate, DateTime DueDate, DateTime ReturnDate)
        {
            int LoanID = -1;
             string query = @"INSERT INTO Loans (BookID, MemberID, LibrarianID, LoanDate, DueDate, ReturnDate)
                            VALUES (@BookID, @MemberID, @LibrarianID, @LoanDate, @DueDate, @ReturnDate)
                            SELECT SCOPE_IDENTITY();";
        try{
             using( SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {       
                   using (SqlCommand command = new SqlCommand(query, connection))
                    {

            command.Parameters.AddWithValue("@BookID", BookID);
            command.Parameters.AddWithValue("@MemberID", MemberID);
            command.Parameters.AddWithValue("@LibrarianID", LibrarianID);

            if(LoanDate != DateTime.MinValue)
                command.Parameters.AddWithValue("@LoanDate", LoanDate);
            else
                command.Parameters.AddWithValue("@LoanDate", DBNull.Value);

            if(DueDate != DateTime.MinValue)
                command.Parameters.AddWithValue("@DueDate", DueDate);
            else
                command.Parameters.AddWithValue("@DueDate", DBNull.Value);

            if(ReturnDate != DateTime.MinValue)
                command.Parameters.AddWithValue("@ReturnDate", ReturnDate);
            else
                command.Parameters.AddWithValue("@ReturnDate", DBNull.Value);
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if(result != null && int.TryParse(result.ToString(), out int insertedID))
                      {
                    LoanID = insertedID;
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

            return LoanID;
        }
        public static bool UpdateLoan(int LoanID, int BookID, int MemberID, int LibrarianID, DateTime LoanDate, DateTime DueDate, DateTime ReturnDate)
        {
            int rowsAffected = 0;
            string query = @"UPDATE Loans  
                                        SET 
                                        BookID = @BookID, 
                            MemberID = @MemberID, 
                            LibrarianID = @LibrarianID, 
                            LoanDate = @LoanDate, 
                            DueDate = @DueDate, 
                            ReturnDate = @ReturnDate
                            WHERE LoanID = @LoanID";
            try{
                   using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        using(SqlCommand command = new SqlCommand(query, connection))
                        {

            command.Parameters.AddWithValue("@LoanID", LoanID);
            command.Parameters.AddWithValue("@BookID", BookID);
            command.Parameters.AddWithValue("@MemberID", MemberID);
            command.Parameters.AddWithValue("@LibrarianID", LibrarianID);
            command.Parameters.AddWithValue("@LoanDate", LoanDate);
            command.Parameters.AddWithValue("@DueDate", DueDate);
            command.Parameters.AddWithValue("@ReturnDate", ReturnDate);
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
        public static bool DeleteLoan(int LoanID)
        {
            int rowsAffected = 0;
            string query = @"Delete Loans 
                                where LoanID = @LoanID";
            try{
                 using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        using(SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@LoanID", LoanID);
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
        public static bool IsLoanExist(int LoanID)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM Loans WHERE LoanID = @LoanID";
            try{
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                       {
                            using(SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@LoanID", LoanID);
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
        public static bool IsLoanExistByLoanID(int LoanID)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM Loans WHERE LoanID = @LoanID";
            try{
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                       {
                            using(SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@LoanID", LoanID);
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
        public static bool IsLoanExistByBookID(int BookID)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM Loans WHERE BookID = @BookID";
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
        public static bool IsLoanExistByMemberID(int MemberID)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM Loans WHERE MemberID = @MemberID";
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
        public static bool IsLoanExistByLibrarianID(int LibrarianID)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM Loans WHERE LibrarianID = @LibrarianID";
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
        public static bool IsLoanExistByLoanDate(DateTime LoanDate)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM Loans WHERE LoanDate = @LoanDate";
            try{
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                       {
                            using(SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@LoanDate", LoanDate);
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
        public static bool IsLoanExistByDueDate(DateTime DueDate)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM Loans WHERE DueDate = @DueDate";
            try{
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                       {
                            using(SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@DueDate", DueDate);
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
        public static bool IsLoanExistByReturnDate(DateTime ReturnDate)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM Loans WHERE ReturnDate = @ReturnDate";
            try{
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                       {
                            using(SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@ReturnDate", ReturnDate);
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
        public static DataTable GetAllLoans()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM Loans";
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
