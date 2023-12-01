// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Threading.Tasks;
using Slimforge.Api.Momo.Remittance.Models.Services.Foundations.OAuth;

namespace Slimforge.Api.Momo.Remittance.Services.Foundations.OAuth
{
    internal partial interface IAuthorizationService
    {
        ValueTask<Authorization> PromptAuthorizationAsync();
    }
}