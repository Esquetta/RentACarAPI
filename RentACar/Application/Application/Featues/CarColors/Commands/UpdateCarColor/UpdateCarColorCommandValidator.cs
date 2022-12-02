using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.CarColors.Commands.UpdateCarColor
{
    public  class UpdateCarColorCommandValidator:AbstractValidator<UpdateCarColorCommand>
    {
        public UpdateCarColorCommandValidator()
        {
            RuleFor(X=>X.Color).NotEmpty();
        }
    }
}
