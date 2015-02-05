using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;
using XPathNXSLT.BusinessLayer;

namespace XPathNXSLT.DataLayer
{
    /// <summary>
    /// Class to handle operations with XML and XSLT file
    /// </summary>
    public class UtilityFunctions
    {
        /// <summary>
        /// Method to add college node where Stream is PCM
        /// </summary>
        /// <param name="xmlFile">Path to the xml file</param>
        /// <returns>status for the operation</returns>
        public static bool AddCollegeNode(string xmlFile)
        {
            bool result = false;
            //Create XmlDocument object
            XmlDocument doc = new XmlDocument();

            //Load the XMl file
            doc.Load(xmlFile);

            //Get the root node
            XmlNode rootNode = doc.SelectSingleNode("Students");

            //Get the Training node
            XmlNodeList nodeStudents = doc.GetElementsByTagName("Student");

            foreach (XmlNode student in nodeStudents)
            {
                XmlNode node = student.SelectSingleNode("Stream");
                if (node.InnerText.Equals("PCM"))
                {

                    //Create new node College and append it
                    XmlNode nodeCollege = doc.CreateElement("College");
                    nodeCollege.InnerText = "Engineering";
                    student.AppendChild(nodeCollege);

                    //Save the XML into the file
                    doc.Save(xmlFile);

                }
            }
            result = true;
            return result;
        }

        /// <summary>
        /// Method to display all students from an XML file
        /// </summary>
        /// <param name="xslFile">Path to XSLT file</param>
        /// <param name="xmlFile">Path to XML file</param>
        /// <returns>List of students</returns>
        public static List<Student> ShowStudents(string xslFile, string xmlFile)
        {
            List<Student> students = new List<Student>();

            //Create XmlDocumentand XPathNavigator objects
            XPathDocument doc = new XPathDocument(xmlFile);
            XPathNavigator navigator = doc.CreateNavigator();

            //move to root and get all child nodes
            navigator.MoveToChild("Students", "");
            XPathNodeIterator listStudents = navigator.SelectChildren(XPathNodeType.All);

            //Store info about Student into the list
            foreach (XPathNavigator student in listStudents)
            {
                string name = student.GetAttribute("name", "");
                string age = student.GetAttribute("age", "");
                student.MoveToChild("Stream", "");
                string stream = student.Value;
                student.MoveToParent();
                student.MoveToChild("Address", "");
                string address = student.Value;

                int ageInt;
                int.TryParse(age, out ageInt);

                students.Add(new Student(name, ageInt, stream, address));
            }

            return students;
        }

        /// <summary>
        /// Method to transform XML to HTML file
        /// </summary>
        /// <param name="xslFile">Path to XSLT file</param>
        /// <param name="xmlFile">Path to XML file</param>
        /// <param name="resultFile">Path to HTML file</param>
        /// <returns>Status of the operation</returns>
        public static bool TransformXSL(string xslFile, string xmlFile, string resultFile)
        {
            bool result = true;
            try
            {
                //create XPAth object and Tranform object
                XPathDocument myXPathDoc = new XPathDocument(xmlFile);
                XslCompiledTransform myXslTrans = new XslCompiledTransform();
                myXslTrans.Load(xslFile);

                //load the writer and transform the xml to result HTML file
                XmlTextWriter myWriter = new XmlTextWriter(resultFile, null);
                myXslTrans.Transform(myXPathDoc, null, myWriter);
                myWriter.Close();
                result = true;
            }
            catch (Exception)
            {
                //if any exception found
                result = false;
            }
            return result;
        }
    }
}