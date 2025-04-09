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
        public static bool IsAuthorExist(int AuthorID)
        {
            return clsAuthorData.IsAuthorExist(AuthorID);
        }
        public static clsAuthor Find(int AuthorID)
        {
            string AuthorName = "";
            bool IsDeleted = false;

            bool IsFound = clsAuthorData.GetAuthorByID(AuthorID, ref AuthorName, ref IsDeleted);

            if(IsFound)
                return new clsAuthor(AuthorID, AuthorName, IsDeleted);
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
