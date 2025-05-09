﻿// <auto-generated />
using System;
using AspDotNetCore.EmployeeProfile.DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AspDotNetCore.EmployeeProfile.DAL.Migrations
{
    [DbContext(typeof(EmployeeProfileDBContext))]
    [Migration("20250415093610_SeedData")]
    partial class SeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AspDotNetCore.EmployeeProfile.DAL.Entities.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<DateOnly>("DOB")
                        .HasColumnType("date")
                        .HasColumnName("DOB");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime")
                        .HasColumnName("DateCreated");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Email");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasColumnName("EmployeeName");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("Char(1)")
                        .HasColumnName("Gender");

                    b.Property<string>("State")
                        .HasColumnType("varchar(30)")
                        .HasColumnName("State");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            DOB = new DateOnly(1994, 1, 14),
                            DateCreated = new DateTime(2025, 4, 15, 15, 6, 9, 271, DateTimeKind.Local).AddTicks(8394),
                            Email = "Employee1@gmail.com",
                            EmployeeName = "Employee1",
                            Gender = "F",
                            State = "Pune"
                        });
                });

            modelBuilder.Entity("AspDotNetCore.EmployeeProfile.DAL.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("Password");

                    b.Property<string>("Roles")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Roles");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("UserName");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Password = "1111",
                            Roles = "Admin",
                            UserName = "testuser1"
                        },
                        new
                        {
                            UserId = 2,
                            Password = "2222",
                            Roles = "Developer",
                            UserName = "testuser2"
                        },
                        new
                        {
                            UserId = 3,
                            Password = "3333",
                            Roles = "Moderator",
                            UserName = "testuser3"
                        },
                        new
                        {
                            UserId = 4,
                            Password = "4444",
                            Roles = "SubAdmin",
                            UserName = "testuser4"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
