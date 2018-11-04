using Solution.Model.Enums;
using System;

namespace Solution.Model.Entities
{
    public class UserLogEntity
    {
        public long UserLogId { get; set; }

        public long UserId { get; set; }

        public LogType LogType { get; set; }

        public string Content { get; set; }

        public DateTime DateTime { get; set; }

        public virtual UserEntity User { get; set; }
    }
}
