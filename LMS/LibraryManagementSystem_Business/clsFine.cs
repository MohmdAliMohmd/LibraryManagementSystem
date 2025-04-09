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
        public static bool IsFineExist(int FineID)
        {
            return clsFineData.IsFineExist(FineID);
        }
        public static clsFine Find(int FineID)
        {
            int MemberID = -1;
            int LoanID = -1;
            int LibrarianID = -1;
            decimal FineFees = -1;
            byte Status = 0;

            bool IsFound = clsFineData.GetFineByID(FineID, ref MemberID, ref LoanID, ref LibrarianID, ref FineFees, ref Status);

            if(IsFound)
                return new clsFine(FineID, MemberID, LoanID, LibrarianID, FineFees, Status);
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
