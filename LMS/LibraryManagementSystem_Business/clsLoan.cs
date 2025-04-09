using System;
using System.Data;
using LibraryManagementSystem_DataAccess;

namespace LibraryManagementSystem_Business
{
    public class clsLoan
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int LoanID { set; get; }
        public int BookID { set; get; }
        public int MemberID { set; get; }
        public int LibrarianID { set; get; }
        public DateTime LoanDate { set; get; }
        public DateTime DueDate { set; get; }
        public DateTime ReturnDate { set; get; }

        public clsLoan()
        {
            this.LoanID = -1;
            this.BookID = -1;
            this.MemberID = -1;
            this.LibrarianID = -1;
            this.LoanDate = DateTime.MinValue;
            this.DueDate = DateTime.MinValue;
            this.ReturnDate = DateTime.MinValue;
            Mode = enMode.AddNew;
        }
        private clsLoan(int LoanID, int BookID, int MemberID, int LibrarianID, DateTime LoanDate, DateTime DueDate, DateTime ReturnDate)
        {
            this.LoanID = LoanID;
            this.BookID = BookID;
            this.MemberID = MemberID;
            this.LibrarianID = LibrarianID;
            this.LoanDate = LoanDate;
            this.DueDate = DueDate;
            this.ReturnDate = ReturnDate;
            Mode = enMode.Update;
        }
        private bool _AddNewLoan()
        {
            this.LoanID = (int)clsLoanData.AddNewLoan(this.BookID, this.MemberID, this.LibrarianID, this.LoanDate, this.DueDate, this.ReturnDate);
            return (this.LoanID != -1);
        }
        private bool _UpdateLoan()
        {
            return clsLoanData.UpdateLoan(this.LoanID, this.BookID, this.MemberID, this.LibrarianID, this.LoanDate, this.DueDate, this.ReturnDate);
        }
        public static bool DeleteLoan(int LoanID)
        {
            return clsLoanData.DeleteLoan(LoanID);
        }
        public static bool IsLoanExist(int LoanID)
        {
            return clsLoanData.IsLoanExist(LoanID);
        }
        public static clsLoan Find(int LoanID)
        {
            int BookID = -1;
            int MemberID = -1;
            int LibrarianID = -1;
            DateTime LoanDate = DateTime.MinValue;
            DateTime DueDate = DateTime.MinValue;
            DateTime ReturnDate = DateTime.MinValue;

            bool IsFound = clsLoanData.GetLoanByID(LoanID, ref BookID, ref MemberID, ref LibrarianID, ref LoanDate, ref DueDate, ref ReturnDate);

            if(IsFound)
                return new clsLoan(LoanID, BookID, MemberID, LibrarianID, LoanDate, DueDate, ReturnDate);
            else
                return null;
        }
        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    if(_AddNewLoan())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateLoan();
            }
            return false;
        }
        public static DataTable GetLoans()
        {
            return clsLoanData.GetAllLoans();
        }
    }
}
