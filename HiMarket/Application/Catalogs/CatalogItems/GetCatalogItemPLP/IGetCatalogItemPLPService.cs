using Application.Dtos;
using Application.Interfase.Context;
using Application.UriComposer;
using Commons;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Catalogs.CatalogItems.GetCatalogItemPLP
{
    public interface IGetCatalogItemPLPService
    {
        PaginatedItemDto<CatalogPLPDto> Execute(CatalogPLPRequestDto request);


    }

    public class GetCatalogItemPLPService : IGetCatalogItemPLPService
    {
        private readonly IDataBaseContext context;
        private readonly IUriComposerService uriComposer;

        public GetCatalogItemPLPService(IDataBaseContext context, IUriComposerService uriComposer)
        {
            this.context = context;
            this.uriComposer = uriComposer;
        }

        public PaginatedItemDto<CatalogPLPDto> Execute(CatalogPLPRequestDto request)
        {
            int rowCount = 0;

            var query = context.CatalogItems
                .Include(p => p.CatalogItemImages)
                .OrderByDescending(p => p.Id)
                .AsQueryable();

            if (request.BrandId != null)
            {
                query = query.Where(p => request.BrandId.Any(b => b == p.CatalogBrandId));
            }

            if (request.CatalogTypeId != null)
            {
                query = query.Where(p => p.CatalogTypeId == request.CatalogTypeId);
            }

            if (!string.IsNullOrEmpty(request.SearchKey))
            {
                query = query.Where(p => p.Name.Contains(request.SearchKey)
                || (p.Description.Contains(request.SearchKey)));
            }

            if (request.AvailableStock == true)
            {
                query = query.Where(p => p.AvailableStock > 0);
            }

            if (request.SortType == SortType.Bestselling)
            {
                query = query.Include(p => p.orderItems)
                    .OrderByDescending(p => p.orderItems.Count());
            }

            if (request.SortType == SortType.MostPopular)
            {
                query = query.Include(p => p.CatalogItemFavourite)
                    .OrderByDescending(p => p.CatalogItemFavourite.Count());
            }

            if (request.SortType == SortType.MostVisited)
            {
                query = query.OrderByDescending(p => p.VisitCount);
            }

            if (request.SortType == SortType.newest)
            {
                query = query.OrderByDescending(p => p.Id);
            }

            if (request.SortType == SortType.cheapest)
            {
                query = query.Include(p => p.Discounts)
                    .OrderBy(p => p.Price);
            }

            if (request.SortType == SortType.mostExpensive)
            {
                query = query.Include(p => p.Discounts)
                    .OrderByDescending(p => p.Price);
            }

            var data = query.PagedResult(request.Page, request.PageSize, out rowCount)
             .Select(p => new CatalogPLPDto
             {
                 Id = p.Id,
                 Name = p.Name,
                 Price = p.Price,
                 Rate = 4,
                 Image = uriComposer.ComposeImageUri(p.CatalogItemImages.FirstOrDefault().Src),
                 AvailableStock=p.AvailableStock
             }).ToList();

            return new PaginatedItemDto<CatalogPLPDto>(request.Page, request.PageSize, rowCount, data);
        }
    }

    public class CatalogPLPRequestDto
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int? CatalogTypeId { get; set; }
        public int[] BrandId { get; set; }
        public bool AvailableStock { get; set; }
        public string SearchKey { get; set; }
        public SortType SortType { get; set; }
    }
    public enum SortType
    {
        /// <summary>
        /// بدونه مرتب سازی
        /// </summary>
        None = 0,

        /// <summary>
        /// پربازدیدترین
        /// </summary>
        MostVisited = 1,

        /// <summary>
        /// پرفروش‌ترین
        /// </summary>
        Bestselling = 2,

        /// <summary>
        /// محبوب‌ترین
        /// </summary>
        MostPopular = 3,

        /// <summary>
        ///  ‌جدیدترین
        /// </summary>
        newest = 4,

        /// <summary>
        /// ارزان‌ترین
        /// </summary>
        cheapest = 5,

        /// <summary>
        /// گران‌ترین
        /// </summary>
        mostExpensive = 6,
    }
    public class CatalogPLPDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public byte Rate { get; set; }
        public int AvailableStock { get; set; }
    }
}
