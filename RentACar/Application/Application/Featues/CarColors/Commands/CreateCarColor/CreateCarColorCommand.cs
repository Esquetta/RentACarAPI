using Application.Featues.CarColors.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.CarColors.Commands.CreateCarColor
{
    public class CreateCarColorCommand:IRequest<CreatedCarColor>
    {
    }
}
