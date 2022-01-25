using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Person.Application.Contracts.Persistence;
using Person.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Person.Application.Features.People_PhoneNumber.Commands.CreatePerson_PhoneNumber
{
    public class CreatePersonPhoneNumberCommandHandler : IRequestHandler<CreatePersonPhoneNumberCommandVm, int>
    {
        private readonly IPersonPhoneNumberRepository _personPhoneNumberRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreatePersonPhoneNumberCommandHandler> _logger;

        public CreatePersonPhoneNumberCommandHandler(IPersonPhoneNumberRepository personPhoneNumberRepository, IMapper mapper,
            ILogger<CreatePersonPhoneNumberCommandHandler> logger)
        {
            _personPhoneNumberRepository = personPhoneNumberRepository ?? throw new ArgumentNullException(nameof(personPhoneNumberRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> Handle(CreatePersonPhoneNumberCommandVm request, CancellationToken cancellationToken)
        {
            var personPhoneNumberEntity = _mapper.Map<Person_PhoneNumber>(request);
            var newPersonPhoneNumber = await _personPhoneNumberRepository.AddAsync(personPhoneNumberEntity);

            _logger.LogInformation($"Address {newPersonPhoneNumber.Id} is successfully created.");

            return newPersonPhoneNumber.Id;
        }
    }
}
