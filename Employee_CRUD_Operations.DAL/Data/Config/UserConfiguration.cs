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
    public class UserConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasKey(U => U.Id);
            builder.Property(U => U.Email).IsRequired();
            builder.Property(U => U.Password).IsRequired();
            builder.HasMany(U => U.Employees).WithOne();
        }
    }
}
