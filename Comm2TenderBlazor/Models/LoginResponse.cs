namespace Comm2TenderBlazor.Models
{
    public class LoginResponse
    {
        public int HttpCode { get; set; }
        public string Message { get; set; }

        public LoginResponseTokens? Tokens { get; set; }

        public LoginResponse(int httpCode, string message = "")
        {
            this.HttpCode = httpCode;
            this.Message = message;
        }
    }
}
