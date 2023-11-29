// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Threading.Tasks;
using Slimforge.Api.Momo.Models.Services.Foundations.Remittances;
using Xunit;

namespace Slimforge.Api.Momo.Tests.Integration.APIs.Remittances
{
    public partial class RemittancesApiTests
    {
        [Fact(Skip = "This test is only for releases")]
        private async Task ShouldGenerateAccessTokenAsync()
        {
            // given - not needed
            
            // when
            var responseAccessToken =
                await this.momoClient.AccessTokens.GenerateAccessTokenAsync();

            // then
            Assert.NotNull(responseAccessToken.AccessToken);
        }
    }
}