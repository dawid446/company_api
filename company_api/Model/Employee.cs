using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace company_api.Model
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid EmployeeID { get; set; }

        public String Name { get; set; }

        public String Surname { get; set; }

        public DateTime DateOfBirth { get; set; }

        public JobTitle JobTitle { get; set; }

        public Guid CompanyID { get; set; }
        public virtual Company Company { get; set; }

    }
    public enum JobTitle
    {
        Adnimistrator,
        Developer,
        Architect,
        Menager
    }
}
