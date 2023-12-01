// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Threading.Tasks;
using Slimforge.Api.Momo.Remittance.Models.Clients.OAuth.Exceptions;
using Slimforge.Api.Momo.Remittance.Models.Services.Foundations.OAuth;
using Slimforge.Api.Momo.Remittance.Models.Services.Foundations.OAuth.Exceptions;
using Slimforge.Api.Momo.Remittance.Services.Foundations.OAuth;
using Xeptions;

namespace Slimforge.Api.Momo.Remittance.Clients.OAuth
{
    internal partial class AuthorizationClient : IAuthorizationClient
    {
        private readonly IAuthorizationService authorizationService;

        public AuthorizationClient(IAuthorizationService authorizationService) =>
            this.authorizationService = authorizationService;

        public async ValueTask<Authorization> PromptAuthorizationAsync()
        {
            try
            {
                return await this.authorizationService.PromptAuthorizationAsync();
            }
            catch (AuthorizationValidationException authorizationValidationException)
            {
                throw new AuthorizationClientValidationException(
                    authorizationValidationException.InnerException as Xeption);
            }
            catch (AuthorizationDependencyValidationException authorizationDependencyValidationException)
            {
                throw new AuthorizationClientValidationException(
                    authorizationDependencyValidationException.InnerException as Xeption);
            }
            catch (AuthorizationDependencyException authorizationDependencyException)
            {
                throw new AuthorizationClientDependencyException(
                    authorizationDependencyException.InnerException as Xeption);
            }
            catch (AuthorizationServiceException authorizationServiceException)
            {
                throw new AuthorizationClientServiceException(
                    authorizationServiceException.InnerException as Xeption);
            }
        }
    }
}
