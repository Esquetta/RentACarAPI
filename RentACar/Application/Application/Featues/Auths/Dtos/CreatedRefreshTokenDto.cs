using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.Auths.Dtos
{
    public class CreatedRefreshTokenDTO
    {
        public string RefreshToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}
