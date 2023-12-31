﻿// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Slimforge.Api.Momo.Remittance.Clients.OAuth;

namespace Slimforge.Api.Momo.Remittance.Clients.MomoApis
{
    public partial interface IMomoClient
    {
        IAuthorizationClient Authorizations { get; }
    }
}
