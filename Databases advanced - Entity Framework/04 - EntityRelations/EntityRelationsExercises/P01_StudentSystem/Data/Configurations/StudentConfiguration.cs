namespace P01_StudentSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> student)
        {
            student.HasKey(s => s.StudentId);

            student.Property(s => s.Name)
                .HasMaxLength(100)
                .IsUnicode()
                .IsRequired();

            student.Property(s => s.PhoneNumber)
                .HasColumnType("char(10)")
                .IsUnicode(false);

            student.HasMany(s => s.HomeworkSubmissions)
                .WithOne(h => h.Student)
                .HasForeignKey(s => s.StudentId);
        }
    }
}
