using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XPathNXSLT.BusinessLayer
{
    /// <summary>
    /// Class holding variuos strings to display as messages
    /// </summary>
    public class Strings
    {
        #region Constant Strings
        public const string XmlFilePath = @"~/Data/iCalibrator.xml";
        public const string XsltFilePath = @"~/Data/iCalibrator.xslt";
        public const string ResultFilePath = @"~/Data/ResultPage.html";
        public const string AddCollegeNodeFailed = "New College node added.";
        public const string AddCollegeNodeSuccess = "New College node added.";
        public const string TransformFailed = "Cannot transform the file.";
        public const string DisplayFailed = "Cannot show the data.";
        #endregion

    }
}