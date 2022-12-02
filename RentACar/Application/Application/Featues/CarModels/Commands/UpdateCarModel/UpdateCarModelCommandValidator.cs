using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.CarModels.Commands.UpdateCarModel
{
    public class UpdateCarModelCommandValidator:AbstractValidator<UpdateCarModelCommand>
    {
        public UpdateCarModelCommandValidator()
        {
            RuleFor(x=>x.ModelName).NotEmpty();
            RuleFor(x=>x.BrandId).NotEmpty();
        }
    }
}
