using System.Data.Entity;

namespace MvcPattern.Models
{
    /// <summary>
    /// Class to hold Student record
    /// </summary>
    public class Student
    {
        #region Attributes
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        #endregion
    }

    /// <summary>
    /// Context class to migrate Student class and hold records of all students
    /// </summary>
    public class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
    }
}