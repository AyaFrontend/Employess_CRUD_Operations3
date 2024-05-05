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
    public class DepartmentConfiguration : IEntityTypeConfiguration<Departments>
    {
        public void Configure(EntityTypeBuilder<Departments> builder)
        {
            builder.HasKey(D => D.Id);
            builder.Property(D => D.Name).IsRequired().HasMaxLength(100);
            builder.Property(D => D.Description).IsRequired().HasMaxLength(400);
            builder.HasMany(D => D.Employees).WithOne();
        }

        
    }
}
