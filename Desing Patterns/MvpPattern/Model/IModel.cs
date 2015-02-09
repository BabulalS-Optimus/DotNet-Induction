using System;
using System.Collections.Generic;

namespace MvpPattern.Model
{
    /// <summary>
    /// Interface for Model
    /// </summary>
    public interface IModel
    {
        /// <summary>
        ///Method to generate messages to be displayed on UI or View 
        /// </summary>
        /// <returns>List of string messages</returns>
        List<String> setInfo();
    }
}
