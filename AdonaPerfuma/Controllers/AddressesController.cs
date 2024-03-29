﻿using AdonaPerfuma.Interfaces;
using AdonaPerfuma.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdonaPerfuma.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressRepo _repo;

        public AddressesController(IAddressRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Manager,General")]
        public async Task<IActionResult> GetAddresses()
        {
            var addresses = await _repo.GetAddresses();
            
            return Ok(addresses);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Manager,General,Customer")]
        public async Task<IActionResult> GetAddress([FromRoute]int id)
        {
            var address =await _repo.GetAddressById(id);
            if (address == null)
                return NotFound();
            else
                return Ok(address);
        }

        [HttpPost]
        public async Task<IActionResult> AddAddress(Address address)
        {
            var id= await _repo.AddAddress(address);

            if (id != -1)
            return Ok(id);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            await _repo.DeleteAddress(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAddress([FromRoute] int id, [FromBody] Address modifiedAddress)
        {
             await _repo.UpdateAddress(id, modifiedAddress);
            return Ok();
        }
    }
}
