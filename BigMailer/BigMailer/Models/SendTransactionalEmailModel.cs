using Newtonsoft.Json;
using System.Collections.Generic;

namespace BigMailer.Models
{
    public class SendTransactionalEmailModel
    {
        [JsonIgnore]
        public string CampaignId { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("field_values")]
        public List<FieldValuePayload> FieldValues { get; set; } = new List<FieldValuePayload>();

        [JsonProperty("variables")]
        public List<VariablePayload> Variables { get; set; } = new List<VariablePayload>();
    }
}
