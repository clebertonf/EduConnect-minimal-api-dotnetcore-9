using EduConnect.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduConnect.API.EntitiesConfiguration;

public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
{
    public void Configure(EntityTypeBuilder<Enrollment> enrollment)
    {
        enrollment.HasKey(e => e.Id);
        enrollment.Property(e => e.Status).HasMaxLength(10).IsRequired();
        enrollment.Property(e => e.EnrollmentDate)
            .HasDefaultValueSql("GETDATE()").IsRequired();

        enrollment.HasOne(e => e.Student)
            .WithMany(s => s.Enrollments)
            .HasForeignKey(e => e.StudentId);
        
        enrollment.HasOne(e => e.Course)
            .WithMany(c => c.Enrollments)
            .HasForeignKey(e => e.CourseId);
    }
}