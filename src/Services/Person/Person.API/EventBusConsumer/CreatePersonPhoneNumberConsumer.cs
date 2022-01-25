using AutoMapper;
using EventBus.Messages.Events;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using Person.Application.Features.People_PhoneNumber.Commands.CreatePerson_PhoneNumber;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Person.API.EventBusConsumer
{
    public class CreatePersonPhoneNumberConsumer : IConsumer<CreatePersonPhoneNumberEvent>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<CreatePersonPhoneNumberConsumer> _logger;

        public CreatePersonPhoneNumberConsumer(IMediator mediator, IMapper mapper,
            ILogger<CreatePersonPhoneNumberConsumer> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Consume(ConsumeContext<CreatePersonPhoneNumberEvent> context)
        {
            var command = _mapper.Map<CreatePersonPhoneNumberCommandVm>(context.Message);
            var result = await _mediator.Send(command);

            _logger.LogInformation("CreatePersonPhoneEvent consumed successfully. Created Person Phone Number Id: {newPersonPhoneNumberId}", result);
        }
    }
}
