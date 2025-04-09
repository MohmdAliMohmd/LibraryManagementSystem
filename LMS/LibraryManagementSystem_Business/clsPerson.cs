using System;
using System.Data;
using LibraryManagementSystem_DataAccess;

namespace LibraryManagementSystem_Business
{
    public class clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int PersonID { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string MiddleName { set; get; }
        public string Email { set; get; }
        public string Phone { set; get; }
        public string Address { set; get; }
        public DateTime DateOfBirth { set; get; }
        public byte Gender { set; get; }
        public string ImagePath { set; get; }
        public DateTime CreationDate { set; get; }
        public DateTime ModificationDate { set; get; }
        public bool IsDeleted { set; get; }

        public clsPerson()
        {
            this.PersonID = -1;
            this.FirstName = "";
            this.LastName = "";
            this.MiddleName = "";
            this.Email = "";
            this.Phone = "";
            this.Address = "";
            this.DateOfBirth = DateTime.MinValue;
            this.Gender = 0;
            this.ImagePath = "";
            this.CreationDate = DateTime.MinValue;
            this.ModificationDate = DateTime.MinValue;
            this.IsDeleted = false;
            Mode = enMode.AddNew;
        }
        private clsPerson(int PersonID, string FirstName, string LastName, string MiddleName, string Email, string Phone, string Address, DateTime DateOfBirth, byte Gender, string ImagePath, DateTime CreationDate, DateTime ModificationDate, bool IsDeleted)
        {
            this.PersonID = PersonID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.MiddleName = MiddleName;
            this.Email = Email;
            this.Phone = Phone;
            this.Address = Address;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.ImagePath = ImagePath;
            this.CreationDate = CreationDate;
            this.ModificationDate = ModificationDate;
            this.IsDeleted = IsDeleted;
            Mode = enMode.Update;
        }
        private bool _AddNewPerson()
        {
            this.PersonID = (int)clsPersonData.AddNewPerson(this.FirstName, this.LastName, this.MiddleName, this.Email, this.Phone, this.Address, this.DateOfBirth, this.Gender, this.ImagePath, this.CreationDate, this.ModificationDate, this.IsDeleted);
            return (this.PersonID != -1);
        }
        private bool _UpdatePerson()
        {
            return clsPersonData.UpdatePerson(this.PersonID, this.FirstName, this.LastName, this.MiddleName, this.Email, this.Phone, this.Address, this.DateOfBirth, this.Gender, this.ImagePath, this.CreationDate, this.ModificationDate, this.IsDeleted);
        }
        public static bool DeletePerson(int PersonID)
        {
            return clsPersonData.DeletePerson(PersonID);
        }
        public static bool IsPersonExist(int PersonID)
        {
            return clsPersonData.IsPersonExist(PersonID);
        }
        public static clsPerson Find(int PersonID)
        {
            string FirstName = "";
            string LastName = "";
            string MiddleName = "";
            string Email = "";
            string Phone = "";
            string Address = "";
            DateTime DateOfBirth = DateTime.MinValue;
            byte Gender = 0;
            string ImagePath = "";
            DateTime CreationDate = DateTime.MinValue;
            DateTime ModificationDate = DateTime.MinValue;
            bool IsDeleted = false;

            bool IsFound = clsPersonData.GetPersonByID(PersonID, ref FirstName, ref LastName, ref MiddleName, ref Email, ref Phone, ref Address, ref DateOfBirth, ref Gender, ref ImagePath, ref CreationDate, ref ModificationDate, ref IsDeleted);

            if(IsFound)
                return new clsPerson(PersonID, FirstName, LastName, MiddleName, Email, Phone, Address, DateOfBirth, Gender, ImagePath, CreationDate, ModificationDate, IsDeleted);
            else
                return null;
        }
        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    if(_AddNewPerson())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdatePerson();
            }
            return false;
        }
        public static DataTable GetPeople()
        {
            return clsPersonData.GetAllPeople();
        }
    }
}
