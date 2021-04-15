using FinancialControl.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialControl.DAL.Mappers
{
    public class CategoryMapper : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Icon).IsRequired().HasMaxLength(15);

            builder.HasOne(c => c.Type).WithMany(t => t.Categories).HasForeignKey(c => c.TypeId).IsRequired();
            builder.HasMany(c => c.Expenditures).WithOne(e => e.Category);
            builder.HasMany(c => c.Profits).WithOne(p => p.Category);

            builder.ToTable("Categories");
        }
    }
}
