using EmployeeServer.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeServer.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<JobEmployee> JobEmployee { get; set; }
        public DbSet<Job> Job { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=my_db5");
        }
    }
}
