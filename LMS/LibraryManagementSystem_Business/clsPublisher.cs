using System;
using System.Data;
using LibraryManagementSystem_DataAccess;

namespace LibraryManagementSystem_Business
{
    public class clsPublisher
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int PublisherID { set; get; }
        public string PublisherName { set; get; }
        public string Address { set; get; }
        public string Phone { set; get; }
        public string Email { set; get; }
        public string WebSite { set; get; }

        public clsPublisher()
        {
            this.PublisherID = -1;
            this.PublisherName = "";
            this.Address = "";
            this.Phone = "";
            this.Email = "";
            this.WebSite = "";
            Mode = enMode.AddNew;
        }
        private clsPublisher(int PublisherID, string PublisherName, string Address, string Phone, string Email, string WebSite)
        {
            this.PublisherID = PublisherID;
            this.PublisherName = PublisherName;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.WebSite = WebSite;
            Mode = enMode.Update;
        }
        private bool _AddNewPublisher()
        {
            this.PublisherID = (int)clsPublisherData.AddNewPublisher(this.PublisherName, this.Address, this.Phone, this.Email, this.WebSite);
            return (this.PublisherID != -1);
        }
        private bool _UpdatePublisher()
        {
            return clsPublisherData.UpdatePublisher(this.PublisherID, this.PublisherName, this.Address, this.Phone, this.Email, this.WebSite);
        }
        public static bool DeletePublisher(int PublisherID)
        {
            return clsPublisherData.DeletePublisher(PublisherID);
        }
        public static bool IsPublisherExist(int PublisherID)
        {
            return clsPublisherData.IsPublisherExist(PublisherID);
        }
        public static clsPublisher Find(int PublisherID)
        {
            string PublisherName = "";
            string Address = "";
            string Phone = "";
            string Email = "";
            string WebSite = "";

            bool IsFound = clsPublisherData.GetPublisherByID(PublisherID, ref PublisherName, ref Address, ref Phone, ref Email, ref WebSite);

            if(IsFound)
                return new clsPublisher(PublisherID, PublisherName, Address, Phone, Email, WebSite);
            else
                return null;
        }
        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    if(_AddNewPublisher())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdatePublisher();
            }
            return false;
        }
        public static DataTable GetPublishingHouses()
        {
            return clsPublisherData.GetAllPublishingHouses();
        }
    }
}
