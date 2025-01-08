using Newtonsoft.Json;

namespace GoosClient.Models
{
    public class DuyuruModel
    {

        [JsonProperty("announcementTitle")]
        public string AnnouncementTitle { get; set; }

        [JsonProperty("announcementSummary")]
        public string AnnouncementSummary { get; set; }

        [JsonProperty("announcementDate")]
        public DateTime AnnouncementDate { get; set; }

        [JsonProperty("semesterId")]
        public int SemesterId { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }
    }

}
