using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.BusinessLayer
{
    public class Messages
    {
        /// <summary>
        /// Constants to print the messages
        /// </summary>

        #region ConstStrings
        public const string ConnToDBFailed = "Cannot connect to Database Server";
        public const string RecordAddSuccess = "Record added successfully.";
        public const string RecordAddFailed = "Record adding failed.";
        public const string RecordUpdateSuccess = "Record updated sucessfully.";
        public const string RecordUpdateFailed = "Record updation failed.";
        public const string NoGridRowSelected = "No row is selected in Grid";
        public const string RecordDeletedSuccess = "Records deleted successfully";
        public const string RecordDeletedFailed = "Record deletion failed.";
        public const string CSVWriteSuccess = "Records added from CSV file to database.";
        public const string CSVWriteFailed = "Record addition from CSV file failed.";
        public const string NoFileFound = "No file found.";
        #endregion

    }
}
