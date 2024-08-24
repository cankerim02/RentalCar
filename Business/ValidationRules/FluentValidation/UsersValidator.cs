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
            //@"@domain\.com$" --- @domain kısmı e-posta domaini ,
            //\. karakter özel anlamı kaybedip nokta olarak sağlaması, $ işareti domain kısmının e posta sonunda olduğunu belirtir.
            RuleFor(p => p.Email).NotEmpty().Matches(@"@gmail\.com$").WithMessage("Email must be from the domain @gmail.com");
            RuleFor(p => p.Email).EmailAddress().When(p => !string.IsNullOrEmpty(p.Email));
            RuleFor(p => p.Passwords).NotEmpty().MinimumLength(8).WithMessage("Password must be  at least 8 characters long");

        }
    }
}
