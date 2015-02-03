using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentManager.DataLayer;
using StudentManager.BusinessLayer;

namespace StudentManager
{
    public partial class AddNewStudent : System.Web.UI.Page
    {
        static List<string> stateKeys = new List<string>();
        static List<string> streamKeys = new List<string>();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AddStreams();
                AddStates();
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
                if (this.GetStreamsFromCache() == null)
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
        /// Event Handler for click event on btnAdd which adds a new student in database
        /// </summary>
        /// <param name="sender">Control on which event occured</param>
        /// <param name="e">Args for event occured</param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //getting the entered information 
            string fullname = txtFullName.Text;
            string fathersName = txtFathersName.Text;
            int rollNo = Convert.ToInt32(txtRollNo.Text);
            int age = Convert.ToInt16(txtAge.Text);
            int stream = Convert.ToInt32(listStream.SelectedValue);
            string address = txtAddress.Text;
            int state = Convert.ToInt32(listState.SelectedValue);

            //calling AddStudent() method to add the record to database
            StudentDataHandler studHandler = new StudentDataHandler();
            bool result = studHandler.AddStudent(fullname, fathersName, rollNo, age, stream, address, state);
            if (result)
            {
                //if record gets added
                Response.Write(Messages.RecordAddSuccess);
                resetControls();  //resetting the controls for new student
            }
            else
            {
                //if record adding failed.
                Response.Write(Messages.RecordAddFailed);
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
        /// Method to reset the controls
        /// </summary>
        protected void resetControls()
        {
            txtFullName.Text = txtFathersName.Text = txtRollNo.Text = txtAge.Text = txtAddress.Text = "";
            listStream.SelectedIndex = 0;
            listState.SelectedIndex = 0;
        }
    }
}