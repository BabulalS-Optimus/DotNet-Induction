using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SendingMails.BusinessLayer
{
    public class Messages
    {
        /// <summary>
        /// Messages for displaying
        /// </summary>
        #region MessageStrings
        public const string NoFolderPathFound = "No folder path found.";
        public const string DirNotFound = "No such directory found.";
        public const string SendMailFailed = "Sending mail failed.";
        public const string SendMailSuccess = "Mail sent successfully.";
        public const string EmailID = "babulal.swami@optimusinfo.com";
        public const string Password = "uzu4c7mymag";
        public const string FileSizeLess = "Size less than 100 bytes.";
        public const string NoFilesDeleted = "No files deleted.";
        #endregion
    }
}