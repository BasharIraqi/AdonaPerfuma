using AdonaPerfuma.DB;
using AdonaPerfuma.Interfaces;
using AdonaPerfuma.Models;
using System.Threading.Tasks;

namespace AdonaPerfuma.Repositories
{
    public class AddressRepo : IAddressRepo
    {
        private readonly PerfumaContext _context;

        public AddressRepo(PerfumaContext context)
        {
            _context = context;
        }

        public async Task<int> AddAddress(Address address)
        {
           var id=await _context.AddAsync(address);
            return address.Id;
        }

        public async Task DeleteAddress(int id)
        {
            var address = await _context.Addresses.FindAsync(id);
            
                _context.Addresses.Remove(address);
                await _context.SaveChangesAsync();
           
        }

        public async Task<Address> GetAddresstById(int id)
        {
            var address = await _context.Addresses.FindAsync(id);
            if (address != null)
            {
                return address;
            }
            else
                return null;
        }

        public async Task UpdateAddress(int id, Address modifiedAddress)
        {
            var address=await _context.Addresses.FindAsync(id);

            if (address != null)
            {
                address.Street = modifiedAddress.Street;
                address.HouseNumber = modifiedAddress.HouseNumber;
                address.PostalCode = modifiedAddress.PostalCode;
                address.City = modifiedAddress.City;
                address.Country = modifiedAddress.Country;

                _context.Addresses.Update(address);
                await _context.SaveChangesAsync();
            }
        }
    }
}
