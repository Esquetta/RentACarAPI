using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.Auth.Dtos
{
    public class LoggedUserDto
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
