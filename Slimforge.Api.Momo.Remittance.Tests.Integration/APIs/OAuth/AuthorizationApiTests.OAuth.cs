// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Threading.Tasks;
using Slimforge.Api.Momo.Remittance.Models.Services.Foundations.OAuth;
using Xunit;

namespace Slimforge.Api.Momo.Remittance.Tests.Integration.APIs.OAuth
{
    public partial class AuthorizationApiTests
    {
        [Fact(Skip = "This test is only for releases")]
        private async Task ShouldPromptAuthorizationAsync()
        {
            // given - not needed
            
            // when
            var responseAuthorization =
                await this.momoClient.Authorizations.PromptAuthorizationAsync();
                
            // then
            Assert.NotNull(responseAuthorization.Response.AccessToken);
        }
    }
}