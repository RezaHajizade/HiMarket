using Domain.Baskets;
using Domain.Catalogs;
using Domain.Discounts;
using Domain.Entity;
using Domain.Order;
using Domain.Payments;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfase.Context
{
    public interface IDataBaseContext
    {
        DbSet<CatalogBrand> CatalogBrands { get; set; }
        DbSet<CatalogType> CatalogTypes { get; set; }
        DbSet<CatalogItem> CatalogItems { get; set; }
        DbSet<Baskets> Baskets { get; set; }
        DbSet<BasketItem> BasketItems { get; set; }
        DbSet<UserAddress> UserAddress { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderItem> OrderItems { get; set; }
        DbSet<payment> Payments { get; set; }
        DbSet<Discount> Discounts { get; set; }
        DbSet<CatalogItemFavourite> catalogItemFavourites { get; set; }
        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
