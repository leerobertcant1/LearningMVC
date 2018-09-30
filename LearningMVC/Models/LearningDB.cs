using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LearningMVC.Models
{
    public class LearningDB: DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}