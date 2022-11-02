using AdonaPerfuma.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdonaPerfuma.Interfaces
{
    public interface IAddressRepo
    {
        Task<List<Address>> GetAddresses();
        Task<Address> GetAddressById(int id);

        Task<int> AddAddress(Address address);

        Task UpdateAddress(int id,Address modifiedAddress);

        Task DeleteAddress(int id);
    }
}
