namespace Comm2TenderBlazor.Models.Dto
{
    using System.Text.Json.Serialization;

    public class Tender
    {
        [JsonPropertyName("tenderId")]
        public int TenderId { get; set; } // int

        [JsonPropertyName("number")]
        public string Number { get; set; } // nvarchar(50)

        [JsonPropertyName("discription")]
        public string Discription { get; set; } // nvarchar(50)

        [JsonPropertyName("percentsDictionary")]
        public PercentsDictionary PercentsDictionary { get; set; } // int

        [JsonPropertyName("winnerProposalId")]
        public int? WinnerProposalId { get; set; } // int

        [JsonPropertyName("winnerProposal")]
        public Proposal? WinnerProposal { get; set; }
    }
}
