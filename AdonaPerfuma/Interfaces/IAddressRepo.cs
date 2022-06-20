using AdonaPerfuma.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdonaPerfuma.Interfaces
{
    public interface IAddressRepo
    {
        Task<Address> GetAddressById(int id);

        Task<int> AddAddress(Address address);

        Task UpdateAddress(int id,Address modifiedAddress);

        Task DeleteAddress(int id);
    }
}
