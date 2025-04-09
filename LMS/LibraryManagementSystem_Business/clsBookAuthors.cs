using System;
using System.Data;
using LibraryManagementSystem_DataAccess;

namespace LibraryManagementSystem_Business
{
    public class clsBookAuthors
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int BookAuthorsID { set; get; }
        public int BookID { set; get; }
        public int AuthorID { set; get; }

        public clsBookAuthors()
        {
            this.BookAuthorsID = -1;
            this.BookID = -1;
            this.AuthorID = -1;
            Mode = enMode.AddNew;
        }
        private clsBookAuthors(int BookAuthorsID, int BookID, int AuthorID)
        {
            this.BookAuthorsID = BookAuthorsID;
            this.BookID = BookID;
            this.AuthorID = AuthorID;
            Mode = enMode.Update;
        }
        private bool _AddNewBookAuthors()
        {
            this.BookAuthorsID = (int)clsBookAuthorsData.AddNewBookAuthors(this.BookID, this.AuthorID);
            return (this.BookAuthorsID != -1);
        }
        private bool _UpdateBookAuthors()
        {
            return clsBookAuthorsData.UpdateBookAuthors(this.BookAuthorsID, this.BookID, this.AuthorID);
        }
        public static bool DeleteBookAuthors(int BookAuthorsID)
        {
            return clsBookAuthorsData.DeleteBookAuthors(BookAuthorsID);
        }
        public static bool IsBookAuthorsExist(int BookAuthorsID)
        {
            return clsBookAuthorsData.IsBookAuthorsExist(BookAuthorsID);
        }
        public static clsBookAuthors Find(int BookAuthorsID)
        {
            int BookID = -1;
            int AuthorID = -1;

            bool IsFound = clsBookAuthorsData.GetBookAuthorsByID(BookAuthorsID, ref BookID, ref AuthorID);

            if(IsFound)
                return new clsBookAuthors(BookAuthorsID, BookID, AuthorID);
            else
                return null;
        }
        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    if(_AddNewBookAuthors())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateBookAuthors();
            }
            return false;
        }
        public static DataTable GetBookAuthors()
        {
            return clsBookAuthorsData.GetAllBookAuthors();
        }
    }
}
