namespace TeisterMask.Data
{
    using Microsoft.EntityFrameworkCore;
    using TeisterMask.Data.Models;

    public class TeisterMaskContext : DbContext
    {
        public TeisterMaskContext() { }

        public TeisterMaskContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<EmployeeTask> EmployeesTasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(e =>
            {
                e.HasKey(x => x.Id);
            });

            modelBuilder.Entity<Project>(p =>
            {
                p.HasKey(x => x.Id);

                p.HasMany(x => x.Tasks)
                .WithOne(x => x.Project)
                .HasForeignKey(x => x.ProjectId);
            });

            modelBuilder.Entity<Task>(t =>
            {
                t.HasKey(x => x.Id);
            });

            modelBuilder.Entity<EmployeeTask>(et =>
            {
                et.HasKey(x => new { x.TaskId, x.EmployeeId});

                et.HasOne(x => x.Employee)
                .WithMany(x => x.EmployeesTasks)
                .HasForeignKey(x => x.EmployeeId);

                et.HasOne(x => x.Task)
                .WithMany(x => x.EmployeesTasks)
                .HasForeignKey(x => x.TaskId);
            });
        }
    }
}