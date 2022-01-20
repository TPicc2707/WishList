using Address.API.Entities;
using Address.API.Repositories;
using AutoMapper;
using EventBus.Messages.Events;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Address.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IMapper _mapper;
        public AddressController(IAddressRepository addressRepository, IMapper mapper,
            IPublishEndpoint publishEndpoint)
        {
            _addressRepository = addressRepository ?? throw new ArgumentNullException(nameof(addressRepository));
            _mapper  = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _publishEndpoint  = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
        }
        [HttpGet("{ID}", Name = "GetAddresses")]
        [ProducesResponseType(typeof(Addresses), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Addresses>> GetAddresses(string ID)
        {
            var addresses = await _addressRepository.GetPersonAddresses(ID);
            return Ok(addresses ?? new Addresses(ID));
        }

        [HttpPost]
        [ProducesResponseType(typeof(Addresses), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Addresses>> UpdateAddresses([FromBody] Addresses addresses)
        {
            return Ok(await _addressRepository.UpdatePersonAddresses(addresses));
        }

        [HttpDelete("{ID}", Name = "DeleteAddresses")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]

        public async Task<IActionResult> DeleteAddresses(string ID)
        {
            await _addressRepository.DeletePersonAddresses(ID);
            return Ok();
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateAddress([FromBody] CreatePersonAddress personAddress)
        {
            var address = await _addressRepository.GetPersonAddresses(personAddress.Person_Id.ToString());
            if(address == null)
            {
                return BadRequest();
            }

            var eventMessage = _mapper.Map<CreatePersonAddressEvent>(personAddress);
            await _publishEndpoint.Publish(eventMessage);

            await _addressRepository.DeletePersonAddresses(address.PersonID);

            return Accepted();
        }

    }
}
