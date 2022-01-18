using Address.API.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Address.API.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly IDistributedCache _redisCache;
        public AddressRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache ?? throw new ArgumentNullException(nameof(redisCache));
        }

        public async Task<Addresses> GetPersonAddresses(string ID)
        {
            var address = await _redisCache.GetStringAsync(ID);
            if (string.IsNullOrEmpty(address))
                return null;
            return JsonConvert.DeserializeObject<Addresses>(address);
        }

        public async Task<Addresses> UpdatePersonAddresses(Addresses address)
        {
            await _redisCache.SetStringAsync(address.PersonID, JsonConvert.SerializeObject(address));
            return await GetPersonAddresses(address.PersonID);
        }

        public async Task DeletePersonAddresses(string ID)
        {
            await _redisCache.RemoveAsync(ID);
        }

    }
}
