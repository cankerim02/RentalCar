using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UsersValidator : AbstractValidator<User>
    {
        public UsersValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty();
            RuleFor(p => p.LastName).NotEmpty();
            RuleFor(p => p.Email).EmailAddress().When(p => !string.IsNullOrEmpty(p.Email));
            RuleFor(p => p.Passwords).NotEmpty();
        }
    }
}
