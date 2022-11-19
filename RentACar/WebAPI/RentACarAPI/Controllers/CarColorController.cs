using Application.Featues.CarColors.Commands.CreateCarColor;
using Application.Featues.CarColors.Commands.DeleteCarColor;
using Application.Featues.CarColors.Commands.UpdateCarColor;
using Application.Featues.CarColors.Dtos;
using Application.Featues.CarColors.Models;
using Application.Featues.CarColors.Queries.GetlistCarColors;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RentACarAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarColorController : BaseController
    {


        [HttpGet]
        public async Task<IActionResult> Getlist([FromQuery]PageRequest pageRequest)
        {
            GetListCarColorQuery getListCarColorQuery = new() {PageRequest=pageRequest };
            CarColorListViewModel result = await Mediator.Send(getListCarColorQuery);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCarColorCommand createCarColorCommand)
        {
            CreatedCarColorDto result = await Mediator.Send(createCarColorCommand);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCarColorCommand updateCarColorCommand)
        {
            UpdatedCarColorDto result = await Mediator.Send(updateCarColorCommand);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteCarColorCommand deleteCarColorCommand)
        {
            DeletedCarColorDto result = await Mediator.Send(deleteCarColorCommand);
            return Ok(result);
        }
    }
}
