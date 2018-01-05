using Newtonsoft.Json;

namespace FacebookTest.Models.CustomerTracking
{
    public class FacebookLeadFormData
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("leadgen_export_csv_url")]
        public string CsvExportUrl { get; set; }

        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}