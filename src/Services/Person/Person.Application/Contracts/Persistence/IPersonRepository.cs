using System.Collections.Generic;
using System.Threading.Tasks;

namespace Person.Application.Contracts.Persistence
{
    public interface IPersonRepository : IAsyncRepository<Domain.Entities.Person>
    {
        Task<IEnumerable<Domain.Entities.Person>> GetPeopleByLastName(string lastName);
    }
}
