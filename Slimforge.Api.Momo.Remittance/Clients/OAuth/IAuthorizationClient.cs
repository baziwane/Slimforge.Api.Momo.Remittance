// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Threading.Tasks;
using Slimforge.Api.Momo.Remittance.Models.Clients.OAuth.Exceptions;
using Slimforge.Api.Momo.Remittance.Models.Services.Foundations.OAuth;

namespace Slimforge.Api.Momo.Remittance.Clients.OAuth
{
    public partial interface IAuthorizationClient
    {
        /// <exception cref="AuthorizationClientValidationException" />
        /// <exception cref="AuthorizationClientDependencyException" />
        /// <exception cref="AuthorizationClientServiceException" />
        ValueTask<Authorization> PromptAuthorizationAsync();
    }
}
