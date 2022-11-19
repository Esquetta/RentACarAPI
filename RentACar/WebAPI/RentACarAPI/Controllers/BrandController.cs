using Application.Featues.Brands.Commands.CreateBrand;
using Application.Featues.Brands.Commands.DeleteBrand;
using Application.Featues.Brands.Commands.UpdateBrand;
using Application.Featues.Brands.Dtos;
using Application.Featues.Brands.Models;
using Application.Featues.Brands.Queries.GetListBrandsWithModels;
using Application.Featues.Brands.Queries.GetListLBrand;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RentACarAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BrandController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListBrandQuery getListBrandQuery = new() { PageRequest=pageRequest };
            BrandListViewModel result = await Mediator.Send(getListBrandQuery);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetListWithCarModels([FromQuery] PageRequest pageRequest)
        {
            GetListBrandsWithModelsQuery getListBrandsWithModelsQuery = new() { PageRequest = pageRequest };
            BrandModelsListViewModel result = await Mediator.Send(getListBrandsWithModelsQuery);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBrandCommand createBrandCommand)
        {
            CreatedBrandDto result = await Mediator.Send(createBrandCommand);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBrandCommand updateBrandCommand)
        {
            UpdatedBrandDto result = await Mediator.Send(updateBrandCommand);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteBrandCommand deleteBrandCommand)
        {
            DeletedBrandDto result = await Mediator.Send(deleteBrandCommand);
            return Ok(result);
        }
    }
}
