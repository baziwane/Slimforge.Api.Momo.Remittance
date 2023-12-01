// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Newtonsoft.Json;

namespace Slimforge.Api.Momo.Remittance.Models.Services.Foundations.ExternalTransfers
{
    internal class ExternalTransferRequest
    {
        [JsonProperty(propertyName: "amount")]
        public string Amount { get; set; }
        [JsonProperty(propertyName: "currency")]
        public string Currency { get; set; }

        [JsonProperty(propertyName: "external_id")]
        public string ExternalId { get; set; }

        [JsonProperty(propertyName: "external_payee")]
        public ExternalPayee Payee { get; set; }

        [JsonProperty(propertyName: "payer_message")]
        public string PayerMessage { get; set; }

        [JsonProperty(propertyName: "payee_note")]
        public string PayeeNote { get; set; }
    }
}
