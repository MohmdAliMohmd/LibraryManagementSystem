using System;
using System.Data;
using LibraryManagementSystem_DataAccess;

namespace LibraryManagementSystem_Business
{
    public class clsLibrarian
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int LibrarianID { set; get; }
        public int PersonID { set; get; }
        public string UserName { set; get; }
        public string PassWord { set; get; }
        public DateTime startDate { set; get; }
        public DateTime EndDate { set; get; }

        public clsLibrarian()
        {
            this.LibrarianID = -1;
            this.PersonID = -1;
            this.UserName = "";
            this.PassWord = "";
            this.startDate = DateTime.MinValue;
            this.EndDate = DateTime.MinValue;
            Mode = enMode.AddNew;
        }
        private clsLibrarian(int LibrarianID, int PersonID, string UserName, string PassWord, DateTime startDate, DateTime EndDate)
        {
            this.LibrarianID = LibrarianID;
            this.PersonID = PersonID;
            this.UserName = UserName;
            this.PassWord = PassWord;
            this.startDate = startDate;
            this.EndDate = EndDate;
            Mode = enMode.Update;
        }
        private bool _AddNewLibrarian()
        {
            this.LibrarianID = (int)clsLibrarianData.AddNewLibrarian(this.PersonID, this.UserName, this.PassWord, this.startDate, this.EndDate);
            return (this.LibrarianID != -1);
        }
        private bool _UpdateLibrarian()
        {
            return clsLibrarianData.UpdateLibrarian(this.LibrarianID, this.PersonID, this.UserName, this.PassWord, this.startDate, this.EndDate);
        }
        public static bool DeleteLibrarian(int LibrarianID)
        {
            return clsLibrarianData.DeleteLibrarian(LibrarianID);
        }
        public static bool IsLibrarianExist(int LibrarianID)
        {
            return clsLibrarianData.IsLibrarianExist(LibrarianID);
        }
        public static clsLibrarian Find(int LibrarianID)
        {
            int PersonID = -1;
            string UserName = "";
            string PassWord = "";
            DateTime startDate = DateTime.MinValue;
            DateTime EndDate = DateTime.MinValue;

            bool IsFound = clsLibrarianData.GetLibrarianByID(LibrarianID, ref PersonID, ref UserName, ref PassWord, ref startDate, ref EndDate);

            if(IsFound)
                return new clsLibrarian(LibrarianID, PersonID, UserName, PassWord, startDate, EndDate);
            else
                return null;
        }
        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    if(_AddNewLibrarian())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateLibrarian();
            }
            return false;
        }
        public static DataTable GetLibrarians()
        {
            return clsLibrarianData.GetAllLibrarians();
        }
    }
}
