// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Slimforge.Api.Momo.Remittance.Models.Services.Foundations.OAuth;
using Slimforge.Api.Momo.Remittance.Models.Services.Foundations.OAuth.Exceptions;
using Slimforge.Api.Momo.Remittance.Models.Services.Foundations.ExternalOAuth;
using Xunit;

namespace Slimforge.Api.Momo.Remittance.Tests.Unit.Services.Foundations.OAuth
{
    public partial class AuthorizationServiceTests
    {
        //[Fact]
        private async Task ShouldThrowValidationExceptionOnPromptIfAuthorizationResponseIsNullAsync()
        {
            // given
            //AuthorizationResponse nullAuthorizationResponse = null;
            var nullAuthorizationException = new NullAuthorizationException();

            var exceptedAuthorizationValidationException =
                new AuthorizationValidationException(
                    message: "Authorization validation error occurred, fix errors and try again.",
                        innerException: nullAuthorizationException);

            // when
            ValueTask<Authorization> generateAuthorizationTask =
                this.authorizationService.PromptAuthorizationAsync();

            AuthorizationValidationException actualAuthorizationValidationException =
                await Assert.ThrowsAsync<AuthorizationValidationException>(
                    generateAuthorizationTask.AsTask);

            // then
            actualAuthorizationValidationException.Should()
                .BeEquivalentTo(exceptedAuthorizationValidationException);

            this.momoBrokerMock.Verify(broker =>
                broker.PostAuthorizationRequestAsync(),
                        Times.Never);

            this.momoBrokerMock.VerifyNoOtherCalls();
        }
        
    }
}