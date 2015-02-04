using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.XPath;

namespace XMLAssignment.DataLayer
{
    /// <summary>
    /// Class to handle variuos operations on XML file
    /// </summary>
    public class XmlDataHandler
    {
        /// <summary>
        /// Method to add a new node in using AppendChild()
        /// </summary>
        /// <param name="filePath">Path for the xml file</param>
        /// <returns>Status of the operation</returns>
        public static bool AddNewNode(string filePath)
        {
            bool result = false;
            //Create XmlDocument object
            XmlDocument doc = new XmlDocument();

            //Load the XMl file
            doc.Load(filePath);

            //Get the root node
            XmlNode rootNode = doc.SelectSingleNode("iCalibrator");

            //Create new node as Assignment
            XmlNode nodeAssign = doc.CreateElement("Assignment");

            //Set the attribute
            XmlAttribute nodeAttrib = doc.CreateAttribute("Submitted");
            nodeAttrib.Value = "Y";

            //append the attribute to the new node
            nodeAssign.Attributes.Append(nodeAttrib);

            //create a child node for new node number with inner text as 1
            XmlNode numberNode = doc.CreateElement("number");
            numberNode.InnerText = "1";

            //Append new node to Assignment node
            nodeAssign.AppendChild(numberNode);

            //Append the node to Assignment node
            rootNode.AppendChild(nodeAssign);

            //Save the XML into the file
            doc.Save(filePath);

            //set result to true
            result = true;
            //return the result
            return result;

        }

        /// <summary>
        /// Method to get the first child from the root node
        /// </summary>
        /// <param name="filePath">Path for the xml file</param>
        /// <returns>Name of the first child</returns>
        public static string GetFirstChild(string filePath)
        {
            string child = null;
            //Create XmlDocumentand XPathNavigator objects
            XPathDocument doc = new XPathDocument(filePath);
            XPathNavigator navigator = doc.CreateNavigator();

            //move to first child of root
            if (navigator.MoveToChild("iCalibrator", ""))
            {
                if (navigator.MoveToFirstChild())
                {
                    child = navigator.LocalName;
                }
            }

            //return the result
            return child;
        }

        /// <summary>
        /// Method to add a new node in using InsertBefore()
        /// </summary>
        /// <param name="filePath">Path for the xml file</param>
        /// <returns>Status of the operation</returns>
        public static bool InsertBefore(string filePath)
        {
            bool result = false;
            //Create XmlDocument object
            XmlDocument doc = new XmlDocument();

            //Load the XMl file
            doc.Load(filePath);

            //Get the root node
            XmlNode rootNode = doc.SelectSingleNode("iCalibrator");

            //Get the Training node
            XmlNode nodeTraining = doc.GetElementsByTagName("Training")[0];

            if (nodeTraining == null)
            {
                return false;
            }
            else
            {
                //Create new node as Testing
                XmlNode nodeAssign = doc.CreateElement("Testing");

                //Append the Testing node before Training node
                rootNode = rootNode.InsertBefore(nodeAssign, nodeTraining);

                //Save the XML into the file
                doc.Save(filePath);

                //set and return result to true
                result = true;
            }
            return result;
        }

        /// <summary>
        /// Method to add a new node in using InsertBefore()
        /// </summary>
        /// <param name="filePath">Path for the xml file</param>
        /// <returns>Status of the operation</returns>
        public static bool RemoveNode(string filePath)
        {
            bool result = false;

            //Create XmlDocument object
            XmlDocument doc = new XmlDocument();

            //Load the XMl file
            doc.Load(filePath);

            //Get the root node and Assignment node
            XmlNode rootNode = doc.SelectSingleNode("iCalibrator");
            XmlNode nodeAssignment = doc.GetElementsByTagName("Assignment")[0];

            if (nodeAssignment == null)
            {
                result = false;
            }
            else
            {
                //remove node and save the xml
                rootNode = rootNode.RemoveChild(nodeAssignment);
                doc.Save(filePath);
                result = true;
            }
            return result;
        }

        /// <summary>
        /// Method to find children in root node
        /// </summary>
        /// <param name="filePath">Path for the xml file</param>
        /// <returns>Status of the operation</returns>
        public static string ChildNode(string filePath)
        {
            string childnodes = "";

            //Create XmlDocumentand XPathNavigator objects
            XPathDocument doc = new XPathDocument(filePath);
            XPathNavigator navigator = doc.CreateNavigator();

            //move to root and get all child nodes
            navigator.MoveToChild("iCalibrator", "");
            XPathNodeIterator listChildNodes = navigator.SelectChildren(XPathNodeType.All);

            //get LoaclName of child nodes
            foreach (XPathNavigator child in listChildNodes)
            {
                childnodes = string.Format("{0} , {1} ", childnodes, child.LocalName);
            }

            return childnodes;
        }

