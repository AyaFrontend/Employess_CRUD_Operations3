using Employee_CRUD_Operations.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_CRUD_Operations.DAL.Data.Config
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employees>
    {
        public void Configure(EntityTypeBuilder<Employees> builder)
        {
            builder.HasKey(E => E.Id);
            builder.Property(E => E.Id).IsRequired();
            builder.Property(E => E.Name).IsRequired().HasMaxLength(100);
            builder.Property(E => E.Email).IsRequired();
            builder.Property(E => E.Mobile).IsRequired();

            builder.HasOne(E => E.Department).WithMany()
                .HasForeignKey(E => E.DepartmentId);
            builder.HasOne(E => E.UserWhoCreated).WithMany()
                .HasForeignKey(E=> E.CreatedBy);
            builder.HasOne(E => E.UserWhoModified).WithMany()
               .HasForeignKey(E => E.ModifiedBy);
        }

        
    }

}
