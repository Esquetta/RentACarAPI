using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.GearBoxses.Commands.CreateGearBox
{
    public class CreateGearBoxCommandValidator:AbstractValidator<CreateGearBoxCommand>
    {
        public CreateGearBoxCommandValidator()
        {
            RuleFor(x=>x.Speed).NotEmpty().GreaterThan(0);
            RuleFor(x=>x.GearType).NotEmpty();
        }
    }
}
