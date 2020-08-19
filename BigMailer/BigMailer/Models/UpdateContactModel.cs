using Newtonsoft.Json;
using System.Collections.Generic;

namespace BigMailer.Models
{
    public class UpdateContactModel
    {
        [JsonIgnore]
        public string ContactId { get; set; }

        [JsonIgnore]
        public Operation FieldValuesOperation { get; set; }

        [JsonIgnore]
        public Operation ListIdsOperation { get; set; }

        [JsonIgnore]
        public Operation UnsubscribeIdsOperation { get; set; }

        [JsonProperty("field_values")]
        public List<FieldValuePayload> FieldValues { get; set; }

        [JsonProperty("unsubscribe_all")]
        public bool UnsubscribeAll { get; set; }

        [JsonProperty("list_ids")]
        public string[] ListIds { get; set; }

        [JsonProperty("unsubscribe_ids")]
        public string[] UnsubscribeIds { get; set; }
    }
}