using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class LoginDTO
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;    
    }

    public class LoginResponseDTO
    {
        public string Token { get; set; } = string.Empty;
    }
}
