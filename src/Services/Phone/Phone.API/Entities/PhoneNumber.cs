namespace Phone.API.Entities
{
    public class PhoneNumber
    {
        public string Type { get; set; }
        public int CountryCode { get; set; }
        public int AreaCode { get; set; }
        public int TelephoneNumber { get; set; }
    }
}
