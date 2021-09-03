using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;
using DataEntity;
using FluentValidation;

namespace Business
{
    public class EventValidator : AbstractValidator<EventObject>
    {
        public EventValidator()
        {
            RuleFor(model => model.Title).NotEmpty().WithMessage("Title is Required");
            RuleFor(model => model.Date).NotEmpty().WithMessage("Date is Required");
            RuleFor(model => model.Location).NotEmpty().WithMessage("Location is Required");
            RuleFor(model => model.StartTime).NotEmpty().WithMessage("Start Time is Required");
            RuleFor(model => model.Duration).InclusiveBetween(0,4).WithMessage("Duration should be between 0-4 hrs");
        }
    }
}
