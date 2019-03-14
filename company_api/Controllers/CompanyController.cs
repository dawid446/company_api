using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using company_api.DTO;
using company_api.Model;
using company_api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace company_api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CompanyController : Controller
    {

        private readonly ICompanyRepository _companyRepository;

        public CompanyController(ICompanyRepository companyRepitory)
        {
            _companyRepository = companyRepitory;
        }
        [HttpGet]
        public IEnumerable<Company> Get()
        {

            return _companyRepository.GetCompanies();
        }


        [Route("create")]
        [HttpPost]
        public IActionResult Post([FromBody]CompanyEmployeeDTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var companyid = _companyRepository.AddCompany(value);

            return Ok(new { id = companyid });
           
        }

        [Route("search")]
        [HttpPost]
        public IActionResult Search([FromBody]SearchDTO search)
        {
            
            return Ok(_companyRepository.Search(search));
        }
        
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string value)
        {
            return Ok();
        }

        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
