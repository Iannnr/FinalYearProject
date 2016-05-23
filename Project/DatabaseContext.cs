using Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class DatabaseContext : DbContext 
    {
        public DatabaseContext() : base("IanConnectionString")
        {

        }

        public DbSet<Court> Courts { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Coach> Coach { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
