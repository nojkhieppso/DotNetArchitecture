using Solution.Model.Enums;

namespace Solution.Model.Models
{
    public class SignedInModel
    {
        public long UserId { get; set; }

        public Roles Roles { get; set; }
    }
}
