using System;
using System.Xml;
using XMLAssignment.BusinessLayer;

namespace XMLAssignment
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            linkToXMLFile.NavigateUrl = "file:///C:/Test/data.xml";
            linkToXMLFile.Enabled = true;
        }

        /// <summary>
        /// Event Handler for btnAddXML button to create a new XML file
        /// </summary>
        /// <param name="sender">Object on which event has occured</param>
        /// <param name="e">Args for event</param>
        protected void btnAddXML_Click(object sender, EventArgs e)
        {
            //create a Xmlwriter object
            XmlWriter writer = XmlWriter.Create(Strings.FilePath);

            //Start writing the document
            writer.WriteStartDocument();

            //Write first node i.e. iCalibrator
            writer.WriteStartElement("iCalibrator");

            //Write new node
            writer.WriteStartElement("Training");
            //Set attribute for the node
            writer.WriteAttributeString("day", 1.ToString());

            //Add Chapter nodes
            writer.WriteElementString("Chapter", "XML-1");
            writer.WriteElementString("Chapter", "XML-2");

            //End of Training node
            writer.WriteEndElement();

            //End of  iCalibrator node
            writer.WriteEndElement();

            //End of writing documnets
            writer.WriteEndDocument();

            //Close the XmlWriter
            writer.Close();

        }
    }
}