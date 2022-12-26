using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Featues.Rents.Commands.CreateRent.CreateRentCommand;

namespace Application.Featues.Rents.Commands.CreateRent
{
    public class CreateRentCommandValidator:AbstractValidator<CreateRentCommand>
    {
        public CreateRentCommandValidator()
        {
            RuleFor(x=>x.userId).NotEmpty();
            RuleFor(x=>x.ReturnDate).NotEmpty();
            RuleFor(x => x.DateOfIssue).NotEmpty();
            
        }
    }
}
