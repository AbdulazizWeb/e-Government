﻿using e_Government.Application.Abstractions;
using e_Government.Infrastructure.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace e_Government.Infrastructure.Services
{
    public class JWTService : ITokenService
    {
        private readonly JWTConfiguration _jwtConfiguration;

        public JWTService(IOptions<JWTConfiguration> jwtConfiguration)
        {
            _jwtConfiguration = jwtConfiguration.Value;
        }

        public string GetAcessToken(Claim[] ministryClaims)
        {
            var jwtClaim = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString())
            };

            var claims = ministryClaims.Concat(jwtClaim);

            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfiguration.Secret)),
                SecurityAlgorithms.HmacSha256
                );

            var token = new JwtSecurityToken(
                _jwtConfiguration.ValidIssuer,
                _jwtConfiguration.ValidAudience,
                claims,
                expires: DateTime.UtcNow.AddMonths(1),
                signingCredentials: credentials);

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }
    }
}