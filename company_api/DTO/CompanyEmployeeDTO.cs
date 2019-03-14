using company_api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace company_api.DTO
{
    public class CompanyEmployeeDTO
    {
      
        
        public String CompanyName { get; set; }

        public DateTime EstablishmentYear { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
