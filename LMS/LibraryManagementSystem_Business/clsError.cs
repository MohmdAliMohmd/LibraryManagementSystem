using System;
using System.Data;
using LibraryManagementSystem_DataAccess;

namespace LibraryManagementSystem_Business
{
    public class clsError
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int ErrorID { set; get; }
        public string ErrorMessage { set; get; }
        public string StackTrace { set; get; }
        public DateTime Timestamp { set; get; }
        public string Severity { set; get; }
        public string AdditionalInfo { set; get; }

        public clsError()
        {
            this.ErrorID = -1;
            this.ErrorMessage = "";
            this.StackTrace = "";
            this.Timestamp = DateTime.MinValue;
            this.Severity = "";
            this.AdditionalInfo = "";
            Mode = enMode.AddNew;
        }
        private clsError(int ErrorID, string ErrorMessage, string StackTrace, DateTime Timestamp, string Severity, string AdditionalInfo)
        {
            this.ErrorID = ErrorID;
            this.ErrorMessage = ErrorMessage;
            this.StackTrace = StackTrace;
            this.Timestamp = Timestamp;
            this.Severity = Severity;
            this.AdditionalInfo = AdditionalInfo;
            Mode = enMode.Update;
        }
        private bool _AddNewError()
        {
            this.ErrorID = (int)clsErrorData.AddNewError(this.ErrorMessage, this.StackTrace, this.Timestamp, this.Severity, this.AdditionalInfo);
            return (this.ErrorID != -1);
        }
        private bool _UpdateError()
        {
            return clsErrorData.UpdateError(this.ErrorID, this.ErrorMessage, this.StackTrace, this.Timestamp, this.Severity, this.AdditionalInfo);
        }
        public static bool DeleteError(int ErrorID)
        {
            return clsErrorData.DeleteError(ErrorID);
        }
        public static bool IsErrorExistByErrorID(int ErrorID)
        {
            return clsErrorData.IsErrorExistByErrorID(ErrorID);
        }
        public static bool IsErrorExistByErrorMessage(string ErrorMessage)
        {
            return clsErrorData.IsErrorExistByErrorMessage(ErrorMessage);
        }
        public static bool IsErrorExistByStackTrace(string StackTrace)
        {
            return clsErrorData.IsErrorExistByStackTrace(StackTrace);
        }
        public static bool IsErrorExistByTimestamp(DateTime Timestamp)
        {
            return clsErrorData.IsErrorExistByTimestamp(Timestamp);
        }
        public static bool IsErrorExistBySeverity(string Severity)
        {
            return clsErrorData.IsErrorExistBySeverity(Severity);
        }
        public static bool IsErrorExistByAdditionalInfo(string AdditionalInfo)
        {
            return clsErrorData.IsErrorExistByAdditionalInfo(AdditionalInfo);
        }
        public static clsError FindByErrorID(int ErrorID)
        {
            string ErrorMessage = "";
            string StackTrace = "";
            DateTime Timestamp = DateTime.MinValue;
            string Severity = "";
            string AdditionalInfo = "";

            bool IsFound = clsErrorData.GetErrorByErrorID(ErrorID , ref ErrorMessage, ref StackTrace, ref Timestamp, ref Severity, ref AdditionalInfo);

            if(IsFound)
                return new clsError(ErrorID , ErrorMessage, StackTrace, Timestamp, Severity, AdditionalInfo);
            else
                return null;
        }
        public static clsError FindByErrorMessage(string ErrorMessage)
        {
            int ErrorID = -1;
            string StackTrace = "";
            DateTime Timestamp = DateTime.MinValue;
            string Severity = "";
            string AdditionalInfo = "";

            bool IsFound = clsErrorData.GetErrorByErrorMessage(ref ErrorID, ErrorMessage , ref StackTrace, ref Timestamp, ref Severity, ref AdditionalInfo);

            if(IsFound)
                return new clsError(ErrorID, ErrorMessage , StackTrace, Timestamp, Severity, AdditionalInfo);
            else
                return null;
        }
        public static clsError FindByStackTrace(string StackTrace)
        {
            int ErrorID = -1;
            string ErrorMessage = "";
            DateTime Timestamp = DateTime.MinValue;
            string Severity = "";
            string AdditionalInfo = "";

            bool IsFound = clsErrorData.GetErrorByStackTrace(ref ErrorID, ref ErrorMessage, StackTrace , ref Timestamp, ref Severity, ref AdditionalInfo);

            if(IsFound)
                return new clsError(ErrorID, ErrorMessage, StackTrace , Timestamp, Severity, AdditionalInfo);
            else
                return null;
        }
        public static clsError FindByTimestamp(DateTime Timestamp)
        {
            int ErrorID = -1;
            string ErrorMessage = "";
            string StackTrace = "";
            string Severity = "";
            string AdditionalInfo = "";

            bool IsFound = clsErrorData.GetErrorByTimestamp(ref ErrorID, ref ErrorMessage, ref StackTrace, Timestamp , ref Severity, ref AdditionalInfo);

            if(IsFound)
                return new clsError(ErrorID, ErrorMessage, StackTrace, Timestamp , Severity, AdditionalInfo);
            else
                return null;
        }
        public static clsError FindBySeverity(string Severity)
        {
            int ErrorID = -1;
            string ErrorMessage = "";
            string StackTrace = "";
            DateTime Timestamp = DateTime.MinValue;
            string AdditionalInfo = "";

            bool IsFound = clsErrorData.GetErrorBySeverity(ref ErrorID, ref ErrorMessage, ref StackTrace, ref Timestamp, Severity , ref AdditionalInfo);

            if(IsFound)
                return new clsError(ErrorID, ErrorMessage, StackTrace, Timestamp, Severity , AdditionalInfo);
            else
                return null;
        }
        public static clsError FindByAdditionalInfo(string AdditionalInfo)
        {
            int ErrorID = -1;
            string ErrorMessage = "";
            string StackTrace = "";
            DateTime Timestamp = DateTime.MinValue;
            string Severity = "";

            bool IsFound = clsErrorData.GetErrorByAdditionalInfo(ref ErrorID, ref ErrorMessage, ref StackTrace, ref Timestamp, ref Severity, AdditionalInfo );

            if(IsFound)
                return new clsError(ErrorID, ErrorMessage, StackTrace, Timestamp, Severity, AdditionalInfo );
            else
                return null;
        }
        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    if(_AddNewError())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateError();
            }
            return false;
        }
        public static DataTable GetErrorLog()
        {
            return clsErrorData.GetAllErrorLog();
        }
    }
}
