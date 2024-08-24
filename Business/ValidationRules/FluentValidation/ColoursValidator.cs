using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ColoursValidator : AbstractValidator<Colour>
    {
        public ColoursValidator()
        {
            RuleFor(p => p.ColourName).NotEmpty().WithMessage("Colour cannot be empty");
        }
    }
}
