using Application.Featues.UserOperationClaims.Commands.CreateUserOperatinoClaimCommand;
using Application.Featues.UserOperationClaims.Commands.UpdateUserOperationClaim;
using Application.Featues.UserOperationClaims.Dtos;
using Application.Featues.UserOperationClaims.Models;
using Application.Featues.UserOperationClaims.Queries.GetListUserOperationClaim;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RentACarAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserOperationClaimController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListUserOperationClaimQuery getListUserOperationClaimQuery = new() { PageRequest = pageRequest };
            UserOperationClaimListViewModel result = await Mediator.Send(getListUserOperationClaimQuery);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUserOperationClaimCommand createUserOperationClaimCommand)
        {
            CreatedUserOperationClaimDto result = await Mediator.Send(createUserOperationClaimCommand);
            return Created("", result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteUserOperationClaimCommand deleteUserOperationClaimCommand)
        {
            DeletedUserOperationClaimDto result = await Mediator.Send(deleteUserOperationClaimCommand);

            return Ok(result);
        }
    }
}
