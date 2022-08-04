using Application.Interfase.Context;
using Domain.Attributes;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class DataBaseContext : DbContext, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var entitytype in builder.Model.GetEntityTypes())
            {
                if (entitytype.ClrType.GetCustomAttributes(typeof(AuditableAttribute), true).Length > 0)
                {
                    builder.Entity(entitytype.Name).Property<DateTime>("InsertTime");
                    builder.Entity(entitytype.Name).Property<DateTime>("UpdateTime");
                    builder.Entity(entitytype.Name).Property<DateTime>("RemoveTime");
                    builder.Entity(entitytype.Name).Property<bool>("IsRemove");
                }
            }


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
                var IsRemoved = entityType.FindProperty("IsRemove");

                if(item.State==EntityState.Added && Inserted!=null)
                {
                    item.Property("Inserttime").CurrentValue = DateTime.Now;
                }

                if (item.State == EntityState.Modified && Updated != null)
                {
                    item.Property("UpdateTime").CurrentValue = DateTime.Now;
                }

                if (item.State == EntityState.Deleted && RemoveTime != null && IsRemoved !=null)
                {
                    item.Property("RemoveTime").CurrentValue = DateTime.Now;
                    item.Property("IsRemove").CurrentValue = true;
                }

               

            }

            return base.SaveChanges();
        }
    }
}

    

