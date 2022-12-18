using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.Photos.Commands.CreatePhoto
{
    public class CreatePhotoCommandValidator:AbstractValidator<CreatePhotoCommand>
    {
        public CreatePhotoCommandValidator()
        {
            RuleFor(x=>x.CarId).GreaterThanOrEqualTo(1);
            RuleFor(x => x.PublicId).NotEmpty();
            RuleFor(x => x.Url).NotEmpty();
            RuleFor(x=>x.IsMain).NotEmpty();
            
        }
    }
}
