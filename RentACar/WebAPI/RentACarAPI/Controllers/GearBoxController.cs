using Application.Featues.GearBoxses.Commands.CreateGearBox;
using Application.Featues.GearBoxses.Commands.DeleteGearBox;
using Application.Featues.GearBoxses.Commands.UpdateGearBox;
using Application.Featues.GearBoxses.Dtos;
using Application.Featues.GearBoxses.Models;
using Application.Featues.GearBoxses.Queries.GetListGearBoxses;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RentACarAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GearBoxController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Getlist([FromQuery] PageRequest pageRequest)
        {
            GetListGearBoxsesQuery getListGearBoxsesQuery = new() { PageRequest = pageRequest };
            GearBoxListViewModel result = await Mediator.Send(getListGearBoxsesQuery);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGearBoxCommand createGearBoxCommand)
        {
            CreatedGearBoxDto result = await Mediator.Send(createGearBoxCommand);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateGearBoxCommand updateGearBoxCommand)
        {
            UpdatedGearBoxDto result = await Mediator.Send(updateGearBoxCommand);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteGearBoxCommand deleteGearBoxCommand)
        {
            DeletedGearBoxDto result = await Mediator.Send(deleteGearBoxCommand);
            return Ok(result);
        }
    }
}
