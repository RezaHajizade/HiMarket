using Admin.EndPoint.ViewModels.Catalogs;
using Application.Catalogs.CatalogItems.AddNewCatalogItem;
using Application.Catalogs.CatalogTypes;
using Application.Catalogs.CrudService.CatalogItems;
using AutoMapper;
using Domain.Catalogs;

namespace Admin.EndPoint.MappingProfiles
{
    public class CatalogVMMappingProfile:Profile
    {
        public CatalogVMMappingProfile()
        {
            CreateMap<CatalogTypeDto,CatalogTypeViewModel>().ReverseMap();
            CreateMap<CatalogItemEditDeleteGetListServiceDto, CatalogItemEditDeleteGetListServiceViewModel>().ReverseMap();
        }


    }
}
