using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomersValidator:AbstractValidator<Customer>
    {
        public CustomersValidator()
        {
            RuleFor(c=>c.CompanyName).NotEmpty().WithMessage("Company name boş olamaz.");
        }
    }
}
