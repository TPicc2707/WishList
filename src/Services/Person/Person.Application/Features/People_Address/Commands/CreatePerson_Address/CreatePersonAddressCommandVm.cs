using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Application.Features.People_Address.Commands.CreatePerson_Address
{
    public class CreatePersonAddressCommandVm : IRequest<int>
    {
        public int Person_Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }

    }
}
