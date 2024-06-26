﻿// <auto-generated />
using System;
using Employee_CRUD_Operations.DAL.Data.StoreContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Employee_CRUD_Operations.DAL.Migrations
{
    [DbContext(typeof(StoreContext))]
    partial class StoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
               
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Employee_CRUD_Operations.DAL.Models.Departments", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Employee_CRUD_Operations.DAL.Models.Employees", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("DepartmentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DepartmentsId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ProfileImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UsersId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("DepartmentsId");

                    b.HasIndex("ModifiedBy");

                    b.HasIndex("UsersId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Employee_CRUD_Operations.DAL.Models.Users", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Employee_CRUD_Operations.DAL.Models.Employees", b =>
                {
                    b.HasOne("Employee_CRUD_Operations.DAL.Models.Users", "UserWhoCreated")
                        .WithMany()
                        .HasForeignKey("CreatedBy");

                    b.HasOne("Employee_CRUD_Operations.DAL.Models.Departments", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId");

                    b.HasOne("Employee_CRUD_Operations.DAL.Models.Departments", null)
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentsId");

                    b.HasOne("Employee_CRUD_Operations.DAL.Models.Users", "UserWhoModified")
                        .WithMany()
                        .HasForeignKey("ModifiedBy");

                    b.HasOne("Employee_CRUD_Operations.DAL.Models.Users", null)
                        .WithMany("Employees")
                        .HasForeignKey("UsersId");

                    b.Navigation("Department");

                    b.Navigation("UserWhoCreated");

                    b.Navigation("UserWhoModified");
                });

            modelBuilder.Entity("Employee_CRUD_Operations.DAL.Models.Departments", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Employee_CRUD_Operations.DAL.Models.Users", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
