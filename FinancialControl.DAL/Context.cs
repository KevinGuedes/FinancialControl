using FinancialControl.BLL.Models;
using FinancialControl.DAL.Mappers;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Type = FinancialControl.BLL.Models.Type;

namespace FinancialControl.DAL
{
    public class Context : IdentityDbContext<User, Role, string>
    {
        public DbSet<Card> Cards { get; set; }

        public DbSet<Category> Categories { get; set; }

        private DbSet<Role> roles;

        public DbSet<Role> GetRoles()
        {
            return roles;
        }

        public void SetRoles(DbSet<Role> value)
        {
            roles = value;
        }

        public DbSet<Profit> Profits { get; set; }

        public DbSet<Expenditure> Expenditures { get; set; }

        public DbSet<Month> Months { get; set; }

        public DbSet<Type> Types { get; set; }

        public override DbSet<User> Users { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new UserMapper());
            builder.ApplyConfiguration(new TypeMapper());
            builder.ApplyConfiguration(new CategoryMapper());
            builder.ApplyConfiguration(new ProfitMapper());
            builder.ApplyConfiguration(new ExpenditureMapper());
            builder.ApplyConfiguration(new CardMapper());
            builder.ApplyConfiguration(new RoleMapper());
            builder.ApplyConfiguration(new MonthMapper());
        }
    }
}
