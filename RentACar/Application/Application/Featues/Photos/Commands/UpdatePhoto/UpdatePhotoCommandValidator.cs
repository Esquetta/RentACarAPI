using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.Photos.Commands.UpdatePhoto
{
    public class UpdatePhotoCommandValidator:AbstractValidator<UpdatePhotoCommand>
    {
        public UpdatePhotoCommandValidator()
        {
            RuleFor(x => x.CarId).GreaterThanOrEqualTo(1);
            RuleFor(x => x.PublicId).NotEmpty();
            RuleFor(x => x.Url).NotEmpty();
            RuleFor(x => x.IsMain).NotEmpty();
            RuleFor(x=>x.Id).NotEmpty();
        }

    }
}
