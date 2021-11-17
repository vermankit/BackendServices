using AutoMapper;
using BookingService.Modals;
using BookingService.Repositories.Entity;
using BookingService.Repositories.Interface;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Shared.Message;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Clients.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _bookingService;
        private readonly IMapper _mapper;
        private readonly IConsumerClient _consumerClient;


        public BookingController(IBookingRepository customerService, IMapper mapper, IConsumerClient consumerClient)
        {
            _bookingService = customerService;
            _mapper = mapper;
            _consumerClient = consumerClient;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<Booking> Get()
        {
            var result = _mapper.Map<List<Booking>>(_bookingService.Get());
            return result;
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id:guid}")]
        public Booking Get(Guid id)
        {
            var result = _mapper.Map<Booking>(_bookingService.Get());
            return result;
        }

        // POST api/<CustomerController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Booking booking)
        {
            var customer = await _consumerClient.GetCustomer(booking.CustomerEmail);

            if (customer == null)
            {
                return NotFound("Customer not found");
            }
            var bookingE = _mapper.Map<BookingEntity>(booking);
            var result = _mapper.Map<Booking>(_bookingService.Add(bookingE));
            return Ok(result);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id:guid}")]
        public Booking Put(Guid id, [FromBody] Booking booking)
        {
            var result = _bookingService.Update(id,_mapper.Map<BookingEntity>(booking));
            return _mapper.Map<Booking>(result); 
        }
    }
}

