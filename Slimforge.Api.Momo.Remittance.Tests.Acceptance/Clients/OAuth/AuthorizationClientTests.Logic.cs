// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------
using System;
using System.Threading.Tasks;
using FluentAssertions;
using Force.DeepCloner;
using Newtonsoft.Json;
using Slimforge.Api.Momo.Remittance.Models.Services.Foundations.OAuth;
using Slimforge.Api.Momo.Remittance.Models.Services.Foundations.ExternalOAuth;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using Xunit;

namespace Slimforge.Api.Momo.Remittance.Tests.Acceptance.Clients.OAuth
{
    public partial class AuthorizationClientTests
    {
        [Fact]
        private async Task ShouldPromptAuthorizationAsync()
        {
            // given
            Authorization randomAuthorization = CreateRandomAuthorization();
            Authorization inputAuthorization = randomAuthorization;

            ExternalAuthorizationResponse authorizationResponse =
                CreateRandomExternalAuthorizationResponse();

            Authorization expectedAuthorization = inputAuthorization.DeepClone();
            expectedAuthorization = ConvertToAuthorization(expectedAuthorization, authorizationResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            string authString = Convert.ToBase64String(
                System.Text.Encoding.UTF8.GetBytes($"{this.apiUser}:{this.apiKey}"));

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath("remittance/token/")
                    .WithHeader("Authorization", $"Basic {authString}")
                    .WithHeader("Ocp-Apim-Subscription-Key", this.subscriptionKey)
                    .WithHeader("Content-Type", "application/json; charset=utf-8"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(authorizationResponse));

            // when
            Authorization actualAuthorization =
                await this.momoClient.Authorizations.PromptAuthorizationAsync();

            // then
            actualAuthorization.Should().BeEquivalentTo(expectedAuthorization);
        }
    }
}