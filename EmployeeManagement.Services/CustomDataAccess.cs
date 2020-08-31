using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Services
{
    public class CustomDataAccess : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public CustomDataAccess(DbContextOptions<CustomDataAccess> options)
            :base(options)
        {

        }
        //Do Some work later...
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
