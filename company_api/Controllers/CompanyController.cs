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
    public class CompanyController : Controller
    {
        private readonly ApplicationContext _context;

        public CompanyController(ApplicationContext application)
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Company company;
            if(value.Employees != null)
            {
                company = new Company
                {
                    CompanyName = value.CompanyName,
                    EstablishmentYear = value.EstablishmentYear,
                    Employee = value.Employees
                };
            }
            else
            {
                company = new Company
                {
                    CompanyName = value.CompanyName,
                    EstablishmentYear = value.EstablishmentYear,
                    
                };
            }
            
            _context.Company.Add(company);
               
            _context.SaveChanges();

            return Ok (new { id = company.CompanyID});
        }

        [HttpPost]
        public IActionResult Search()
        {
            return Ok();
        }
        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string value)
        {
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
