using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.GearBoxses.Commands.DeleteGearBox
{
    public class DeleteGearBoxCommandValidator:AbstractValidator<DeleteGearBoxCommand>
    {
        public DeleteGearBoxCommandValidator()
        {
            RuleFor(x=>x.Id);
        }
    }
}
