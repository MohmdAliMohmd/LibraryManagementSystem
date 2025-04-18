using System;
using System.Data;
using LibraryManagementSystem_DataAccess;

namespace LibraryManagementSystem_Business
{
    public class clsFine
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int FineID { set; get; }
        public int MemberID { set; get; }
        public int LoanID { set; get; }
        public int LibrarianID { set; get; }
        public decimal FineFees { set; get; }
        public byte Status { set; get; }

        public clsFine()
        {
            this.FineID = -1;
            this.MemberID = -1;
            this.LoanID = -1;
            this.LibrarianID = -1;
            this.FineFees = -1;
            this.Status = 0;
            Mode = enMode.AddNew;
        }
        private clsFine(int FineID, int MemberID, int LoanID, int LibrarianID, decimal FineFees, byte Status)
        {
            this.FineID = FineID;
            this.MemberID = MemberID;
            this.LoanID = LoanID;
            this.LibrarianID = LibrarianID;
            this.FineFees = FineFees;
            this.Status = Status;
            Mode = enMode.Update;
        }
        private bool _AddNewFine()
        {
            this.FineID = (int)clsFineData.AddNewFine(this.MemberID, this.LoanID, this.LibrarianID, this.FineFees, this.Status);
            return (this.FineID != -1);
        }
        private bool _UpdateFine()
        {
            return clsFineData.UpdateFine(this.FineID, this.MemberID, this.LoanID, this.LibrarianID, this.FineFees, this.Status);
        }
        public static bool DeleteFine(int FineID)
        {
            return clsFineData.DeleteFine(FineID);
        }
        public static bool IsFineExistByFineID(int FineID)
        {
            return clsFineData.IsFineExistByFineID(FineID);
        }
        public static bool IsFineExistByMemberID(int MemberID)
        {
            return clsFineData.IsFineExistByMemberID(MemberID);
        }
        public static bool IsFineExistByLoanID(int LoanID)
        {
            return clsFineData.IsFineExistByLoanID(LoanID);
        }
        public static bool IsFineExistByLibrarianID(int LibrarianID)
        {
            return clsFineData.IsFineExistByLibrarianID(LibrarianID);
        }
        public static bool IsFineExistByFineFees(decimal FineFees)
        {
            return clsFineData.IsFineExistByFineFees(FineFees);
        }
        public static bool IsFineExistByStatus(byte Status)
        {
            return clsFineData.IsFineExistByStatus(Status);
        }
        public static clsFine FindByFineID(int FineID)
        {
            int MemberID = -1;
            int LoanID = -1;
            int LibrarianID = -1;
            decimal FineFees = -1;
            byte Status = 0;

            bool IsFound = clsFineData.GetFineByFineID(FineID , ref MemberID, ref LoanID, ref LibrarianID, ref FineFees, ref Status);

            if(IsFound)
                return new clsFine(FineID , MemberID, LoanID, LibrarianID, FineFees, Status);
            else
                return null;
        }
        public static clsFine FindByMemberID(int MemberID)
        {
            int FineID = -1;
            int LoanID = -1;
            int LibrarianID = -1;
            decimal FineFees = -1;
            byte Status = 0;

            bool IsFound = clsFineData.GetFineByMemberID(ref FineID, MemberID , ref LoanID, ref LibrarianID, ref FineFees, ref Status);

            if(IsFound)
                return new clsFine(FineID, MemberID , LoanID, LibrarianID, FineFees, Status);
            else
                return null;
        }
        public static clsFine FindByLoanID(int LoanID)
        {
            int FineID = -1;
            int MemberID = -1;
            int LibrarianID = -1;
            decimal FineFees = -1;
            byte Status = 0;

            bool IsFound = clsFineData.GetFineByLoanID(ref FineID, ref MemberID, LoanID , ref LibrarianID, ref FineFees, ref Status);

            if(IsFound)
                return new clsFine(FineID, MemberID, LoanID , LibrarianID, FineFees, Status);
            else
                return null;
        }
        public static clsFine FindByLibrarianID(int LibrarianID)
        {
            int FineID = -1;
            int MemberID = -1;
            int LoanID = -1;
            decimal FineFees = -1;
            byte Status = 0;

            bool IsFound = clsFineData.GetFineByLibrarianID(ref FineID, ref MemberID, ref LoanID, LibrarianID , ref FineFees, ref Status);

            if(IsFound)
                return new clsFine(FineID, MemberID, LoanID, LibrarianID , FineFees, Status);
            else
                return null;
        }
        public static clsFine FindByFineFees(decimal FineFees)
        {
            int FineID = -1;
            int MemberID = -1;
            int LoanID = -1;
            int LibrarianID = -1;
            byte Status = 0;

            bool IsFound = clsFineData.GetFineByFineFees(ref FineID, ref MemberID, ref LoanID, ref LibrarianID, FineFees , ref Status);

            if(IsFound)
                return new clsFine(FineID, MemberID, LoanID, LibrarianID, FineFees , Status);
            else
                return null;
        }
        public static clsFine FindByStatus(byte Status)
        {
            int FineID = -1;
            int MemberID = -1;
            int LoanID = -1;
            int LibrarianID = -1;
            decimal FineFees = -1;

            bool IsFound = clsFineData.GetFineByStatus(ref FineID, ref MemberID, ref LoanID, ref LibrarianID, ref FineFees, Status );

            if(IsFound)
                return new clsFine(FineID, MemberID, LoanID, LibrarianID, FineFees, Status );
            else
                return null;
        }
        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    if(_AddNewFine())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateFine();
            }
            return false;
        }
        public static DataTable GetFines()
        {
            return clsFineData.GetAllFines();
        }
    }
}
