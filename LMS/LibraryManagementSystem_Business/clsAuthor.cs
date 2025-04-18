using System;
using System.Data;
using LibraryManagementSystem_DataAccess;

namespace LibraryManagementSystem_Business
{
    public class clsAuthor
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int AuthorID { set; get; }
        public string AuthorName { set; get; }
        public bool IsDeleted { set; get; }

        public clsAuthor()
        {
            this.AuthorID = -1;
            this.AuthorName = "";
            this.IsDeleted = false;
            Mode = enMode.AddNew;
        }
        private clsAuthor(int AuthorID, string AuthorName, bool IsDeleted)
        {
            this.AuthorID = AuthorID;
            this.AuthorName = AuthorName;
            this.IsDeleted = IsDeleted;
            Mode = enMode.Update;
        }
        private bool _AddNewAuthor()
        {
            this.AuthorID = (int)clsAuthorData.AddNewAuthor(this.AuthorName, this.IsDeleted);
            return (this.AuthorID != -1);
        }
        private bool _UpdateAuthor()
        {
            return clsAuthorData.UpdateAuthor(this.AuthorID, this.AuthorName, this.IsDeleted);
        }
        public static bool DeleteAuthor(int AuthorID)
        {
            return clsAuthorData.DeleteAuthor(AuthorID);
        }
        public static bool IsAuthorExistByAuthorID(int AuthorID)
        {
            return clsAuthorData.IsAuthorExistByAuthorID(AuthorID);
        }
        public static bool IsAuthorExistByAuthorName(string AuthorName)
        {
            return clsAuthorData.IsAuthorExistByAuthorName(AuthorName);
        }
        public static bool IsAuthorExistByIsDeleted(bool IsDeleted)
        {
            return clsAuthorData.IsAuthorExistByIsDeleted(IsDeleted);
        }
        public static clsAuthor FindByAuthorID(int AuthorID)
        {
            string AuthorName = "";
            bool IsDeleted = false;

            bool IsFound = clsAuthorData.GetAuthorByAuthorID(AuthorID , ref AuthorName, ref IsDeleted);

            if(IsFound)
                return new clsAuthor(AuthorID , AuthorName, IsDeleted);
            else
                return null;
        }
        public static clsAuthor FindByAuthorName(string AuthorName)
        {
            int AuthorID = -1;
            bool IsDeleted = false;

            bool IsFound = clsAuthorData.GetAuthorByAuthorName(ref AuthorID, AuthorName , ref IsDeleted);

            if(IsFound)
                return new clsAuthor(AuthorID, AuthorName , IsDeleted);
            else
                return null;
        }
        public static clsAuthor FindByIsDeleted(bool IsDeleted)
        {
            int AuthorID = -1;
            string AuthorName = "";

            bool IsFound = clsAuthorData.GetAuthorByIsDeleted(ref AuthorID, ref AuthorName, IsDeleted );

            if(IsFound)
                return new clsAuthor(AuthorID, AuthorName, IsDeleted );
            else
                return null;
        }
        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    if(_AddNewAuthor())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateAuthor();
            }
            return false;
        }
        public static DataTable GetAuthors()
        {
            return clsAuthorData.GetAllAuthors();
        }
    }
}
