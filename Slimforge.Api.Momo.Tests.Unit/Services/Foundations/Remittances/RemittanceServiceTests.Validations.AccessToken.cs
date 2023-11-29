// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Slimforge.Api.Momo.Models.Services.Foundations.Remittances;
using Slimforge.Api.Momo.Models.Services.Foundations.Remittances.Exceptions;
using Slimforge.Api.Momo.Models.Services.Foundations.ExternalRemittances;
using Xunit;

namespace Slimforge.Api.Momo.Tests.Unit.Services.Foundations.Remittances
{
    public partial class RemittanceServiceTests
    {
        //[Fact]
        private async Task ShouldThrowValidationExceptionOnPromptIfAccessTokenResponseIsNullAsync()
        {
            // given
            //AccessTokenResponse nullAccessTokenResponse = null;
            var nullRemittanceException = new NullRemittanceException();

            var exceptedRemittanceValidationException =
                new RemittanceValidationException(
                    message: "Remittance validation error occurred, fix errors and try again.",
                        innerException: nullRemittanceException);

            // when
            ValueTask<AccessTokenResponse> generateAccessTokenTask =
                this.remittanceService.GenerateAccessTokenAsync();

            RemittanceValidationException actualRemittanceValidationException =
                await Assert.ThrowsAsync<RemittanceValidationException>(
                    generateAccessTokenTask.AsTask);

            // then
            actualRemittanceValidationException.Should()
                .BeEquivalentTo(exceptedRemittanceValidationException);

            this.momoBrokerMock.Verify(broker =>
                broker.PostAccessTokenRequestAsync(),
                        Times.Never);

            this.momoBrokerMock.VerifyNoOtherCalls();
        }
        
    }
}