using Application.Featues.OperationClaims.Commands.CreateOperationClaim;
using Application.Featues.OperationClaims.Commands.DeleteOperationClaim;
using Application.Featues.OperationClaims.Commands.UpdateOperationClaim;
using Application.Featues.OperationClaims.Dtos;
using Application.Featues.OperationClaims.Models;
using Application.Featues.OperationClaims.Queries.GetListOperationClaimQuery;
using Core.Application.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RentACarAPI.Controllers
{
    
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles ="Moderator")]
    public class OperationClaimController : BaseController
    {


        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListOperationClaimQuery getListOperationClaimQuery = new() { PageRequest = pageRequest };
            OperationClaimListViewModel result = await Mediator.Send(getListOperationClaimQuery);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOperationClaimCommand createOperationClaimCommand)
        {
            CreatedOperationClaimDto result = await Mediator.Send(createOperationClaimCommand);
            return Created("Created",result);

        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateOperationClaimCommand updateOperationClaimCommand)
        {
            UpdatedOperationClaimDto result = await Mediator.Send(updateOperationClaimCommand);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteOperationClaimCommand deleteOperationClaimCommand)
        {
            DeletedOperationClaimDto result = await Mediator.Send(deleteOperationClaimCommand);
            return Ok(result);
        }
    }
}
