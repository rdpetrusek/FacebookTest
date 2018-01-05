using System.Collections.Generic;
using Newtonsoft.Json;

namespace FacebookTest.Models.CustomerTracking
{
    public class FacebookFieldData
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("values")]
        public List<string> Values { get; set; }
    }
}