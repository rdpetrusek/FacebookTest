using Newtonsoft.Json;

namespace FacebookTest.Models.CustomerTracking
{
    public class FacebookValueData
    {
        [JsonProperty("ad_id")]
        public string AdId { get; set; }

        [JsonProperty("form_id")]
        public string FormId { get; set; }

        [JsonProperty("leadgen_id")]
        public string LeadGenId { get; set; }

        [JsonProperty("created_time")]
        public int CreatedTime { get; set; }

        [JsonProperty("page_id")]
        public string PageId { get; set; }

        [JsonProperty("adgroup_id")]
        public string AdGroupId { get; set; }
    }
}