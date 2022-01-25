using System.Collections.Generic;

namespace Phone.API.Entities
{
    public class PhoneNumbers
    {
        public string PersonID { get; set; }
        public List<PhoneNumber> Person_PhoneNumbers { get; set; } = new List<PhoneNumber>();

        public PhoneNumbers()
        {

        }

        public PhoneNumbers(string ID)
        {
            PersonID = ID;
        }
    }
}
