using Application.Dtos;
using Application.Interfase.Context;
using AutoMapper;
using Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Catalogs.CrudService.CatalogItems
{
    public interface ICatalogItemEditDeleteGetListService
    {
        BaseDto<CatalogItemEditDeleteGetListServiceDto> Edit(CatalogItemEditDeleteGetListServiceDto catalogItemDto);
        BaseDto Delete(int Id);
        BaseDto<CatalogItemEditDeleteGetListServiceDto> FindById(int Id);
        PaginatedItemDto<CatalogItemEditDeleteGetListServiceDto> GetList(int? Id, int page, int pageSize);
    }

    public class CatalogItemEditDeleteGetListService : ICatalogItemEditDeleteGetListService
    {
        private readonly IMapper mapper;
        private readonly IDataBaseContext context;

        public CatalogItemEditDeleteGetListService(IMapper mapper, IDataBaseContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        public BaseDto Delete(int Id)
        {
            var data = context.CatalogItems.Find(Id);
            context.CatalogItems.Remove(data);
            context.SaveChanges();
            return new BaseDto(
           true,
           new List<string> { "آیتم با موفقیت حذف شد" }
           );
        }

        public BaseDto<CatalogItemEditDeleteGetListServiceDto> Edit(CatalogItemEditDeleteGetListServiceDto catalogItemDto)
        {
            var data = context.CatalogItems.FirstOrDefault(p => p.Id == catalogItemDto.Id);
            mapper.Map(catalogItemDto,data);
            context.SaveChanges();
            return new BaseDto<CatalogItemEditDeleteGetListServiceDto>(
              true,
              new List<string> { $"با موفقیت ویرایش شد"},
            
           mapper.Map<CatalogItemEditDeleteGetListServiceDto>(data)                   
            );               
        }

        public BaseDto<CatalogItemEditDeleteGetListServiceDto> FindById(int Id)
        {
            var data = context.CatalogItems.FirstOrDefault(p => p.Id == Id);
            var result=mapper.Map<CatalogItemEditDeleteGetListServiceDto>(data);
            return new BaseDto<CatalogItemEditDeleteGetListServiceDto>(
                 true,
                null,
                result);

        }

        public PaginatedItemDto<CatalogItemEditDeleteGetListServiceDto> GetList(int? Id, int page, int pageSize)
        {
            int totalCount = 0;
            var data = context.CatalogItems
                .Where(p => p.Id == Id)
                .PagedResult(page, pageSize,out totalCount);

            var result = mapper.ProjectTo<CatalogItemEditDeleteGetListServiceDto>(data).ToList();

            return new PaginatedItemDto<CatalogItemEditDeleteGetListServiceDto>(page, pageSize, totalCount, result);
                
                            
        }
    }

    public class CatalogItemEditDeleteGetListServiceDto
    {
        public int Id { get; set; }
       public string? Name { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public int AvailableStock { get; set; }
        public int RestockThreshold { get; set; }
        public int MaxStockThreshold { get; set; }

    }
}
