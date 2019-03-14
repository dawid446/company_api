using company_api.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using company_api.DTO;

namespace company_api.Validators
{
    public class CompanyValidator : AbstractValidator<CompanyEmployeeDTO>
    {
        public CompanyValidator()
        {
            RuleFor(x => x.CompanyName)
                .NotEmpty()
                .MaximumLength(100);

            RuleForEach(x => x.Employees)
                .SetValidator(new EmployeeValidator())
                .When(x => x.Employees != null);
            
                
        }
    }

    public class EmployeeValidator : AbstractValidator<Employee>
    {

        public EmployeeValidator()
        {
            RuleFor(x => x.DateOfBirth).NotEmpty();
            RuleFor(x => x.JobTitle).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Surname).NotEmpty();
        }
    }
}
