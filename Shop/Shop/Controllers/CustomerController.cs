using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Shop.Models;
using Shop.ModelsDto;
using Shop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    [Route("/api/customers")]
    public class CustomerController : Controller
    {
        private IShopRepository _shopRepository;

        public CustomerController(IShopRepository shopRepository)
        {
            _shopRepository = shopRepository;
        }

        [HttpGet()]
        public IActionResult GetCustomers()
        {
            var customers = _shopRepository.GetCustomers();
            var customerToDisplay = Mapper.Map<IEnumerable<CustomerDto>>(customers);
            return Ok(customerToDisplay);
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomers(int id)
        {
            if(!_shopRepository.ExistCustomer(id))
            {
                return NotFound();
            }
            var customer = _shopRepository.GetCustomer(id);
            return Ok(customer);
        }

        [HttpPost()]
        public IActionResult AddCustomer([FromBody] CustomerForCreationDto customer)
        {
            if(customer == null)
            {
                return BadRequest();
            }

            var customerForPost = Mapper.Map<Customer>(customer);

            _shopRepository.AddCustomer(customerForPost);

            
            if(!_shopRepository.Save())
            {
                return StatusCode(500,"An internal server error occured. Please try again!");
            }

            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            
            if(!_shopRepository.ExistCustomer(id))
            {
                return NotFound();
            }

            _shopRepository.DeleteCustomer(id);

            if (!_shopRepository.Save())
            {
                return StatusCode(500, "An internal server error occured. Please try again!");
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer([FromBody] Customer customer, int id)
        {
            if(!_shopRepository.ExistCustomer(id))
            {
                return NotFound();
            }

            _shopRepository.UpdateCustomer(customer, id);

            if(!_shopRepository.Save())
            {
                return StatusCode(500, "An internal server error occured. Please try again!");
            }

            return Ok();
        }
    }
}
