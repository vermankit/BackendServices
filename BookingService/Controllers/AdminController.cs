using AutoMapper;
using BookingService.Enums;
using BookingService.Repositories.Interface;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Shared.Clients.Interface;
using Shared.Message;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IBookingRepository _bookingService;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IPartnerClient _partnerClient;
        private readonly IConsumerClient _consumerClient;
        private readonly IConfiguration _configuration;


        public AdminController(IBookingRepository customerService
            , IMapper mapper, IPublishEndpoint publishEndpoint,
            IPartnerClient partnerClient, IConfiguration configuration, IConsumerClient consumerClient)
        {
            _bookingService = customerService;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
            _partnerClient = partnerClient;
            _configuration = configuration;
            _consumerClient = consumerClient;
        }

        //[HttpPatch("booking/{bookingId}/change-status/{status}")]
        //public IActionResult ApprovedBooking(Guid bookingId,Status status)
        //{
        //    var booking = _bookingService.Get(bookingId);

        //    if (booking == null)
        //    {
        //        return NotFound();
        //    }

        //    booking.Status = status;
        //    _bookingService.Update(bookingId,booking);
        //    return Ok();
        //}


        [HttpPatch("booking/{id}/assign-partner/{email}")]
        public async Task<IActionResult> AssignPartner(string id, string email)
        {
            var booking = _bookingService.Get(id);

            if (booking == null)
            {
                return NotFound();
            }
            var partner  = await _partnerClient.GetPartner(email);
            var customer = await _consumerClient.GetCustomer(booking.CustomerEmail);
            booking.ServiceProvideEmail = partner.Email;
            booking.Status = Status.Processing;
            await _publishEndpoint.Publish(new EmailMessage()
            {
                Message = $"Booking Received for Address : {customer.Address} , Contact Number {customer.PhoneNumber} SlotTime {booking.Slot} " +
                          $"Please click on below link to approve or deny" +
                          $"{_configuration["Application:Gateway"]}/booking/{id}/partner/{email}/change-status/2,{_configuration["Application:Gateway"]}booking/{id}/partner/{email}/change-status/5",
                Subject = "Booking Received",
                To = partner.Email
            });

            _bookingService.Update(booking.BookingNumber, booking);
            return Ok();
        }

        [HttpPatch("booking/{id}/partner/{email}/change-status/{status}")]
        public async Task<IActionResult> ChangeBookingStatus(string id, string email,Status status)
        {
            var booking = _bookingService.Get(id);

            if (booking == null)
            {
                return NotFound();
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

            _bookingService.Update(booking.BookingNumber, booking);
            return Ok();
        }

    }
}

