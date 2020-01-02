using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidationExercise.Models;

namespace FluentValidationExercise.Validator
{
    public class PersonValidator: AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(p => p.Name)
                .NotNull().WithMessage("{name}不能为空");

            RuleFor(p => p.Age)
                .GreaterThan(18).WithMessage("不能超过18");
        }
    }
}
