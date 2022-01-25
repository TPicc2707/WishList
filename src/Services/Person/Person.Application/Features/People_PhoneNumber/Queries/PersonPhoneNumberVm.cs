namespace Person.Application.Features.People_PhoneNumber.Queries
{
    public class PersonPhoneNumberVm
    {
        public int Id { get; set; }
        public int Person_Id { get; set; }
        public string Type { get; set; }
        public int CountryCode { get; set; }
        public int AreaCode { get; set; }
        public int TelephoneNumber { get; set; }

    }
}
