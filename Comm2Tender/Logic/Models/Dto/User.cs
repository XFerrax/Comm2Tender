using System.Collections;

namespace Comm2Tender.Logic.Models.Dto
{
    public class User
    {
        public long UserId { get; set; } // int
        public Role Role { get; set; } // int
        public string Name { get; set; } // nvarchar(50)
        public string Email { get; set; } // nvarchar(50)
        public string Password { get; set; } // nvarchar(50)
        public bool IsActive { get; set; }


        public static implicit operator User(Data.User a)
        {
            if (a == null) return null;

            return new User()
            {
                UserId = a.UserId,
                Role = a.Role,
                Name = a.Name,
                Email = a.Email,
                Password = "Unknow String",
                IsActive = a.IsActive,
            };
        }

        public static implicit operator Data.User(User a)
        {
            if (a == null) return null;

            return new Data.User()
            {
                UserId = a.UserId,
                RoleId = a.Role.RoleId,
                Name = a.Name,
                Email = a.Email,
                Password = a.Password,
                IsActive = a.IsActive,
            };
        }
    }
}
