using Core.Utilities.Results;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcern.Validation
{
    public static class ValidationTool 
    {
       public static void Validate(IValidator validator,object entity)
        {
            var context = new ValidationContext<object>(entity);
            //UsersValidator usersValidator = new UsersValidator();
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}


