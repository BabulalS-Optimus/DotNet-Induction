using StudentManager.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentManager.BusinessLayer;
using System.Web.Caching;

namespace StudentManager
{
    public partial class DeleteStudent : System.Web.UI.Page
    {
        static List<string> stateKeys = new List<string>();
        static List<string> streamKeys = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if the page is loaded for the first time
                AddStreams();
            }
        }
     
        /// <summary>
        /// Method to update the cache
        /// </summary>
        public void UpdateCache()
        {
           
            var streams = new UtilityFunctions().GetAllStreams();
            streamKeys.Clear();

            foreach (var stream in streams)
            {
                streamKeys.Add("Stream" + stream.Key.ToString());
                System.Web.HttpContext.Current.Cache.Insert("Stream" + stream.Key.ToString(), stream.Value);
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
                string streamName = System.Web.HttpContext.Current.Cache.Get(key).ToString();
                int streamID = Convert.ToInt32(key.Substring(6));
                if (streamName == null)
                    return null;
                listStreams.Add(streamID, streamName);
            }
            return listStreams;
        }

        /// <summary>
        /// Method to add Streams in ListBox
        /// </summary>
        protected void AddStreams()
        {
            //clearing all the previous items from the list
            listStreams.Items.Clear();
            listStreams.Items.Add("All");

            if (this.GetStreamsFromCache() == null || this.GetStreamsFromCache().Count == 0)
                UpdateCache();

            //getting all the streams from the database
            Dictionary<int, string> list = this.GetStreamsFromCache();

            //extracting keys
            int[] keys = list.Keys.ToArray();

            for (int i = 0; i < keys.Length; i++)
            {
                ListItem item = new ListItem();
                item.Text = list[keys[i]];
                item.Value = keys[i].ToString();
                listStreams.Items.Add(item);  //adding all the items one-by-one to the listbox
            }
        }

        /// <summary>
        /// SelectedIndexChanged Event Handler for listStreams
        /// </summary>
        /// <param name="sender">lisStream object</param>
        /// <param name="e">Args for event</param>
        protected void listStreams_SelectedIndexChanged(object sender, EventArgs e)
        {
            //reading the data from database
            List<Student> students = StudentDataHandler.ListAllStudent();

            listStudLeft.Items.Clear();
            listStudRight.Items.Clear();

            if (listStreams.SelectedIndex == 0)   //if user selects 'All'
            {
                //adding rows to the DataTable
                foreach (Student item in students)
                {
                    listStudLeft.Items.Add(new ListItem(item.FullName, item.RollNo.ToString()));
                }
            }
            else  //if user selects a specific stream
            {
                //adding rows to the DataTable
                foreach (Student item in students)
                {
                    if (item.Stream == Convert.ToInt32(listStreams.SelectedValue))
                    {
                        listStudLeft.Items.Add(new ListItem(item.FullName, item.RollNo.ToString()));
                    }
                }
            }
        }

        /// <summary>
        /// Click event on MoveRight button to move selected items from Left list to Right list
        /// </summary>
        /// <param name="sender">btnMoveRight button object</param>
        /// <param name="e">Args for the event</param>
        protected void btnMoveRight_Click(object sender, EventArgs e)
        {
            //travesring all the items in the list
            for (int i = 0; i < listStudLeft.Items.Count; i++)
            {
                ListItem item = listStudLeft.Items[i];
                //checking if item is selected or not
                if (item.Selected)
                {
                    listStudRight.Items.Add(item);  //adding the item to Right list
                    listStudLeft.Items.Remove(item); //deleting the item from left list
                }
            }
        }


        /// <summary>
        /// Click event on MoveLeft button to move selected items from Right list to Left list
        /// </summary>
        /// <param name="sender">btnMoveLeft button object</param>
        /// <param name="e">Args for the event</param>
        protected void btnMoveLeft_Click(object sender, EventArgs e)
        {
            //traversing all the items in the list
            for (int i = 0; i < listStudRight.Items.Count; i++)
            {
                ListItem item = listStudRight.Items[i];
                //checking if item is selected or not
                if (item.Selected)
                {
                    listStudLeft.Items.Add(item);  //adding in left list
                    listStudRight.Items.Remove(item); //deleting item from Right list
                }
            }
        }

        /// <summary>
        /// Method to delete the student records
        /// </summary>
        /// <param name="rollNos">Concatenated string of roll numbers</param>
        [WebMethod]
        public static string DeleteStudents(string rollNos)
        {
            string result = Messages.RecordDeletedFailed;

            if (StudentDataHandler.DeleteStudent(rollNos))
            {
                result = Messages.RecordDeletedSuccess;
            }
            return result;
        }
    }
}