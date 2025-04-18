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
        public static bool IsPublisherExistByPublisherID(int PublisherID)
        {
            return clsPublisherData.IsPublisherExistByPublisherID(PublisherID);
        }
        public static bool IsPublisherExistByPublisherName(string PublisherName)
        {
            return clsPublisherData.IsPublisherExistByPublisherName(PublisherName);
        }
        public static bool IsPublisherExistByAddress(string Address)
        {
            return clsPublisherData.IsPublisherExistByAddress(Address);
        }
        public static bool IsPublisherExistByPhone(string Phone)
        {
            return clsPublisherData.IsPublisherExistByPhone(Phone);
        }
        public static bool IsPublisherExistByEmail(string Email)
        {
            return clsPublisherData.IsPublisherExistByEmail(Email);
        }
        public static bool IsPublisherExistByWebSite(string WebSite)
        {
            return clsPublisherData.IsPublisherExistByWebSite(WebSite);
        }
        public static clsPublisher FindByPublisherID(int PublisherID)
        {
            string PublisherName = "";
            string Address = "";
            string Phone = "";
            string Email = "";
            string WebSite = "";

            bool IsFound = clsPublisherData.GetPublisherByPublisherID(PublisherID , ref PublisherName, ref Address, ref Phone, ref Email, ref WebSite);

            if(IsFound)
                return new clsPublisher(PublisherID , PublisherName, Address, Phone, Email, WebSite);
            else
                return null;
        }
        public static clsPublisher FindByPublisherName(string PublisherName)
        {
            int PublisherID = -1;
            string Address = "";
            string Phone = "";
            string Email = "";
            string WebSite = "";

            bool IsFound = clsPublisherData.GetPublisherByPublisherName(ref PublisherID, PublisherName , ref Address, ref Phone, ref Email, ref WebSite);

            if(IsFound)
                return new clsPublisher(PublisherID, PublisherName , Address, Phone, Email, WebSite);
            else
                return null;
        }
        public static clsPublisher FindByAddress(string Address)
        {
            int PublisherID = -1;
            string PublisherName = "";
            string Phone = "";
            string Email = "";
            string WebSite = "";

            bool IsFound = clsPublisherData.GetPublisherByAddress(ref PublisherID, ref PublisherName, Address , ref Phone, ref Email, ref WebSite);

            if(IsFound)
                return new clsPublisher(PublisherID, PublisherName, Address , Phone, Email, WebSite);
            else
                return null;
        }
        public static clsPublisher FindByPhone(string Phone)
        {
            int PublisherID = -1;
            string PublisherName = "";
            string Address = "";
            string Email = "";
            string WebSite = "";

            bool IsFound = clsPublisherData.GetPublisherByPhone(ref PublisherID, ref PublisherName, ref Address, Phone , ref Email, ref WebSite);

            if(IsFound)
                return new clsPublisher(PublisherID, PublisherName, Address, Phone , Email, WebSite);
            else
                return null;
        }
        public static clsPublisher FindByEmail(string Email)
        {
            int PublisherID = -1;
            string PublisherName = "";
            string Address = "";
            string Phone = "";
            string WebSite = "";

            bool IsFound = clsPublisherData.GetPublisherByEmail(ref PublisherID, ref PublisherName, ref Address, ref Phone, Email , ref WebSite);

            if(IsFound)
                return new clsPublisher(PublisherID, PublisherName, Address, Phone, Email , WebSite);
            else
                return null;
        }
        public static clsPublisher FindByWebSite(string WebSite)
        {
            int PublisherID = -1;
            string PublisherName = "";
            string Address = "";
            string Phone = "";
            string Email = "";

            bool IsFound = clsPublisherData.GetPublisherByWebSite(ref PublisherID, ref PublisherName, ref Address, ref Phone, ref Email, WebSite );

            if(IsFound)
                return new clsPublisher(PublisherID, PublisherName, Address, Phone, Email, WebSite );
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
