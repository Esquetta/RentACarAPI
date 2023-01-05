using Application.Featues.Rents.Commands.CreateRent;
using Application.Featues.Rents.Commands.DeleteRent;
using Application.Featues.Rents.Commands.UpdateRent;
using Application.Featues.Rents.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RentACarAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles ="Manager")]
    public class RentController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRentCommand createRentCommand)
        {
            CreatedRentDto result = await Mediator.Send(createRentCommand);
            return Created("", result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateRentCommand updateRentCommand)
        {
            UpdatedRentDto result = await Mediator.Send(updateRentCommand);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteRentCommand deleteRentCommand)
        {
            DeletedRentDto result = await Mediator.Send(deleteRentCommand);
            return Ok(result);
        }
    }
}
