using System;
using XMLAssignment.BusinessLayer;
using XMLAssignment.DataLayer;

namespace XMLAssignment
{
    public partial class DisplayXML : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            linkToXMLFile.NavigateUrl = "file:///C:/Test/data.xml";
            linkToXMLFileStudent.NavigateUrl = "file:///C:/Test/Students.xml";
        }

        /// <summary>
        /// Event Handler for btnAddNode button to add a new node in XML file
        /// </summary>
        /// <param name="sender">Object on which event has occured</param>
        /// <param name="e">Args for event</param>
        protected void btnAddNode_Click(object sender, EventArgs e)
        {

            //Call AddNewNode() method to add new node
            bool result = XmlDataHandler.AddNewNode(Strings.FilePath);

            //Check the returned result
            if (result)
            {
                //if success
                txtResult.Text = Strings.NodeAddSuccess;
            }
            else
            {
                //if failure
                txtResult.Text = Strings.NodeAddSuccess;
            }
        }

        /// <summary>
        /// Event Handler for btnFirstChild button that displays first child in root node
        /// </summary>
        /// <param name="sender">Object on which event has occured</param>
        /// <param name="e">Args for event</param>
        protected void btnFirstChild_Click(object sender, EventArgs e)
        {

            // Call GetFirstChild() method of XmlDataHandler class 
            // to get first childof the root
            string result = XmlDataHandler.GetFirstChild(Strings.FilePath);

            // Check the result
            if (result == null)
            {
                // if null received
                txtResult.Text = Strings.NoChildNodeFound;
            }
            else
            {
                // if data received
                txtResult.Text = result;
            }

        }

        /// <summary>
        /// Event Handler for btnInsertBefore button 
        /// that adds a new node Testing before Training node
        /// </summary>
        /// <param name="sender">Object on which event has occured</param>
        /// <param name="e">Args for event</param>
        protected void btnInsertBefore_Click(object sender, EventArgs e)
        {
            //Call the InsertBefore() method to insert the node into the xml
            bool result = XmlDataHandler.InsertBefore(Strings.FilePath);

            //check the result
            if (result)
            {
                txtResult.Text = Strings.InsertBeforeSuccees;
            }
            else
            {
                txtResult.Text = Strings.InsertBeforeFailed;
            }
        }

        /// <summary>
        /// Event Handler for btnRemoveNode button 
        /// that removes Assignment node
        /// </summary>
        /// <param name="sender">Object on which event has occured</param>
        /// <param name="e">Args for event</param>
        protected void btnRemoveNode_Click(object sender, EventArgs e)
        {
            //Call the RemoveNode() method to remove the node
            bool result = XmlDataHandler.RemoveNode(Strings.FilePath);

            //check the result
            if (result)
            {
                txtResult.Text = Strings.RemoveNodeSuccess;
            }
            else
            {
                txtResult.Text = Strings.RemoveNodeFailed;
            }
        }

        /// <summary>
        /// Event Handler for btnChildNode button 
        /// that counts the number of child nodes in root
        /// </summary>
        /// <param name="sender">Object on which event has occured</param>
        /// <param name="e">Args for event</param>
        protected void btnChildNode_Click(object sender, EventArgs e)
        {
            //Call the ChildNode() method to count the child nodes
            string result = XmlDataHandler.ChildNode(Strings.FilePath);

            txtResult.Text = result.ToString();
        }

        /// <summary>
        /// Event Handler for btnTotalNodes button 
        /// that counts the number of child nodes in root
        /// </summary>
        /// <param name="sender">Object on which event has occured</param>
        /// <param name="e">Args for event</param>
        protected void btnTotalNodes_Click(object sender, EventArgs e)
        {
            //Call the TotalNodes() method to count the child nodes
            int result = XmlDataHandler.TotalNodes(Strings.FilePath);

            txtResult.Text = result.ToString();
        }

        /// <summary>
        /// Event Handler for btnReplaceNode button 
        /// that replaces Testing node with TestingOver
        /// </summary>
        /// <param name="sender">Object on which event has occured</param>
        /// <param name="e">Args for event</param>
        protected void btnReplaceNode_Click(object sender, EventArgs e)
        {
            //Call the RemoveNode() method to remove the node
            bool result = XmlDataHandler.ReplaceNode(Strings.FilePath);

            //check the result
            if (result)
            {
                txtResult.Text = Strings.ReplaceNodeSuccess;
            }
            else
            {
                txtResult.Text = Strings.ReplaceNodeFailed;
            }
        }

        /// <summary>
        /// Event Handler for btnGetMCAStudents button 
        /// that gets all MCA student names
        /// </summary>
        /// <param name="sender">Object on which event has occured</param>
        /// <param name="e">Args for event</param>
        protected void btnGetMCAStudents_Click(object sender, EventArgs e)
        {
            //Call the GetMCAStudents() method
            string names = XmlDataHandler.GetMCAStudents(Strings.StudentFilePath);

            txtResult.Text = names;
        }

        /// <summary>
        /// Event Handler for btnGetDGradeStudents button 
        /// that gets all D grade students
        /// </summary>
        /// <param name="sender">Object on which event has occured</param>
        /// <param name="e">Args for event</param>
        protected void btnGetDGradeStudents_Click(object sender, EventArgs e)
        {
            //Call the GetDGradeStudents() method
            string names = XmlDataHandler.GetDGradeStudents(Strings.StudentFilePath);

            txtResult.Text = names;
        }

        protected void btnLoadAndSaveXML_Click(object sender, EventArgs e)
        {
            if (fileUploadXML.HasFile)
            {
                //Call LoadStudentsFromXMLFile() method
                bool result = XmlDataHandler.LoadStudentsFromXMLFile(Strings.StudentFilePath);

                //check the result
                if (result)
                {
                    txtResult.Text = Strings.SaveStudentsSuccess;
                }
                else
                {
                    txtResult.Text = Strings.SaveStudentsFailed;
                }

            }
            else
            {
                txtResult.Text = Strings.NoFileFound;
            }
        }

    }
}