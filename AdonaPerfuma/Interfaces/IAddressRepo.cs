using AdonaPerfuma.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdonaPerfuma.Interfaces
{
    public interface IAddressRepo
    {
        public Task<Address> GetAddressById(int id);

        public Task<int> AddAddress(Address address);

        public Task UpdateAddress(int id,Address modifiedAddress);

        public Task DeleteAddress(int id);
    }
}
