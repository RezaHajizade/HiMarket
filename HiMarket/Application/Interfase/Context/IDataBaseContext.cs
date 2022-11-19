using Domain.Baskets;
using Domain.Catalogs;
using Domain.Entity;
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
         DbSet<Bascket> basckets { get; set; }
        DbSet<BascketItem> BascketItems { get; set; }
        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);


    }
}
