using Application.Dtos;
using Application.Interfase.Context;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Catalogs.CrudService.CatalogItems
{
    public interface ICatalogItemService
    {
        BaseDto<CatalogItemDto> Edit(CatalogItemDto catalogItemDto);
        BaseDto Delete(int Id);
        PaginatedItemDto<CatalogItemDto> GetList(CatalogItemDto catalogItemDto, int page, int pageSize);

    }

    public class CatalogItemService : ICatalogItemService
    {
        private readonly IMapper mapper;
        private readonly IDataBaseContext context;

        public CatalogItemService(IMapper mapper, IDataBaseContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        public BaseDto Delete(int Id)
        {
            var data = context.CatalogItems.FirstOrDefault(p => p.Id == Id);
            var result = context.CatalogItems.Remove(data);
            context.SaveChanges();
            return new BaseDto(
           true,
           new List<string> { "آیتم با موفقیت حذف شد" }
           );
        }

        public BaseDto<CatalogItemDto> Edit(CatalogItemDto catalogItemDto)
        {
            var data = context.CatalogItems.FirstOrDefault(p => p.Id == catalogItemDto.Id);
            var result = mapper.Map(catalogItemDto, data);
            context.SaveChanges();
            return new BaseDto<CatalogItemDto>(
              true,
              new List<string> { $"با موفقیت ویرایش شد"},
              mapper.Map<CatalogItemDto>(data)                               
            );               
        }

        public PaginatedItemDto<CatalogItemDto> GetList(CatalogItemDto catalogItemDto, int page, int pageSize)
        {
            var data=context.CatalogItems.FirstOrDefault(p => p.Id == catalogItemDto.Id);
            var result = mapper.Map(catalogItemDto, data);

            return new PaginatedItemDto<CatalogItemDto>(
                {
                
            });
        }
    }

    public class CatalogItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int AvailableStock { get; set; }
        public int RestockThreshold { get; set; }
        public int MaxStockThreshold { get; set; }

    }
}
