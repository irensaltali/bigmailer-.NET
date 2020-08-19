using BigMailer.Models;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BigMailer
{
    public class MailService
    {
        private static readonly HttpClient client = new HttpClient();
        private static string BrandId;
        private const string BaseAddress = "https://api.bigmailer.io";
        private readonly CultureInfo DefaultCultureInfo = new CultureInfo("en-US");

        public MailService(string brandId, string APIKey)
        {
            if (client == null || client.BaseAddress == null)
            {
                client.BaseAddress = new Uri(BaseAddress);
                client.DefaultRequestHeaders.Add("X-API-Key", APIKey);
            }

            BrandId = brandId;
        }

        public TransactionalEmailResponseModel SendTransactionalEmail(SendTransactionalEmailModel model) => SendTransactionalEmailAsync(model).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<TransactionalEmailResponseModel> SendTransactionalEmailAsync(SendTransactionalEmailModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));
            try
            {
                string json = JsonConvert.SerializeObject(model);
                using StringContent stringContent = new StringContent(json, Encoding.Default, "application/json");

                var result = await client.PostAsync(new Uri(BaseAddress + "/v1/brands/" + BrandId + "/transactional-campaigns/" + model.CampaignId + "/send"), stringContent);
                var jsonResponse = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<TransactionalEmailResponseModel>(jsonResponse);

                response.IsSuccessfull = result.IsSuccessStatusCode;

                return response;
            }
            catch (Exception e)
            {
                return new TransactionalEmailResponseModel
                {
                    IsSuccessfull = false,
                    Message = e.Message
                };
            }
        }

        public UpdateContactResponseModel UpdateContact(UpdateContactModel model) => UpdateContactAsync(model).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<UpdateContactResponseModel> UpdateContactAsync(UpdateContactModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));
            try
            {
                string json = JsonConvert.SerializeObject(model, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });

                using StringContent stringContent = new StringContent(json, Encoding.Default, "application/json");

                var result = await client.PostAsync(new Uri(BaseAddress + "/v1/brands/" + BrandId + "/contacts/" + model.ContactId
                    + "?field_values_op=" + model.FieldValuesOperation.ToString().ToLower(DefaultCultureInfo)
                    + "&list_ids_op=" + model.ListIdsOperation.ToString().ToLower(DefaultCultureInfo)
                    + "&unsubscribe_ids_op=" + model.UnsubscribeIdsOperation.ToString().ToLower(DefaultCultureInfo)), stringContent);
                var jsonResponse = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<UpdateContactResponseModel>(jsonResponse);

                response.IsSuccessfull = result.IsSuccessStatusCode;

                return response;
            }
            catch (Exception e)
            {
                return new UpdateContactResponseModel
                {
                    IsSuccessfull = false,
                    Message = e.Message
                };
            }
        }

    }
}
