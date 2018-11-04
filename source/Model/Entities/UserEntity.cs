using Solution.Model.Enums;
using System.Collections.Generic;

namespace Solution.Model.Entities
{
    public class UserEntity
    {
        public long UserId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public Roles Roles { get; set; }

        public Status Status { get; set; }

        public virtual ICollection<UserLogEntity> UsersLogs { get; set; } = new HashSet<UserLogEntity>();
    }
}
