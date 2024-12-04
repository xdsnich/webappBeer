using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace WebAppbotbeer.Data.Dto
{
    public class TelegramUserDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("telegram_id")]
        public long TelegramId { get; set; } = 1;
        [Required]
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("photo_url")]
        public string PhotoUrl { get; set; }

        [Required]
        [JsonPropertyName("hash")]
        public string Hash { get; set; }

        [JsonPropertyName("auth_date")]
        public long AuthDate { get; set; }
    }
}
