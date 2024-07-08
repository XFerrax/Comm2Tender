namespace Comm2TenderBlazor.Models.Dto
{
    using System.Text.Json.Serialization;

    public class User
    {
        [JsonPropertyName("userId")]
        public int UserId { get; set; }
        [JsonPropertyName("role")]
        public Role Role { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("password")]
        public string Password { get; set; }
        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }
    }
}
