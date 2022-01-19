using Address.API.Entities;
using AutoMapper;
using EventBus.Messages.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Address.API.Mapping
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<CreatePersonAddress, CreatePersonAddressEvent>().ReverseMap();
        }
    }
}
