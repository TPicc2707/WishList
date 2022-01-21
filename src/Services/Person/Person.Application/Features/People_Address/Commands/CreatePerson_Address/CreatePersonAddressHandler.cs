﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Person.Application.Contracts.Persistence;
using Person.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Person.Application.Features.People_Address.Commands.CreatePerson_Address
{
    public class CreatePersonAddressHandler : IRequestHandler<CreatePersonAddressCommandVm, int>
    {
        private readonly IPersonAddressRepository _personAddressRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreatePersonAddressHandler> _logger;

        public CreatePersonAddressHandler(IPersonAddressRepository personAddressRepository, IMapper mapper,
            ILogger<CreatePersonAddressHandler> logger)
        {
            _personAddressRepository = personAddressRepository ?? throw new ArgumentNullException(nameof(personAddressRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        public async Task<int> Handle(CreatePersonAddressCommandVm request, CancellationToken cancellationToken)
        {
            var personAddressEntity = _mapper.Map<Person_Address>(request);
            var newPersonAddress = await _personAddressRepository.AddAsync(personAddressEntity);

            _logger.LogInformation($"Address {newPersonAddress.Id} is successfully created.");

            return newPersonAddress.Id;
        }
    }
}
