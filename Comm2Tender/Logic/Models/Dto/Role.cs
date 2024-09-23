using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comm2Tender.Logic.Models.Dto
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Name { get; set; }   

        public static implicit operator Role(Data.Role a)
        {
            if (a == null) return null;

            return new Role()
            {
                RoleId = a.RoleId,
                Name = a.Name
            };
        }
    }
}
