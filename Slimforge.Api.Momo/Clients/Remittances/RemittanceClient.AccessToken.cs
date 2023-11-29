// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Threading.Tasks;
using Slimforge.Api.Momo.Models.Clients.Remittances.Exceptions;
using Slimforge.Api.Momo.Models.Services.Foundations.Remittances;
using Slimforge.Api.Momo.Models.Services.Foundations.Remittances.Exceptions;
using Slimforge.Api.Momo.Services.Foundations.Remittances;
using Xeptions;

namespace Slimforge.Api.Momo.Clients.Remittances
{
    internal partial class RemittanceClient : IRemittanceClient
    {
        private readonly IRemittanceService remittanceService;

        public RemittanceClient(IRemittanceService remittanceService) =>
            this.remittanceService = remittanceService;

        public async ValueTask<AccessTokenResponse> GenerateAccessTokenAsync()
        {
            try
            {
                return await this.remittanceService.GenerateAccessTokenAsync();
            }
            catch (RemittanceValidationException remittanceValidationException)
            {
                throw new RemittanceClientValidationException(
                    remittanceValidationException.InnerException as Xeption);
            }
            catch (RemittanceDependencyValidationException remittanceDependencyValidationException)
            {
                throw new RemittanceClientValidationException(
                    remittanceDependencyValidationException.InnerException as Xeption);
            }
            catch (RemittanceDependencyException remittanceDependencyException)
            {
                throw new RemittanceClientDependencyException(
                    remittanceDependencyException.InnerException as Xeption);
            }
            catch (RemittanceServiceException remittanceServiceException)
            {
                throw new RemittanceClientServiceException(
                    remittanceServiceException.InnerException as Xeption);
            }
        }
    }
}
