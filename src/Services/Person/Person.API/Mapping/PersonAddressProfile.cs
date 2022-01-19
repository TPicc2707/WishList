using AutoMapper;
using EventBus.Messages.Events;
using Person.Application.Features.People_Address.Commands.CreatePerson_Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Person.API.Mapping
{
    public class PersonAddressProfile : Profile
    {
        public PersonAddressProfile()
        {
            CreateMap<CreatePersonAddressCommandVm, CreatePersonAddressEvent>().ReverseMap();
        }
    }
}
