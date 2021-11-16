using AutoMapper;
using BookingService.Enums;
using BookingService.Repositories.Interface;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Shared.Clients.Interface;

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

        public AdminController(IBookingRepository customerService
            , IMapper mapper, IPublishEndpoint publishEndpoint,
            IPartnerClient partnerClient)
        {
            _bookingService = customerService;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
            _partnerClient = partnerClient;
        }

        [HttpPatch("booking/{bookingId}/change-status/{status}")]
        public IActionResult ApprovedBooking(Guid bookingId,Status status)
        {
            var booking = _bookingService.Get(bookingId);

            if (booking == null)
            {
                return NotFound();
            }

            booking.Status = status;
            _bookingService.Update(bookingId,booking);
            return Ok();
        }


        [HttpPatch("booking/{Id}/assign-partner/{email}")]
        public async Task<IActionResult> AssignPartner(Guid Id, string email)
        {
            var booking = _bookingService.Get(Id);

            if (booking == null)
            {
                return NotFound();
            }

            var partner  = await _partnerClient.GetPartner(email);
            booking.ServiceProvideEmail = partner.Email;
            _bookingService.Update(Id, booking);
            return Ok();
        }

    }
}

