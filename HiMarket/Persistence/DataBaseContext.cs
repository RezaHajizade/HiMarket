using Application.Interfase.Context;
using Domain.Attributes;
using Domain.Banners;
using Domain.Baskets;
using Domain.Catalogs;
using Domain.Discounts;
using Domain.Entity;
using Domain.Order;
using Domain.Payments;
using Domain.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityConfigurations;
using Persistence.Migrations;
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
        public DbSet<Baskets> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<UserAddress> UserAddress { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<payment> Payments { get; set; }
        public DbSet<Discount> Discount  { get; set; }
        public DbSet<CatalogItemFavourite> catalogItemFavourites  { get; set; }
        public DbSet<Banner> Banners { get; set; }
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

            builder.Entity<BasketItem>()
                .HasQueryFilter(m => EF.Property<bool>(m, "IsRemoved") == false);

            builder.Entity<Baskets>()
                .HasQueryFilter(m => EF.Property<bool>(m, "IsRemoved") == false);

            builder.ApplyConfiguration(new CatalogTypeEntityTypeConfiguration());
            builder.ApplyConfiguration(new CatalogBrandEntityTypeConfiguration());


            DataBaseContextSeed.CatalogSeed(builder);


            //تمام فیلد های  درون کلاس آدرس به عنوان یک فیلد درون تیبل اردرمون ذخیره بشوند و در واقع یک تیبل جدا برامون ایجاد نشه و ای اف هم بهمون خطا نمیده
            builder.Entity<Order>().OwnsOne(p => p.Address);
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

                if(entityType!=null)
                {
                    var Inserted = entityType.FindProperty("InsertTime");
                    var Updated = entityType.FindProperty("UpdateTime");
                    var RemoveTime = entityType.FindProperty("RemoveTime");
                    var IsRemoved = entityType.FindProperty("IsRemoved");

                    if (item.State == EntityState.Added && Inserted != null)
                    {
                        item.Property("InsertTime").CurrentValue = DateTime.Now;
                    }

                    if (item.State == EntityState.Modified && Updated != null)
                    {
                        item.Property("UpdateTime").CurrentValue = DateTime.Now;
                    }

                    if (item.State == EntityState.Deleted && RemoveTime != null && IsRemoved != null)
                    {
                        item.Property("RemoveTime").CurrentValue = DateTime.Now;
                        item.Property("IsRemoved").CurrentValue = true;
                        item.State = EntityState.Modified;
                    }
                }

               
            }
            return base.SaveChanges();
        }
    }
}



