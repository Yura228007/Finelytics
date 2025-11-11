using finelytics.Models;
using Microsoft.EntityFrameworkCore;

namespace finelytics.Domain
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

            builder.Entity<UserPlan>()
                .HasOne<Plan>()
                .WithMany()
                .HasForeignKey(up => up.PlanId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<UserPlan>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(up => up.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<PlanCategory>()
                .HasOne<Plan>()
                .WithMany()
                .HasForeignKey(pc => pc.PlanId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<PlanCategory>()
                .HasOne<Category>()
                .WithMany()
                .HasForeignKey(pc => pc.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.Entity<UsersGroup>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(ug => ug.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<UsersGroup>()
                .HasOne<Group>()
                .WithMany()
                .HasForeignKey(ug => ug.GroupId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}