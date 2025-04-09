using System;
using System.Data;
using LibraryManagementSystem_DataAccess;

namespace LibraryManagementSystem_Business
{
    public class clsReservation
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int ReservationID { set; get; }
        public int BookID { set; get; }
        public int MemberID { set; get; }
        public int LibrarianID { set; get; }
        public DateTime ReservationDate { set; get; }
        public byte Status { set; get; }

        public clsReservation()
        {
            this.ReservationID = -1;
            this.BookID = -1;
            this.MemberID = -1;
            this.LibrarianID = -1;
            this.ReservationDate = DateTime.MinValue;
            this.Status = 0;
            Mode = enMode.AddNew;
        }
        private clsReservation(int ReservationID, int BookID, int MemberID, int LibrarianID, DateTime ReservationDate, byte Status)
        {
            this.ReservationID = ReservationID;
            this.BookID = BookID;
            this.MemberID = MemberID;
            this.LibrarianID = LibrarianID;
            this.ReservationDate = ReservationDate;
            this.Status = Status;
            Mode = enMode.Update;
        }
        private bool _AddNewReservation()
        {
            this.ReservationID = (int)clsReservationData.AddNewReservation(this.BookID, this.MemberID, this.LibrarianID, this.ReservationDate, this.Status);
            return (this.ReservationID != -1);
        }
        private bool _UpdateReservation()
        {
            return clsReservationData.UpdateReservation(this.ReservationID, this.BookID, this.MemberID, this.LibrarianID, this.ReservationDate, this.Status);
        }
        public static bool DeleteReservation(int ReservationID)
        {
            return clsReservationData.DeleteReservation(ReservationID);
        }
        public static bool IsReservationExist(int ReservationID)
        {
            return clsReservationData.IsReservationExist(ReservationID);
        }
        public static clsReservation Find(int ReservationID)
        {
            int BookID = -1;
            int MemberID = -1;
            int LibrarianID = -1;
            DateTime ReservationDate = DateTime.MinValue;
            byte Status = 0;

            bool IsFound = clsReservationData.GetReservationByID(ReservationID, ref BookID, ref MemberID, ref LibrarianID, ref ReservationDate, ref Status);

            if(IsFound)
                return new clsReservation(ReservationID, BookID, MemberID, LibrarianID, ReservationDate, Status);
            else
                return null;
        }
        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    if(_AddNewReservation())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateReservation();
            }
            return false;
        }
        public static DataTable GetReservations()
        {
            return clsReservationData.GetAllReservations();
        }
    }
}
