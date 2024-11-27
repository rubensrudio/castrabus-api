using System.Text.Json.Serialization;

namespace CastraBus.Application.Entities.ViewModel
{
    public class MessengerVm
    {
        [JsonPropertyName("type")]
        public String Type { get; set; }

        [JsonPropertyName("queue")]
        public String Queue { get; set; }

        [JsonPropertyName("message")]
        public String Message { get; set; }

        [JsonPropertyName("createdAt")]
        public String CreatedAt { get; set; }
    }
}
