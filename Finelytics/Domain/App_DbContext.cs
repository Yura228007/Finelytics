using Finelytics.Models;
using Microsoft.EntityFrameworkCore;

namespace Finelytics.Domain
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<PlanCategory> PlansCategories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserPlan> UserPlans { get; set; }
        public DbSet<UsersGroup> UsersGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}