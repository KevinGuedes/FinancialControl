using FinancialControl.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialControl.DAL.Mappers
{
    public class ExpenditureMapper : IEntityTypeConfiguration<Expenditure>
    {
        public void Configure(EntityTypeBuilder<Expenditure> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Description).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Value).IsRequired();
            builder.Property(e => e.Day).IsRequired();
            builder.Property(e => e.Year).IsRequired();

            builder.HasOne(e => e.Card).WithMany(c => c.Expenditures).HasForeignKey(e => e.CardId).IsRequired();

            builder.HasOne(e => e.User).WithMany(u => u.Expenditures).HasForeignKey(e => e.UserId).IsRequired();

            builder.HasOne(e => e.Category).WithMany(c => c.Expenditures).HasForeignKey(e => e.CategoryId).IsRequired();

            builder.HasOne(e => e.Month).WithMany(c => c.Expenditures).HasForeignKey(e => e.MonthId).IsRequired();

            builder.ToTable("Expenditures");
        }
    }
}
