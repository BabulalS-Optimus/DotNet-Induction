using System.Data.Entity;

namespace MvcPattern.Models
{
    public class User 
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}