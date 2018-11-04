using System.Security.Claims;

namespace Solution.CrossCutting.Utils
{
    public static class ClaimsPrincipalExtensions
    {
        public static long ClaimNameIdentifierValue(this ClaimsPrincipal claimsPrincipal)
        {
            return long.TryParse(claimsPrincipal.ClaimNameIdentifier(), out var value) ? value : 0;
        }

        public static Claim Claim(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            return claimsPrincipal?.FindFirst(claimType);
        }

        public static string ClaimNameIdentifier(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.Claim(ClaimTypes.NameIdentifier)?.Value;
        }
    }
}
