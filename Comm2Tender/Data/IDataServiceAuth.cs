using Comm2Tender.Logic.Models;
using System;

namespace Comm2Tender.Data
{
    public partial interface IDataService
    {
        int CheckUser(string login, string password);

        /// <summary>
        /// Проверка блокировки пользователя
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <returns>Возвращает true если пользователь заблокирован</returns>
        bool CheckUserBlocking(int userId);

        int AddUserToken(int userId, string data, DateTime dateTime, DateTime accessExpires, DateTime refreshExpires);
        
        bool DeleteAllUserToken(int userId);

        bool DeleteUserToken(int userTokenId);

        Logic.Models.Dto.UserView GetUserView(int userId);
        
    }
}
