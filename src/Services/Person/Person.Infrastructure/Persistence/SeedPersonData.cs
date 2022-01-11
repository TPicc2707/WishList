using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Person.Infrastructure.Persistence
{
    public class SeedPersonData
    {
        public static async Task SeedAsync(PersonDbContext personContext, ILogger<SeedPersonData> logger)
        {
            if (!personContext.People.Any())
            {
                personContext.People.AddRange(SeedData());
                await personContext.SaveChangesAsync();
                logger.LogInformation("Seed database with default Person data.");
            }
        }

        private static IEnumerable<Domain.Entities.Person> SeedData()
        {
            return new List<Domain.Entities.Person>
            {
                new Domain.Entities.Person()
                {
                    Title = "Mr",
                    FirstName = "Tony",
                    MiddleInitial = "N",
                    LastName = "Piccirilli",
                    Gender = "Male",
                    DateOfBirth = new DateTime(1995, 2, 10),
                    Age = 26
                },
                new Domain.Entities.Person()
                {
                    Title = "Ms",
                    FirstName = "Shelby",
                    MiddleInitial = "N",
                    LastName = "Siddons",
                    Gender = "Female",
                    DateOfBirth = new DateTime(1998, 12, 19),
                    Age = 23
                }
            };

        }
    }
}
