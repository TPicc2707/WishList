using Person.Domain.Common;

namespace Person.Domain.Entities
{
    public class Person_PhoneNumber : EntityBase
    {
        public int Person_Id { get; set; }
        public string Type { get; set; }
        public int CountryCode { get; set; }
        public int AreaCode { get; set; }
        public int TelephoneNumber { get; set; }

    }
}
