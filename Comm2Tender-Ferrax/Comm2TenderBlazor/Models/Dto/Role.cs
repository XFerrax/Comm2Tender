namespace Comm2TenderBlazor.Models.Dto
{
    using System.Text.Json.Serialization;

    public class Role
    {
        [JsonPropertyName("roleId")]
        public int RoleId { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
