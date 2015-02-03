using StudentManager.BusinessLayer;
using StudentManager.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentManager
{
    public partial class EditStudent : System.Web.UI.Page
    {
        //object of Student to store the record
        static Student stud = null;
        static List<string> stateKeys = new List<string>();
        static List<string> streamKeys = new List<string>();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //checking whether there is any querystring or not
                if (Request.QueryString.Count == 0)
                {
                    //Redirecting to AllStudents page to select a student to update
                    Response.Redirect("AllStudents.aspx");
                }

                AddStreams();   //to add streams to the respective listBox
                AddStates();    //to add states to the respective listBox

                //extracting the student ID from query string
                string queryData = Request.QueryString["StudID"];
                int studID = Convert.ToInt32(queryData);

                //getting the Student record from the database
                stud = StudentDataHandler.FindStudent(studID);

                //filling up the controls with the old data
                txtFullName.Text = stud.FullName;
                txtFathersName.Text = stud.FathersName;
                txtRollNo.Text = stud.RollNo.ToString();
                txtAge.Text = stud.Age.ToString();
                listStream.SelectedValue = stud.Stream.ToString();
                string address = txtAddress.Text = stud.Address;
                listState.SelectedValue = stud.State.ToString();
            }
        }

        /// <summary>
        /// Method to update the cache
        /// </summary>
        public void UpdateCache()
        {
            //adding streams to the cache
            var streams = new UtilityFunctions().GetAllStreams();
            streamKeys.Clear();

            foreach (var stream in streams)
            {
                streamKeys.Add("Stream" + stream.Key.ToString());
                System.Web.HttpContext.Current.Cache.Insert("Stream" + stream.Key.ToString(), stream.Value);
            }
            //adding states to the cache
            var states = UtilityFunctions.GetAllStates();
            stateKeys.Clear();

            foreach (var state in states)
            {
                stateKeys.Add("State" + state.Key.ToString());
                System.Web.HttpContext.Current.Cache.Insert("State" + state.Key.ToString(), state.Value);
            }
        }

        /// <summary>
        /// MEthod to retreive Streams from cache
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, string> GetStreamsFromCache()
        {
            Dictionary<int, string> listStreams = new Dictionary<int, string>();
            foreach (string key in streamKeys)
            {
                //getting the streams by key
                string streamName = System.Web.HttpContext.Current.Cache.Get(key).ToString();
                int streamID = Convert.ToInt32(key.Substring(6));
                if (streamName == null)
                    return null;
                //adding the stream to Dictionary object
                listStreams.Add(streamID, streamName);
            }
            return listStreams;
        }

        /// <summary>
        /// MEthod to retreive States from cache
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, string> GetStatesFromCache()
        {
            Dictionary<int, string> listStates = new Dictionary<int, string>();
            foreach (string key in stateKeys)
            {
                //getting the streams by key
                string stateName = System.Web.HttpContext.Current.Cache.Get(key).ToString();
                int stateID = Convert.ToInt32(key.Substring(5));
                if (stateName == null)
                    return null;
                //adding the stream to Dictionary object
                listStates.Add(stateID, stateName);
            }
            return listStates;
        }

        /// <summary>
        /// Method to add States in State ListBox
        /// </summary>
        protected void AddStates()
        {
            //clearing all the previous items from the list
            listState.Items.Clear();
            listState.Items.Add("Select state");

            try
            {
                if (this.GetStatesFromCache() == null || this.GetStatesFromCache().Count == 0)
                    UpdateCache();
            }
            catch (Exception ex)
            {
                UpdateCache();
            }
            //getting all the streams from the database
            Dictionary<int, string> list = this.GetStatesFromCache();

            //extracting keys
            int[] keys = list.Keys.ToArray();

            for (int i = 0; i < keys.Length; i++)
            {
                ListItem item = new ListItem();
                item.Text = list[keys[i]];
                item.Value = keys[i].ToString();
                listState.Items.Add(item); //adding all the items one-by-one to the listbox
            }
        }

        /// <summary>
        /// Method to add Streams in ListBox
        /// </summary>
        protected void AddStreams()
        {
            //clearing all the previous items from the list
            listStream.Items.Clear();
            listStream.Items.Add("Select stream");


            try
            {
                if (this.GetStreamsFromCache() == null || this.GetStreamsFromCache().Count == 0)
                    UpdateCache();
            }
            catch (Exception ex)
            {
                UpdateCache();
            }
            //getting all the streams from the database
            Dictionary<int, string> list = this.GetStreamsFromCache();
            

            //extracting keys
            int[] keys = list.Keys.ToArray();

            for (int i = 0; i < keys.Length; i++)
            {
                ListItem item = new ListItem();
                item.Text = list[keys[i]];
                item.Value = keys[i].ToString();
                listStream.Items.Add(item);  //adding all the items one-by-one to the listbox
            }
        }


        /// <summary>
        /// Method to validate whether any state is selected by Student or not
        /// </summary>
        /// <param name="source">Control attribute on which this event has occured</param>
        /// <param name="args">Event Args for the control</param>
        protected void stateValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //checking the index selected
            if (listState.SelectedIndex > 0)
            {
                //the valid option selected
                args.IsValid = true;
            }
            else
            {
                //option selected is not vaid
                args.IsValid = false;
            }
        }

        /// <summary>
        /// CLick Event Handler for btnUpdate button to update record of a student
        /// </summary>
        /// <param name="source">Control attribute on which this event has occured</param>
        /// <param name="args">Event Args for the control</param>
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //getting the newly entered data for student
            string fullname = txtFullName.Text;
            string fathersName = txtFathersName.Text;
            int rollNo = Convert.ToInt32(txtRollNo.Text);
            int age = Convert.ToInt16(txtAge.Text);
            int stream = Convert.ToInt32(listStream.SelectedValue);
            string address = txtAddress.Text;
            int state = Convert.ToInt32(listState.SelectedValue);

            //updating the Student object
            stud.FullName = fullname;
            stud.FathersName = fathersName;
            stud.RollNo = rollNo;
            stud.Age = age;
            stud.Stream = stream;
            stud.Address = address;
            stud.State = state;

            //calling the update method
            bool result = StudentDataHandler.UpdateStudent(stud);
            if (result)
            {
                // if result gets updated
                Response.Write(Messages.RecordUpdateSuccess);
            }
            else
            {
                //if updation gets failed.
                Response.Write(Messages.RecordUpdateFailed);
            }
        }
    }
}