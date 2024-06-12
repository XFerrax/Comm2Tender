using LinqToDB;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Comm2Tender.Data
{
    public partial class DataService : IDataService
    {
        public int CheckUser(string login, string password)
        {
            using (var db = GetDatabase())
            {
                var user = db.User.Where(a => a.Email == login).FirstOrDefault();

                return user?.Password == password ? user.UserId : 0;
            }
        }

        public bool CheckUserBlocking(int userId)
        {
            using var db = GetDatabase();
            return db.User.Where(a => a.UserId == userId && a.IsActive == true).Any() == false;
        }

        public int AddUserToken(int userId, string data, DateTime dateTime, DateTime accessExpires, DateTime refreshExpires)
        {
            using var db = GetDatabase();
            var refreshAuth = db.UserToken.Where(a=>a.UserId == userId&&a.Data == data).FirstOrDefault();
            if (refreshAuth is null)
            {
                return db.InsertWithInt32Identity(
                new UserToken
                {
                    UserId = userId,
                    DateTime = dateTime,
                    ExpiresAccessDateTime = accessExpires,
                    ExpiresRefreshDateTime = refreshExpires,
                    Data = data
                });
            }
            else
            {
                var updCount = db.Update<UserToken>(new UserToken()
                {
                    UserTokenId = refreshAuth.UserTokenId,
                    UserId = refreshAuth.UserId,
                    DateTime = dateTime,
                    ExpiresAccessDateTime = accessExpires,
                    ExpiresRefreshDateTime = refreshExpires,
                    Data = refreshAuth.Data,
                });
                return updCount == 1 ? refreshAuth.UserTokenId : 0;
            }
            
        }

        public bool DeleteAllUserToken(int userId)
        {
            using var db = GetDatabase();
            db.UserToken.Where(a => a.UserId == userId).Delete();
            return true;
        }

        public bool DeleteUserToken(int userId)
        {
            using var db = GetDatabase();
            return db.UserToken.Where(a => a.UserId == userId).Delete() == 1;
        }

        public Logic.Models.Dto.UserView GetUserView(int userId)
        {
            using var db = GetDatabase();
            Logic.Models.Dto.UserView result = db.User
                .LoadWith(a => a.Role)
                .First(a => a.UserId == userId);

            return result;
        }
    }
}
