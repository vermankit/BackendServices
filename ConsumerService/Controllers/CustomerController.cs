using System;
using System.Collections.Generic;
using ConsumerService.Modals;
using ConsumerService.Services.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConsumerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _customerService.Get();
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public Customer Get(Guid id)
        {
            return _customerService.Get(id);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public Customer Post([FromBody] Customer customer)
        {
            return _customerService.Add(customer);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public Customer Put(Guid id, [FromBody] Customer customer)
        {
            return _customerService.Update(id, customer);
        }
    }
}