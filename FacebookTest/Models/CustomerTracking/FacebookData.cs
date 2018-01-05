using System.Collections.Generic;
using Newtonsoft.Json;

namespace FacebookTest.Models.CustomerTracking
{
    public class FacebookData
    {
        [JsonProperty("entry")]
        public List<FacebookEntryData> Entry { get; set; }

        [JsonProperty("object")]
        public string Object { get; set; }
    }
}