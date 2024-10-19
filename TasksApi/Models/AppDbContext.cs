using Microsoft.EntityFrameworkCore;

namespace TasksApi.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<TodoTask> TodoTasks { get; set; } = null!;

        public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(user => user.TodoTasks)
                .WithOne(todoTask => todoTask.Creator)
                .HasForeignKey(todoTask => todoTask.CreatorId)
                .HasConstraintName("My_CreatorId_Constraint");
        }
    }
}
