// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Slimforge.Api.Momo.Remittance.Models.Services.Foundations.OAuth;
using Slimforge.Api.Momo.Remittance.Models.Services.Foundations.ExternalOAuth;
using Xunit;

namespace Slimforge.Api.Momo.Remittance.Tests.Unit.Services.Foundations.OAuth
{
    public partial class AuthorizationServiceTests
    {
        [Fact]
        private async Task ShouldGenerateAuthorizationAsync()
        {
            // given
            //DateTimeOffset randomDate = GetRandomDate();
            int randomDateNumber = GetRandomNumber();

            dynamic randomAuthorizationProperties = CreateRandomAuthorizationProperties();
            dynamic randomAuthorizationResponseProperties = CreateRandomAuthorizationResponseProperties();
            

            var randomAuthorization = new Authorization
            {
                Response = new AuthorizationResponse
                {
                    AccessToken = randomAuthorizationResponseProperties.AccessToken,
                    TokenType = randomAuthorizationResponseProperties.TokenType,
                    ExpiresIn = randomAuthorizationResponseProperties.ExpiresIn
                }
            };

            var randomAuthorizationResponse = new AuthorizationResponse
            {
                AccessToken = randomAuthorizationResponseProperties.AccessToken,
                TokenType = randomAuthorizationResponseProperties.TokenType,
                ExpiresIn = randomAuthorizationResponseProperties.ExpiresIn
            };

            var randomExternalAuthorizationResponse = new ExternalAuthorizationResponse
            {
                AccessToken = randomAuthorizationResponseProperties.AccessToken,
                TokenType = randomAuthorizationResponseProperties.TokenType,
                ExpiresIn = randomAuthorizationResponseProperties.ExpiresIn
            };

            Authorization inputAuthorization = randomAuthorization;
            Authorization expectedAuthorization = inputAuthorization.DeepClone();
            expectedAuthorization.Response = randomAuthorizationResponse;

            ExternalAuthorizationResponse returnedExternalAuthorizationResponse =
                randomExternalAuthorizationResponse;

            this.momoBrokerMock.Setup(broker =>
                broker.PostAuthorizationRequestAsync())
                        .ReturnsAsync(returnedExternalAuthorizationResponse);

            // when
            Authorization actualAuthorization =
                await this.authorizationService.PromptAuthorizationAsync();

            // then
            actualAuthorization.Should().BeEquivalentTo(expectedAuthorization);

            this.momoBrokerMock.Verify(broker =>
                broker.PostAuthorizationRequestAsync(),
                        Times.Once);

            this.momoBrokerMock.VerifyNoOtherCalls();
        }
    }
}