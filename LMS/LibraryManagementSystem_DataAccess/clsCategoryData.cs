using System;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem_DataAccess
{
    public class clsCategoryData
    {
        public static bool GetCategoryByID(int CategoryID, ref string CategoryName, ref int ParentCategory)
        {
            bool isFound = false;
            string query = "SELECT * FROM BookCategories WHERE CategoryID = @CategoryID";
            try
            { 
              using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                 {         
                using(SqlCommand command = new SqlCommand(query, connection))
                    {
                    command.Parameters.AddWithValue("@CategoryID", CategoryID);        
                    connection.Open();
                     using (SqlDataReader reader = command.ExecuteReader())      
                          {
        
                        if(reader.Read())
                        {
                            isFound = true;
        
                        CategoryName = (string)reader["CategoryName"];

                    if(reader["ParentCategory"] != DBNull.Value)
                        ParentCategory = (int)reader["ParentCategory"];
                    else
                        ParentCategory = -1;

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
        public static bool GetCategoryByCategoryID(int  CategoryID , ref string CategoryName, ref int ParentCategory)
        {
            bool isFound = false;
            string query = "SELECT * FROM BookCategories WHERE CategoryID = @CategoryID";
            try
            { 
              using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                 {         
                using(SqlCommand command = new SqlCommand(query, connection))
                    {
                    command.Parameters.AddWithValue("@CategoryID", CategoryID);        
                    connection.Open();
                     using (SqlDataReader reader = command.ExecuteReader())      
                          {
        
                        if(reader.Read())
                        {
                            isFound = true;
        
                        CategoryName = (string)reader["CategoryName"];

                    if(reader["ParentCategory"] != DBNull.Value)
                        ParentCategory = (int)reader["ParentCategory"];
                    else
                        ParentCategory = -1;

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
        public static bool GetCategoryByCategoryName(ref int CategoryID, string  CategoryName , ref int ParentCategory)
        {
            bool isFound = false;
            string query = "SELECT * FROM BookCategories WHERE CategoryName = @CategoryName";
            try
            { 
              using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                 {         
                using(SqlCommand command = new SqlCommand(query, connection))
                    {
                    command.Parameters.AddWithValue("@CategoryName", CategoryName);        
                    connection.Open();
                     using (SqlDataReader reader = command.ExecuteReader())      
                          {
        
                        if(reader.Read())
                        {
                            isFound = true;
        
                        CategoryID = (int)reader["CategoryID"];

                    if(reader["ParentCategory"] != DBNull.Value)
                        ParentCategory = (int)reader["ParentCategory"];
                    else
                        ParentCategory = -1;

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
        public static bool GetCategoryByParentCategory(ref int CategoryID, ref string CategoryName, int  ParentCategory )
        {
            bool isFound = false;
            string query = "SELECT * FROM BookCategories WHERE ParentCategory = @ParentCategory";
            try
            { 
              using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                 {         
                using(SqlCommand command = new SqlCommand(query, connection))
                    {
                    command.Parameters.AddWithValue("@ParentCategory", ParentCategory);        
                    connection.Open();
                     using (SqlDataReader reader = command.ExecuteReader())      
                          {
        
                        if(reader.Read())
                        {
                            isFound = true;
        
                        CategoryID = (int)reader["CategoryID"];
                        CategoryName = (string)reader["CategoryName"];
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
        public static int AddNewCategory(string CategoryName, int ParentCategory)
        {
            int CategoryID = -1;
             string query = @"INSERT INTO BookCategories (CategoryName, ParentCategory)
                            VALUES (@CategoryName, @ParentCategory)
                            SELECT SCOPE_IDENTITY();";
        try{
             using( SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {       
                   using (SqlCommand command = new SqlCommand(query, connection))
                    {

            command.Parameters.AddWithValue("@CategoryName", CategoryName);

            if(ParentCategory != -1)
                command.Parameters.AddWithValue("@ParentCategory", ParentCategory);
            else
                command.Parameters.AddWithValue("@ParentCategory", DBNull.Value);
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if(result != null && int.TryParse(result.ToString(), out int insertedID))
                      {
                    CategoryID = insertedID;
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

            return CategoryID;
        }
        public static bool UpdateCategory(int CategoryID, string CategoryName, int ParentCategory)
        {
            int rowsAffected = 0;
            string query = @"UPDATE BookCategories  
                                        SET 
                                        CategoryName = @CategoryName, 
                            ParentCategory = @ParentCategory
                            WHERE CategoryID = @CategoryID";
            try{
                   using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        using(SqlCommand command = new SqlCommand(query, connection))
                        {

            command.Parameters.AddWithValue("@CategoryID", CategoryID);
            command.Parameters.AddWithValue("@CategoryName", CategoryName);
            command.Parameters.AddWithValue("@ParentCategory", ParentCategory);
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
        public static bool DeleteCategory(int CategoryID)
        {
            int rowsAffected = 0;
            string query = @"Delete BookCategories 
                                where CategoryID = @CategoryID";
            try{
                 using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        using(SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@CategoryID", CategoryID);
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
        public static bool IsCategoryExist(int CategoryID)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM BookCategories WHERE CategoryID = @CategoryID";
            try{
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                       {
                            using(SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@CategoryID", CategoryID);
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
        public static bool IsCategoryExistByCategoryID(int CategoryID)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM BookCategories WHERE CategoryID = @CategoryID";
            try{
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                       {
                            using(SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@CategoryID", CategoryID);
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
        public static bool IsCategoryExistByCategoryName(string CategoryName)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM BookCategories WHERE CategoryName = @CategoryName";
            try{
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                       {
                            using(SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@CategoryName", CategoryName);
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
        public static bool IsCategoryExistByParentCategory(int ParentCategory)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM BookCategories WHERE ParentCategory = @ParentCategory";
            try{
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                       {
                            using(SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@ParentCategory", ParentCategory);
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
        public static DataTable GetAllBookCategories()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM BookCategories";
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
