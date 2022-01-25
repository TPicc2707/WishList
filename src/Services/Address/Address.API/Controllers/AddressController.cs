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

        public AddressController(IAddressRepository addressRepository, IPublishEndpoint publishEndpoint,
            IMapper mapper)
        {
            _addressRepository = addressRepository ?? throw new ArgumentNullException(nameof(addressRepository));
            _publishEndpoint  = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
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

        [Route("[action]/{ID}")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateAddress(string ID)
        {
            var address = await _addressRepository.GetPersonAddresses(ID);
            if(address == null)
            {
                return BadRequest();
            }

            foreach(var personAddress in address.PersonAddresses)
            {
                CreatePersonAddress newAddress = new CreatePersonAddress();
                newAddress.Person_Id = Convert.ToInt32(ID);
                newAddress.Street = personAddress.Street;
                newAddress.City = personAddress.City;
                newAddress.State = personAddress.State;
                newAddress.ZipCode = personAddress.ZipCode;

                var eventMessage = _mapper.Map<CreatePersonAddressEvent>(newAddress);
                await _publishEndpoint.Publish(eventMessage);
            }

            await _addressRepository.DeletePersonAddresses(address.PersonID);

            return Accepted();
        }

    }
}
