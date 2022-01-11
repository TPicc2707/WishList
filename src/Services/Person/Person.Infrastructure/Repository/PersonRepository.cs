using Microsoft.EntityFrameworkCore;
using Person.Application.Contracts.Persistence;
using Person.Infrastructure.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Person.Infrastructure.Repository
{
    public class PersonRepository : RepositoryBase<Domain.Entities.Person>, IPersonRepository
    {
        public PersonRepository(PersonDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<Domain.Entities.Person>> GetPeopleByLastName(string lastName)
        {
            var personList = await _dbContext.People.Where(p => p.LastName == lastName).OrderBy(p => p.LastName).ToListAsync();

            return personList;
        }

    }
}
