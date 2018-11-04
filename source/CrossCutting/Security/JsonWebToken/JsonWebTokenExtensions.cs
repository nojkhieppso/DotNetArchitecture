using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace Solution.CrossCutting.Security
{
    public static class JsonWebTokenExtensions
    {
        public static void AddJti(this ICollection<Claim> claims)
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
        }

        public static void AddRoles(this ICollection<Claim> claims, string[] roles)
        {
            roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
        }

        public static void AddSub(this ICollection<Claim> claims, string sub)
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, sub));
        }
    }
}
