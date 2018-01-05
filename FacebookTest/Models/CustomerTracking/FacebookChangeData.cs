using System.Collections.Generic;
using Newtonsoft.Json;

namespace FacebookTest.Models.CustomerTracking
{
    public class FacebookChangeData
    {
        [JsonProperty("field")]
        public string Field { get; set; }

        [JsonProperty("value")]
        public FacebookValueData Value { get; set; }
    }
}