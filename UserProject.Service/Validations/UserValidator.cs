using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProject.Core.Models;

namespace UserProject.Service.Validations
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.GSM).NotNull().WithMessage("{PropertyName} is required.").NotEmpty().WithMessage("{PropertyName} is required.").Length(11).WithMessage("{PropertyName} must have 11 characters.");
            RuleFor(x => x.FirstName).NotNull().WithMessage("{PropertyName} is required.").NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.FirstName).NotNull().WithMessage("{PropertyName} is required.").NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.BirthDate).NotNull().WithMessage("{PropertyName} is required.").NotEmpty().WithMessage("{PropertyName} is required.").LessThan(DateTime.Now).WithMessage("{PropertyName} must be older than present time.");
            RuleFor(x => x.Email).NotNull().WithMessage("{PropertyName} is required.").NotEmpty().WithMessage("{PropertyName} is required.").EmailAddress().WithMessage("{PropertyName} is not exist.");
        }
    }
}
