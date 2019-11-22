namespace P01_StudentSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;
    public class ResourceConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> resource)
        {
            resource.HasKey(r => r.ResourceId);

            resource.Property(r => r.Name)
                .HasMaxLength(DataValidations.Resourse.MaxNameLength)
                .IsUnicode();

            resource.Property(r => r.Url)
                .IsUnicode(false);
        }
    }
}
