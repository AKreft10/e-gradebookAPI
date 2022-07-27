using e_gradebookAPI.Data;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_gradebookAPI.Dtos.Validators
{
    public class RegisterStudentDtoValidator : AbstractValidator<RegisterStudentDto>
    {
        public RegisterStudentDtoValidator(AppDbContext dbContext)
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.FirstName)
                .MinimumLength(3)
                .NotEmpty();

            RuleFor(x => x.LastName)
                .MinimumLength(3)
                .NotEmpty();

            RuleFor(x => x.Email)
                .Custom((value, context) =>
                {
                    var emailInUse = dbContext.Students.Any(z => z.Email == value);

                    if (emailInUse)
                        context.AddFailure("Email", "That email is taken");
                });




        }
    }
}
