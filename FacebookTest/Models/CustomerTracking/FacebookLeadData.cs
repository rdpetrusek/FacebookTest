using System.Collections.Generic;
using Newtonsoft.Json;

namespace FacebookTest.Models.CustomerTracking
{
    public class FacebookLeadData
    {
        [JsonProperty("created_time")]
        public string CreatedTime { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("field_data")]
        public List<FacebookFieldData> FieldData { get; set; }
    }
}