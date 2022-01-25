using AutoMapper;
using EventBus.Messages.Events;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Phone.API.Entities;
using Phone.API.Repositories;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Phone.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PhoneNumberController : ControllerBase
    {
        private readonly IPhoneNumberRepository _phoneNumberRepository;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IMapper _mapper;

        public PhoneNumberController(IPhoneNumberRepository phoneNumberRepository, IPublishEndpoint publishEndpoint,
            IMapper mapper)
        {
            _phoneNumberRepository = phoneNumberRepository ?? throw new ArgumentNullException(nameof(phoneNumberRepository));
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("{ID}", Name = "GetPhoneNumbers")]
        [ProducesResponseType(typeof(PhoneNumbers), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PhoneNumbers>> GetPhoneNumbers(string ID)
        {
            var phoneNumbers = await _phoneNumberRepository.GetPersonPhoneNumbers(ID);
            return Ok(phoneNumbers ?? new PhoneNumbers(ID));
        }

        [HttpPost]
        [ProducesResponseType(typeof(PhoneNumbers), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PhoneNumbers>> UpdatePhoneNumbers([FromBody] PhoneNumbers phoneNumbers)
        {
            return Ok(await _phoneNumberRepository.UpdatePersonPhoneNumbers(phoneNumbers));
        }

        [HttpDelete("{ID}", Name = "DeletePhoneNumbers")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]

        public async Task<IActionResult> DeletePhoneNumbers(string ID)
        {
            await _phoneNumberRepository.DeletePersonPhoneNumbers(ID);
            return Ok();
        }

        [Route("[action]/{ID}")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreatePhoneNumber(string ID)
        {
            var phoneNumber = await _phoneNumberRepository.GetPersonPhoneNumbers(ID);
            if (phoneNumber == null)
            {
                return BadRequest();
            }

            foreach (var personPhoneNumber in phoneNumber.Person_PhoneNumbers)
            {
                CreatePersonPhoneNumber newPhoneNumber = new CreatePersonPhoneNumber();
                newPhoneNumber.Person_Id = Convert.ToInt32(ID);
                newPhoneNumber.Type = personPhoneNumber.Type;
                newPhoneNumber.CountryCode = personPhoneNumber.CountryCode;
                newPhoneNumber.AreaCode = personPhoneNumber.AreaCode;
                newPhoneNumber.TelephoneNumber = personPhoneNumber.TelephoneNumber;

                var eventMessage = _mapper.Map<CreatePersonPhoneNumberEvent>(newPhoneNumber);
                await _publishEndpoint.Publish(eventMessage);
            }

            await _phoneNumberRepository.DeletePersonPhoneNumbers(phoneNumber.PersonID);

            return Accepted();
        }

    }
}
