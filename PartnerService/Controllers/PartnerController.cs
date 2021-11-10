using Microsoft.AspNetCore.Mvc;
using PartnerService.Modals;
using System.Collections.Generic;


namespace PartnerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnerController : ControllerBase
    {

        public PartnerController()
        {

        }

        [HttpGet]
        public IEnumerable<Partner> Get()
        {
            return System.Array.Empty<Partner>();
        }


        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PartnerController>
        [HttpPost]
        public void Post([FromBody] Partner partner)
        {
        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Partner partner)
        {
        }

    }
}
