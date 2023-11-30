// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using RESTFulSense.Exceptions;
using Slimforge.Api.Momo.Remittance.Models.Services.Foundations.Remittances;
using Slimforge.Api.Momo.Remittance.Models.Services.Foundations.Remittances.Exceptions;

namespace Slimforge.Api.Momo.Remittance.Services.Foundations.Remittances
{
    internal partial class RemittanceService
    {
        private delegate ValueTask<AccessTokenResponse> ReturningAccessTokenFunction();

        private static async ValueTask<AccessTokenResponse> TryCatch(ReturningAccessTokenFunction returningAccessTokenFunction)
        {
            try
            {
                return await returningAccessTokenFunction();
            }
            catch (NullRemittanceException nullRemittanceException)
            {
                throw new RemittanceValidationException(nullRemittanceException);
            }
            catch (InvalidRemittanceException invalidRemittanceException)
            {
                throw new RemittanceValidationException(
                    invalidRemittanceException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationRemittanceException =
                    new InvalidConfigurationRemittanceException(httpResponseUrlNotFoundException);

                throw new RemittanceDependencyException(invalidConfigurationRemittanceException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedRemittanceException =
                    new UnauthorizedRemittanceException(httpResponseUnauthorizedException);

                throw new RemittanceDependencyException(unauthorizedRemittanceException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedRemittanceException =
                    new UnauthorizedRemittanceException(httpResponseForbiddenException);

                throw new RemittanceDependencyException(unauthorizedRemittanceException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundRemittanceException =
                    new NotFoundRemittanceException(httpResponseNotFoundException);

                throw new RemittanceDependencyValidationException(notFoundRemittanceException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidRemittanceException =
                    new InvalidRemittanceException(httpResponseBadRequestException);

                throw new RemittanceDependencyValidationException(invalidRemittanceException);
            }

            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallRemittanceException =
                    new ExcessiveCallRemittanceException(httpResponseTooManyRequestsException);

                throw new RemittanceDependencyValidationException(excessiveCallRemittanceException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerRemittanceException =
                    new FailedServerRemittanceException(httpResponseException);

                throw new RemittanceDependencyException(failedServerRemittanceException);
            }
            catch (Exception exception)
            {
                var failedRemittanceServiceException =
                    new FailedRemittanceServiceException(exception);

                throw new RemittanceServiceException(failedRemittanceServiceException);
            }
        }
    }
}