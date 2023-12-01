// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using RESTFulSense.Exceptions;
using Slimforge.Api.Momo.Remittance.Models.Services.Foundations.OAuth;
using Slimforge.Api.Momo.Remittance.Models.Services.Foundations.OAuth.Exceptions;
using Slimforge.Api.Momo.Remittance.Models.Services.Foundations.ExternalOAuth;
using Xunit;

namespace Slimforge.Api.Momo.Remittance.Tests.Unit.Services.Foundations.OAuth
{
    public partial class AuthorizationServiceTests
    {
        [Fact]
        private async Task ShouldThrowDependencyExceptionOnGenerateIfUrlNotFoundErrorOccursAsync()
        {
            // given

            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationAuthorizationException =
                new InvalidConfigurationAuthorizationException(
                    message: "Invalid configuration error occurred, fix errors and try again.",
                        innerException: httpResponseUrlNotFoundException);

            var expectedAuthorizationDependencyException =
                new AuthorizationDependencyException(
                    message: "Authorization dependency error occurred, contact support.",
                        innerException: invalidConfigurationAuthorizationException);

            this.momoBrokerMock.Setup(broker => broker.PostAuthorizationRequestAsync())
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<Authorization> generateAuthorizationTask =
               this.authorizationService.PromptAuthorizationAsync();

            AuthorizationDependencyException actualAuthorizationException =
                await Assert.ThrowsAsync<AuthorizationDependencyException>(
                    generateAuthorizationTask.AsTask);

            // then
            actualAuthorizationException.Should().BeEquivalentTo(
                expectedAuthorizationDependencyException);

            this.momoBrokerMock.Verify(broker =>
                broker.PostAuthorizationRequestAsync(),
                        Times.Once);

            this.momoBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        private async Task ShouldThrowDependencyExceptionOnGenerateIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given

            var unauthorizedAuthorizationException =
                new UnauthorizedAuthorizationException(
                    message: "Unauthorized authorization request, fix errors and try again.",
                        innerException: unauthorizedException);

            var expectedAuthorizationDependencyException =
                new AuthorizationDependencyException(
                    message: "Authorization dependency error occurred, contact support.",
                        innerException: unauthorizedAuthorizationException);

            this.momoBrokerMock.Setup(broker =>
                broker.PostAuthorizationRequestAsync())
                        .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<Authorization> generateAuthorizationTask =
                this.authorizationService.PromptAuthorizationAsync();

            AuthorizationDependencyException actualAuthorizationDependencyException =
                await Assert.ThrowsAsync<AuthorizationDependencyException>(
                    generateAuthorizationTask.AsTask);

            // then
            actualAuthorizationDependencyException.Should().BeEquivalentTo(
                expectedAuthorizationDependencyException);

            this.momoBrokerMock.Verify(broker =>
                broker.PostAuthorizationRequestAsync(),
                        Times.Once);

            this.momoBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        private async Task ShouldThrowDependencyValidationExceptionOnGenerateIfAuthorizationNotFoundAsync()
        {
            // given

            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundAuthorizationException =
                new NotFoundAuthorizationException(
                    message: "Not found authorization error occurred, fix errors and try again.",
                        innerException: httpResponseNotFoundException);

            var expectedAuthorizationDependencyValidationException =
                new AuthorizationDependencyValidationException(
                    message: "Authorization dependency validation error occurred, fix errors and try again.",
                        innerException: notFoundAuthorizationException);

            this.momoBrokerMock.Setup(broker =>
                broker.PostAuthorizationRequestAsync())
                        .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<Authorization> generateAuthorizationTask =
                this.authorizationService.PromptAuthorizationAsync();

            AuthorizationDependencyValidationException actualAuthorizationDependencyException =
                await Assert.ThrowsAsync<AuthorizationDependencyValidationException>(
                    generateAuthorizationTask.AsTask);

            // then
            actualAuthorizationDependencyException.Should().BeEquivalentTo(
                expectedAuthorizationDependencyValidationException);

            this.momoBrokerMock.Verify(broker =>
                broker.PostAuthorizationRequestAsync(),
                        Times.Once);

            this.momoBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        private async Task ShouldThrowDependencyValidationExceptionOnGenerateIfBadRequestOccursAsync()
        {
            // given

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidAuthorizationException =
                new InvalidAuthorizationException(
                    message: "Invalid authorization error occurred, fix errors and try again.",
                        innerException: httpResponseBadRequestException);

            var expectedAuthorizationDependencyValidationException =
                new AuthorizationDependencyValidationException(
                    message: "Authorization dependency validation error occurred, fix errors and try again.",
                        innerException: invalidAuthorizationException);

            this.momoBrokerMock.Setup(broker => 
            broker.PostAuthorizationRequestAsync())
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<Authorization> generateAuthorizationTask =
               this.authorizationService.PromptAuthorizationAsync();

            AuthorizationDependencyValidationException actualAuthorizationDependencyException =
                await Assert.ThrowsAsync<AuthorizationDependencyValidationException>(
                    generateAuthorizationTask.AsTask);

            // then
            actualAuthorizationDependencyException.Should().BeEquivalentTo(
                expectedAuthorizationDependencyValidationException);

            this.momoBrokerMock.Verify(broker =>
                broker.PostAuthorizationRequestAsync(),
                        Times.Once);

            this.momoBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        private async Task ShouldThrowDependencyValidationExceptionOnGenerateIfTooManyRequestsOccurredAsync()
        {
            // given

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallAuthorizationException =
                new ExcessiveCallAuthorizationException(
                    message: "Excessive call error occurred, limit your calls.",
                        innerException: httpResponseTooManyRequestsException);

            var expectedAuthorizationDependencyValidationException =
                new AuthorizationDependencyValidationException(
                    message: "Authorization dependency validation error occurred, fix errors and try again.",
                        innerException: excessiveCallAuthorizationException);

            this.momoBrokerMock.Setup(broker => 
            broker.PostAuthorizationRequestAsync())
                    .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<Authorization> generateAuthorizationTask =
               this.authorizationService.PromptAuthorizationAsync();

            AuthorizationDependencyValidationException actualAuthorizationDependencyValidationException =
                await Assert.ThrowsAsync<AuthorizationDependencyValidationException>(
                    generateAuthorizationTask.AsTask);

            // then
            actualAuthorizationDependencyValidationException.Should().BeEquivalentTo(
                expectedAuthorizationDependencyValidationException);

            this.momoBrokerMock.Verify(broker =>
                broker.PostAuthorizationRequestAsync(),
                        Times.Once);

            this.momoBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        private async Task ShouldThrowDependencyExceptionOnGenerateIfHttpErrorOccursAsync()
        {
            // given

            var httpResponseException =
                new HttpResponseException();

            var failedServerAuthorizationException =
                new FailedServerAuthorizationException(
                    message: "Failed server authorization error occurred, contact support.",
                        innerException: httpResponseException);

            var expectedAuthorizationDependencyException =
                new AuthorizationDependencyException(
                    message: "Authorization dependency error occurred, contact support.",
                        innerException: failedServerAuthorizationException);

            this.momoBrokerMock.Setup(broker => 
                broker.PostAuthorizationRequestAsync())
                    .ThrowsAsync(httpResponseException);

            // when
            ValueTask<Authorization> generateAuthorizationTask =
               this.authorizationService.PromptAuthorizationAsync();

            AuthorizationDependencyException actualAuthorizationException =
                await Assert.ThrowsAsync<AuthorizationDependencyException>(
                    generateAuthorizationTask.AsTask);

            // then
            actualAuthorizationException.Should().BeEquivalentTo(
                expectedAuthorizationDependencyException);

            this.momoBrokerMock.Verify(broker =>
                broker.PostAuthorizationRequestAsync(),
                        Times.Once);

            this.momoBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        private async Task ShouldThrowServiceExceptionOnGenerateIfServiceErrorOccursAsync()
        {
            // given
            var serviceException = new Exception();

            var failedAuthorizationServiceException =
                new FailedAuthorizationServiceException(
                    message: "Failed authorization error occurred, contact support.",
                        innerException: serviceException);

            var expectedAuthorizationServiceException =
                new AuthorizationServiceException(
                    message: "Authorization service error occurred, contact support.",
                        innerException: failedAuthorizationServiceException);

            this.momoBrokerMock.Setup(broker => 
                broker.PostAuthorizationRequestAsync())
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<Authorization> generateAuthorizationTask =
               this.authorizationService.PromptAuthorizationAsync();

            AuthorizationServiceException actualAuthorizationServiceException =
                await Assert.ThrowsAsync<AuthorizationServiceException>(
                    generateAuthorizationTask.AsTask);

            // then
            actualAuthorizationServiceException.Should().BeEquivalentTo(
                expectedAuthorizationServiceException);

            this.momoBrokerMock.Verify(broker =>
                broker.PostAuthorizationRequestAsync(),
                        Times.Once);

            this.momoBrokerMock.VerifyNoOtherCalls();
        }
    }
}