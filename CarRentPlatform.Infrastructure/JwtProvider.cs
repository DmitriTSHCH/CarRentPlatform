using CarRentPlatform.Application.Intefaces.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace CarRentPlatform.Infrastructure
{
    public class JwtProvider : IJwtProvider
    {
        private readonly JwtOptions _options;
        public JwtProvider(IOptions<JwtOptions> options)
        {
            _options = options.Value;
        }

        public string Generate(Guid userId)
        {
            Claim[] claims = [new("userId", userId.ToString())];

            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)),
                                                            SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(signingCredentials: signingCredentials,
                                             expires: DateTime.UtcNow.AddHours(_options.ExpireHours),
                                             claims: claims,
                                             issuer: _options.Issuer,
                                             audience: _options.Audience);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
