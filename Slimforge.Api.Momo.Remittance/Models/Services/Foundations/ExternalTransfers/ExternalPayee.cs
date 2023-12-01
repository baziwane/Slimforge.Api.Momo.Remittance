// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Newtonsoft.Json;

namespace Slimforge.Api.Momo.Remittance.Models.Services.Foundations.ExternalTransfers
{
    internal class ExternalPayee
    {
        [JsonProperty(propertyName: "party_id_type")]
        public string PartyIdType { get; set; }

        [JsonProperty(propertyName: "party_id")]
        public string PartyId { get; set; }
    }
}