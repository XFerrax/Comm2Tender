using Comm2Tender.Logic.Models;
using Comm2Tender.Logic.Models.Dto;
using System;

namespace Comm2Tender.Data
{
    public partial interface IDataService 
    {
        User CheckUser(string login, string password);

        /// <summary>
        /// Проверка блокировки пользователя
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <returns>Возвращает true если пользователь заблокирован</returns>
        bool CheckUserBlocking(long userId);

        long AddUserToken(long userId, string data, DateTime dateTime, DateTime accessExpires, DateTime refreshExpires);
        
        bool DeleteAllUserToken(long userId);

        bool DeleteUserToken(long userTokenId);

        Logic.Models.Dto.UserView GetUserView(long userId);
        
    }
}
