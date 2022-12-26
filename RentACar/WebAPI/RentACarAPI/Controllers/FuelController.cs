using Application.Featues.Fuels.Commands.CreateFuel;
using Application.Featues.Fuels.Commands.DeleteFuel;
using Application.Featues.Fuels.Dtos;
using Application.Featues.Fuels.Models;
using Application.Featues.Fuels.Queries.GetListFuels;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RentACarAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FuelController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Getlist([FromQuery] PageRequest pageRequest)
        {
            GetListFuelQuery getListFuelQuery = new() { PageRequest = pageRequest };
            FuelListViewModel result = await Mediator.Send(getListFuelQuery);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateFuelCommand createFuelCommand)
        {
            CreatedFuelDto result = await Mediator.Send(createFuelCommand);
            return Created("", result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateFuelCommand updateFuelCommand)
        {
            UpdatedFuelDto result = await Mediator.Send(updateFuelCommand);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteFuelCommand deleteFuelCommand)
        {
            DeletedFuelDto result = await Mediator.Send(deleteFuelCommand);
            return Ok(result);
        }
    }
}
