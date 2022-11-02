using AdonaPerfuma.DB;
using AdonaPerfuma.Interfaces;
using AdonaPerfuma.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public async Task<List<Address>> GetAddresses()
        {
            var addresses=await _context.Addresses.ToListAsync();

            return addresses;
        }

        public async Task<int> AddAddress(Address address)
        {
            var isAddressExist = await _context.Addresses.SingleOrDefaultAsync(a => a.PostalCode == address.PostalCode
            && a.Country == address.Country
            && a.HouseNumber == address.HouseNumber
            && a.City == address.City
            && a.Street==address.Street);

            if (isAddressExist == null)
            {
                await _context.Addresses.AddAsync(address);
                await _context.SaveChangesAsync();

                return address.Id;
            }

            else
            {
                return -1;
            }
        }

        public async Task DeleteAddress(int id)
        {
            var address = await _context.Addresses.FindAsync(id);
            
                _context.Addresses.Remove(address);
                await _context.SaveChangesAsync();
           
        }

        public async Task<Address> GetAddressById(int id)
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
