// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

namespace Slimforge.Api.Momo.Models.Services.Foundations.Remittances
{
    public class AccessTokenResponse
    {
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public int ExpiresIn { get; set; }
    }
}