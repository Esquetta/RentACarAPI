using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.CarColors.Commands.DeleteCarColor
{
    public class DeleteCarColorCommandValidator:AbstractValidator<DeleteCarColorCommand>
    {
        public DeleteCarColorCommandValidator()
        {
            RuleFor(x=>x.Id).NotEmpty();
        }
    }
}
