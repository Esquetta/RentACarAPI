using Application.Featues.Cars.Commands.CreateCar;
using Application.Featues.Cars.Commands.DeleteCar;
using Application.Featues.Cars.Commands.UpdateCar;
using Application.Featues.Cars.Dtos;
using Application.Featues.Cars.Models;
using Application.Featues.Cars.Queries.GetCarById;
using Application.Featues.Cars.Queries.GetListCar;
using Application.Featues.Cars.Queries.GetListCarByDynamic;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace RentACarAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarController : BaseController
    {


        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] GetCarByIdQuery getCarByIdQuery)
        {
            CarListViewModel result = await Mediator.Send(getCarByIdQuery);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateCarCommand createCarCommand)
        {
            CreatedCarDto createdCarDto = await Mediator.Send(createCarCommand);
            return Created("Operation Success.",createdCarDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]UpdateCarCommand updateCarCommand)
        {
            UpdatedCarDto updatedCarDto = await Mediator.Send(updateCarCommand);
            return Ok(updatedCarDto);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteCarCommand deleteCarCommand)
        {
            DeletedCarDto deletedCarDto = await Mediator.Send(deleteCarCommand);
            return Ok(deletedCarDto);
        }
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListCarQuery getListCarQuery = new() { PageRequest= pageRequest };
            CarListViewModel carListViewModel = await Mediator.Send(getListCarQuery);
            return Ok(carListViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetListDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListCarByDynamicQuery getListCarByDynamicQuery = new() { PageRequest= pageRequest,Dynamic=dynamic };
            CarListViewModel carListViewModel = await Mediator.Send(getListCarByDynamicQuery);
            return Ok(carListViewModel);
        }
    }
}
