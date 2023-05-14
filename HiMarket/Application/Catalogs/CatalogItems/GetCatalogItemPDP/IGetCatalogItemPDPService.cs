using Application.Interfase.Context;
using Application.UriComposer;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Catalogs.CatalogItems.GetCatalogItemPDP
{
    public interface IGetCatalogItemPDPService
    {
        CatalogItemPDPDto Execute(int id);
    }


    public class GetCatalogItemPDPService : IGetCatalogItemPDPService
    {
        private readonly IDataBaseContext context;
        private readonly IMapper mapper;
        private readonly IUriComposerService uriComposer;

        public GetCatalogItemPDPService(IDataBaseContext context,IMapper mapper, IUriComposerService uriComposer)
        {
            this.context = context;
            this.mapper = mapper;
            this.uriComposer = uriComposer;
        }
        public CatalogItemPDPDto Execute(int id)
        {
            var catalogitem = context.CatalogItems
                 .Include(p => p.CatalogItemFeatures)
                 .Include(p => p.CatalogItemImages)
                 .Include(p => p.CatalogType)
                 .Include(p=>p.CatalogBrand)
                 .SingleOrDefault(p => p.Id == id);

            var feature = catalogitem.CatalogItemFeatures
                .Select(p => new PDPFeaturesDto
                {
                    Group = p.Group,
                    Key = p.Key,
                    Value = p.Value
                }).ToList()
                .GroupBy(p=>p.Group);

            var similarCatalogItem = context.CatalogItems
                .Include(p => p.CatalogItemImages)
                .Where(p => p.CatalogTypeId == catalogitem.CatalogTypeId)
                .Take(10)
                .Select(p => new SimilarCatalogItemDto
                {
                    Id = p.Id,
                    Images =uriComposer.ComposeImageUri(catalogitem.CatalogItemImages.FirstOrDefault().Src),
                    Name = p.Name,
                    Price = p.Price
                }).ToList();

            return new CatalogItemPDPDto
            {
                Features = feature,
                SimilarCatalogs = similarCatalogItem,
                Id = catalogitem.Id,
                Brand = catalogitem.CatalogBrand.Brand,
                Name = catalogitem.Name,
                Description = catalogitem.Description,
                Price = catalogitem.Price,
                Type = catalogitem.CatalogType.Type,
                Image = catalogitem.CatalogItemImages.Select(p => uriComposer.ComposeImageUri(p.Src)).ToList(),
            };
          
        }
    }
    public class CatalogItemPDPDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public List<string> Image { get; set; }
        public string Description  { get; set; }
        public IEnumerable<IGrouping<string, PDPFeaturesDto>> Features { get; set; }
        public List<SimilarCatalogItemDto> SimilarCatalogs { get; set; }

    }

    public class PDPFeaturesDto
    {
        public string Group { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public class SimilarCatalogItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Images { get; set; }
    }
}
