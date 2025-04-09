using System;
using System.Data;
using LibraryManagementSystem_DataAccess;

namespace LibraryManagementSystem_Business
{
    public class clsCategory
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int CategoryID { set; get; }
        public string CategoryName { set; get; }
        public int ParentCategory { set; get; }

        public clsCategory()
        {
            this.CategoryID = -1;
            this.CategoryName = "";
            this.ParentCategory = -1;
            Mode = enMode.AddNew;
        }
        private clsCategory(int CategoryID, string CategoryName, int ParentCategory)
        {
            this.CategoryID = CategoryID;
            this.CategoryName = CategoryName;
            this.ParentCategory = ParentCategory;
            Mode = enMode.Update;
        }
        private bool _AddNewCategory()
        {
            this.CategoryID = (int)clsCategoryData.AddNewCategory(this.CategoryName, this.ParentCategory);
            return (this.CategoryID != -1);
        }
        private bool _UpdateCategory()
        {
            return clsCategoryData.UpdateCategory(this.CategoryID, this.CategoryName, this.ParentCategory);
        }
        public static bool DeleteCategory(int CategoryID)
        {
            return clsCategoryData.DeleteCategory(CategoryID);
        }
        public static bool IsCategoryExist(int CategoryID)
        {
            return clsCategoryData.IsCategoryExist(CategoryID);
        }
        public static clsCategory Find(int CategoryID)
        {
            string CategoryName = "";
            int ParentCategory = -1;

            bool IsFound = clsCategoryData.GetCategoryByID(CategoryID, ref CategoryName, ref ParentCategory);

            if(IsFound)
                return new clsCategory(CategoryID, CategoryName, ParentCategory);
            else
                return null;
        }
        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    if(_AddNewCategory())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateCategory();
            }
            return false;
        }
        public static DataTable GetBookCategories()
        {
            return clsCategoryData.GetAllBookCategories();
        }
    }
}
