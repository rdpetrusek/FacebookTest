using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;

namespace FacebookTest.Controllers
{
    //[System.Web.Http.RoutePrefix("facebook")]
    public class FacebookController : ApiController
    {
        //[HttpGet]
        //public HttpResponseMessage Get()
        //{
        //    var response = new HttpResponseMessage(HttpStatusCode.OK)
        //    {
        //        Content = new StringContent(HttpContext.Current.Request.QueryString["hub.challenge"])
        //    };
        //    response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
        //    return response;
        //}

        //[HttpPost]
        //public async Task<HttpResponseMessage> Post([FromBody] FacebookData data)
        //{
        //    try
        //    {
        //        PostToGA("fb-test", "fb-received");
        //        var entry = data.Entry.FirstOrDefault();
        //        var change = entry?.Changes.FirstOrDefault();
        //        if (change == null) return new HttpResponseMessage(HttpStatusCode.BadRequest);

        //        //Generate user access token here https://developers.facebook.com/tools/accesstoken/
        //        const string token = "EAAEbGnrCSeoBAHrRIMAmqjmrPRoo3zrEjoHCEQbJkv4JvSnBlC0PqwaOkruGUme2pATjbigamnmRymiBK51m3rrNjS0CDp8SodkTQFGjTUURNEyu1gkibYC3CBZBDck1dmi48poaRdWgbWEBGzPZCiT3uWZCnRhRDp0MR0AbNZBd6jvyV7ZBc43v7JWM2zq0ZD";

        //        var leadUrl = $"https://graph.facebook.com/v2.10/{change.Value.LeadGenId}?access_token={token}";
        //        var formUrl = $"https://graph.facebook.com/v2.10/{change.Value.FormId}?access_token={token}";

        //        using (var httpClientLead = new HttpClient())
        //        {
        //            var response = await httpClientLead.GetStringAsync(formUrl);
        //            if (!string.IsNullOrEmpty(response))
        //            {
        //                var jsonObjLead = JsonConvert.DeserializeObject<FacebookLeadFormData>(response);
        //                //jsonObjLead.Name contains the lead ad name

        //                //If response is valid get the field data
        //                using (var httpClientFields = new HttpClient())
        //                {
        //                    var responseFields = await httpClientFields.GetStringAsync(leadUrl);
        //                    if (!string.IsNullOrEmpty(responseFields))
        //                    {
        //                        var jsonObjFields = JsonConvert.DeserializeObject<FacebookLeadData>(responseFields);
        //                        //jsonObjFields.FieldData contains the field value
        //                    }
        //                }
        //            }
        //        }
        //        return new HttpResponseMessage(HttpStatusCode.OK);
        //    }
        //    catch (Exception ex)
        //    {
        //        return new HttpResponseMessage(HttpStatusCode.BadGateway);
        //    }
        //}

        //private void PostToGA(string id, string eventName)
        //{
        //    var client = new HttpClient();
        //    client.PostAsync(string.Format("https://www.google-analytics.com/collect?v=1&t=event&tid=UA-1242489-6&cid={0}&ec=users&ea={1}", id, eventName), null);
        //}
    }
    //[HttpGet]
    //public string Index()
    //{
    //    //var response = new HttpResponseMessage(HttpStatusCode.OK);
    //    //response.Content = new StringContent(HttpContext.Request.QueryString["hub.challenge"]);
    //    var challenge = System.Web.HttpContext.Content.Request.QueryString["hub.challenge"];
    //    //response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
    //    //return response;
    //    return challenge;
    //}

    //[HttpPost]
    //[ActionName("Index")]
    //public JsonResult IndexPost([FromBody]FacebookData data)
    //{
    //    try
    //    {
    //        PostToGA("fb-test", "fb-received");
    //        var entry = data.Entry.FirstOrDefault();
    //        var change = entry?.Changes.FirstOrDefault();
    //        if (change == null) return new JsonResult { Data = "Bad Request", JsonRequestBehavior = JsonRequestBehavior.AllowGet };

    //        //Generate user access token here https://developers.facebook.com/tools/accesstoken/
    //        const string token = "EAAEbGnrCSeoBAHrRIMAmqjmrPRoo3zrEjoHCEQbJkv4JvSnBlC0PqwaOkruGUme2pATjbigamnmRymiBK51m3rrNjS0CDp8SodkTQFGjTUURNEyu1gkibYC3CBZBDck1dmi48poaRdWgbWEBGzPZCiT3uWZCnRhRDp0MR0AbNZBd6jvyV7ZBc43v7JWM2zq0ZD";

    //        var leadUrl = $"https://graph.facebook.com/v2.10/{change.Value.LeadGenId}?access_token={token}";
    //        var formUrl = $"https://graph.facebook.com/v2.10/{change.Value.FormId}?access_token={token}";

    //        using (var httpClientLead = new HttpClient())
    //        {
    //            var response = httpClientLead.GetAsync(formUrl).Result;
    //            if (response != null && response.IsSuccessStatusCode)
    //            {
    //                PostToGA("fb-test", "fb-get-form-success");
    //                var formContent = response.Content;
    //                var jsonObjLead = JsonConvert.DeserializeObject<FacebookLeadFormData>(formContent.ReadAsStringAsync().Result);
    //                //jsonObjLead.Name contains the lead ad name

    //                //If response is valid get the field data
    //                using (var httpClientFields = new HttpClient())
    //                {
    //                    var responseFields = httpClientFields.GetAsync(leadUrl).Result;
    //                    if (responseFields != null && responseFields.IsSuccessStatusCode)
    //                    {
    //                        PostToGA("fb-test", "fb-get-lead-success");
    //                        var fieldContent = responseFields.Content;
    //                        var jsonObjFields = JsonConvert.DeserializeObject<FacebookLeadData>(fieldContent.ReadAsStringAsync().Result);
    //                        //jsonObjFields.FieldData contains the field value
    //                    }
    //                }
    //            }
    //        }
    //        return new JsonResult { Data = "Ok", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
    //    }
    //    catch (Exception ex)
    //    {
    //        return new JsonResult { Data = "Bad Gateway", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
    //    }
    //}

    //private void PostToGA(string id, string eventName)
    //{
    //    var client = new HttpClient();
    //    client.PostAsync(string.Format("https://www.google-analytics.com/collect?v=1&t=event&tid=UA-1242489-6&cid={0}&ec=users&ea={1}", id, eventName), null);
    //}
}