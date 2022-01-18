using Address.API.Entities;
using System.Threading.Tasks;

namespace Address.API.Repositories
{
    public interface IAddressRepository
    {
        Task<Addresses> GetPersonAddresses(string ID);
        Task<Addresses> UpdatePersonAddresses(Addresses address);
        Task DeletePersonAddresses(string ID);

    }
}
