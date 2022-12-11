using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.Cars.Commands.CreateCar
{
    public class CreateCarCommandValidator:AbstractValidator<CreateCarCommand>
    {
        public CreateCarCommandValidator()
        {
            RuleFor(x=>x.CarColorId).NotEmpty();
            RuleFor(x => x.HorsePower).NotEmpty();
            RuleFor(x => x.CarModelId).NotEmpty();
            RuleFor(x => x.Price).NotEmpty();
            RuleFor(x => x.BrandId).NotEmpty();
            RuleFor(x => x.Miles).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.FuelId).NotEmpty();
            RuleFor(x => x.For_Rent).NotEmpty();
            RuleFor(x => x.GearBoxId).NotEmpty();
            RuleFor(x => x.ProductionDate).NotEmpty();
            
        }
    }
}
