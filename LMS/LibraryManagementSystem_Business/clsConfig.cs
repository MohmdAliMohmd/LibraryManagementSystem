using System;
using System.Data;
using LibraryManagementSystem_DataAccess;

namespace LibraryManagementSystem_Business
{
    public class clsConfig
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int ConfigID { set; get; }
        public string ConfigKey { set; get; }
        public double ConfigValue { set; get; }
        public DateTime LastUpdate { set; get; }

        public clsConfig()
        {
            this.ConfigID = -1;
            this.ConfigKey = "";
            this.ConfigValue = -1;
            this.LastUpdate = DateTime.MinValue;
            Mode = enMode.AddNew;
        }
        private clsConfig(int ConfigID, string ConfigKey, double ConfigValue, DateTime LastUpdate)
        {
            this.ConfigID = ConfigID;
            this.ConfigKey = ConfigKey;
            this.ConfigValue = ConfigValue;
            this.LastUpdate = LastUpdate;
            Mode = enMode.Update;
        }
        private bool _AddNewConfig()
        {
            this.ConfigID = (int)clsConfigData.AddNewConfig(this.ConfigKey, this.ConfigValue, this.LastUpdate);
            return (this.ConfigID != -1);
        }
        private bool _UpdateConfig()
        {
            return clsConfigData.UpdateConfig(this.ConfigID, this.ConfigKey, this.ConfigValue, this.LastUpdate);
        }
        public static bool DeleteConfig(int ConfigID)
        {
            return clsConfigData.DeleteConfig(ConfigID);
        }
        public static bool IsConfigExist(int ConfigID)
        {
            return clsConfigData.IsConfigExist(ConfigID);
        }
        public static clsConfig Find(int ConfigID)
        {
            string ConfigKey = "";
            double ConfigValue = -1;
            DateTime LastUpdate = DateTime.MinValue;

            bool IsFound = clsConfigData.GetConfigByID(ConfigID, ref ConfigKey, ref ConfigValue, ref LastUpdate);

            if(IsFound)
                return new clsConfig(ConfigID, ConfigKey, ConfigValue, LastUpdate);
            else
                return null;
        }
        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    if(_AddNewConfig())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateConfig();
            }
            return false;
        }
        public static DataTable GetConfigurations()
        {
            return clsConfigData.GetAllConfigurations();
        }
    }
}
