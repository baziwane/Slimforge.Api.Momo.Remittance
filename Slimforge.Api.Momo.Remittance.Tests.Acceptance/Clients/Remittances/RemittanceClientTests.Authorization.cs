// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Threading.Tasks;
using FluentAssertions;
using Force.DeepCloner;
using Newtonsoft.Json;
using Slimforge.Api.Momo.Remittance.Models.Services.Foundations.Remittances;
using Slimforge.Api.Momo.Remittance.Models.Services.Foundations.ExternalRemittances;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using Xunit;

namespace Slimforge.Api.Momo.Remittance.Tests.Acceptance.Clients.Remittances
{
    public partial class RemittanceClientTests
    {
        [Fact]
        private async Task ShouldGenerateAccessTokenAsync()
        {
            // given
            AccessToken randomAccessToken = CreateRandomAccessToken();
            AccessToken inputAccessToken = randomAccessToken;

            ExternalAccessTokenResponse accessTokenResponse =
                CreateRandomExternalAccessTokenResponse();

            AccessToken expectedAccessToken = inputAccessToken.DeepClone();
            expectedAccessToken = ConvertToAccessToken(expectedAccessToken, accessTokenResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            string authString = Convert.ToBase64String(
                System.Text.Encoding.UTF8.GetBytes($"{this.ApiUser}:{this.ApiKey}"));

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath("remittance/token/")
                    .WithHeader("Authorization", $"Basic {authString}")
                    .WithHeader("Ocp-Apim-Subscription-Key", this.subscriptionKey)
                    .WithHeader("Content-Type", "application/json; charset=utf-8"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(accessTokenResponse));

            // when
            AccessToken actualAccessToken =
                await this.momoClient.AccessTokens.GenerateAccessTokenAsync();

            // then
            actualAccessToken.Should().BeEquivalentTo(expectedAccessToken);
        }
    }
}