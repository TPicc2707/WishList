using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Address.API.Entities
{
    public class CreatePersonAddress
    {
        public int Person_Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }

    }
}
