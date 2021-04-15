using FinancialControl.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialControl.DAL.Mappers
{
    public class CardMapper : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).IsRequired().HasMaxLength(20);
            builder.HasIndex(c => c.Name).IsUnique();

            builder.Property(c => c.Company).IsRequired().HasMaxLength(15);
            builder.Property(c => c.Number).IsRequired().HasMaxLength(20);

            builder.HasIndex(c => c.Number).IsUnique();
            builder.Property(c => c.Limit).IsRequired();

            builder.HasOne(c => c.User).WithMany(c => c.Cards).HasForeignKey(c => c.UserId).IsRequired().OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(c => c.Expenditures).WithOne(p => p.Card);

            builder.ToTable("Cards");
        }
    }
}
