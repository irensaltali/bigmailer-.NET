using Newtonsoft.Json;

namespace BigMailer.Models
{
    public class BaseResponseModel
    {
        [JsonIgnore]
        public bool IsSuccessfull { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("param")]
        public string Param { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

    }
}
