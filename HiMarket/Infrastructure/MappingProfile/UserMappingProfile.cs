using Application.Users;
using AutoMapper;
using Domain.Entity;
using Domain.Order;
using Domain.Users;
using Persistence.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MappingProfile
{
    public  class UserMappingProfile:Profile
    {
        public UserMappingProfile() 
        {
            CreateMap<UserAddress, UserAddressDto>();
            CreateMap<AddUserAddressDto, UserAddress>();
            CreateMap<UserAddress, Address>();
        }
    }
}
