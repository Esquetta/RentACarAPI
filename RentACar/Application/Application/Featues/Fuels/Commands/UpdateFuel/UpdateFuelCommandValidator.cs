using Application.Featues.Fuels.Commands.DeleteFuel;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.Fuels.Commands.UpdateFuel
{
    public class UpdateFuelCommandValidator:AbstractValidator<UpdateFuelCommand>
    {
        public UpdateFuelCommandValidator()
        {
            RuleFor(x=>x.FuelType).NotEmpty();
        }
    }
}
