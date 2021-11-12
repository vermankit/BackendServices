using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PartnerService.Modals;
using PartnerService.Services.Interface;

namespace PartnerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnerController : ControllerBase
    {
        private readonly IPartnerService _partnerService;

        public PartnerController(IPartnerService partnerService)
        {
            _partnerService = partnerService;
        }

        [HttpGet]
        public IEnumerable<Partner> Get()
        {
            return _partnerService.Get();
        }


        [HttpGet("{id}")]
        public Partner Get(Guid id)
        {
            return _partnerService.Get(id);
        }

        // POST api/<PartnerController>
        [HttpPost]
        public Partner Post([FromBody] Partner partner)
        {
            return _partnerService.Add(partner);
        }


        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Partner partner)
        {
            _partnerService.Update(id, partner);
        }
    }
}