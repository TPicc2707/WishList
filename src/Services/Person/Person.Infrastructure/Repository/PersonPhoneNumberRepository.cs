using Person.Application.Contracts.Persistence;
using Person.Domain.Entities;
using Person.Infrastructure.Persistence;

namespace Person.Infrastructure.Repository
{
    public class PersonPhoneNumberRepository : RepositoryBase<Person_PhoneNumber>, IPersonPhoneNumberRepository
    {
        public PersonPhoneNumberRepository(PersonDbContext dbContext) : base(dbContext)
        {
        }
    }
}
