using EduConnect.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduConnect.API.EntitiesConfiguration;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> studend)
    {
        studend.HasKey(s => s.Id);
        studend.Property(s => s.FirstName).HasMaxLength(30).IsRequired();
        studend.Property(s => s.Email).HasMaxLength(50).IsRequired();

        studend.HasOne(s => s.Address)
            .WithOne(s => s.Student)
            .HasForeignKey<Address>(s => s.StudentId);
        
        studend.HasMany(s => s.Enrollments)
            .WithOne(s => s.Student)
            .HasForeignKey(s => s.StudentId);
    }
}