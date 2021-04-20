using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Type = FinancialControl.BLL.Models.Type;

namespace FinancialControl.DAL.Mappers
{
    public class TypeMapper : IEntityTypeConfiguration<Type>
    {
        public void Configure(EntityTypeBuilder<Type> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).IsRequired().HasMaxLength(20);
            builder.HasMany(t => t.Categories).WithOne(c => c.Type);

            builder.HasData(
                new Type
                {
                    Id = 1,
                    Name = "Expenditure"
                },
                new Type
                {
                    Id = 2,
                    Name = "Profit"
                });

            builder.ToTable("Types");
        }
    }
}
