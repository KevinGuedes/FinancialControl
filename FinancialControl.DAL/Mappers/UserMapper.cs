using FinancialControl.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialControl.DAL.Mappers
{
    public class UserMapper : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Id);

            builder.Property(u => u.TaxNumber).IsRequired().HasMaxLength(20);
            builder.HasIndex(u => u.TaxNumber).IsUnique();

            builder.Property(u => u.Occupation).IsRequired().HasMaxLength(30);

            builder.HasMany(u => u.Cards).WithOne(c => c.User).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(u => u.Expenditures).WithOne(e => e.User).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(u => u.Profits).WithOne(p => p.User).OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("Users");
        }
    }
}
