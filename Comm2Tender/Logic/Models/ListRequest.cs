using System;
using System.Collections.Generic;

namespace Comm2Tender.Logic.Models
{
    public class ListRequest
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public string Search { get; set; }

        public DateTimeOffset? DateTime { get; set; }
        public bool IsActual { get; set; }

        public List<SortItem> Sort { get; set; }

        public List<FilterItem> Filter { get; set; }
    }
}