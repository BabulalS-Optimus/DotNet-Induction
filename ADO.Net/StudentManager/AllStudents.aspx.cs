using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentManager.DataLayer;
using System.Data;
using StudentManager.BusinessLayer;

namespace StudentManager
{
    public partial class AllStudetns : System.Web.UI.Page
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
        /// Method to add Streams in ListBox
        /// </summary>
        protected void AddStreams()
        {
            //clearing all the previous items from the list
            listStream.Items.Clear();
            listStream.Items.Add("All");


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
        /// SelctIndexChanged Event Handler for listStream to show the students from the selected stream
        /// </summary>
        /// <param name="sender">Control on which the event occured</param>
        /// <param name="e">Args for the event occured.</param>
        protected void listStream_SelectedIndexChanged(object sender, EventArgs e)
        {
            //creating a new DataTable for GridView
            DataTable studTable = new DataTable();
            //settign the columns for the table
            studTable.Columns.Add("StudID", typeof(int));
            studTable.Columns.Add("FullName", typeof(string));
            studTable.Columns.Add("FathersName", typeof(string));
            studTable.Columns.Add("RollNo", typeof(int));
            studTable.Columns.Add("Age", typeof(int));
            studTable.Columns.Add("Stream", typeof(string));
            studTable.Columns.Add("Address", typeof(string));
            studTable.Columns.Add("State", typeof(string));

            //reading the data from database
            List<Student> students = StudentDataHandler.ListAllStudent();


            if (listStream.SelectedIndex == 0)   //if user selects 'All'
            {
                //adding rows to the DataTable
                foreach (Student item in students)
                {
                    studTable.Rows.Add(
                        item.StudID,
                        item.FullName,
                        item.FathersName,
                        item.RollNo,
                        item.Age,
                        UtilityFunctions.GetStreamName(item.Stream),
                        item.Address,
                        UtilityFunctions.GetStateName(item.State)
                        );
                }
            }
            else  //if user selects a specific stream
            {
                //adding rows to the DataTable
                foreach (Student item in students)
                {
                    if (item.Stream == Convert.ToInt32(listStream.SelectedValue))
                    {
                        studTable.Rows.Add(
                            item.StudID,
                            item.FullName,
                            item.FathersName,
                            item.RollNo,
                            item.Age,
                            UtilityFunctions.GetStreamName(item.Stream),
                            item.Address,
                            UtilityFunctions.GetStateName(item.State)
                            );
                    }
                }
            }
            //setting up the DataSource for the GridView
            gridStudents.DataSource = studTable;
            gridStudents.DataBind();
        }

        /// <summary>
        /// Method to handle sorting of the grid view
        /// </summary>
        /// <param name="sender">Control for gridView on which the sorting is being performed</param>
        /// <param name="e">Sorting event arguments</param>
        protected void gridStudents_Sorting(object sender, GridViewSortEventArgs e)
        {

            //getting the DataTable from the GridView
            DataTable table = gridStudents.DataSource as DataTable;

            //if there is any table on the gridview
            if (table != null)
            {
                string newSortDirection;
                //setting up the new sorting order
                if (e.SortDirection.Equals("ASC"))
                {
                    newSortDirection = "DESC";
                }
                else
                {
                    newSortDirection = "ASC";
                }

                //creating the view for displaying
                DataView dataView = new DataView(table);
                //sorting the view 
                dataView.Sort = e.SortExpression + " " + newSortDirection;
                //showing the view on GridView
                gridStudents.DataSource = dataView;
                gridStudents.DataBind();
            }
        }

        /// <summary>
        /// Click event for btnEdit to redirect the page to update selected record
        /// </summary>
        /// <param name="sender">Control on which the event has occured</param>
        /// <param name="e">Click event arguments</param>
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            //finding the selected index of the GridView
            int index = gridStudents.SelectedIndex;
            if (index >= 0)
            {
                //setting up the querystring and redirecting to the Update page
                string studID = gridStudents.Rows[index].Cells[1].Text;
                Response.Redirect("EditStudent.aspx?studID=" + studID);
            }
            else
            {
                Response.Write(Messages.NoGridRowSelected);
            }
        }



    }
}