namespace Comm2Tender.Logic.Models
{
    public class Response
    {
        public bool Result { get; set; }
        public string Message { get; set; }

        public Response()
        {
            Result = false;
            Message = "";
        }
    }
}