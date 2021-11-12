using System;
using System.Collections.Generic;
using BookingService.Modals;
using BookingService.Services.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService customerService)
        {
            _bookingService = customerService;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<Booking> Get()
        {
            return _bookingService.Get();
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id:guid}")]
        public Booking Get(Guid id)
        {
            return _bookingService.Get(id);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public Booking Post([FromBody] Booking customer)
        {
            return _bookingService.Add(customer);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id:guid}")]
        public Booking Put(Guid id, [FromBody] Booking customer)
        {
            return _bookingService.Update(id, customer);
        }
    }
}




