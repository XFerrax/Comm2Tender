namespace Comm2TenderBlazor.Models.Dto
{
    public class ListRequest
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public string Search { get; set; }
        public bool IsActual { get; set; }

        public List<SortItem> Sort { get; set; }

        public List<FilterItem> Filter { get; set; }

        public ListRequest()
        {
            this.Size = -1;
            this.Page = 1;
            this.Search = string.Empty;
            this.IsActual = false;
            this.Sort = new List<SortItem>();
            this.Filter = new List<FilterItem>();
        }
    }
}
