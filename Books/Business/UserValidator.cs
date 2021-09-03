using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;
using DataEntity;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Business
{
    public class UserValidator : AbstractValidator<UserObject>
    {
        public UserValidator()
        {
            RuleFor(model => model.Email).NotEmpty().WithMessage("Email is Required");
            RuleFor(model => model.Password).NotEmpty().WithMessage("Password is Required");
            RuleFor(model => model.FullName).NotEmpty().WithMessage("Full Name is Required");
            RuleFor(model => model.Email).EmailAddress().WithMessage("Please enter a valid Email ID");
            RuleFor(model => model.Password).Matches(@"^.*(?=.{6,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$").WithMessage("Password must be at least 6 characters and contains at least one special character, number and Upper case character");
        }
    }
}
