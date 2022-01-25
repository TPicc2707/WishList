using MediatR;

namespace Person.Application.Features.People_PhoneNumber.Commands.CreatePerson_PhoneNumber
{
    public class CreatePersonPhoneNumberCommandVm : IRequest<int>
    {
        public int Person_Id { get; set; }
        public string Type { get; set; }
        public int CountryCode { get; set; }
        public int AreaCode { get; set; }
        public int TelephoneNumber { get; set; }

    }
}
