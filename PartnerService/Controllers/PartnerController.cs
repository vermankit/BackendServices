using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PartnerService.Modals;
using PartnerService.Repositories.Interface;

namespace PartnerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnerController : ControllerBase
    {
        private readonly IPartnerRepository _partnerService;

        public PartnerController(IPartnerRepository partnerService)
        {
            _partnerService = partnerService;
        }

        [HttpGet]
        public IEnumerable<Partner> Get()
        {
            return _partnerService.Get();
        }


        [HttpGet("{id:guid}")]
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


        [HttpPut("{id:guid}")]
        public void Put(Guid id, [FromBody] Partner partner)
        {
            _partnerService.Update(id, partner);
        }
    }
}