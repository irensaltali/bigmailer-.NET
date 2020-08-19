using Newtonsoft.Json;

namespace BigMailer.Models
{
    public class TransactionalEmailResponseModel: BaseResponseModel
    {
        [JsonProperty("contact_id")]
        public string ContactId { get; set; }
    }
}
