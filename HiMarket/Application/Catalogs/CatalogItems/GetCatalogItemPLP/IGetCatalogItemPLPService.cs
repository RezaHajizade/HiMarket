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
        PaginatedItemDto<CatalogPLPDto> Execute(int page, int pageSize);


    }

    public class GetCatalogItemPLPService: IGetCatalogItemPLPService
    {
        private readonly IDataBaseContext context;
        private readonly IUriComposerService uriComposer;

        public GetCatalogItemPLPService(IDataBaseContext context, IUriComposerService uriComposer)
        {
            this.context = context;
            this.uriComposer = uriComposer;
        }

        public PaginatedItemDto<CatalogPLPDto> Execute(int page, int pageSize)
        {
            int rowCount = 0;

            var data = context.CatalogItems
                .Include(p => p.CatalogItemImages)
                .OrderByDescending(p => p.Id)
                .PagedResult(page, pageSize, out rowCount)
                .Select(p => new CatalogPLPDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Rate = 4,
                    Image = uriComposer.ComposeImageUri(p.CatalogItemImages.FirstOrDefault().Src),
                }).ToList() ;

            return new PaginatedItemDto<CatalogPLPDto>(page, pageSize, rowCount, data);
        }
    }

    public class CatalogPLPDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public byte Rate { get; set; }
    }
}
