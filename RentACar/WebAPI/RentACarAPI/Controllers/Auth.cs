using Application.Featues.Auth.Commands.Login;
using Application.Featues.Auth.Commands.Register;
using Application.Featues.Auth.Dtos;
using Core.Security.Dtos;
using Core.Security.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RentACarAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Auth : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
        {
            RegisterCommand registerCommand = new()
            {
                UserForRegisterDto = userForRegisterDto,
                IpAddress = GetIpAddress()
            };

            RefreshTokenDto result = await Mediator.Send(registerCommand);
            SetRefreshTokenToCookie(result.RefreshToken);
            return Created("", result.AccessToken);



        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginCommand loginCommand)
        {
            var result = await Mediator.Send(loginCommand);
            return Ok(result);
        }
        private void SetRefreshTokenToCookie(RefreshToken refreshToken)
        {
            CookieOptions cookieOptions = new()
            {
                Expires = DateTime.Now.AddDays(7),
                HttpOnly = true
            };
            Response.Cookies.Append("RefreshToken", refreshToken.Token, cookieOptions);
        }
    }
}
