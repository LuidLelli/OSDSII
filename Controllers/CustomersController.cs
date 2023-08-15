using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using OsDsII.api.Models;


namespace OSDSII.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private static List<Customer> _customer = new List<Customer>();
        private static int _nextId = 1;

        
        [HttpGet("GetAll")]
        public IActionResult GetAllCustomers()
        {
            return Ok(_customer);
        }

        
        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            Customer customer = _customer.Find(c => c.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        
        [HttpPost]
        public IActionResult CreateCustomer([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest("Invalido");
            }

            customer.Id = _nextId++;
            _customer.Add(customer);

            return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Id }, customer);
        }

        
        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, [FromBody] Customer updatedCustomer)
        {
            Customer existingCustomer = _customer.Find(c => c.Id == id);

            if (existingCustomer == null)
            {
                return NotFound();
            }

            existingCustomer.Name = updatedCustomer.Name;
            existingCustomer.Email = updatedCustomer.Email;

            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            Customer customer = _customer.Find(c => c.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            _customer.Remove(customer);

            return NoContent();
        }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
