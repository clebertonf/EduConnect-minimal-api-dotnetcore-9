using EduConnect.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduConnect.API.EntitiesConfiguration;

public class CourseConfiguration: IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> course)
    {
        course.HasKey(c => c.Id);
        course.Property(c => c.Title).HasMaxLength(50).IsRequired();
        course.Property(c => c.Description).HasMaxLength(50).IsRequired();
        course.Property(c => c.Duration).HasAnnotation("MinValue", 1).IsRequired();

        course.HasMany<Enrollment>(c => c.Enrollments)
            .WithOne(c => c.Course)
            .HasForeignKey(e => e.CourseId);
    }
}