using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace Diplom_one
{
    class Db : DbContext
    {
        public Db() : base("DBConnection") { }
        public DbSet<Register> Register { get; set; }
        public DbSet<Task> Task { get; set; }
        public DbSet<User> User { get; set; }
    }
}
