using System.Collections.Generic;

namespace Comm2Tender.Logic.Models.Dto
{
    public class UserView
    {
        public long UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }

        public static implicit operator UserView(Data.User a)
        {
            if (a == null) return null;

            var result = new UserView()
            {
                UserId = a.UserId,
                Name = a.Name,
                Email = a.Email,
                Role = a.Role,
            };

            return result;
        }
    }
}
