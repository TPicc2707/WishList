using Microsoft.EntityFrameworkCore;
using Person.Domain.Common;
using Person.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Person.Infrastructure.Persistence
{
    public class PersonDbContext : DbContext
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options)
        {

        }

        public DbSet<Domain.Entities.Person> People { get; set; }
        public DbSet<Person_Address> People_Addresses { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "admin";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "admin";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
