using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.Brands.Commands.UpdateBrand
{
    public class UpdateBrandCommandValidator:AbstractValidator<UpdateBrandCommand>
    {
        public UpdateBrandCommandValidator()
        {
            RuleFor(x=>x.Id).NotEmpty();
            RuleFor(x=>x.BrandName).NotEmpty();


        }
    }
}
