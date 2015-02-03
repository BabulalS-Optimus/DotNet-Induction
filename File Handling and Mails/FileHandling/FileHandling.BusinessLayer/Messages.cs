using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileHandling.BusinessLayer
{
    public class Messages
    {
        /// <summary>
        /// Constant strings to be used in the project for displaying some messages
        /// </summary>
        /// 
        #region ConstStrings
        public const string DirCreationSuccess = "Directory created successfully.";
        public const string DirCreationFailed = "Directory creation failed.";
        public const string FileCreationSuccess = "Files created successfully.";
        public const string FileCreationFailed = "File creation failed.";
        public const string FileReadOnlySuccess = "Files Read Only access set successfully.";
        public const string FileReadOnlyFailed = "File Access right not set.";
        public const string ContentCopySuccess = "File contents copied successfully.";
        public const string ContentCopyFailed = "File contents are not copied.";
        public const string CompressSuccess = "File is compressed successfully.";
        public const string CompressFailed = "File compression failed.";
        public const string NoContentFoundInFile = "No contents found in the binary file.";
        #endregion

    }
}