using System;
using System.Data;
using LibraryManagementSystem_DataAccess;

namespace LibraryManagementSystem_Business
{
    public class clsBook
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int BookID { set; get; }
        public string Title { set; get; }
        public string ISBN { set; get; }
        public int categoryID { set; get; }
        public int PublisherID { set; get; }
        public int PublicationYear { set; get; }
        public int CopiesAvailable { set; get; }

        public clsBook()
        {
            this.BookID = -1;
            this.Title = "";
            this.ISBN = "";
            this.categoryID = -1;
            this.PublisherID = -1;
            this.PublicationYear = -1;
            this.CopiesAvailable = -1;
            Mode = enMode.AddNew;
        }
        private clsBook(int BookID, string Title, string ISBN, int categoryID, int PublisherID, int PublicationYear, int CopiesAvailable)
        {
            this.BookID = BookID;
            this.Title = Title;
            this.ISBN = ISBN;
            this.categoryID = categoryID;
            this.PublisherID = PublisherID;
            this.PublicationYear = PublicationYear;
            this.CopiesAvailable = CopiesAvailable;
            Mode = enMode.Update;
        }
        private bool _AddNewBook()
        {
            this.BookID = (int)clsBookData.AddNewBook(this.Title, this.ISBN, this.categoryID, this.PublisherID, this.PublicationYear, this.CopiesAvailable);
            return (this.BookID != -1);
        }
        private bool _UpdateBook()
        {
            return clsBookData.UpdateBook(this.BookID, this.Title, this.ISBN, this.categoryID, this.PublisherID, this.PublicationYear, this.CopiesAvailable);
        }
        public static bool DeleteBook(int BookID)
        {
            return clsBookData.DeleteBook(BookID);
        }
        public static bool IsBookExist(int BookID)
        {
            return clsBookData.IsBookExist(BookID);
        }
        public static clsBook Find(int BookID)
        {
            string Title = "";
            string ISBN = "";
            int categoryID = -1;
            int PublisherID = -1;
            int PublicationYear = -1;
            int CopiesAvailable = -1;

            bool IsFound = clsBookData.GetBookByID(BookID, ref Title, ref ISBN, ref categoryID, ref PublisherID, ref PublicationYear, ref CopiesAvailable);

            if(IsFound)
                return new clsBook(BookID, Title, ISBN, categoryID, PublisherID, PublicationYear, CopiesAvailable);
            else
                return null;
        }
        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    if(_AddNewBook())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateBook();
            }
            return false;
        }
        public static DataTable GetBooks()
        {
            return clsBookData.GetAllBooks();
        }
    }
}