        /// <summary>
        /// Method to count children in root node
        /// </summary>
        /// <param name="filePath">Path for the xml file</param>
        /// <returns>Status of the operation</returns>
        public static int TotalNodes(string filePath)
        {
            int childnodes = 0;

            //Create XmlDocumentand XPathNavigator objects
            XPathDocument doc = new XPathDocument(filePath);
            XPathNavigator navigator = doc.CreateNavigator();

            //move to root and get all child nodes
            navigator.MoveToChild("iCalibrator", "");
            XPathNodeIterator listChildNodes = navigator.SelectChildren(XPathNodeType.All);
            childnodes = listChildNodes.Count;

            return childnodes;
        }

        /// <summary>
        /// Method to replace a node
        /// </summary>
        /// <param name="filePath">Path for the xml file</param>
        /// <returns>Status of the operation</returns>
        public static bool ReplaceNode(string filePath)
        {
            bool result = false;

            //Create XmlDocument object
            XmlDocument doc = new XmlDocument();

            //Load the XMl file
            doc.Load(filePath);

            //Get the root node and Assignment node
            XmlNode rootNode = doc.SelectSingleNode("iCalibrator");
            XmlNode nodeTestingOld = doc.GetElementsByTagName("Testing")[0];

            if (nodeTestingOld == null)
            {
                result = false;
            }
            else
            {
                //Create new node as Testing Over
                XmlNode nodeTestingNew = doc.CreateElement("TestingOver");

                //Append the Testing node before Training node
                rootNode = rootNode.ReplaceChild(nodeTestingNew, nodeTestingOld);

                //Save the XML into the file
                doc.Save(filePath);

                result = true;
            }
            return result;
        }

        /// <summary>
        /// Method to get student names having MCA brach
        /// </summary>
        /// <param name="filePath">Path for the xml file</param>
        /// <returns>Names of the students</returns>
        public static string GetMCAStudents(string filePath)
        {
            string names = "";

            XmlDocument doc = new XmlDocument();

            //Load the XMl file
            doc.Load(filePath);

            //Get the root node and Assignment node
            XmlNodeList listStudents = doc.GetElementsByTagName("fullname");
            XmlNodeList listbraches = doc.GetElementsByTagName("branch");

            //Find MCA students
            for (int i = 0; i < listbraches.Count; i++)
            {
                if (listbraches[i].InnerText.Contains("MCA"))
                {
                    names = string.Format("{0} , {1}", names, listStudents[i].InnerText);
                }
            }

            return names;
        }

        /// <summary>
        /// Method to get student names having D grade
        /// </summary>
        /// <param name="filePath">Path for the xml file</param>
        /// <returns>Names of the students</returns>
        public static string GetDGradeStudents(string filePath)
        {
            string names = "";

            XmlDocument doc = new XmlDocument();

            //Load the XMl file
            doc.Load(filePath);

            //Get the root node and Assignment node
            XmlNodeList listStudents = doc.GetElementsByTagName("fullname");
            XmlNodeList listgrades = doc.GetElementsByTagName("grade");

            //Find MCA students
            for (int i = 0; i < listgrades.Count; i++)
            {
                if (listgrades[i].InnerText.Contains("D"))
                {
                    names = string.Format("{0} , {1}", names, listStudents[i].InnerText);
                }
            }

            return names;
        }

        public static bool LoadStudentsFromXMLFile(string fileName)
        {
            bool result = false;

            if (!File.Exists(fileName))
            {
                return false;
            }

            List<Student> listStudents = new List<Student>();

            XmlDocument doc = new XmlDocument();

            //Load the XMl file
            doc.Load(fileName);

            int count = doc.GetElementsByTagName("student").Count;

            for (int i = 0; i < count; i++)
            {
                //Get the record details 
                string fullname = doc.GetElementsByTagName("fullname")[i].InnerText;
                string fathersName = doc.GetElementsByTagName("fathersname")[i].InnerText;
                string rollNo = doc.GetElementsByTagName("rollnumber")[i].InnerText;
                string age = doc.GetElementsByTagName("age")[i].InnerText;
                string branch = doc.GetElementsByTagName("branch")[i].InnerText;
                string address = doc.GetElementsByTagName("address")[i].InnerText;
                string state = doc.GetElementsByTagName("state")[i].InnerText;

                int rollInt;
                int.TryParse(rollNo, out rollInt);

                int ageInt;
                int.TryParse(age, out ageInt);

                //create student object and save it in List
                listStudents.Add(new Student(fullname, fathersName, rollInt, ageInt, branch, address, state));
            }


            //call InsertStudents() method to save into database
            Student.InsertStudents(listStudents);
            result = true;

            return result;
        }
    }
}