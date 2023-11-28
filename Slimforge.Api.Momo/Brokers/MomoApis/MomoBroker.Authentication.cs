// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Threading.Tasks;
using Slimforge.Api.Momo.Models.Services.Foundations.ExternalAuthentication;

namespace Slimforge.Api.Momo.Brokers.MomoApis
{
    internal partial class MomoBroker
    {
        public async ValueTask<ExternalAuthenticationResponse> PostAuthenticationRequestAsync() =>
            await PostAsyncForAuthentication<ExternalAuthenticationResponse>(relativeUrl: "collection/token/", null);

    }
}