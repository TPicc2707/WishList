using AutoMapper;
using Person.Application.Features.People.Commands.CreatePerson;
using Person.Application.Features.People.Commands.UpdatePerson;
using Person.Application.Features.People.Queries;
using Person.Application.Features.People_Address.Commands.CreatePerson_Address;
using Person.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.Person, PersonVm>().ReverseMap();
            CreateMap<Domain.Entities.Person, CreatePersonCommandVm>().ReverseMap();
            CreateMap<Domain.Entities.Person, UpdatePersonCommandVm>().ReverseMap();

            CreateMap<Person_Address, CreatePersonAddressCommandVm>().ReverseMap();
        }
    }
}
