using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.Core.Models;

namespace MyProject.Data.DataAccess;

public class LinkTableDefinition : BaseEntityTypeConfiguration<Link>
{
    public override void Configure(EntityTypeBuilder<Link> builder)
    {
        base.Configure(builder); 

        builder
            .Property(e => e.Destination)
            .IsRequired()
            .HasMaxLength(64);

        builder
            .Property(e => e.SubDomain)
            .HasMaxLength(4);
    }
}
