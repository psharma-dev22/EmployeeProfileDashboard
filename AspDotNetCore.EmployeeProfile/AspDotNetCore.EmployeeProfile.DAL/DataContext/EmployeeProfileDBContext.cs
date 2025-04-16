using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspDotNetCore.EmployeeProfile.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspDotNetCore.EmployeeProfile.DAL.DataContext
{
    public class EmployeeProfileDBContext : DbContext
    {
        public EmployeeProfileDBContext(DbContextOptions<EmployeeProfileDBContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 1,
                    EmployeeName = "Employee1",
                    DOB = new DateOnly(1994, 1, 14),
                    Gender = 'F',
                    State = "Pune",
                    Email = "Employee1@gmail.com"
                }
                );
            modelBuilder.Entity<User>().HasData(
               new User
               {
                   UserId = 1,
                   UserName = "testuser1",
                   Password = "1111",
                   Roles = "Admin"
               }
               , new User
               {
                   UserId = 2,
                   UserName = "testuser2",
                   Password = "2222",
                   Roles = "Developer"
               }
               , new User
               {
                   UserId = 3,
                   UserName = "testuser3",
                   Password = "3333",
                   Roles = "Moderator"
               }
               , new User
               {
                   UserId = 4,
                   UserName = "testuser4",
                   Password = "4444",
                   Roles = "SubAdmin"
               }
               );
        }
    }
}
