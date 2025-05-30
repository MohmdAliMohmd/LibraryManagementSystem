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
        public static bool IsLibrarianExistByLibrarianID(int LibrarianID)
        {
            return clsLibrarianData.IsLibrarianExistByLibrarianID(LibrarianID);
        }
        public static bool IsLibrarianExistByPersonID(int PersonID)
        {
            return clsLibrarianData.IsLibrarianExistByPersonID(PersonID);
        }
        public static bool IsLibrarianExistByUserName(string UserName)
        {
            return clsLibrarianData.IsLibrarianExistByUserName(UserName);
        }
        public static bool IsLibrarianExistByPassWord(string PassWord)
        {
            return clsLibrarianData.IsLibrarianExistByPassWord(PassWord);
        }
        public static bool IsLibrarianExistBystartDate(DateTime startDate)
        {
            return clsLibrarianData.IsLibrarianExistBystartDate(startDate);
        }
        public static bool IsLibrarianExistByEndDate(DateTime EndDate)
        {
            return clsLibrarianData.IsLibrarianExistByEndDate(EndDate);
        }
        public static clsLibrarian FindByLibrarianID(int LibrarianID)
        {
            int PersonID = -1;
            string UserName = "";
            string PassWord = "";
            DateTime startDate = DateTime.MinValue;
            DateTime EndDate = DateTime.MinValue;

            bool IsFound = clsLibrarianData.GetLibrarianByLibrarianID(LibrarianID , ref PersonID, ref UserName, ref PassWord, ref startDate, ref EndDate);

            if(IsFound)
                return new clsLibrarian(LibrarianID , PersonID, UserName, PassWord, startDate, EndDate);
            else
                return null;
        }
        public static clsLibrarian FindByPersonID(int PersonID)
        {
            int LibrarianID = -1;
            string UserName = "";
            string PassWord = "";
            DateTime startDate = DateTime.MinValue;
            DateTime EndDate = DateTime.MinValue;

            bool IsFound = clsLibrarianData.GetLibrarianByPersonID(ref LibrarianID, PersonID , ref UserName, ref PassWord, ref startDate, ref EndDate);

            if(IsFound)
                return new clsLibrarian(LibrarianID, PersonID , UserName, PassWord, startDate, EndDate);
            else
                return null;
        }
        public static clsLibrarian FindByUserName(string UserName)
        {
            int LibrarianID = -1;
            int PersonID = -1;
            string PassWord = "";
            DateTime startDate = DateTime.MinValue;
            DateTime EndDate = DateTime.MinValue;

            bool IsFound = clsLibrarianData.GetLibrarianByUserName(ref LibrarianID, ref PersonID, UserName , ref PassWord, ref startDate, ref EndDate);

            if(IsFound)
                return new clsLibrarian(LibrarianID, PersonID, UserName , PassWord, startDate, EndDate);
            else
                return null;
        }
        public static clsLibrarian FindByPassWord(string PassWord)
        {
            int LibrarianID = -1;
            int PersonID = -1;
            string UserName = "";
            DateTime startDate = DateTime.MinValue;
            DateTime EndDate = DateTime.MinValue;

            bool IsFound = clsLibrarianData.GetLibrarianByPassWord(ref LibrarianID, ref PersonID, ref UserName, PassWord , ref startDate, ref EndDate);

            if(IsFound)
                return new clsLibrarian(LibrarianID, PersonID, UserName, PassWord , startDate, EndDate);
            else
                return null;
        }
        public static clsLibrarian FindBystartDate(DateTime startDate)
        {
            int LibrarianID = -1;
            int PersonID = -1;
            string UserName = "";
            string PassWord = "";
            DateTime EndDate = DateTime.MinValue;

            bool IsFound = clsLibrarianData.GetLibrarianBystartDate(ref LibrarianID, ref PersonID, ref UserName, ref PassWord, startDate , ref EndDate);

            if(IsFound)
                return new clsLibrarian(LibrarianID, PersonID, UserName, PassWord, startDate , EndDate);
            else
                return null;
        }
        public static clsLibrarian FindByEndDate(DateTime EndDate)
        {
            int LibrarianID = -1;
            int PersonID = -1;
            string UserName = "";
            string PassWord = "";
            DateTime startDate = DateTime.MinValue;

            bool IsFound = clsLibrarianData.GetLibrarianByEndDate(ref LibrarianID, ref PersonID, ref UserName, ref PassWord, ref startDate, EndDate );

            if(IsFound)
                return new clsLibrarian(LibrarianID, PersonID, UserName, PassWord, startDate, EndDate );
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
