using Application.Featues.CarModels.Commands.CreateCarModel;
using Application.Featues.CarModels.Commands.DeleteCarModel;
using Application.Featues.CarModels.Commands.UpdateCarModel;
using Application.Featues.CarModels.Dtos;
using Application.Featues.CarModels.Models;
using Application.Featues.CarModels.Queries.GetListCarModelQuery;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace RentACarAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarModelController : BaseController
    {


        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery]PageRequest pageRequest)
        {
            GetListCarModelQuery getListCarModelQuery = new() { PageRequest=pageRequest};
            CarModelListViewModel result = await Mediator.Send(getListCarModelQuery);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCarModelCommand createCarModelCommand)
        {
            CreatedCarModelDto createdCarModelDto = await Mediator.Send(createCarModelCommand);
            return Created("",createdCarModelDto);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCarModelCommand updateCarModelCommand)
        {
            UpdatedCarModelDto updatedCarModelDto = await Mediator.Send(updateCarModelCommand);
            return Ok(updatedCarModelDto);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteCarModelCommand deleteCarModelCommand)
        {
            DeletedCarModelDto deletedCarModelDto = await Mediator.Send(deleteCarModelCommand);
            return Ok(deletedCarModelDto);
        }


    }
}
