using Application.Users;
using AutoMapper;
using Domain.Entity;
using Domain.Users;
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
            CreateMap<UserAddress,UserAddressDto>().ReverseMap();
            CreateMap<AddUserAddressDto, UserAddress>().ReverseMap(); 
            CreateMap<User,UserAddress> ().ReverseMap();
        }
    }
}
