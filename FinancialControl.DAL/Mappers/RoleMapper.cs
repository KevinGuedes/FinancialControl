using FinancialControl.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FinancialControl.DAL.Mappers
{
    public class RoleMapper : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(r => r.Id).ValueGeneratedOnAdd();
            builder.Property(r => r.Description).IsRequired().HasMaxLength(50);

            builder.HasData(
                new Role
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR",
                    Description = "System Administrator"
                },
                 new Role
                 {
                     Id = Guid.NewGuid().ToString(),
                     Name = "User",
                     NormalizedName = "USER",
                     Description = "System User",
                 }
            );

            builder.ToTable("Roles");
        }
    }
}
