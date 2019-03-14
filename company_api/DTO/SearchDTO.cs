using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using company_api.Model;
namespace company_api.DTO
{
    public class SearchDTO
    {
       public String Keyword { get; set; }
       public DateTime EmployeeDateOfBirthFrom { get; set; }
       public DateTime EmployeeDateOfBirthTo { get; set; }
       public JobTitle EmployeeJobTitles { get; set; }
    }

}
