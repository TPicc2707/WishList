using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Messages.Events
{
    public class CreatePersonPhoneNumberEvent
    {
        public int Person_Id { get; set; }
        public string Type { get; set; }
        public int CountryCode { get; set; }
        public int AreaCode { get; set; }
        public int TelephoneNumber { get; set; }

    }
}
