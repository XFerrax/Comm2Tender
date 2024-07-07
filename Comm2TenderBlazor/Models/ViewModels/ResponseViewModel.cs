namespace Comm2TenderBlazor.Models.ViewModels
{
    using System.Text.Json.Serialization;

    public class ResponseViewModel<T>
    {
        [JsonPropertyName("items")]
        public List<T> Items { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }
    }
}
