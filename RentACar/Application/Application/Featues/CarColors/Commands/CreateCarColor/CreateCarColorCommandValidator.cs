using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.CarColors.Commands.CreateCarColor
{
    public class CreateCarColorCommandValidator:AbstractValidator<CreateCarColorCommand>
    {
        public CreateCarColorCommandValidator()
        {
            RuleFor(x=>x.Color).NotEmpty();
        }
    }
}
