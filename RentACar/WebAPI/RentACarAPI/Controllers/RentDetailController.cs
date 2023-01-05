using Application.Featues.RentDetails.Commands.CreateRentDetail;
using Application.Featues.RentDetails.Commands.DeleteRentDetail;
using Application.Featues.RentDetails.Commands.UpdateRentDetail;
using Application.Featues.RentDetails.Dtos;
using Application.Featues.RentDetails.Queries.GetRentById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace RentACarAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Manager")]
    public class RentDetailController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRentDetailCommand createRentDetailCommand)
        {
            CreatedRentDetailDto result = await Mediator.Send(createRentDetailCommand);
            return Created("", result);
        }
        //[HttpPut]
        //public async Task<IActionResult> Update([FromBody] UpdateRentDetailCommand updateRentDetailCommand)
        //{
        //    UpdatedRentDetailDto result = await Mediator.Send(updateRentDetailCommand);
        //    return Ok(result);
        //}
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteRentDetailCommand deleteRentDetailCommand)
        {
            DeletedRentDetailDto result = await Mediator.Send(deleteRentDetailCommand);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] GetRentByIdQuery getRentByIdQuery)
        {
            RentDetailListViewDto result = await Mediator.Send(getRentByIdQuery);
            return Ok(result);

        }
    }
}
