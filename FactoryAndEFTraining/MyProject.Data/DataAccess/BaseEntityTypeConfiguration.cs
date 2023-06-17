using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.Core.Models;

namespace MyProject.Data.DataAccess
{
    public abstract class BaseEntityTypeConfiguration<TBase> : IEntityTypeConfiguration<TBase> where TBase : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TBase> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Created).HasDefaultValueSql("now() at time zone 'utc'");
            builder.Property(e => e.LastUpdated).HasDefaultValueSql("now() at time zone 'utc'");
        }
    }
}