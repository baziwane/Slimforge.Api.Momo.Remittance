// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Threading.Tasks;
using Slimforge.Api.Momo.Remittance.Models.Services.Foundations.Remittances;

namespace Slimforge.Api.Momo.Remittance.Services.Foundations.Remittances
{
    internal partial interface IRemittanceService
    {
        ValueTask<AccessTokenResponse> GenerateAccessTokenAsync();
    }
}