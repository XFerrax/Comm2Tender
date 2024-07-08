namespace Comm2Tender.Logic.Models
{
    public class LoginResponse
    {
        public int HttpCode { get; set; }
        public string Message { get; set; }

        public LoginResponseTokens? Tokens { get; set; }

        public LoginResponse(int httpCode, string message = "")
        {
            HttpCode = httpCode;
            Message = message;
        }
    }
}
