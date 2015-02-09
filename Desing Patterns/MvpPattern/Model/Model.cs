using System;
using System.Collections.Generic;

namespace MvpPattern.Model
{
    /// <summary>
    /// Model class implementing IModel interface
    /// </summary>
    public class Model : IModel
    {
        /// <summary>
        /// Method to create information to be displayed on UI or View
        /// </summary>
        /// <returns>List of string messages</returns>
        public List<String> setInfo()
        {
            //Create a list of messages and return it.
            List<String> list = new List<string>();
            list.Add("Enter Name:");
            list.Add("Use capital letter only");
            return list;
        }
    }
}