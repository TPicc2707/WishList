using AutoMapper;
using EventBus.Messages.Events;
using Person.Application.Features.People_Address.Commands.CreatePerson_Address;
using Person.Application.Features.People_PhoneNumber.Commands.CreatePerson_PhoneNumber;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Person.API.Mapping
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<CreatePersonAddressCommandVm, CreatePersonAddressEvent>().ReverseMap();
            CreateMap<CreatePersonPhoneNumberCommandVm, CreatePersonPhoneNumberEvent>().ReverseMap();
        }
    }
}
