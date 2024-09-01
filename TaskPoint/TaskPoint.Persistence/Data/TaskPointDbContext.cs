using Microsoft.EntityFrameworkCore;
using TaskPoint.Domain.Model;
using Task = TaskPoint.Domain.Model.Task;

namespace TaskPoint.Persistence.Data;

public class TaskPointDbContext : DbContext
{
    public TaskPointDbContext(DbContextOptions<TaskPointDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Task> Tasks { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<TaskTag> TaskTags { get; set; }
    public DbSet<Comment> Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        
        modelBuilder.Entity<TaskTag>()
            .HasKey(tt => new { tt.TaskId, tt.TagId });

        modelBuilder.Entity<Task>()
            .Property(t => t.Status)
            .HasConversion<int>();

        modelBuilder.Entity<Task>()
            .Property(t => t.Priority)
            .HasConversion<int>();

        modelBuilder.Entity<Task>()
           .HasMany(t => t.TaskTags)
           .WithOne(tt => tt.Task)
           .HasForeignKey(tt => tt.TaskId)
           .OnDelete(DeleteBehavior.Cascade);
    }

}