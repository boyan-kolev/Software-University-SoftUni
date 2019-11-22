namespace P01_StudentSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> course)
        {
            course.HasKey(c => c.CourseId);

            course.Property(c => c.Name)
                .HasMaxLength(DataValidations.Course.MaxNameLength)
                .IsUnicode();

            course.Property(c => c.Description)
                .IsUnicode();

            course.HasMany(c => c.Resources)
                .WithOne(r => r.Course)
                .HasForeignKey(c => c.CourseId);

            course.HasMany(c => c.HomeworkSubmissions)
                .WithOne(hs => hs.Course)
                .HasForeignKey(c => c.CourseId);
        }
    }
}
