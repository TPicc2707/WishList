using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Person.Application.Contracts.Persistence;
using Person.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Person.Application.Features.People.Commands.UpdatePerson
{
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommandVm>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdatePersonCommandHandler> _logger;

        public UpdatePersonCommandHandler(IPersonRepository personRepository, IMapper mapper,
            ILogger<UpdatePersonCommandHandler> logger)
        {
            _personRepository = personRepository ?? throw new ArgumentNullException(nameof(personRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(UpdatePersonCommandVm request, CancellationToken cancellationToken)
        {
            var personToUpdate = await _personRepository.GetByIdAsync(request.Id);
            if (personToUpdate == null)
                throw new NotFoundException(nameof(Domain.Entities.Person), request.Id);

            _mapper.Map(request, personToUpdate, typeof(UpdatePersonCommandVm), typeof(Domain.Entities.Person));

            int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            int dob = int.Parse(personToUpdate.DateOfBirth.ToString("yyyyMMdd"));
            personToUpdate.Age = (now - dob) / 10000;

            await _personRepository.UpdateAsync(personToUpdate);

            _logger.LogInformation($"Order {personToUpdate.Id} is successfully updated");

            return Unit.Value;
        }
    }
}
