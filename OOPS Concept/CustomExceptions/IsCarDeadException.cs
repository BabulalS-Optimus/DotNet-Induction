using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomExceptions
{
    /// <summary>
    /// Custom exception class to handle exceptions from Vehicle class
    /// </summary>
    public class IsCarDeadException : Exception
    {
        /// <summary>
        /// object to store the exceptions generated
        /// </summary>
        public static List<string> messages = new List<string>();

        /// <summary>
        /// default non parametric constructor
        /// </summary>
        public IsCarDeadException()
            : base()
        {
        }

        /// <summary>
        /// parametric constructor with a call to base class constructor
        /// </summary>
        /// <param name="message"></param>
        /// <param name="speed"></param>
        public IsCarDeadException(string message, float speed)
            : base(message)
        {

            string messageChange = message + " at [ Date : " + DateTime.Now.ToString() + " , Speed : " + speed + " ]";
            messages.Add(messageChange);

            //logging exception in Application Event Log
            
            //Note : as this account does not have the Administrative privileges, we cannot write Event Logs
            //uncomment the code if you have Privileges to create event logs for this account.

            /*
            * EventLog eventLog = new EventLog();
            * eventLog.Source = "Vehicle";
            * eventLog.WriteEntry(messageChange);
            */
        }
    }
}
