﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarsValidator:AbstractValidator<Car>
    {
        public CarsValidator()
        {
            RuleFor(c => c.CarName).MinimumLength(2);
            RuleFor(c=> c.DailyPrice).GreaterThan(0);
        }
    }
}
