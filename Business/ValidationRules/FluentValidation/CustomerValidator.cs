using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
   public class CustomerValidator:AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.CompanyName).NotEmpty().MinimumLength(2);
            RuleFor(c => c.Id).NotEmpty().GreaterThan(0);
            RuleFor(c => c.UserId).NotEmpty().GreaterThan(0);
        }
    }
}
