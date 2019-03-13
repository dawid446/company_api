using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace company_api.Model
{
    public class Company
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid CompanyID { get; set; }

        public String CompanyName { get; set; }

        public DateTime EstablishmentYear { get; set; }

        public virtual ICollection<Employee> Employee { get; set; } 

    }
}
