using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.Fuels.Commands.DeleteFuel
{
    public class DeleteFuelCommandValidator:AbstractValidator<DeleteFuelCommand>
    {
        public DeleteFuelCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
