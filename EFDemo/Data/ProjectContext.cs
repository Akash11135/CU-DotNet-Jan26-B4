using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDemo.Entity;
using Microsoft.EntityFrameworkCore;

namespace EFDemo.Data
{
    public class ProjectContext : DbContext
    {

        public DbSet<Laptop> Laptops { get; set; }


        //initial catalog here means what database for connection, if resent connect to that else 
        string path = "Data Source=AKASH\\SQLEXPRESS02;Initial Catalog=MyLaptopsDb;Integrated Security=True;TrustServerCertificate=True;";

        //function to connect to the database.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(path);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
