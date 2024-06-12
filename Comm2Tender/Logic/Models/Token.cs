using System;

namespace Comm2Tender.Logic.Models
{
    public struct Token
    {
        public int TokenId { get; set; }

        public int UserId { get; set; }

        public DateTime Expires { get; set; }
    }
}
