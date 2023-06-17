using System.Reflection;

using Microsoft.EntityFrameworkCore;

using Flynk.Common.Utils;

namespace MyProject.Data.DataAccess;
using Core.Models;

public class MyDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Link> Links { get; set; }
    
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=MyProject;User Id=postgres;Password=12345678;Include Error Detail=true;");
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            // Replace table names
            entity.SetTableName(entity.GetTableName().CamelCaseToSnakeCase());

            // Replace column names            
            foreach (var property in entity.GetProperties())
            {
                var columnName = property.GetColumnName();
                property.SetColumnName(columnName.CamelCaseToSnakeCase());
            }

            foreach (var key in entity.GetKeys())
            {
                key.SetName(key.GetName().CamelCaseToSnakeCase());
            }

            foreach (var key in entity.GetForeignKeys())
            {
                key.SetConstraintName(key.GetConstraintName().CamelCaseToSnakeCase());
            }

            foreach (var index in entity.GetIndexes())
            {
                index.SetName(index.GetName().CamelCaseToSnakeCase());
            }
        }
    }
}
