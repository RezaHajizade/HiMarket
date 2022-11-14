using Application.Dtos;
using Application.Interfase.Context;
using AutoMapper;
using Domain.Catalogs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Catalogs.CatalogItems.AddNewCatalogItem
{
    public interface IAddNewCatalogItemService
    {
        BaseDto<int> Execute(AddNewCatalogItemDto request);
    }

    public class AddNewCatalogItemService : IAddNewCatalogItemService
    {
        private readonly IDataBaseContext context;
        private readonly IMapper mapper;
        public AddNewCatalogItemService(IDataBaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public BaseDto<int> Execute(AddNewCatalogItemDto request)
        {
            var catalogItem = mapper.Map<CatalogItem>(request);
            context.CatalogItems.Add(catalogItem);
            context.SaveChanges();
            return new BaseDto<int>(true, new List<string> { "با موفقیت ثبت شد" }, catalogItem.Id);
        }
    }

}
