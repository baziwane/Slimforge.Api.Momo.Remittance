// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Slimforge.Api.Momo.Models.Services.Foundations.Remittances;
using Slimforge.Api.Momo.Models.Services.Foundations.ExternalRemittances;
using Xunit;

namespace Slimforge.Api.Momo.Tests.Unit.Services.Foundations.Remittances
{
    public partial class RemittanceServiceTests
    {
        [Fact]
        private async Task ShouldGenerateAccessTokenAsync()
        {
            // given
            //DateTimeOffset randomDate = GetRandomDate();
            int randomDateNumber = GetRandomNumber();

            dynamic randomAccessTokenProperties = CreateRandomAccessTokenProperties();

            var randomAccessTokenResponse = new AccessTokenResponse
            {
                AccessToken = randomAccessTokenProperties.AccessToken,
                TokenType = randomAccessTokenProperties.TokenType,
                ExpiresIn = randomAccessTokenProperties.ExpiresIn
            };

            var randomExternalAccessTokenResponse = new ExternalAccessTokenResponse
            {
                AccessToken = randomAccessTokenProperties.AccessToken,
                TokenType = randomAccessTokenProperties.TokenType,
                ExpiresIn = randomAccessTokenProperties.ExpiresIn
            };

            AccessTokenResponse inputAccessToken = randomAccessTokenResponse;
            AccessTokenResponse expectedAccessToken = inputAccessToken.DeepClone();
            //expectedAccessToken.Response = randomAccessTokenResponse;

            ExternalAccessTokenResponse returnedExternalAccessTokenResponse =
                randomExternalAccessTokenResponse;

            this.momoBrokerMock.Setup(broker =>
                broker.PostAccessTokenRequestAsync())
                        .ReturnsAsync(returnedExternalAccessTokenResponse);

            // when
            AccessTokenResponse actualAccessToken =
                await this.remittanceService.GenerateAccessTokenAsync();

            // then
            actualAccessToken.Should().BeEquivalentTo(expectedAccessToken);

            this.momoBrokerMock.Verify(broker =>
                broker.PostAccessTokenRequestAsync(),
                        Times.Once);

            this.momoBrokerMock.VerifyNoOtherCalls();
        }
    }
}