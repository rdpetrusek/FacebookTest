using System.Web.Http;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using FacebookTest.Models.CustomerTracking;
using Newtonsoft.Json;


namespace FacebookTest.Api.Controllers
{
    public class WebhooksController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(HttpContext.Current.Request.QueryString["hub.challenge"]);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
            return response;
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Post([FromBody] FacebookData data)
        {
            try
            {
                PostToGA("fb-test", "fb-received");
                var entry = data.Entry.FirstOrDefault();
                var change = entry?.Changes.FirstOrDefault();
                if (change == null) return new HttpResponseMessage(HttpStatusCode.BadRequest);

                //Generate user access token here https://developers.facebook.com/tools/accesstoken/
                const string token = "EAAEbGnrCSeoBAHrRIMAmqjmrPRoo3zrEjoHCEQbJkv4JvSnBlC0PqwaOkruGUme2pATjbigamnmRymiBK51m3rrNjS0CDp8SodkTQFGjTUURNEyu1gkibYC3CBZBDck1dmi48poaRdWgbWEBGzPZCiT3uWZCnRhRDp0MR0AbNZBd6jvyV7ZBc43v7JWM2zq0ZD";

                var leadUrl = $"https://graph.facebook.com/v2.10/{change.Value.LeadGenId}?access_token={token}";
                var formUrl = $"https://graph.facebook.com/v2.10/{change.Value.FormId}?access_token={token}";

                using (var httpClientLead = new HttpClient())
                {
                    var response = await httpClientLead.GetStringAsync(formUrl);
                    if (!string.IsNullOrEmpty(response))
                    {
                        PostToGA("fb-test", "fb-get-form-success");
                        var jsonObjLead = JsonConvert.DeserializeObject<FacebookLeadFormData>(response);
                        //jsonObjLead.Name contains the lead ad name

                        //If response is valid get the field data
                        using (var httpClientFields = new HttpClient())
                        {
                            var responseFields = await httpClientFields.GetStringAsync(leadUrl);
                            if (!string.IsNullOrEmpty(responseFields))
                            {
                                PostToGA("fb-test", "fb-get-lead-success");
                                var jsonObjFields = JsonConvert.DeserializeObject<FacebookLeadData>(responseFields);
                                //jsonObjFields.FieldData contains the field value
                            }
                        }
                    }
                }
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Error-->{ex.Message}");
                Trace.WriteLine($"StackTrace-->{ex.StackTrace}");
                return new HttpResponseMessage(HttpStatusCode.BadGateway);
            }
        }

        private void PostToGA(string id, string eventName)
        {
            var client = new HttpClient();
            client.PostAsync(string.Format("https://www.google-analytics.com/collect?v=1&t=event&tid=UA-1242489-6&cid={0}&ec=users&ea={1}", id, eventName), null);
        }
    }
}