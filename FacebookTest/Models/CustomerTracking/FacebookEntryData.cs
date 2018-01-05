using System.Collections.Generic;
using Newtonsoft.Json;

namespace FacebookTest.Models.CustomerTracking
{
    public class FacebookEntryData
    {
        [JsonProperty("changes")]
        public List<FacebookChangeData> Changes { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("time")]
        public int Time { get; set; }
    }
}