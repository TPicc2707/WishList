﻿using Person.Application.Contracts.Persistence;
using Person.Domain.Entities;
using Person.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Infrastructure.Repository
{
    public class PersonAddressRepository : RepositoryBase<Person_Address>, IPersonAddressRepository
    {
        public PersonAddressRepository(PersonDbContext dbContext) : base(dbContext)
        {
        }
    }
}
