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
        public static bool IsLoanExistByLoanID(int LoanID)
        {
            return clsLoanData.IsLoanExistByLoanID(LoanID);
        }
        public static bool IsLoanExistByBookID(int BookID)
        {
            return clsLoanData.IsLoanExistByBookID(BookID);
        }
        public static bool IsLoanExistByMemberID(int MemberID)
        {
            return clsLoanData.IsLoanExistByMemberID(MemberID);
        }
        public static bool IsLoanExistByLibrarianID(int LibrarianID)
        {
            return clsLoanData.IsLoanExistByLibrarianID(LibrarianID);
        }
        public static bool IsLoanExistByLoanDate(DateTime LoanDate)
        {
            return clsLoanData.IsLoanExistByLoanDate(LoanDate);
        }
        public static bool IsLoanExistByDueDate(DateTime DueDate)
        {
            return clsLoanData.IsLoanExistByDueDate(DueDate);
        }
        public static bool IsLoanExistByReturnDate(DateTime ReturnDate)
        {
            return clsLoanData.IsLoanExistByReturnDate(ReturnDate);
        }
        public static clsLoan FindByLoanID(int LoanID)
        {
            int BookID = -1;
            int MemberID = -1;
            int LibrarianID = -1;
            DateTime LoanDate = DateTime.MinValue;
            DateTime DueDate = DateTime.MinValue;
            DateTime ReturnDate = DateTime.MinValue;

            bool IsFound = clsLoanData.GetLoanByLoanID(LoanID , ref BookID, ref MemberID, ref LibrarianID, ref LoanDate, ref DueDate, ref ReturnDate);

            if(IsFound)
                return new clsLoan(LoanID , BookID, MemberID, LibrarianID, LoanDate, DueDate, ReturnDate);
            else
                return null;
        }
        public static clsLoan FindByBookID(int BookID)
        {
            int LoanID = -1;
            int MemberID = -1;
            int LibrarianID = -1;
            DateTime LoanDate = DateTime.MinValue;
            DateTime DueDate = DateTime.MinValue;
            DateTime ReturnDate = DateTime.MinValue;

            bool IsFound = clsLoanData.GetLoanByBookID(ref LoanID, BookID , ref MemberID, ref LibrarianID, ref LoanDate, ref DueDate, ref ReturnDate);

            if(IsFound)
                return new clsLoan(LoanID, BookID , MemberID, LibrarianID, LoanDate, DueDate, ReturnDate);
            else
                return null;
        }
        public static clsLoan FindByMemberID(int MemberID)
        {
            int LoanID = -1;
            int BookID = -1;
            int LibrarianID = -1;
            DateTime LoanDate = DateTime.MinValue;
            DateTime DueDate = DateTime.MinValue;
            DateTime ReturnDate = DateTime.MinValue;

            bool IsFound = clsLoanData.GetLoanByMemberID(ref LoanID, ref BookID, MemberID , ref LibrarianID, ref LoanDate, ref DueDate, ref ReturnDate);

            if(IsFound)
                return new clsLoan(LoanID, BookID, MemberID , LibrarianID, LoanDate, DueDate, ReturnDate);
            else
                return null;
        }
        public static clsLoan FindByLibrarianID(int LibrarianID)
        {
            int LoanID = -1;
            int BookID = -1;
            int MemberID = -1;
            DateTime LoanDate = DateTime.MinValue;
            DateTime DueDate = DateTime.MinValue;
            DateTime ReturnDate = DateTime.MinValue;

            bool IsFound = clsLoanData.GetLoanByLibrarianID(ref LoanID, ref BookID, ref MemberID, LibrarianID , ref LoanDate, ref DueDate, ref ReturnDate);

            if(IsFound)
                return new clsLoan(LoanID, BookID, MemberID, LibrarianID , LoanDate, DueDate, ReturnDate);
            else
                return null;
        }
        public static clsLoan FindByLoanDate(DateTime LoanDate)
        {
            int LoanID = -1;
            int BookID = -1;
            int MemberID = -1;
            int LibrarianID = -1;
            DateTime DueDate = DateTime.MinValue;
            DateTime ReturnDate = DateTime.MinValue;

            bool IsFound = clsLoanData.GetLoanByLoanDate(ref LoanID, ref BookID, ref MemberID, ref LibrarianID, LoanDate , ref DueDate, ref ReturnDate);

            if(IsFound)
                return new clsLoan(LoanID, BookID, MemberID, LibrarianID, LoanDate , DueDate, ReturnDate);
            else
                return null;
        }
        public static clsLoan FindByDueDate(DateTime DueDate)
        {
            int LoanID = -1;
            int BookID = -1;
            int MemberID = -1;
            int LibrarianID = -1;
            DateTime LoanDate = DateTime.MinValue;
            DateTime ReturnDate = DateTime.MinValue;

            bool IsFound = clsLoanData.GetLoanByDueDate(ref LoanID, ref BookID, ref MemberID, ref LibrarianID, ref LoanDate, DueDate , ref ReturnDate);

            if(IsFound)
                return new clsLoan(LoanID, BookID, MemberID, LibrarianID, LoanDate, DueDate , ReturnDate);
            else
                return null;
        }
        public static clsLoan FindByReturnDate(DateTime ReturnDate)
        {
            int LoanID = -1;
            int BookID = -1;
            int MemberID = -1;
            int LibrarianID = -1;
            DateTime LoanDate = DateTime.MinValue;
            DateTime DueDate = DateTime.MinValue;

            bool IsFound = clsLoanData.GetLoanByReturnDate(ref LoanID, ref BookID, ref MemberID, ref LibrarianID, ref LoanDate, ref DueDate, ReturnDate );

            if(IsFound)
                return new clsLoan(LoanID, BookID, MemberID, LibrarianID, LoanDate, DueDate, ReturnDate );
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
