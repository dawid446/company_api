using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using company_api.DTO;
using company_api.Model;
using Microsoft.AspNetCore.Mvc;

namespace company_api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ValuesController : Controller
    {
        private readonly ApplicationContext _context;

        public ValuesController(ApplicationContext application)
        {
            _context = application;
        }
        [HttpGet]
        public IEnumerable<Company> Get()
        {

            return _context.Company.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(Guid id)
        {
          
            return "value";
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]CompanyEmployeeDTO value)
        {
            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
