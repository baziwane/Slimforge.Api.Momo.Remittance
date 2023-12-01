// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Threading.Tasks;
using Slimforge.Api.Momo.Remittance.Models.Services.Foundations.ExternalOAuth;

namespace Slimforge.Api.Momo.Remittance.Brokers.MomoApis
{
    internal partial class MomoBroker
    {
        public async ValueTask<ExternalAuthorizationResponse> PostAuthorizationRequestAsync() =>
            await PostAsyncForAuthentication<ExternalAuthorizationResponse>(relativeUrl: "remittance/token/", null);

    }
}