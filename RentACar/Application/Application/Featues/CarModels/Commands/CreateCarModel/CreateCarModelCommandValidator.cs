using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.CarModels.Commands.CreateCarModel
{
    public class CreateCarModelCommandValidator:AbstractValidator<CreateCarModelCommand>
    {
        public CreateCarModelCommandValidator()
        {
            RuleFor(x=>x.ModelName).NotEmpty();
            RuleFor(x => x.BrandId).NotEmpty();
        }
    }
}
