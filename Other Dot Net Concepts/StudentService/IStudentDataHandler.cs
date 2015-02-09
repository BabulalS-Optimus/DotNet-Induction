using System.ServiceModel;
using System.Collections.Generic;

namespace StudentService
{
    /// <summary>
    /// Interface for the service to be implemented
    /// </summary>
    [ServiceContract]
    interface IStudentDataHandler
    {
        /// <summary>
        /// Method to Get record of the student
        /// </summary>
        /// <param name="rollNo">Roll number to search for</param>
        /// <returns>Record of the student</returns>
        [OperationContract]
        List<string> GetStudentRecord(int rollNo);
    }
}
