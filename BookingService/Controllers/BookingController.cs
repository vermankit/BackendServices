using AutoMapper;
using BookingService.Enums;
using BookingService.Modals;
using BookingService.Repositories.Entity;
using BookingService.Repositories.Interface;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Shared.Clients.Interface;
using Shared.Message;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        private readonly IPartnerClient _partnerClient;
        private readonly IPublishEndpoint _publishEndpoint;


        public BookingController(IBookingRepository customerService, IMapper mapper, IConsumerClient consumerClient, IPartnerClient partnerClient, IPublishEndpoint publishEndpoint)
        {
            _bookingService = customerService;
            _mapper = mapper;
            _consumerClient = consumerClient;
            _partnerClient = partnerClient;
            _publishEndpoint = publishEndpoint;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<Booking> Get()
        {
            var result = _mapper.Map<List<Booking>>(_bookingService.Get());
            return result;
        }

        // GET api/<CustomerController>/5
        [HttpGet("{bookingNumber}")]
        public Booking Get(string bookingNumber)
        {
            var result = _mapper.Map<Booking>(_bookingService.Get(bookingNumber));
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
        [HttpPut("{bookingNumber}")]
        public Booking Put(string bookingNumber, [FromBody] Booking booking)
        {
            var result = _bookingService.Update(bookingNumber, _mapper.Map<BookingEntity>(booking));
            return _mapper.Map<Booking>(result);
        }


        [HttpPatch("{id}/partner/{email}/change-status/{status}")]
        public async Task<IActionResult> ChangeBookingStatus(string id, string email, Status status)
        {
            var booking = _bookingService.Get(id);

            if (booking == null)
            {
                return NotFound();
            }

            if (booking.Status == Status.Confirmed)
            {
                return Ok("Booking Already Confirmed");
            }

            var partner = await _partnerClient.GetPartner(email);
            var customer = await _consumerClient.GetCustomer(booking.CustomerEmail);

            if (partner == null)
            {
                return NotFound();
            }

            booking.Status = status;
            await _publishEndpoint.Publish(new EmailMessage()
            {
                Message = $"Partner Assigned for booking {booking.RequestedService} at {booking.Slot} Partner Contact Number {partner.PhoneNumber}",
                Subject = "Booking Confirmed",
                To = customer.Email
            });

            var result = _bookingService.Update(booking.BookingNumber, booking);
            return Ok(_mapper.Map<Booking>(result));
        }
    }
}

