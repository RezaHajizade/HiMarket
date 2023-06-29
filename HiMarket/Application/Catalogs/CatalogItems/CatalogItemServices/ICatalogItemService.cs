using Application.Dtos;
using Application.Interfase.Context;
using Application.UriComposer;
using AutoMapper;
using Commons;
using Domain.Catalogs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MongoDB.Driver.WriteConcern;

namespace Application.Catalogs.CatalogItems.CatalogItemServices
{
    public interface ICatalogItemService
    {
        List<CatalogBrandDto> GetBrand();
        List<ListCatalogTypeDto> GetCatalogType();
        PaginatedItemDto<CatalogItemListItemDto> GetCatalogList(int page,int pageSize);
        void AddToMyFavourite(string UserId, int CatalogItemId);
        PaginatedItemDto<FavouriteCatalogItemDto> GetMyFavourite(string UserId, int page = 1, int pageSize = 20);
    }
    public class CatalogItemService : ICatalogItemService
    {

        private readonly IDataBaseContext context;
        private readonly IMapper mapper;
        private readonly IUriComposerService uriComposerService;

        public CatalogItemService(IDataBaseContext context,
            IMapper mapper,
            IUriComposerService uriComposerService)
        {
            this.context = context;
            this.mapper = mapper;
            this.uriComposerService = uriComposerService;
        }

        public void AddToMyFavourite(string UserId, int CatalogItemId)
        {
            var catalogItem = context.CatalogItems.Find(CatalogItemId);
            CatalogItemFavourite catalogItemFavourite = new CatalogItemFavourite
            {
                UserId = UserId,
                CatalogItem = catalogItem
            };
            context.catalogItemFavourites.Add(catalogItemFavourite);
            context.SaveChanges();
                
        }

        public List<CatalogBrandDto> GetBrand()
        {
            var brands = context.CatalogBrands
           .OrderBy(p => p.Brand).Take(500).ToList();

            var data = mapper.Map<List<CatalogBrandDto>>(brands);
            return data;
        }

        public PaginatedItemDto<CatalogItemListItemDto> GetCatalogList(int page, int pageSize)        
        
        {
            int rowcount=0;
            var catalogItem = context.CatalogItems
                .Include(p => p.CatalogBrand)               
                .Include(p=>p.CatalogType)                        
                .ToPaged(page, pageSize, out rowcount);

            var data = mapper.Map<List<CatalogItemListItemDto>>(catalogItem);
       
            return new PaginatedItemDto<CatalogItemListItemDto>(page, pageSize,rowcount,data);
                
        }

        public List<ListCatalogTypeDto> GetCatalogType()
        {
            var types = context.CatalogTypes
               .Include(p => p.ParentCatalogType)
               .Include(p => p.ParentCatalogType)
               .ThenInclude(p => p.ParentCatalogType.ParentCatalogType)
                .Include(p => p.SubType)
                .Where(p => p.ParentCatalogTypeId != null)
                .Where(p => p.SubType.Count == 0)
                 .Select(p => new { p.Id, p.Type, p.ParentCatalogType, p.SubType })
                                .ToList()
                .Select(p => new ListCatalogTypeDto
                {
                    Id = p.Id,
                    Type = $"{p?.Type ?? ""} - {p?.ParentCatalogType?.Type ?? ""} - {p?.ParentCatalogType?.ParentCatalogType?.Type ?? ""}"
                }).ToList();
            return types;
        }

        public PaginatedItemDto<FavouriteCatalogItemDto> GetMyFavourite(string UserId, int page = 1, int pageSize = 20)
        {
            var model = context.CatalogItems
                .Include(p => p.CatalogItemImages)
                .Include(p => p.Discounts)
                .Include(p => p.CatalogItemFavourite)
                .Where(p => p.CatalogItemFavourite.Any(f => f.UserId == UserId))
                .OrderByDescending(p=>p.Id)
                .AsQueryable();

            int rowCount = 0;

            var data = model.PagedResult(page, pageSize, out rowCount)
                .ToList()
                .Select(p => new FavouriteCatalogItemDto
                {
                    Name = p.Name,
                    Id = p.Id,
                    Price = p.Price,
                    Rate = 4,
                    AvailableStock = p.AvailableStock,
                    Image = uriComposerService.ComposeImageUri(p.CatalogItemImages.FirstOrDefault().Src)
                }).ToList();
            return new PaginatedItemDto<FavouriteCatalogItemDto>(page, pageSize, rowCount, data);
        }
    }

    public class FavouriteCatalogItemDto
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public int Rate { get; set; }
        public int AvailableStock { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
    public class CatalogBrandDto
    {
        public int Id { get; set; }
        public string Brand { get; set; }
    }
    public class ListCatalogTypeDto
    {
        public int Id { get; set; }
        public string? Type { get; set; }
    }

    public class CatalogItemListItemDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
        public string? Type { get; set; }
        public string? Brand { get; set; }
        public int AvailableStock { get; set; }
        public int RestockThreshold { get; set; }
        public int MaxStockThreshold { get; set; }

    }
}
