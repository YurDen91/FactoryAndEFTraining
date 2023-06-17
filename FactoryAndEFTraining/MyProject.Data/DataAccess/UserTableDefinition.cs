using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.Core.Models;

namespace MyProject.Data.DataAccess;

public class UserTableDefinition : BaseEntityTypeConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder); 

        builder
            .Property(e => e.UserName)
            .IsRequired()
            .HasMaxLength(64);

        builder
            .Property(e => e.Passsword)
            .IsRequired()
            .HasMaxLength(128);

        builder
            .HasOne(u => u.Person)
            .WithOne()
            .HasForeignKey<User>(u => u.PersonId);
    }
}
