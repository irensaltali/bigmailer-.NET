using Newtonsoft.Json;
using System.ComponentModel;

namespace BigMailer.Models
{

    public class FieldValuePayload
    {
        [JsonProperty("date")]
        public string DateValue { get; set; }

        [JsonProperty("integer")]
        [DefaultValue(null)]
        public int? IntegerValue { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("string")]
        public string StringValue { get; set; }
    }

    public class VariablePayload
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

    }

    public enum Operation
    {
        Add,
        Replace
    }
}
