using FinancialControl.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialControl.DAL.Mappers
{
    public class ProfitMapper : IEntityTypeConfiguration<Profit>
    {
        public void Configure(EntityTypeBuilder<Profit> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Description).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Value).IsRequired();
            builder.Property(p => p.Day).IsRequired();
            builder.Property(p => p.Year).IsRequired();

            builder.HasOne(p => p.Category).WithMany(c => c.Profits).HasForeignKey(p => p.CategoryId).IsRequired();

            builder.HasOne(p => p.Month).WithMany(m => m.Profits).HasForeignKey(p => p.MonthId).IsRequired();

            builder.HasOne(p => p.User).WithMany(u => u.Profits).HasForeignKey(p => p.UserId).IsRequired();

            builder.ToTable("Profits");
        }
    }
}
