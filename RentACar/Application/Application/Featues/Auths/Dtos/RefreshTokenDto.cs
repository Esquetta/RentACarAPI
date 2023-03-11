using Application.Featues.Auths.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.Auth.Dtos
{
    public class RefreshTokenDto
    {
        public AccessToken AccessToken { get; set; }
        public CreatedRefreshTokenDTO RefreshToken { get; set; }
    }
}
