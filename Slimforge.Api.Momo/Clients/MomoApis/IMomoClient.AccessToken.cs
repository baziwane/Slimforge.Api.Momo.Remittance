// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Slimforge.Api.Momo.Clients.Remittances;

namespace Slimforge.Api.Momo.Clients.MomoApis
{
    public partial interface IMomoClient
    {
        IRemittanceClient AccessTokens { get; }
    }
}
