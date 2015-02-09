using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Sample.Models
{
    public class FileHandler
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string FilePath { get; set; }
    }
    public class FileHandlerContext : DbContext
    {
        public DbSet<User> Files { get; set; }

        public DbSet<FileHandler> FileHandlers { get; set; }
    }
}