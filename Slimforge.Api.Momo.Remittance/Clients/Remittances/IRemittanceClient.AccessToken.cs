// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Threading.Tasks;
using Slimforge.Api.Momo.Remittance.Models.Clients.Remittances.Exceptions;
using Slimforge.Api.Momo.Remittance.Models.Services.Foundations.Remittances;

namespace Slimforge.Api.Momo.Remittance.Clients.Remittances
{
    public partial interface IRemittanceClient
    {
        ValueTask<AccessTokenResponse> GenerateAccessTokenAsync();
    }
}
