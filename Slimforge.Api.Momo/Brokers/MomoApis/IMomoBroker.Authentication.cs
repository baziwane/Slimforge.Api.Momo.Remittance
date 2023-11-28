// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Threading.Tasks;
using Slimforge.Api.Momo.Models.Services.Foundations.ExternalAuthentication;

namespace Slimforge.Api.Momo.Brokers.MomoApis
{
    internal partial interface IMomoBroker
    {
        ValueTask<ExternalAuthenticationResponse> PostAuthenticationRequestAsync();
    }
}