using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using eCaiet.BE.Classes.InjectedInterfaces;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace eCaiet.BE.Classes.Utilities
{
    public class TokenBuilder : ITokenBuilder
    {
        private readonly string _secretKey;

        public TokenBuilder(string secretKey)
        {
            _secretKey = secretKey;
        }

        public string Generate<T>(T key)
        {
            var claims = new[]
            {
                new Claim("User", JsonConvert.SerializeObject(key))
            };
            var symKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var token = new JwtSecurityToken(
                signingCredentials: new SigningCredentials(symKey, SecurityAlgorithms.HmacSha256),
                claims: claims
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
