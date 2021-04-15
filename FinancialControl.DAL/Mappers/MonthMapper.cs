using FinancialControl.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialControl.DAL.Mappers
{
    public class MonthMapper : IEntityTypeConfiguration<Month>
    {
        public void Configure(EntityTypeBuilder<Month> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Name).IsRequired().HasMaxLength(50);
            builder.HasIndex(m => m.Name).IsUnique();

            builder.HasMany(m => m.Expenditures).WithOne(e => e.Month);
            builder.HasMany(m => m.Profits).WithOne(p => p.Month);

            builder.HasData(
                new Month
                {
                    Id = 1,
                    Name = "January"
                },
                new Month
                {
                    Id = 2,
                    Name = "February"
                },
                new Month
                {
                    Id = 3,
                    Name = "March"
                },
                new Month
                {
                    Id = 4,
                    Name = "April"
                },
                new Month
                {
                    Id = 5,
                    Name = "May"
                },
                new Month
                {
                    Id = 6,
                    Name = "June"
                },
                new Month
                {
                    Id = 7,
                    Name = "July"
                },
                new Month
                {
                    Id = 8,
                    Name = "August"
                },
                new Month
                {
                    Id = 9,
                    Name = "September"
                },
                new Month
                {
                    Id = 10,
                    Name = "October"
                },
                new Month
                {
                    Id = 11,
                    Name = "November"
                },
                new Month
                {
                    Id = 12,
                    Name = "December"
                }
            );

            builder.ToTable("Months");
        }
    }
}
