using System;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem_DataAccess
{
    public class clsPersonData
    {
        public static bool GetPersonByID(int PersonID, ref string FirstName, ref string LastName, ref string MiddleName, ref string Email, ref string Phone, ref string Address, ref DateTime DateOfBirth, ref byte Gender, ref string ImagePath, ref DateTime CreationDate, ref DateTime ModificationDate, ref bool IsDeleted)
        {
            bool isFound = false;
            string query = "SELECT * FROM People WHERE PersonID = @PersonID";
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
        
                        FirstName = (string)reader["FirstName"];
                        LastName = (string)reader["LastName"];

                    if(reader["MiddleName"] != DBNull.Value)
                        MiddleName = (string)reader["MiddleName"];
                    else
                        MiddleName = "";


                    if(reader["Email"] != DBNull.Value)
                        Email = (string)reader["Email"];
                    else
                        Email = "";


                    if(reader["Phone"] != DBNull.Value)
                        Phone = (string)reader["Phone"];
                    else
                        Phone = "";


                    if(reader["Address"] != DBNull.Value)
                        Address = (string)reader["Address"];
                    else
                        Address = "";


                    if(reader["DateOfBirth"] != DBNull.Value)
                        DateOfBirth = (DateTime)reader["DateOfBirth"];
                    else
                        DateOfBirth = DateTime.MinValue;

                        Gender = (byte)reader["Gender"];

                    if(reader["ImagePath"] != DBNull.Value)
                        ImagePath = (string)reader["ImagePath"];
                    else
                        ImagePath = "";


                    if(reader["CreationDate"] != DBNull.Value)
                        CreationDate = (DateTime)reader["CreationDate"];
                    else
                        CreationDate = DateTime.MinValue;


                    if(reader["ModificationDate"] != DBNull.Value)
                        ModificationDate = (DateTime)reader["ModificationDate"];
                    else
                        ModificationDate = DateTime.MinValue;


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
        public static bool GetPersonByPersonID(int  PersonID , ref string FirstName, ref string LastName, ref string MiddleName, ref string Email, ref string Phone, ref string Address, ref DateTime DateOfBirth, ref byte Gender, ref string ImagePath, ref DateTime CreationDate, ref DateTime ModificationDate, ref bool IsDeleted)
        {
            bool isFound = false;
            string query = "SELECT * FROM People WHERE PersonID = @PersonID";
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
        
                        FirstName = (string)reader["FirstName"];
                        LastName = (string)reader["LastName"];

                    if(reader["MiddleName"] != DBNull.Value)
                        MiddleName = (string)reader["MiddleName"];
                    else
                        MiddleName = "";


                    if(reader["Email"] != DBNull.Value)
                        Email = (string)reader["Email"];
                    else
                        Email = "";


                    if(reader["Phone"] != DBNull.Value)
                        Phone = (string)reader["Phone"];
                    else
                        Phone = "";


                    if(reader["Address"] != DBNull.Value)
                        Address = (string)reader["Address"];
                    else
                        Address = "";


                    if(reader["DateOfBirth"] != DBNull.Value)
                        DateOfBirth = (DateTime)reader["DateOfBirth"];
                    else
                        DateOfBirth = DateTime.MinValue;

                        Gender = (byte)reader["Gender"];

                    if(reader["ImagePath"] != DBNull.Value)
                        ImagePath = (string)reader["ImagePath"];
                    else
                        ImagePath = "";


                    if(reader["CreationDate"] != DBNull.Value)
                        CreationDate = (DateTime)reader["CreationDate"];
                    else
                        CreationDate = DateTime.MinValue;


                    if(reader["ModificationDate"] != DBNull.Value)
                        ModificationDate = (DateTime)reader["ModificationDate"];
                    else
                        ModificationDate = DateTime.MinValue;


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
        public static bool GetPersonByFirstName(ref int PersonID, string  FirstName , ref string LastName, ref string MiddleName, ref string Email, ref string Phone, ref string Address, ref DateTime DateOfBirth, ref byte Gender, ref string ImagePath, ref DateTime CreationDate, ref DateTime ModificationDate, ref bool IsDeleted)
        {
            bool isFound = false;
            string query = "SELECT * FROM People WHERE FirstName = @FirstName";
            try
            { 
              using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                 {         
                using(SqlCommand command = new SqlCommand(query, connection))
                    {
                    command.Parameters.AddWithValue("@FirstName", FirstName);        
                    connection.Open();
                     using (SqlDataReader reader = command.ExecuteReader())      
                          {
        
                        if(reader.Read())
                        {
                            isFound = true;
        
                        PersonID = (int)reader["PersonID"];
                        LastName = (string)reader["LastName"];

                    if(reader["MiddleName"] != DBNull.Value)
                        MiddleName = (string)reader["MiddleName"];
                    else
                        MiddleName = "";


                    if(reader["Email"] != DBNull.Value)
                        Email = (string)reader["Email"];
                    else
                        Email = "";


                    if(reader["Phone"] != DBNull.Value)
                        Phone = (string)reader["Phone"];
                    else
                        Phone = "";


                    if(reader["Address"] != DBNull.Value)
                        Address = (string)reader["Address"];
                    else
                        Address = "";


                    if(reader["DateOfBirth"] != DBNull.Value)
                        DateOfBirth = (DateTime)reader["DateOfBirth"];
                    else
                        DateOfBirth = DateTime.MinValue;

                        Gender = (byte)reader["Gender"];

                    if(reader["ImagePath"] != DBNull.Value)
                        ImagePath = (string)reader["ImagePath"];
                    else
                        ImagePath = "";


                    if(reader["CreationDate"] != DBNull.Value)
                        CreationDate = (DateTime)reader["CreationDate"];
                    else
                        CreationDate = DateTime.MinValue;


                    if(reader["ModificationDate"] != DBNull.Value)
                        ModificationDate = (DateTime)reader["ModificationDate"];
                    else
                        ModificationDate = DateTime.MinValue;


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
        public static bool GetPersonByLastName(ref int PersonID, ref string FirstName, string  LastName , ref string MiddleName, ref string Email, ref string Phone, ref string Address, ref DateTime DateOfBirth, ref byte Gender, ref string ImagePath, ref DateTime CreationDate, ref DateTime ModificationDate, ref bool IsDeleted)
        {
            bool isFound = false;
            string query = "SELECT * FROM People WHERE LastName = @LastName";
            try
            { 
              using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                 {         
                using(SqlCommand command = new SqlCommand(query, connection))
                    {
                    command.Parameters.AddWithValue("@LastName", LastName);        
                    connection.Open();
                     using (SqlDataReader reader = command.ExecuteReader())      
                          {
        
                        if(reader.Read())
                        {
                            isFound = true;
        
                        PersonID = (int)reader["PersonID"];
                        FirstName = (string)reader["FirstName"];

                    if(reader["MiddleName"] != DBNull.Value)
                        MiddleName = (string)reader["MiddleName"];
                    else
                        MiddleName = "";


                    if(reader["Email"] != DBNull.Value)
                        Email = (string)reader["Email"];
                    else
                        Email = "";


                    if(reader["Phone"] != DBNull.Value)
                        Phone = (string)reader["Phone"];
                    else
                        Phone = "";


                    if(reader["Address"] != DBNull.Value)
                        Address = (string)reader["Address"];
                    else
                        Address = "";


                    if(reader["DateOfBirth"] != DBNull.Value)
                        DateOfBirth = (DateTime)reader["DateOfBirth"];
                    else
                        DateOfBirth = DateTime.MinValue;

                        Gender = (byte)reader["Gender"];

                    if(reader["ImagePath"] != DBNull.Value)
                        ImagePath = (string)reader["ImagePath"];
                    else
                        ImagePath = "";


                    if(reader["CreationDate"] != DBNull.Value)
                        CreationDate = (DateTime)reader["CreationDate"];
                    else
                        CreationDate = DateTime.MinValue;


                    if(reader["ModificationDate"] != DBNull.Value)
                        ModificationDate = (DateTime)reader["ModificationDate"];
                    else
                        ModificationDate = DateTime.MinValue;


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
        public static bool GetPersonByMiddleName(ref int PersonID, ref string FirstName, ref string LastName, string  MiddleName , ref string Email, ref string Phone, ref string Address, ref DateTime DateOfBirth, ref byte Gender, ref string ImagePath, ref DateTime CreationDate, ref DateTime ModificationDate, ref bool IsDeleted)
        {
            bool isFound = false;
            string query = "SELECT * FROM People WHERE MiddleName = @MiddleName";
            try
            { 
              using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                 {         
                using(SqlCommand command = new SqlCommand(query, connection))
                    {
                    command.Parameters.AddWithValue("@MiddleName", MiddleName);        
                    connection.Open();
                     using (SqlDataReader reader = command.ExecuteReader())      
                          {
        
                        if(reader.Read())
                        {
                            isFound = true;
        
                        PersonID = (int)reader["PersonID"];
                        FirstName = (string)reader["FirstName"];
                        LastName = (string)reader["LastName"];

                    if(reader["Email"] != DBNull.Value)
                        Email = (string)reader["Email"];
                    else
                        Email = "";


                    if(reader["Phone"] != DBNull.Value)
                        Phone = (string)reader["Phone"];
                    else
                        Phone = "";


                    if(reader["Address"] != DBNull.Value)
                        Address = (string)reader["Address"];
                    else
                        Address = "";


                    if(reader["DateOfBirth"] != DBNull.Value)
                        DateOfBirth = (DateTime)reader["DateOfBirth"];
                    else
                        DateOfBirth = DateTime.MinValue;

                        Gender = (byte)reader["Gender"];

                    if(reader["ImagePath"] != DBNull.Value)
                        ImagePath = (string)reader["ImagePath"];
                    else
                        ImagePath = "";


                    if(reader["CreationDate"] != DBNull.Value)
                        CreationDate = (DateTime)reader["CreationDate"];
                    else
                        CreationDate = DateTime.MinValue;


                    if(reader["ModificationDate"] != DBNull.Value)
                        ModificationDate = (DateTime)reader["ModificationDate"];
                    else
                        ModificationDate = DateTime.MinValue;


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
        public static bool GetPersonByEmail(ref int PersonID, ref string FirstName, ref string LastName, ref string MiddleName, string  Email , ref string Phone, ref string Address, ref DateTime DateOfBirth, ref byte Gender, ref string ImagePath, ref DateTime CreationDate, ref DateTime ModificationDate, ref bool IsDeleted)
        {
            bool isFound = false;
            string query = "SELECT * FROM People WHERE Email = @Email";
            try
            { 
              using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                 {         
                using(SqlCommand command = new SqlCommand(query, connection))
                    {
                    command.Parameters.AddWithValue("@Email", Email);        
                    connection.Open();
                     using (SqlDataReader reader = command.ExecuteReader())      
                          {
        
                        if(reader.Read())
                        {
                            isFound = true;
        
                        PersonID = (int)reader["PersonID"];
                        FirstName = (string)reader["FirstName"];
                        LastName = (string)reader["LastName"];

                    if(reader["MiddleName"] != DBNull.Value)
                        MiddleName = (string)reader["MiddleName"];
                    else
                        MiddleName = "";


                    if(reader["Phone"] != DBNull.Value)
                        Phone = (string)reader["Phone"];
                    else
                        Phone = "";


                    if(reader["Address"] != DBNull.Value)
                        Address = (string)reader["Address"];
                    else
                        Address = "";


                    if(reader["DateOfBirth"] != DBNull.Value)
                        DateOfBirth = (DateTime)reader["DateOfBirth"];
                    else
                        DateOfBirth = DateTime.MinValue;

                        Gender = (byte)reader["Gender"];

                    if(reader["ImagePath"] != DBNull.Value)
                        ImagePath = (string)reader["ImagePath"];
                    else
                        ImagePath = "";


                    if(reader["CreationDate"] != DBNull.Value)
                        CreationDate = (DateTime)reader["CreationDate"];
                    else
                        CreationDate = DateTime.MinValue;


                    if(reader["ModificationDate"] != DBNull.Value)
                        ModificationDate = (DateTime)reader["ModificationDate"];
                    else
                        ModificationDate = DateTime.MinValue;


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
        public static bool GetPersonByPhone(ref int PersonID, ref string FirstName, ref string LastName, ref string MiddleName, ref string Email, string  Phone , ref string Address, ref DateTime DateOfBirth, ref byte Gender, ref string ImagePath, ref DateTime CreationDate, ref DateTime ModificationDate, ref bool IsDeleted)
        {
            bool isFound = false;
            string query = "SELECT * FROM People WHERE Phone = @Phone";
            try
            { 
              using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                 {         
                using(SqlCommand command = new SqlCommand(query, connection))
                    {
                    command.Parameters.AddWithValue("@Phone", Phone);        
                    connection.Open();
                     using (SqlDataReader reader = command.ExecuteReader())      
                          {
        
                        if(reader.Read())
                        {
                            isFound = true;
        
                        PersonID = (int)reader["PersonID"];
                        FirstName = (string)reader["FirstName"];
                        LastName = (string)reader["LastName"];

                    if(reader["MiddleName"] != DBNull.Value)
                        MiddleName = (string)reader["MiddleName"];
                    else
                        MiddleName = "";


                    if(reader["Email"] != DBNull.Value)
                        Email = (string)reader["Email"];
                    else
                        Email = "";


                    if(reader["Address"] != DBNull.Value)
                        Address = (string)reader["Address"];
                    else
                        Address = "";


                    if(reader["DateOfBirth"] != DBNull.Value)
                        DateOfBirth = (DateTime)reader["DateOfBirth"];
                    else
                        DateOfBirth = DateTime.MinValue;

                        Gender = (byte)reader["Gender"];

                    if(reader["ImagePath"] != DBNull.Value)
                        ImagePath = (string)reader["ImagePath"];
                    else
                        ImagePath = "";


                    if(reader["CreationDate"] != DBNull.Value)
                        CreationDate = (DateTime)reader["CreationDate"];
                    else
                        CreationDate = DateTime.MinValue;


                    if(reader["ModificationDate"] != DBNull.Value)
                        ModificationDate = (DateTime)reader["ModificationDate"];
                    else
                        ModificationDate = DateTime.MinValue;


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
        public static bool GetPersonByAddress(ref int PersonID, ref string FirstName, ref string LastName, ref string MiddleName, ref string Email, ref string Phone, string  Address , ref DateTime DateOfBirth, ref byte Gender, ref string ImagePath, ref DateTime CreationDate, ref DateTime ModificationDate, ref bool IsDeleted)
        {
            bool isFound = false;
            string query = "SELECT * FROM People WHERE Address = @Address";
            try
            { 
              using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                 {         
                using(SqlCommand command = new SqlCommand(query, connection))
                    {
                    command.Parameters.AddWithValue("@Address", Address);        
                    connection.Open();
                     using (SqlDataReader reader = command.ExecuteReader())      
                          {
        
                        if(reader.Read())
                        {
                            isFound = true;
        
                        PersonID = (int)reader["PersonID"];
                        FirstName = (string)reader["FirstName"];
                        LastName = (string)reader["LastName"];

                    if(reader["MiddleName"] != DBNull.Value)
                        MiddleName = (string)reader["MiddleName"];
                    else
                        MiddleName = "";


                    if(reader["Email"] != DBNull.Value)
                        Email = (string)reader["Email"];
                    else
                        Email = "";


                    if(reader["Phone"] != DBNull.Value)
                        Phone = (string)reader["Phone"];
                    else
                        Phone = "";


                    if(reader["DateOfBirth"] != DBNull.Value)
                        DateOfBirth = (DateTime)reader["DateOfBirth"];
                    else
                        DateOfBirth = DateTime.MinValue;

                        Gender = (byte)reader["Gender"];

                    if(reader["ImagePath"] != DBNull.Value)
                        ImagePath = (string)reader["ImagePath"];
                    else
                        ImagePath = "";


                    if(reader["CreationDate"] != DBNull.Value)
                        CreationDate = (DateTime)reader["CreationDate"];
                    else
                        CreationDate = DateTime.MinValue;


                    if(reader["ModificationDate"] != DBNull.Value)
                        ModificationDate = (DateTime)reader["ModificationDate"];
                    else
                        ModificationDate = DateTime.MinValue;


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
        public static bool GetPersonByDateOfBirth(ref int PersonID, ref string FirstName, ref string LastName, ref string MiddleName, ref string Email, ref string Phone, ref string Address, DateTime  DateOfBirth , ref byte Gender, ref string ImagePath, ref DateTime CreationDate, ref DateTime ModificationDate, ref bool IsDeleted)
        {
            bool isFound = false;
            string query = "SELECT * FROM People WHERE DateOfBirth = @DateOfBirth";
            try
            { 
              using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                 {         
                using(SqlCommand command = new SqlCommand(query, connection))
                    {
                    command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);        
                    connection.Open();
                     using (SqlDataReader reader = command.ExecuteReader())      
                          {
        
                        if(reader.Read())
                        {
                            isFound = true;
        
                        PersonID = (int)reader["PersonID"];
                        FirstName = (string)reader["FirstName"];
                        LastName = (string)reader["LastName"];

                    if(reader["MiddleName"] != DBNull.Value)
                        MiddleName = (string)reader["MiddleName"];
                    else
                        MiddleName = "";


                    if(reader["Email"] != DBNull.Value)
                        Email = (string)reader["Email"];
                    else
                        Email = "";


                    if(reader["Phone"] != DBNull.Value)
                        Phone = (string)reader["Phone"];
                    else
                        Phone = "";


                    if(reader["Address"] != DBNull.Value)
                        Address = (string)reader["Address"];
                    else
                        Address = "";

                        Gender = (byte)reader["Gender"];

                    if(reader["ImagePath"] != DBNull.Value)
                        ImagePath = (string)reader["ImagePath"];
                    else
                        ImagePath = "";


                    if(reader["CreationDate"] != DBNull.Value)
                        CreationDate = (DateTime)reader["CreationDate"];
                    else
                        CreationDate = DateTime.MinValue;


                    if(reader["ModificationDate"] != DBNull.Value)
                        ModificationDate = (DateTime)reader["ModificationDate"];
                    else
                        ModificationDate = DateTime.MinValue;


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
        public static bool GetPersonByGender(ref int PersonID, ref string FirstName, ref string LastName, ref string MiddleName, ref string Email, ref string Phone, ref string Address, ref DateTime DateOfBirth, byte  Gender , ref string ImagePath, ref DateTime CreationDate, ref DateTime ModificationDate, ref bool IsDeleted)
        {
            bool isFound = false;
            string query = "SELECT * FROM People WHERE Gender = @Gender";
            try
            { 
              using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                 {         
                using(SqlCommand command = new SqlCommand(query, connection))
                    {
                    command.Parameters.AddWithValue("@Gender", Gender);        
                    connection.Open();
                     using (SqlDataReader reader = command.ExecuteReader())      
                          {
        
                        if(reader.Read())
                        {
                            isFound = true;
        
                        PersonID = (int)reader["PersonID"];
                        FirstName = (string)reader["FirstName"];
                        LastName = (string)reader["LastName"];

                    if(reader["MiddleName"] != DBNull.Value)
                        MiddleName = (string)reader["MiddleName"];
                    else
                        MiddleName = "";


                    if(reader["Email"] != DBNull.Value)
                        Email = (string)reader["Email"];
                    else
                        Email = "";


                    if(reader["Phone"] != DBNull.Value)
                        Phone = (string)reader["Phone"];
                    else
                        Phone = "";


                    if(reader["Address"] != DBNull.Value)
                        Address = (string)reader["Address"];
                    else
                        Address = "";


                    if(reader["DateOfBirth"] != DBNull.Value)
                        DateOfBirth = (DateTime)reader["DateOfBirth"];
                    else
                        DateOfBirth = DateTime.MinValue;


                    if(reader["ImagePath"] != DBNull.Value)
                        ImagePath = (string)reader["ImagePath"];
                    else
                        ImagePath = "";


                    if(reader["CreationDate"] != DBNull.Value)
                        CreationDate = (DateTime)reader["CreationDate"];
                    else
                        CreationDate = DateTime.MinValue;


                    if(reader["ModificationDate"] != DBNull.Value)
                        ModificationDate = (DateTime)reader["ModificationDate"];
                    else
                        ModificationDate = DateTime.MinValue;


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
        public static bool GetPersonByImagePath(ref int PersonID, ref string FirstName, ref string LastName, ref string MiddleName, ref string Email, ref string Phone, ref string Address, ref DateTime DateOfBirth, ref byte Gender, string  ImagePath , ref DateTime CreationDate, ref DateTime ModificationDate, ref bool IsDeleted)
        {
            bool isFound = false;
            string query = "SELECT * FROM People WHERE ImagePath = @ImagePath";
            try
            { 
              using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                 {         
                using(SqlCommand command = new SqlCommand(query, connection))
                    {
                    command.Parameters.AddWithValue("@ImagePath", ImagePath);        
                    connection.Open();
                     using (SqlDataReader reader = command.ExecuteReader())      
                          {
        
                        if(reader.Read())
                        {
                            isFound = true;
        
                        PersonID = (int)reader["PersonID"];
                        FirstName = (string)reader["FirstName"];
                        LastName = (string)reader["LastName"];

                    if(reader["MiddleName"] != DBNull.Value)
                        MiddleName = (string)reader["MiddleName"];
                    else
                        MiddleName = "";


                    if(reader["Email"] != DBNull.Value)
                        Email = (string)reader["Email"];
                    else
                        Email = "";


                    if(reader["Phone"] != DBNull.Value)
                        Phone = (string)reader["Phone"];
                    else
                        Phone = "";


                    if(reader["Address"] != DBNull.Value)
                        Address = (string)reader["Address"];
                    else
                        Address = "";


                    if(reader["DateOfBirth"] != DBNull.Value)
                        DateOfBirth = (DateTime)reader["DateOfBirth"];
                    else
                        DateOfBirth = DateTime.MinValue;

                        Gender = (byte)reader["Gender"];

                    if(reader["CreationDate"] != DBNull.Value)
                        CreationDate = (DateTime)reader["CreationDate"];
                    else
                        CreationDate = DateTime.MinValue;


                    if(reader["ModificationDate"] != DBNull.Value)
                        ModificationDate = (DateTime)reader["ModificationDate"];
                    else
                        ModificationDate = DateTime.MinValue;


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
        public static bool GetPersonByCreationDate(ref int PersonID, ref string FirstName, ref string LastName, ref string MiddleName, ref string Email, ref string Phone, ref string Address, ref DateTime DateOfBirth, ref byte Gender, ref string ImagePath, DateTime  CreationDate , ref DateTime ModificationDate, ref bool IsDeleted)
        {
            bool isFound = false;
            string query = "SELECT * FROM People WHERE CreationDate = @CreationDate";
            try
            { 
              using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                 {         
                using(SqlCommand command = new SqlCommand(query, connection))
                    {
                    command.Parameters.AddWithValue("@CreationDate", CreationDate);        
                    connection.Open();
                     using (SqlDataReader reader = command.ExecuteReader())      
                          {
        
                        if(reader.Read())
                        {
                            isFound = true;
        
                        PersonID = (int)reader["PersonID"];
                        FirstName = (string)reader["FirstName"];
                        LastName = (string)reader["LastName"];

                    if(reader["MiddleName"] != DBNull.Value)
                        MiddleName = (string)reader["MiddleName"];
                    else
                        MiddleName = "";


                    if(reader["Email"] != DBNull.Value)
                        Email = (string)reader["Email"];
                    else
                        Email = "";


                    if(reader["Phone"] != DBNull.Value)
                        Phone = (string)reader["Phone"];
                    else
                        Phone = "";


                    if(reader["Address"] != DBNull.Value)
                        Address = (string)reader["Address"];
                    else
                        Address = "";


                    if(reader["DateOfBirth"] != DBNull.Value)
                        DateOfBirth = (DateTime)reader["DateOfBirth"];
                    else
                        DateOfBirth = DateTime.MinValue;

                        Gender = (byte)reader["Gender"];

                    if(reader["ImagePath"] != DBNull.Value)
                        ImagePath = (string)reader["ImagePath"];
                    else
                        ImagePath = "";


                    if(reader["ModificationDate"] != DBNull.Value)
                        ModificationDate = (DateTime)reader["ModificationDate"];
                    else
                        ModificationDate = DateTime.MinValue;


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
        public static bool GetPersonByModificationDate(ref int PersonID, ref string FirstName, ref string LastName, ref string MiddleName, ref string Email, ref string Phone, ref string Address, ref DateTime DateOfBirth, ref byte Gender, ref string ImagePath, ref DateTime CreationDate, DateTime  ModificationDate , ref bool IsDeleted)
        {
            bool isFound = false;
            string query = "SELECT * FROM People WHERE ModificationDate = @ModificationDate";
            try
            { 
              using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                 {         
                using(SqlCommand command = new SqlCommand(query, connection))
                    {
                    command.Parameters.AddWithValue("@ModificationDate", ModificationDate);        
                    connection.Open();
                     using (SqlDataReader reader = command.ExecuteReader())      
                          {
        
                        if(reader.Read())
                        {
                            isFound = true;
        
                        PersonID = (int)reader["PersonID"];
                        FirstName = (string)reader["FirstName"];
                        LastName = (string)reader["LastName"];

                    if(reader["MiddleName"] != DBNull.Value)
                        MiddleName = (string)reader["MiddleName"];
                    else
                        MiddleName = "";


                    if(reader["Email"] != DBNull.Value)
                        Email = (string)reader["Email"];
                    else
                        Email = "";


                    if(reader["Phone"] != DBNull.Value)
                        Phone = (string)reader["Phone"];
                    else
                        Phone = "";


                    if(reader["Address"] != DBNull.Value)
                        Address = (string)reader["Address"];
                    else
                        Address = "";


                    if(reader["DateOfBirth"] != DBNull.Value)
                        DateOfBirth = (DateTime)reader["DateOfBirth"];
                    else
                        DateOfBirth = DateTime.MinValue;

                        Gender = (byte)reader["Gender"];

                    if(reader["ImagePath"] != DBNull.Value)
                        ImagePath = (string)reader["ImagePath"];
                    else
                        ImagePath = "";


                    if(reader["CreationDate"] != DBNull.Value)
                        CreationDate = (DateTime)reader["CreationDate"];
                    else
                        CreationDate = DateTime.MinValue;


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
        public static bool GetPersonByIsDeleted(ref int PersonID, ref string FirstName, ref string LastName, ref string MiddleName, ref string Email, ref string Phone, ref string Address, ref DateTime DateOfBirth, ref byte Gender, ref string ImagePath, ref DateTime CreationDate, ref DateTime ModificationDate, bool  IsDeleted )
        {
            bool isFound = false;
            string query = "SELECT * FROM People WHERE IsDeleted = @IsDeleted";
            try
            { 
              using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                 {         
                using(SqlCommand command = new SqlCommand(query, connection))
                    {
                    command.Parameters.AddWithValue("@IsDeleted", IsDeleted);        
                    connection.Open();
                     using (SqlDataReader reader = command.ExecuteReader())      
                          {
        
                        if(reader.Read())
                        {
                            isFound = true;
        
                        PersonID = (int)reader["PersonID"];
                        FirstName = (string)reader["FirstName"];
                        LastName = (string)reader["LastName"];

                    if(reader["MiddleName"] != DBNull.Value)
                        MiddleName = (string)reader["MiddleName"];
                    else
                        MiddleName = "";


                    if(reader["Email"] != DBNull.Value)
                        Email = (string)reader["Email"];
                    else
                        Email = "";


                    if(reader["Phone"] != DBNull.Value)
                        Phone = (string)reader["Phone"];
                    else
                        Phone = "";


                    if(reader["Address"] != DBNull.Value)
                        Address = (string)reader["Address"];
                    else
                        Address = "";


                    if(reader["DateOfBirth"] != DBNull.Value)
                        DateOfBirth = (DateTime)reader["DateOfBirth"];
                    else
                        DateOfBirth = DateTime.MinValue;

                        Gender = (byte)reader["Gender"];

                    if(reader["ImagePath"] != DBNull.Value)
                        ImagePath = (string)reader["ImagePath"];
                    else
                        ImagePath = "";


                    if(reader["CreationDate"] != DBNull.Value)
                        CreationDate = (DateTime)reader["CreationDate"];
                    else
                        CreationDate = DateTime.MinValue;


                    if(reader["ModificationDate"] != DBNull.Value)
                        ModificationDate = (DateTime)reader["ModificationDate"];
                    else
                        ModificationDate = DateTime.MinValue;

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
        public static int AddNewPerson(string FirstName, string LastName, string MiddleName, string Email, string Phone, string Address, DateTime DateOfBirth, byte Gender, string ImagePath)
        {
            int PersonID = -1;
             string query = @"INSERT INTO People (FirstName, LastName, MiddleName, Email, Phone, Address, DateOfBirth, Gender, ImagePath, CreationDate, ModificationDate, IsDeleted)
                            VALUES (@FirstName, @LastName, @MiddleName, @Email, @Phone, @Address, @DateOfBirth, @Gender, @ImagePath, @CreationDate, @ModificationDate, @IsDeleted)
                            SELECT SCOPE_IDENTITY();";
        try{
             using( SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {       
                   using (SqlCommand command = new SqlCommand(query, connection))
                    {

            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);

            if(MiddleName != "")
                command.Parameters.AddWithValue("@MiddleName", MiddleName);
            else
                command.Parameters.AddWithValue("@MiddleName", DBNull.Value);

            if(Email != "")
                command.Parameters.AddWithValue("@Email", Email);
            else
                command.Parameters.AddWithValue("@Email", DBNull.Value);

            if(Phone != "")
                command.Parameters.AddWithValue("@Phone", Phone);
            else
                command.Parameters.AddWithValue("@Phone", DBNull.Value);

            if(Address != "")
                command.Parameters.AddWithValue("@Address", Address);
            else
                command.Parameters.AddWithValue("@Address", DBNull.Value);

            if(DateOfBirth != DateTime.MinValue)
                command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            else
                command.Parameters.AddWithValue("@DateOfBirth", DBNull.Value);
            command.Parameters.AddWithValue("@Gender", Gender);

            if(ImagePath != "")
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);

            
                command.Parameters.AddWithValue("@CreationDate", DateTime.Now);
            
                command.Parameters.AddWithValue("@ModificationDate", DBNull.Value);

                command.Parameters.AddWithValue("@IsDeleted", DBNull.Value);
            
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if(result != null && int.TryParse(result.ToString(), out int insertedID))
                      {
                    PersonID = insertedID;
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

            return PersonID;
        }
        public static bool UpdatePerson(int PersonID, string FirstName, string LastName, string MiddleName, string Email, string Phone, string Address, DateTime DateOfBirth, byte Gender, string ImagePath, DateTime CreationDate, DateTime ModificationDate, bool IsDeleted)
        {
            int rowsAffected = 0;
            string query = @"UPDATE People  
                                        SET 
                                        FirstName = @FirstName, 
                            LastName = @LastName, 
                            MiddleName = @MiddleName, 
                            Email = @Email, 
                            Phone = @Phone, 
                            Address = @Address, 
                            DateOfBirth = @DateOfBirth, 
                            Gender = @Gender, 
                            ImagePath = @ImagePath, 
                           
                            WHERE PersonID = @PersonID";
            try{
                   using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        using(SqlCommand command = new SqlCommand(query, connection))
                        {

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@MiddleName", MiddleName);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@ImagePath", ImagePath);
           
            command.Parameters.AddWithValue("@ModificationDate", DateTime.Now);
            
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
        public static bool DeletePerson(int PersonID)
        {
            int rowsAffected = 0;
            string query = @"Delete People 
                                where PersonID = @PersonID";
            try{
                 using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                    {
                        using(SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@PersonID", PersonID);
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
        public static bool IsPersonExist(int PersonID)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM People WHERE PersonID = @PersonID";
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
        public static bool IsPersonExistByPersonID(int PersonID)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM People WHERE PersonID = @PersonID";
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
        public static bool IsPersonExistByFirstName(string FirstName)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM People WHERE FirstName = @FirstName";
            try{
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                       {
                            using(SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@FirstName", FirstName);
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
        public static bool IsPersonExistByLastName(string LastName)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM People WHERE LastName = @LastName";
            try{
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                       {
                            using(SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@LastName", LastName);
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
        public static bool IsPersonExistByMiddleName(string MiddleName)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM People WHERE MiddleName = @MiddleName";
            try{
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                       {
                            using(SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@MiddleName", MiddleName);
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
        public static bool IsPersonExistByEmail(string Email)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM People WHERE Email = @Email";
            try{
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                       {
                            using(SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@Email", Email);
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
        public static bool IsPersonExistByPhone(string Phone)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM People WHERE Phone = @Phone";
            try{
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                       {
                            using(SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@Phone", Phone);
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
        public static bool IsPersonExistByAddress(string Address)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM People WHERE Address = @Address";
            try{
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                       {
                            using(SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@Address", Address);
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
        public static bool IsPersonExistByDateOfBirth(DateTime DateOfBirth)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM People WHERE DateOfBirth = @DateOfBirth";
            try{
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                       {
                            using(SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
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
        public static bool IsPersonExistByGender(byte Gender)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM People WHERE Gender = @Gender";
            try{
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                       {
                            using(SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@Gender", Gender);
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
        public static bool IsPersonExistByImagePath(string ImagePath)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM People WHERE ImagePath = @ImagePath";
            try{
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                       {
                            using(SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@ImagePath", ImagePath);
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
        public static bool IsPersonExistByCreationDate(DateTime CreationDate)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM People WHERE CreationDate = @CreationDate";
            try{
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                       {
                            using(SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@CreationDate", CreationDate);
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
        public static bool IsPersonExistByModificationDate(DateTime ModificationDate)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM People WHERE ModificationDate = @ModificationDate";
            try{
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                       {
                            using(SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@ModificationDate", ModificationDate);
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
        public static bool IsPersonExistByIsDeleted(bool IsDeleted)
        {
            bool isFound = false;
            string query = "SELECT Found=1 FROM People WHERE IsDeleted = @IsDeleted";
            try{
                    using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                       {
                            using(SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@IsDeleted", IsDeleted);
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
        public static DataTable GetAllPeople()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM People";
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
