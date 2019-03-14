using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using company_api.Model;
using company_api.DTO;

namespace company_api.Repository
{
    public interface ICompanyRepository
    {
        Guid AddCompany(CompanyEmployeeDTO item);
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
    }
}
