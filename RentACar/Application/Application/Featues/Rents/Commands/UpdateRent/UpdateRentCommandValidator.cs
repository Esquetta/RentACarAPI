using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.Rents.Commands.UpdateRent
{
    public class UpdateRentCommandValidator:AbstractValidator<UpdateRentCommand>
    {
        public UpdateRentCommandValidator()
        {
            RuleFor(x => x.userId).NotEmpty();
            RuleFor(x => x.ReturnDate).NotEmpty();
            RuleFor(x => x.DateOfIssue).NotEmpty();
        }
    }
}
