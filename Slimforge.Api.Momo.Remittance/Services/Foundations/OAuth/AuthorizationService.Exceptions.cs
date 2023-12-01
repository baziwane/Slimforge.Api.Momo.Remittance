// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using RESTFulSense.Exceptions;
using Slimforge.Api.Momo.Remittance.Models.Services.Foundations.OAuth;
using Slimforge.Api.Momo.Remittance.Models.Services.Foundations.OAuth.Exceptions;

namespace Slimforge.Api.Momo.Remittance.Services.Foundations.OAuth
{
    internal partial class AuthorizationService
    {
        private delegate ValueTask<Authorization> ReturningAuthorizationFunction();

        private static async ValueTask<Authorization> TryCatch(ReturningAuthorizationFunction returningAuthorizationFunction)
        {
            try
            {
                return await returningAuthorizationFunction();
            }
            catch (NullAuthorizationException nullAuthorizationException)
            {
                throw new AuthorizationValidationException(nullAuthorizationException);
            }
            catch (InvalidAuthorizationException invalidAuthorizationException)
            {
                throw new AuthorizationValidationException(
                    invalidAuthorizationException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationAuthorizationException =
                    new InvalidConfigurationAuthorizationException(httpResponseUrlNotFoundException);

                throw new AuthorizationDependencyException(invalidConfigurationAuthorizationException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedAuthorizationException =
                    new UnauthorizedAuthorizationException(httpResponseUnauthorizedException);

                throw new AuthorizationDependencyException(unauthorizedAuthorizationException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedAuthorizationException =
                    new UnauthorizedAuthorizationException(httpResponseForbiddenException);

                throw new AuthorizationDependencyException(unauthorizedAuthorizationException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundAuthorizationException =
                    new NotFoundAuthorizationException(httpResponseNotFoundException);

                throw new AuthorizationDependencyValidationException(notFoundAuthorizationException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidAuthorizationException =
                    new InvalidAuthorizationException(httpResponseBadRequestException);

                throw new AuthorizationDependencyValidationException(invalidAuthorizationException);
            }

            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallAuthorizationException =
                    new ExcessiveCallAuthorizationException(httpResponseTooManyRequestsException);

                throw new AuthorizationDependencyValidationException(excessiveCallAuthorizationException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerAuthorizationException =
                    new FailedServerAuthorizationException(httpResponseException);

                throw new AuthorizationDependencyException(failedServerAuthorizationException);
            }
            catch (Exception exception)
            {
                var failedAuthorizationServiceException =
                    new FailedAuthorizationServiceException(exception);

                throw new AuthorizationServiceException(failedAuthorizationServiceException);
            }
        }
    }
}