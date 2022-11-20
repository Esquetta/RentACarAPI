using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.GearBoxses.Commands.UpdateGearBox
{
    public class UpdateGearBoxCommandValidator:AbstractValidator<UpdateGearBoxCommand>
    {
        public UpdateGearBoxCommandValidator()
        {
            RuleFor(x => x.Speed).NotEmpty().GreaterThan(0);
            RuleFor(x => x.GearType).NotEmpty();
        }
    }
}
