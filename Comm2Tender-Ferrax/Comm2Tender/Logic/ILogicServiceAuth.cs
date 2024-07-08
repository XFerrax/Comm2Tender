using Comm2Tender.Logic.Models;

namespace Comm2Tender.Logic
{
    public partial interface ILogicServiceAuth : ILogicService
    {
        LoginResponse Login(LoginRequest model);

        bool Logout();

        AuthUserView GetUserView();
    }
}
