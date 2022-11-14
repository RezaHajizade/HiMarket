using Application.Interfase.Context;
using Domain.Attributes;
using Domain.Catalogs;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityConfigurations;
using Persistence.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class DataBaseContext : DbContext, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) 
            : base(options)
        {

        }
        public DbSet<CatalogBrand> CatalogBrands { get; set; }
        public DbSet<CatalogType> CatalogTypes { get; set; }
        public DbSet<CatalogItem> CatalogItems { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                if (entityType.ClrType.GetCustomAttributes(typeof(AuditableAttribute), true).Length > 0)
                {
                    builder.Entity(entityType.Name).Property<DateTime>("InsertTime").HasDefaultValue(DateTime.Now);
                    builder.Entity(entityType.Name).Property<DateTime?>("UpdateTime");
                    builder.Entity(entityType.Name).Property<DateTime?>("RemoveTime");
                    builder.Entity(entityType.Name).Property<bool>("IsRemoved").HasDefaultValue(false);
                }
            }

            builder.Entity<CatalogType>()
                .HasQueryFilter(m => EF.Property<bool>(m, "IsRemoved") == false);

            builder.ApplyConfiguration(new CatalogTypeEntityTypeConfiguration());
            builder.ApplyConfiguration(new CatalogBrandEntityTypeConfiguration());
         

            DataBaseContextSeed.CatalogSeed(builder);
            base.OnModelCreating(builder);
        }
        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(p => p.State == EntityState.Modified ||
                 p.State == EntityState.Added ||
                 p.State == EntityState.Deleted);


            foreach (var item in modifiedEntries)
            {
                var entityType = item.Context.Model.FindEntityType(item.Entity.GetType());

                var Inserted = entityType.FindProperty("InsertTime");
                var Updated = entityType.FindProperty("UpdateTime");
                var RemoveTime = entityType.FindProperty("RemoveTime");
                var IsRemoved = entityType.FindProperty("IsRemoved");

                if(item.State==EntityState.Added && Inserted!=null)
                {
                    item.Property("InsertTime").CurrentValue = DateTime.Now;
                }

                if (item.State == EntityState.Modified && Updated != null)
                {
                    item.Property("UpdateTime").CurrentValue = DateTime.Now;
                }

                if (item.State == EntityState.Deleted && RemoveTime != null && IsRemoved !=null)
                {
                    item.Property("RemoveTime").CurrentValue = DateTime.Now;
                    item.Property("IsRemoved").CurrentValue = true;
                    item.State= EntityState.Modified;
                }          
            }
            return base.SaveChanges();
        }
    }
}

    

