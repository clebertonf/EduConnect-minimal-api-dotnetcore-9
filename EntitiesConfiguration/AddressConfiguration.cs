using EduConnect.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduConnect.API.EntitiesConfiguration;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> address)
    {
        address.HasKey(a => a.Id);
        address.Property(a => a.City).HasMaxLength(30).IsRequired();
        address.Property(a => a.State).HasMaxLength(30).IsRequired();
        address.Property(a => a.ZipCode).HasMaxLength(10).IsRequired();
        address.Property(a => a.Street).HasMaxLength(40).IsRequired();

        address.HasOne<Student>(a => a.Student)
            .WithOne(s => s.Address)
            .HasForeignKey<Address>(a => a.StudentId);
    }
}