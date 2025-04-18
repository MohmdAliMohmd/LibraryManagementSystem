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
        public string FullName
        {
            get { return FirstName + " " + MiddleName + " " + LastName; }
        }

        public clsPerson(int personID, string firstName, string lastName, string middleName, string email, string phone, string address, DateTime dateOfBirth, byte gender, string imagePath)
        {
            Mode = enMode.Update;
            PersonID = personID;
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            MiddleName = middleName ?? throw new ArgumentNullException(nameof(middleName));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Phone = phone ?? throw new ArgumentNullException(nameof(phone));
            Address = address ?? throw new ArgumentNullException(nameof(address));
            DateOfBirth = dateOfBirth;
            Gender = gender;
            ImagePath = imagePath ?? throw new ArgumentNullException(nameof(imagePath));
           
        }

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
        private clsPerson(int PersonID, string FirstName, string LastName, string MiddleName, string Email, string Phone, string Address, DateTime DateOfBirth, byte Gender, string ImagePath)
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
            this.PersonID = (int)clsPersonData.AddNewPerson(this.FirstName, this.LastName, this.MiddleName, this.Email, this.Phone, this.Address, this.DateOfBirth, this.Gender, this.ImagePath);
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
        public static bool IsPersonExistByPersonID(int PersonID)
        {
            return clsPersonData.IsPersonExistByPersonID(PersonID);
        }
        public static bool IsPersonExistByFirstName(string FirstName)
        {
            return clsPersonData.IsPersonExistByFirstName(FirstName);
        }
        public static bool IsPersonExistByLastName(string LastName)
        {
            return clsPersonData.IsPersonExistByLastName(LastName);
        }
        public static bool IsPersonExistByMiddleName(string MiddleName)
        {
            return clsPersonData.IsPersonExistByMiddleName(MiddleName);
        }
        public static bool IsPersonExistByEmail(string Email)
        {
            return clsPersonData.IsPersonExistByEmail(Email);
        }
        public static bool IsPersonExistByPhone(string Phone)
        {
            return clsPersonData.IsPersonExistByPhone(Phone);
        }
        public static bool IsPersonExistByAddress(string Address)
        {
            return clsPersonData.IsPersonExistByAddress(Address);
        }
        public static bool IsPersonExistByDateOfBirth(DateTime DateOfBirth)
        {
            return clsPersonData.IsPersonExistByDateOfBirth(DateOfBirth);
        }
        public static bool IsPersonExistByGender(byte Gender)
        {
            return clsPersonData.IsPersonExistByGender(Gender);
        }
        public static bool IsPersonExistByImagePath(string ImagePath)
        {
            return clsPersonData.IsPersonExistByImagePath(ImagePath);
        }
        public static bool IsPersonExistByCreationDate(DateTime CreationDate)
        {
            return clsPersonData.IsPersonExistByCreationDate(CreationDate);
        }
        public static bool IsPersonExistByModificationDate(DateTime ModificationDate)
        {
            return clsPersonData.IsPersonExistByModificationDate(ModificationDate);
        }
        public static bool IsPersonExistByIsDeleted(bool IsDeleted)
        {
            return clsPersonData.IsPersonExistByIsDeleted(IsDeleted);
        }
        public static clsPerson FindByPersonID(int PersonID)
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

            bool IsFound = clsPersonData.GetPersonByPersonID(PersonID , ref FirstName, ref LastName, ref MiddleName, ref Email, ref Phone, ref Address, ref DateOfBirth, ref Gender, ref ImagePath, ref CreationDate, ref ModificationDate, ref IsDeleted);

            if(IsFound)
                return new clsPerson(PersonID , FirstName, LastName, MiddleName, Email, Phone, Address, DateOfBirth, Gender, ImagePath, CreationDate, ModificationDate, IsDeleted);
            else
                return null;
        }
        public static clsPerson FindByFirstName(string FirstName)
        {
            int PersonID = -1;
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

            bool IsFound = clsPersonData.GetPersonByFirstName(ref PersonID, FirstName , ref LastName, ref MiddleName, ref Email, ref Phone, ref Address, ref DateOfBirth, ref Gender, ref ImagePath, ref CreationDate, ref ModificationDate, ref IsDeleted);

            if(IsFound)
                return new clsPerson(PersonID, FirstName , LastName, MiddleName, Email, Phone, Address, DateOfBirth, Gender, ImagePath, CreationDate, ModificationDate, IsDeleted);
            else
                return null;
        }
        public static clsPerson FindByLastName(string LastName)
        {
            int PersonID = -1;
            string FirstName = "";
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

            bool IsFound = clsPersonData.GetPersonByLastName(ref PersonID, ref FirstName, LastName , ref MiddleName, ref Email, ref Phone, ref Address, ref DateOfBirth, ref Gender, ref ImagePath, ref CreationDate, ref ModificationDate, ref IsDeleted);

            if(IsFound)
                return new clsPerson(PersonID, FirstName, LastName , MiddleName, Email, Phone, Address, DateOfBirth, Gender, ImagePath, CreationDate, ModificationDate, IsDeleted);
            else
                return null;
        }
        public static clsPerson FindByMiddleName(string MiddleName)
        {
            int PersonID = -1;
            string FirstName = "";
            string LastName = "";
            string Email = "";
            string Phone = "";
            string Address = "";
            DateTime DateOfBirth = DateTime.MinValue;
            byte Gender = 0;
            string ImagePath = "";
            DateTime CreationDate = DateTime.MinValue;
            DateTime ModificationDate = DateTime.MinValue;
            bool IsDeleted = false;

            bool IsFound = clsPersonData.GetPersonByMiddleName(ref PersonID, ref FirstName, ref LastName, MiddleName , ref Email, ref Phone, ref Address, ref DateOfBirth, ref Gender, ref ImagePath, ref CreationDate, ref ModificationDate, ref IsDeleted);

            if(IsFound)
                return new clsPerson(PersonID, FirstName, LastName, MiddleName , Email, Phone, Address, DateOfBirth, Gender, ImagePath, CreationDate, ModificationDate, IsDeleted);
            else
                return null;
        }
        public static clsPerson FindByEmail(string Email)
        {
            int PersonID = -1;
            string FirstName = "";
            string LastName = "";
            string MiddleName = "";
            string Phone = "";
            string Address = "";
            DateTime DateOfBirth = DateTime.MinValue;
            byte Gender = 0;
            string ImagePath = "";
            DateTime CreationDate = DateTime.MinValue;
            DateTime ModificationDate = DateTime.MinValue;
            bool IsDeleted = false;

            bool IsFound = clsPersonData.GetPersonByEmail(ref PersonID, ref FirstName, ref LastName, ref MiddleName, Email , ref Phone, ref Address, ref DateOfBirth, ref Gender, ref ImagePath, ref CreationDate, ref ModificationDate, ref IsDeleted);

            if(IsFound)
                return new clsPerson(PersonID, FirstName, LastName, MiddleName, Email , Phone, Address, DateOfBirth, Gender, ImagePath, CreationDate, ModificationDate, IsDeleted);
            else
                return null;
        }
        public static clsPerson FindByPhone(string Phone)
        {
            int PersonID = -1;
            string FirstName = "";
            string LastName = "";
            string MiddleName = "";
            string Email = "";
            string Address = "";
            DateTime DateOfBirth = DateTime.MinValue;
            byte Gender = 0;
            string ImagePath = "";
            DateTime CreationDate = DateTime.MinValue;
            DateTime ModificationDate = DateTime.MinValue;
            bool IsDeleted = false;

            bool IsFound = clsPersonData.GetPersonByPhone(ref PersonID, ref FirstName, ref LastName, ref MiddleName, ref Email, Phone , ref Address, ref DateOfBirth, ref Gender, ref ImagePath, ref CreationDate, ref ModificationDate, ref IsDeleted);

            if(IsFound)
                return new clsPerson(PersonID, FirstName, LastName, MiddleName, Email, Phone , Address, DateOfBirth, Gender, ImagePath, CreationDate, ModificationDate, IsDeleted);
            else
                return null;
        }
        public static clsPerson FindByAddress(string Address)
        {
            int PersonID = -1;
            string FirstName = "";
            string LastName = "";
            string MiddleName = "";
            string Email = "";
            string Phone = "";
            DateTime DateOfBirth = DateTime.MinValue;
            byte Gender = 0;
            string ImagePath = "";
            DateTime CreationDate = DateTime.MinValue;
            DateTime ModificationDate = DateTime.MinValue;
            bool IsDeleted = false;

            bool IsFound = clsPersonData.GetPersonByAddress(ref PersonID, ref FirstName, ref LastName, ref MiddleName, ref Email, ref Phone, Address , ref DateOfBirth, ref Gender, ref ImagePath, ref CreationDate, ref ModificationDate, ref IsDeleted);

            if(IsFound)
                return new clsPerson(PersonID, FirstName, LastName, MiddleName, Email, Phone, Address , DateOfBirth, Gender, ImagePath, CreationDate, ModificationDate, IsDeleted);
            else
                return null;
        }
        public static clsPerson FindByDateOfBirth(DateTime DateOfBirth)
        {
            int PersonID = -1;
            string FirstName = "";
            string LastName = "";
            string MiddleName = "";
            string Email = "";
            string Phone = "";
            string Address = "";
            byte Gender = 0;
            string ImagePath = "";
            DateTime CreationDate = DateTime.MinValue;
            DateTime ModificationDate = DateTime.MinValue;
            bool IsDeleted = false;

            bool IsFound = clsPersonData.GetPersonByDateOfBirth(ref PersonID, ref FirstName, ref LastName, ref MiddleName, ref Email, ref Phone, ref Address, DateOfBirth , ref Gender, ref ImagePath, ref CreationDate, ref ModificationDate, ref IsDeleted);

            if(IsFound)
                return new clsPerson(PersonID, FirstName, LastName, MiddleName, Email, Phone, Address, DateOfBirth , Gender, ImagePath, CreationDate, ModificationDate, IsDeleted);
            else
                return null;
        }
        public static clsPerson FindByGender(byte Gender)
        {
            int PersonID = -1;
            string FirstName = "";
            string LastName = "";
            string MiddleName = "";
            string Email = "";
            string Phone = "";
            string Address = "";
            DateTime DateOfBirth = DateTime.MinValue;
            string ImagePath = "";
            DateTime CreationDate = DateTime.MinValue;
            DateTime ModificationDate = DateTime.MinValue;
            bool IsDeleted = false;

            bool IsFound = clsPersonData.GetPersonByGender(ref PersonID, ref FirstName, ref LastName, ref MiddleName, ref Email, ref Phone, ref Address, ref DateOfBirth, Gender , ref ImagePath, ref CreationDate, ref ModificationDate, ref IsDeleted);

            if(IsFound)
                return new clsPerson(PersonID, FirstName, LastName, MiddleName, Email, Phone, Address, DateOfBirth, Gender , ImagePath, CreationDate, ModificationDate, IsDeleted);
            else
                return null;
        }
        public static clsPerson FindByImagePath(string ImagePath)
        {
            int PersonID = -1;
            string FirstName = "";
            string LastName = "";
            string MiddleName = "";
            string Email = "";
            string Phone = "";
            string Address = "";
            DateTime DateOfBirth = DateTime.MinValue;
            byte Gender = 0;
            DateTime CreationDate = DateTime.MinValue;
            DateTime ModificationDate = DateTime.MinValue;
            bool IsDeleted = false;

            bool IsFound = clsPersonData.GetPersonByImagePath(ref PersonID, ref FirstName, ref LastName, ref MiddleName, ref Email, ref Phone, ref Address, ref DateOfBirth, ref Gender, ImagePath , ref CreationDate, ref ModificationDate, ref IsDeleted);

            if(IsFound)
                return new clsPerson(PersonID, FirstName, LastName, MiddleName, Email, Phone, Address, DateOfBirth, Gender, ImagePath , CreationDate, ModificationDate, IsDeleted);
            else
                return null;
        }
        public static clsPerson FindByCreationDate(DateTime CreationDate)
        {
            int PersonID = -1;
            string FirstName = "";
            string LastName = "";
            string MiddleName = "";
            string Email = "";
            string Phone = "";
            string Address = "";
            DateTime DateOfBirth = DateTime.MinValue;
            byte Gender = 0;
            string ImagePath = "";
            DateTime ModificationDate = DateTime.MinValue;
            bool IsDeleted = false;

            bool IsFound = clsPersonData.GetPersonByCreationDate(ref PersonID, ref FirstName, ref LastName, ref MiddleName, ref Email, ref Phone, ref Address, ref DateOfBirth, ref Gender, ref ImagePath, CreationDate , ref ModificationDate, ref IsDeleted);

            if(IsFound)
                return new clsPerson(PersonID, FirstName, LastName, MiddleName, Email, Phone, Address, DateOfBirth, Gender, ImagePath, CreationDate , ModificationDate, IsDeleted);
            else
                return null;
        }
        public static clsPerson FindByModificationDate(DateTime ModificationDate)
        {
            int PersonID = -1;
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
            bool IsDeleted = false;

            bool IsFound = clsPersonData.GetPersonByModificationDate(ref PersonID, ref FirstName, ref LastName, ref MiddleName, ref Email, ref Phone, ref Address, ref DateOfBirth, ref Gender, ref ImagePath, ref CreationDate, ModificationDate , ref IsDeleted);

            if(IsFound)
                return new clsPerson(PersonID, FirstName, LastName, MiddleName, Email, Phone, Address, DateOfBirth, Gender, ImagePath, CreationDate, ModificationDate , IsDeleted);
            else
                return null;
        }
        public static clsPerson FindByIsDeleted(bool IsDeleted)
        {
            int PersonID = -1;
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

            bool IsFound = clsPersonData.GetPersonByIsDeleted(ref PersonID, ref FirstName, ref LastName, ref MiddleName, ref Email, ref Phone, ref Address, ref DateOfBirth, ref Gender, ref ImagePath, ref CreationDate, ref ModificationDate, IsDeleted );

            if(IsFound)
                return new clsPerson(PersonID, FirstName, LastName, MiddleName, Email, Phone, Address, DateOfBirth, Gender, ImagePath, CreationDate, ModificationDate, IsDeleted );
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
                        this.CreationDate = DateTime.Now;
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
