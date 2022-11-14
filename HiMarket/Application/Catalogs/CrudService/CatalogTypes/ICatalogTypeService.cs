using Application.Dtos;
using Application.Interfase.Context;
using AutoMapper;
using AutoMapper.Internal.Mappers;
using Commons;
using Domain.Catalogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Catalogs.CatalogTypes
{
    public interface ICatalogTypeService
    {
        BaseDto<CatalogTypeDto> Add(CatalogTypeDto catalogTypeDto);
        BaseDto<CatalogTypeDto> Edit(CatalogTypeDto catalogTypeDto);
        BaseDto Remove(int Id);
        BaseDto<CatalogTypeDto> FindById(int Id);
        PaginatedItemDto<CatalogTypeListDto> GetList(int? parentId, int page, int pageSize);
    }

    public class CatalogTypeService : ICatalogTypeService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper mapper;

        public CatalogTypeService(IDataBaseContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }
        public BaseDto<CatalogTypeDto> Add(CatalogTypeDto catalogType)
        {
            var model = mapper.Map<CatalogType>(catalogType);
            _context.CatalogTypes.Add(model);
            _context.SaveChanges();
            return new BaseDto<CatalogTypeDto>
               (
                        true,
                 new List<string> { $"تایپ {model.Type}  با موفقیت در سیستم ثبت شد" },
                 mapper.Map<CatalogTypeDto>(model)
             );
        }

        public BaseDto<CatalogTypeDto> Edit(CatalogTypeDto catalogTypeDto)
        {
            var model = _context.CatalogTypes.FirstOrDefault(p => p.Id == catalogTypeDto.Id);
            mapper.Map(catalogTypeDto, model);
            _context.SaveChanges();
            return new BaseDto<CatalogTypeDto>(
                 true,
                 new List<string> { $"تایپ {model.Type} با موفقیت در سیستم ویرایش شد" },

                  mapper.Map<CatalogTypeDto>(model)
            );
        }

        public BaseDto<CatalogTypeDto> FindById(int Id)
        {
            var data = _context.CatalogTypes.Find(Id);
            var result = mapper.Map<CatalogTypeDto>(data);

            return new BaseDto<CatalogTypeDto>(
                true,
                null,
                result
                );

        }

        public PaginatedItemDto<CatalogTypeListDto> GetList(int? parentId, int page, int pageSize)
        {
            int totalCount = 0;
            var model = _context.CatalogTypes
                .Where(p => p.ParentCatalogTypeId == parentId)
                .PagedResult(page, pageSize, out totalCount);
            var result = mapper.ProjectTo<CatalogTypeListDto>(model).ToList();
            return new PaginatedItemDto<CatalogTypeListDto>(page, pageSize, totalCount, result);
        }

        public BaseDto Remove(int Id)
        {
            var catalogType = _context.CatalogTypes.Find(Id);
            _context.CatalogTypes.Remove(catalogType);
            _context.SaveChanges();
            return new BaseDto(
                true,
                new List<string> { "آیتم با موفقیت حذف شد" }
                
                );

        }
    }

    public class CatalogTypeDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int? ParentCatalogTypeId { get; set; }
    }
    public class CatalogTypeListDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int SubTypeCount { get; set; }
    }

}
