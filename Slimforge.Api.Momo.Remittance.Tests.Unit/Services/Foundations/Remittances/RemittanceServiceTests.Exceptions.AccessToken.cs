// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using RESTFulSense.Exceptions;
using Slimforge.Api.Momo.Remittance.Models.Services.Foundations.Remittances;
using Slimforge.Api.Momo.Remittance.Models.Services.Foundations.Remittances.Exceptions;
using Slimforge.Api.Momo.Remittance.Models.Services.Foundations.ExternalRemittances;
using Xunit;

namespace Slimforge.Api.Momo.Remittance.Tests.Unit.Services.Foundations.Remittances
{
    public partial class RemittanceServiceTests
    {
        [Fact]
        private async Task ShouldThrowDependencyExceptionOnGenerateIfUrlNotFoundErrorOccursAsync()
        {
            // given

            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationRemittanceException =
                new InvalidConfigurationRemittanceException(
                    message: "Invalid configuration error occurred, fix errors and try again.",
                        innerException: httpResponseUrlNotFoundException);

            var expectedRemittanceDependencyException =
                new RemittanceDependencyException(
                    message: "Remittance dependency error occurred, contact support.",
                        innerException: invalidConfigurationRemittanceException);

            this.momoBrokerMock.Setup(broker => broker.PostAccessTokenRequestAsync())
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<AccessTokenResponse> generateAccessTokenTask =
               this.remittanceService.GenerateAccessTokenAsync();

            RemittanceDependencyException actualRemittanceException =
                await Assert.ThrowsAsync<RemittanceDependencyException>(
                    generateAccessTokenTask.AsTask);

            // then
            actualRemittanceException.Should().BeEquivalentTo(
                expectedRemittanceDependencyException);

            this.momoBrokerMock.Verify(broker =>
                broker.PostAccessTokenRequestAsync(),
                        Times.Once);

            this.momoBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        private async Task ShouldThrowDependencyExceptionOnGenerateIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given

            var unauthorizedRemittanceException =
                new UnauthorizedRemittanceException(
                    message: "Unauthorized remittance request, fix errors and try again.",
                        innerException: unauthorizedException);

            var expectedRemittanceDependencyException =
                new RemittanceDependencyException(
                    message: "Remittance dependency error occurred, contact support.",
                        innerException: unauthorizedRemittanceException);

            this.momoBrokerMock.Setup(broker =>
                broker.PostAccessTokenRequestAsync())
                        .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<AccessTokenResponse> generateAccessTokenTask =
                this.remittanceService.GenerateAccessTokenAsync();

            RemittanceDependencyException actualRemittanceDependencyException =
                await Assert.ThrowsAsync<RemittanceDependencyException>(
                    generateAccessTokenTask.AsTask);

            // then
            actualRemittanceDependencyException.Should().BeEquivalentTo(
                expectedRemittanceDependencyException);

            this.momoBrokerMock.Verify(broker =>
                broker.PostAccessTokenRequestAsync(),
                        Times.Once);

            this.momoBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        private async Task ShouldThrowDependencyValidationExceptionOnGenerateIfAccessTokenNotFoundAsync()
        {
            // given

            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundRemittanceException =
                new NotFoundRemittanceException(
                    message: "Not found remittance error occurred, fix errors and try again.",
                        innerException: httpResponseNotFoundException);

            var expectedRemittanceDependencyValidationException =
                new RemittanceDependencyValidationException(
                    message: "Remittance dependency validation error occurred, fix errors and try again.",
                        innerException: notFoundRemittanceException);

            this.momoBrokerMock.Setup(broker =>
                broker.PostAccessTokenRequestAsync())
                        .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<AccessTokenResponse> generateAccessTokenTask =
                this.remittanceService.GenerateAccessTokenAsync();

            RemittanceDependencyValidationException actualRemittanceDependencyException =
                await Assert.ThrowsAsync<RemittanceDependencyValidationException>(
                    generateAccessTokenTask.AsTask);

            // then
            actualRemittanceDependencyException.Should().BeEquivalentTo(
                expectedRemittanceDependencyValidationException);

            this.momoBrokerMock.Verify(broker =>
                broker.PostAccessTokenRequestAsync(),
                        Times.Once);

            this.momoBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        private async Task ShouldThrowDependencyValidationExceptionOnGenerateIfBadRequestOccursAsync()
        {
            // given

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidRemittanceException =
                new InvalidRemittanceException(
                    message: "Invalid remittance error occurred, fix errors and try again.",
                        innerException: httpResponseBadRequestException);

            var expectedRemittanceDependencyValidationException =
                new RemittanceDependencyValidationException(
                    message: "Remittance dependency validation error occurred, fix errors and try again.",
                        innerException: invalidRemittanceException);

            this.momoBrokerMock.Setup(broker => 
            broker.PostAccessTokenRequestAsync())
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<AccessTokenResponse> generateAccessTokenTask =
               this.remittanceService.GenerateAccessTokenAsync();

            RemittanceDependencyValidationException actualRemittanceDependencyException =
                await Assert.ThrowsAsync<RemittanceDependencyValidationException>(
                    generateAccessTokenTask.AsTask);

            // then
            actualRemittanceDependencyException.Should().BeEquivalentTo(
                expectedRemittanceDependencyValidationException);

            this.momoBrokerMock.Verify(broker =>
                broker.PostAccessTokenRequestAsync(),
                        Times.Once);

            this.momoBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        private async Task ShouldThrowDependencyValidationExceptionOnGenerateIfTooManyRequestsOccurredAsync()
        {
            // given

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallRemittanceException =
                new ExcessiveCallRemittanceException(
                    message: "Excessive call error occurred, limit your calls.",
                        innerException: httpResponseTooManyRequestsException);

            var expectedRemittanceDependencyValidationException =
                new RemittanceDependencyValidationException(
                    message: "Remittance dependency validation error occurred, fix errors and try again.",
                        innerException: excessiveCallRemittanceException);

            this.momoBrokerMock.Setup(broker => 
            broker.PostAccessTokenRequestAsync())
                    .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<AccessTokenResponse> generateAccessTokenTask =
               this.remittanceService.GenerateAccessTokenAsync();

            RemittanceDependencyValidationException actualRemittanceDependencyValidationException =
                await Assert.ThrowsAsync<RemittanceDependencyValidationException>(
                    generateAccessTokenTask.AsTask);

            // then
            actualRemittanceDependencyValidationException.Should().BeEquivalentTo(
                expectedRemittanceDependencyValidationException);

            this.momoBrokerMock.Verify(broker =>
                broker.PostAccessTokenRequestAsync(),
                        Times.Once);

            this.momoBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        private async Task ShouldThrowDependencyExceptionOnGenerateIfHttpErrorOccursAsync()
        {
            // given

            var httpResponseException =
                new HttpResponseException();

            var failedServerRemittanceException =
                new FailedServerRemittanceException(
                    message: "Failed server remittance error occurred, contact support.",
                        innerException: httpResponseException);

            var expectedRemittanceDependencyException =
                new RemittanceDependencyException(
                    message: "Remittance dependency error occurred, contact support.",
                        innerException: failedServerRemittanceException);

            this.momoBrokerMock.Setup(broker => 
                broker.PostAccessTokenRequestAsync())
                    .ThrowsAsync(httpResponseException);

            // when
            ValueTask<AccessTokenResponse> generateAccessTokenTask =
               this.remittanceService.GenerateAccessTokenAsync();

            RemittanceDependencyException actualRemittanceException =
                await Assert.ThrowsAsync<RemittanceDependencyException>(
                    generateAccessTokenTask.AsTask);

            // then
            actualRemittanceException.Should().BeEquivalentTo(
                expectedRemittanceDependencyException);

            this.momoBrokerMock.Verify(broker =>
                broker.PostAccessTokenRequestAsync(),
                        Times.Once);

            this.momoBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        private async Task ShouldThrowServiceExceptionOnGenerateIfServiceErrorOccursAsync()
        {
            // given
            var serviceException = new Exception();

            var failedRemittanceServiceException =
                new FailedRemittanceServiceException(
                    message: "Failed remittance error occurred, contact support.",
                        innerException: serviceException);

            var expectedRemittanceServiceException =
                new RemittanceServiceException(
                    message: "Remittance service error occurred, contact support.",
                        innerException: failedRemittanceServiceException);

            this.momoBrokerMock.Setup(broker => 
                broker.PostAccessTokenRequestAsync())
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<AccessTokenResponse> generateAccessTokenTask =
               this.remittanceService.GenerateAccessTokenAsync();

            RemittanceServiceException actualRemittanceServiceException =
                await Assert.ThrowsAsync<RemittanceServiceException>(
                    generateAccessTokenTask.AsTask);

            // then
            actualRemittanceServiceException.Should().BeEquivalentTo(
                expectedRemittanceServiceException);

            this.momoBrokerMock.Verify(broker =>
                broker.PostAccessTokenRequestAsync(),
                        Times.Once);

            this.momoBrokerMock.VerifyNoOtherCalls();
        }
    }
}