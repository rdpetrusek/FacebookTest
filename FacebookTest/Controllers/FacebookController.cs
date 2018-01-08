using System;
using System.Linq;
using System.Web.Http;
using System.Net.Http;
using System.Net.Http.Headers;
using FacebookTest.Models.CustomerTracking;
using System.Web.Mvc;
using Newtonsoft.Json;
using HttpPost = System.Web.Http.HttpPostAttribute;
using HttpGet = System.Web.Http.HttpGetAttribute;
using System.Net;

namespace FacebookTest.Controllers
{
    public class FacebookController : Controller
    {
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(HttpContext.Request.QueryString["hub.challenge"])
            };
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
            return response;
        }

        [HttpPost]
        public JsonResult Post([FromBody]FacebookData data)
        {
            try
            {
                PostToGA("fb-test", "fb-received");
                var entry = data.Entry.FirstOrDefault();
                var change = entry?.Changes.FirstOrDefault();
                if (change == null) return new JsonResult { Data = "Bad Request", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

                //Generate user access token here https://developers.facebook.com/tools/accesstoken/
                const string token = "EAAEbGnrCSeoBAHrRIMAmqjmrPRoo3zrEjoHCEQbJkv4JvSnBlC0PqwaOkruGUme2pATjbigamnmRymiBK51m3rrNjS0CDp8SodkTQFGjTUURNEyu1gkibYC3CBZBDck1dmi48poaRdWgbWEBGzPZCiT3uWZCnRhRDp0MR0AbNZBd6jvyV7ZBc43v7JWM2zq0ZD";

                var leadUrl = $"https://graph.facebook.com/v2.10/{change.Value.LeadGenId}?access_token={token}";
                var formUrl = $"https://graph.facebook.com/v2.10/{change.Value.FormId}?access_token={token}";

                using (var httpClientLead = new HttpClient())
                {
                    var response = httpClientLead.GetAsync(formUrl).Result;
                    if (response != null && response.IsSuccessStatusCode)
                    {
                        PostToGA("fb-test", "fb-get-form-success");
                        var formContent = response.Content;
                        var jsonObjLead = JsonConvert.DeserializeObject<FacebookLeadFormData>(formContent.ReadAsStringAsync().Result);
                        //jsonObjLead.Name contains the lead ad name

                        //If response is valid get the field data
                        using (var httpClientFields = new HttpClient())
                        {
                            var responseFields = httpClientFields.GetAsync(leadUrl).Result;
                            if (responseFields != null && responseFields.IsSuccessStatusCode)
                            {
                                PostToGA("fb-test", "fb-get-lead-success");
                                var fieldContent = responseFields.Content;
                                var jsonObjFields = JsonConvert.DeserializeObject<FacebookLeadData>(fieldContent.ReadAsStringAsync().Result);
                                //jsonObjFields.FieldData contains the field value
                            }
                        }
                    }
                }
                return new JsonResult { Data = "Ok", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception ex)
            {
                return new JsonResult { Data = "Bad Gateway", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        private void PostToGA(string id, string eventName)
        {
            var client = new HttpClient();
            client.PostAsync(string.Format("https://www.google-analytics.com/collect?v=1&t=event&tid=UA-1242489-6&cid={0}&ec=users&ea={1}", id, eventName), null);
        }
    }
}