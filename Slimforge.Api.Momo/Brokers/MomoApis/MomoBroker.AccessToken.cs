// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Threading.Tasks;
using Slimforge.Api.Momo.Models.Services.Foundations.ExternalRemittances;

namespace Slimforge.Api.Momo.Brokers.MomoApis
{
    internal partial class MomoBroker
    {
        public async ValueTask<ExternalAccessTokenResponse> PostAccessTokenRequestAsync() =>
            await PostAsyncForAuthentication<ExternalAccessTokenResponse>(relativeUrl: "remittance/token/", null);

    }
}