using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.CarModels.Commands.DeleteCarModel
{
    public class DeleteCarModelCommandValidator:AbstractValidator<DeleteCarModelCommand>
    {
        public DeleteCarModelCommandValidator()
        {
            RuleFor(x=>x.Id).NotEmpty();
        }
    }
}
