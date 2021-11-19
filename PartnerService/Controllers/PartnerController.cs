using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PartnerService.Modals;
using PartnerService.Repositories.Entity;
using PartnerService.Repositories.Interface;
using System.Collections.Generic;

namespace PartnerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnerController : ControllerBase
    {
        private readonly IPartnerRepository _partnerService;
        private readonly IMapper _mapper;

        public PartnerController(IPartnerRepository partnerService, IMapper mapper)
        {
            _partnerService = partnerService;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<Partner> Get()
        {
            return _mapper.Map<List<Partner>>(_partnerService.Get());
        }


        [HttpGet("email/{email}")]
        public IActionResult Get(string email)
        {
            var result = _partnerService.Get(email);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<Partner>(result));
        }

        [HttpGet("area-code/{code:int}")]
        public IActionResult GetByAreaCode(int code)
        {
            var result = _partnerService.GetByAreaCode(code);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<Partner>>(result));
        }

        // POST api/<PartnerController>
        [HttpPost]
        public Partner Post([FromBody] Partner partner)
        {
            return _mapper.Map<Partner>(_partnerService.Add(_mapper.Map<PartnerEntity>(partner)));
        }


        [HttpPut("{email}")]
        public IActionResult Put(string email, [FromBody] Partner partner)
        {
            var result = _partnerService.Get(email);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<Partner>(_partnerService.Update(email, _mapper.Map<PartnerEntity>(partner))));
        }
    }
}