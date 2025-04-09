using System;
using System.Data;
using LibraryManagementSystem_DataAccess;

namespace LibraryManagementSystem_Business
{
    public class clsMember
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int MemberID { set; get; }
        public int PersonID { set; get; }
        public DateTime RegistrationDate { set; get; }
        public int RegisteredBy { set; get; }

        public clsMember()
        {
            this.MemberID = -1;
            this.PersonID = -1;
            this.RegistrationDate = DateTime.MinValue;
            this.RegisteredBy = -1;
            Mode = enMode.AddNew;
        }
        private clsMember(int MemberID, int PersonID, DateTime RegistrationDate, int RegisteredBy)
        {
            this.MemberID = MemberID;
            this.PersonID = PersonID;
            this.RegistrationDate = RegistrationDate;
            this.RegisteredBy = RegisteredBy;
            Mode = enMode.Update;
        }
        private bool _AddNewMember()
        {
            this.MemberID = (int)clsMemberData.AddNewMember(this.PersonID, this.RegistrationDate, this.RegisteredBy);
            return (this.MemberID != -1);
        }
        private bool _UpdateMember()
        {
            return clsMemberData.UpdateMember(this.MemberID, this.PersonID, this.RegistrationDate, this.RegisteredBy);
        }
        public static bool DeleteMember(int MemberID)
        {
            return clsMemberData.DeleteMember(MemberID);
        }
        public static bool IsMemberExist(int MemberID)
        {
            return clsMemberData.IsMemberExist(MemberID);
        }
        public static clsMember Find(int MemberID)
        {
            int PersonID = -1;
            DateTime RegistrationDate = DateTime.MinValue;
            int RegisteredBy = -1;

            bool IsFound = clsMemberData.GetMemberByID(MemberID, ref PersonID, ref RegistrationDate, ref RegisteredBy);

            if(IsFound)
                return new clsMember(MemberID, PersonID, RegistrationDate, RegisteredBy);
            else
                return null;
        }
        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    if(_AddNewMember())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateMember();
            }
            return false;
        }
        public static DataTable GetMembers()
        {
            return clsMemberData.GetAllMembers();
        }
    }
}
