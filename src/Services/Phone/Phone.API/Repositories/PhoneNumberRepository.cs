using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Phone.API.Entities;
using System;
using System.Threading.Tasks;

namespace Phone.API.Repositories
{
    public class PhoneNumberRepository : IPhoneNumberRepository
    {
        private readonly IDistributedCache _redisCache;
        public PhoneNumberRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache ?? throw new ArgumentNullException(nameof(redisCache));
        }

        public async Task<PhoneNumbers> GetPersonPhoneNumbers(string ID)
        {
            var address = await _redisCache.GetStringAsync(ID);
            if (string.IsNullOrEmpty(address))
                return null;
            return JsonConvert.DeserializeObject<PhoneNumbers>(address);
        }

        public async Task<PhoneNumbers> UpdatePersonPhoneNumbers(PhoneNumbers phoneNumbers)
        {
            await _redisCache.SetStringAsync(phoneNumbers.PersonID, JsonConvert.SerializeObject(phoneNumbers));
            return await GetPersonPhoneNumbers(phoneNumbers.PersonID);
        }

        public async Task DeletePersonPhoneNumbers(string ID)
        {
            await _redisCache.RemoveAsync(ID);
        }

    }
}
