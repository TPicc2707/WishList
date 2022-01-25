using Person.Domain.Entities;

namespace Person.Application.Contracts.Persistence
{
    public interface IPersonPhoneNumberRepository : IAsyncRepository<Person_PhoneNumber>
    {
    }
}
