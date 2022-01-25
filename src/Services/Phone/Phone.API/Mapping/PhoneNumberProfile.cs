using AutoMapper;
using EventBus.Messages.Events;
using Phone.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phone.API.Mapping
{
    public class PhoneNumberProfile : Profile
    {
        public PhoneNumberProfile()
        {
            CreateMap<CreatePersonPhoneNumber, CreatePersonPhoneNumberEvent>().ReverseMap();
        }
    }
}
