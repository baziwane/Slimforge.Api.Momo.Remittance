// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Newtonsoft.Json;

namespace Slimforge.Api.Momo.Remittance.Models.Services.Foundations.ExternalTransfers
{
    internal class ExternalTransferResponse
    {
        [JsonProperty(propertyName: "amount")]
        public string Amount { get; set; }

        [JsonProperty(propertyName: "currency")]
        public string Currency { get; set; }

        [JsonProperty(propertyName: "financial_transaction_id")]
        public string FinancialTransactionId { get; set; }

        [JsonProperty(propertyName: "external_id")]
        public string ExternalId { get; set; }

        [JsonProperty(propertyName: "payee")]
        public ExternalPayee Payee { get; set; }

        [JsonProperty(propertyName: "payer_message")]
        public string PayerMessage { get; set; }

        [JsonProperty(propertyName: "payee_note")]
        public string PayeeNote { get; set; }

        [JsonProperty(propertyName: "status")]
        public string Status { get; set; }
        
    }
}
