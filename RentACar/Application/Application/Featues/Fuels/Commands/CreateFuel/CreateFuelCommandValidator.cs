using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.Fuels.Commands.CreateFuel
{
    public class CreateFuelCommandValidator:AbstractValidator<CreateFuelCommand>
    {
        public CreateFuelCommandValidator()
        {
            RuleFor(x=>x.FuelType).NotEmpty();
                
        }
    }
}
