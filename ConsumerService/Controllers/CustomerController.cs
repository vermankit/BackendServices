using AutoMapper;
using ConsumerService.Modals;
using ConsumerService.Repositories.Entity;
using ConsumerService.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConsumerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerRepository customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _mapper.Map<List<Customer>>(_customerService.Get());
        }

        // GET api/<CustomerController>/5
        [HttpGet("{email}")]
        public IActionResult Get(string email)
        {
            var result = _customerService.Get(email);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<Customer>(result));
        }

        // POST api/<CustomerController>
        [HttpPost]
        public Customer Post([FromBody] Customer customer)
        {
            return _mapper.Map<Customer>(_customerService.Add(_mapper.Map<CustomerEntity>(customer)));
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{email}")]
        public IActionResult Put(string email, [FromBody] Customer customer)
        {
            var result = _customerService.Get(email);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<Customer>(_customerService.Update(email, _mapper.Map<CustomerEntity>(customer))));
        }


    }
}