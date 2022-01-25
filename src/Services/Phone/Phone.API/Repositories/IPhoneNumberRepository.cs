using Phone.API.Entities;
using System.Threading.Tasks;

namespace Phone.API.Repositories
{
    public interface IPhoneNumberRepository
    {
        Task<PhoneNumbers> GetPersonPhoneNumbers(string ID);
        Task<PhoneNumbers> UpdatePersonPhoneNumbers(PhoneNumbers phoneNumbers);
        Task DeletePersonPhoneNumbers(string ID);

    }
}
