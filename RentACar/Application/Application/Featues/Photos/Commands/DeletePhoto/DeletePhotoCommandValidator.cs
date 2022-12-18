using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.Photos.Commands.DeletePhoto
{
    public class DeletePhotoCommandValidator:AbstractValidator<DeletePhotoCommand>
    {
        public DeletePhotoCommandValidator()
        {
            RuleFor(x=>x.Id).NotEmpty();
        }
    }
}
