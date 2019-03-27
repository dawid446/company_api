using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using company_api.Model;
using company_api.DTO;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace company_api.Repository
{
    public interface ICompanyRepository
    {
        Guid AddCompany(CompanyEmployeeDTO item);
        List<Company> Search(SearchDTO search);
        IEnumerable<Company> GetCompanies();

    }
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationContext _context;

        public CompanyRepository(ApplicationContext application)
        {
            _context = application;
        }

        public Guid AddCompany(CompanyEmployeeDTO item)
        {
            try
            {
                var company = new Company
                {
                    CompanyName = item.CompanyName,
                    EstablishmentYear = item.EstablishmentYear,
                    Employee = item.Employees

                };
                _context.Company.Add(company);
                _context.SaveChanges();

                return company.CompanyID; 
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public IEnumerable<Company> GetCompanies()
        {
            return _context.Company.ToList();
        }

        public List<Company> Search(SearchDTO search)
        {
            List<Company> company = _context.Company
                .Where(s => search.Keyword
                .All(k => s.CompanyName.Contains(k)))
                .Include(x=> x.Employee).ToList();
            
           return company;
        }
    }
}
