using System;

namespace Solution.Model.Enums
{
    [Flags]
    public enum Roles
    {
        None = 0,
        User = 1,
        Admin = 2
    }
}
