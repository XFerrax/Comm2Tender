
using Comm2Tender.Logic.Enum;
using Comm2Tender.Logic.Models;
using Comm2Tender.Logic.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Comm2Tender.Logic
{
    public partial class LogicService : ILogicServiceAuth
    {

        public LoginResponse Login(LoginRequest model)
        {
            var response = new LoginResponse(StatusCodes.Status401Unauthorized);
            string ip = GetIP();
            string data = $"логин {model.Login}, пароль {model.Password}, IP {ip}";
            string tail = $"# {data}";

            // TODO: Необходимо проверить не слишком ли часто пользователь выполняет вход, так как при нормальной работе access-токен (токен доступа) обновляется за счет предоставления refresh-токена выдаваемого на длительный срок и действующего всего один раз    

            #region Пример успешно работающей аутентификации удерживающей региональный портал приема показаний и платежей.
            var user = DataService.CheckUser(model.Login, model.Password);
            if (user != null)
            {
                if (DataService.CheckUserBlocking(user.UserId) == false)
                {
                    //Logger.LogDebug($"Логин и пароль верный {tail}");
                    return AddToken(user, ip, tail);
                }
                else
                {
                    response.Message = "Пользователь заблокирован";
                    //Logger.LogDebug($"Пользователь заблокирован {tail}");
                }
            }
            else
            {
                //Logger.LogDebug($"Не удалось выполнить вход в систему {tail}");
                //DataService.AddUserAuthLog(userId, data, DateTimeOffset.Now, false);
                if (user != null)
                {
                    //Logger.LogDebug($"Проверим блокировку пользователя {tail}");
                    if (DataService.CheckUserBlocking(user.UserId))
                    {
                        //Logger.LogDebug($"Пользователь не заблокирован, проверим не превышено ли количество попыток входа {tail}");
                        var maxLoginAttemptinterval = Configuration.GetValue<TimeSpan>("Auth:MaxLoginAttemptInterval");
                        //int count = DataService.GetUserAuthLogAttempt(userId, maxLoginAttemptinterval);
                        int count = 0;
                        //Logger.LogDebug($"Количество неуспешных попыток входа {count} {tail}");
                        if (count >= Configuration.GetValue<int>("Auth:MaxLoginAttempt"))
                        {
                            var message = $"Превышено количество попыток входа, временная блокировка на {Configuration.GetValue<TimeSpan>("Auth:TemporaryBlockingInterval"):HH\\:mm\\:ss}";
                            //Logger.LogWarning($"{message} {tail}");
                            BlockUser(user.UserId, message, Configuration.GetValue<TimeSpan>("Auth:TemporaryBlockingInterval"));
                            //SendingService.SendEmailAsync(
                            //    Frontend.Rubleexpress,
                            //    $"{Configuration["ItEmail"]},{Configuration["SupportEmail"]}",
                            //    "Блокировка пользователя",
                            //    $"{message} {tail}",
                            //    Configuration["ProjectNameRubleexpress"]
                            //);
                        }
                    }
                    else
                    {
                        //Logger.LogDebug($"Пользователь заблокирован {tail}");
                    }
                }


            }
            #endregion
            
            return response;
        }

        public UserView GetUser()
        {
            return DataService.GetUserView(GetUserId());
        }

        public bool Logout()
        {
            return DataService.DeleteUserToken(GetUserTokenId());
        }

        private LoginResponse AddToken(User user, string ip, string tail)
        {
            var now = DateTime.Now;
            var accessExpires = now + Configuration.GetValue<TimeSpan>("Jwt:AccessTokenTTL");
            var refreshExpires = now + Configuration.GetValue<TimeSpan>("Jwt:RefreshTokenTTL");
            var response = new LoginResponse(StatusCodes.Status401Unauthorized);
            var userTokenId = DataService.AddUserToken(user.UserId, ip, now, accessExpires, refreshExpires);
            if (userTokenId > 0)
            {
                var creds = GetSigningCredentials();
                response.Tokens = new LoginResponseTokens()
                {
                    AccessToken = CreateToken(creds, user, userTokenId.ToString(), UserTokenType.Access.ToString(), accessExpires),
                    RefreshToken = CreateToken(creds, user, userTokenId.ToString(), UserTokenType.Refresh.ToString(), refreshExpires)
                };
                response.HttpCode = StatusCodes.Status200OK;

            }
            return response;
        }

        private SigningCredentials GetSigningCredentials()
        {
            return new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"])), SecurityAlgorithms.HmacSha256); ;
        }

        private string CreateToken(SigningCredentials creds, User user, string tokenId, string tokenType, DateTimeOffset expires)
        {
            
            var claims = new[]
            {
                new Claim(Configuration["Jwt:ClaimNameUser"], user.UserId.ToString()),
                new Claim(Configuration["Jwt:ClaimNameToken"], tokenId),
                new Claim(Configuration["Jwt:ClaimNameType"], tokenType),
                new Claim(ClaimTypes.Role, user.Role.Name)
            };

            return new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken(
                issuer: Configuration["Jwt:Issuer"],
                audience: Configuration["Jwt:Audience"],
                expires: expires.DateTime,
                claims: claims,
                signingCredentials: creds
                ));

        }

        public bool BlockUser(int userId, string reason, TimeSpan? blockingTimeSpan = null)
        {
            string ip = GetIP();
            var tail = $"# UserId {userId}, причина {reason}, IP {ip}";
            //Logger.LogDebug($"Блокировка пользователя с удалением всех токенов {tail}");
            DataService.DeleteAllUserToken(userId);
            return true;
            //if (blockingTimeSpan != null)
            //{
            //    return DataService.AddUserBlocking(userId, reason, DateTimeOffset.Now, DateTimeOffset.Now + blockingTimeSpan.Value);
            //}
            //else
            //{
            //    return DataService.AddUserBlocking(userId, reason, DateTimeOffset.Now);
            //}
        }

        public AuthUserView GetUserView()
        {
            var req = new ListRequest();
            req.Filter = new List<FilterItem>() { new FilterItem() { Prop = "userId", Value = GetUserId() } };
            var roleId = DataService.SearchUser(req).listRequest.FirstOrDefault().Role.RoleId;
            switch ((RolesType)roleId)
            {
                case RolesType.Administrator:
                    return new AuthUserView()
                    {
                        MenuItems = new List<UserMenuItem>()
                        {
                            new UserMenuItem("Пользователи", "/users", "mdi-account-group"),
                            new UserMenuItem("Контрагенты", "/agents", "mdi-briefcase-account"),
                            new UserMenuItem("Заявки", "/proposals", "mdi-invoice-multiple"),
                            new UserMenuItem("Процентные ставки", "/percents", "mdi-bank-plus"),
                            new UserMenuItem("Таможенные пошлины", "/customsfee", "mdi-train-car-box-full"),
                        }
                    };
                case RolesType.Economist:
                    return new AuthUserView()
                    {
                        MenuItems = new List<UserMenuItem>()
                        {
                            new UserMenuItem("Контрагенты", "/agents", "mdi-briefcase-account"),
                            new UserMenuItem("Процентные ставки", "/percents", "mdi-bank-plus"),
                            new UserMenuItem("Таможенные пошлины", "/customsfee", "mdi-train-car-box-full"),
                        }
                    };
                case RolesType.Specialist:
                    return new AuthUserView()
                    {
                        MenuItems = new List<UserMenuItem>()
                        {
                            new UserMenuItem("Контрагенты", "/agents", "mdi-briefcase-account"),
                            new UserMenuItem("Заявки", "/proposals", "mdi-invoice-multiple"),
                        }
                    };
                default:
                    return new AuthUserView();
            }
        }
    }
}
