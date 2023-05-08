using Application.Interfase.Context;
using AutoMapper;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users
{
    public interface IUserAddressService
    {
        List<UserAddressDto> GetAddress(string userId);
        void AddNewAddress(AddUserAddressDto address);
    }

    public class UserAddressService : IUserAddressService
    {
        private readonly IDataBaseContext context;
        private readonly IMapper mapper;

        public UserAddressService(IDataBaseContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void AddNewAddress(AddUserAddressDto address)
        {
            var data=mapper.Map<UserAddress>(address);
            context.UserAddress.Add(data);
            context.SaveChanges();
        }

        public List<UserAddressDto> GetAddress(string userId)
        {
            var address = context.UserAddress.Where(p => p.UserId == userId);
            var data = mapper.Map<List<UserAddressDto>>(address);
            return data;
        }
    }
    public class UserAddressDto
    {
        public int Id { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string PostalAddress { get; set; }
        public string ReciverName { get; set; }
    }
    public class AddUserAddressDto
    {
        public string UserId { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string PostalAddress { get; set; }
        public string ReciverName { get; set; }
    }
}
