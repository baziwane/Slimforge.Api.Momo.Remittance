using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Slimforge.Api.Momo.Models.Services.Foundations.Authentication
{
    public class AuthenticationResponse
    {
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public int ExpiresIn { get; set; }
    }
}