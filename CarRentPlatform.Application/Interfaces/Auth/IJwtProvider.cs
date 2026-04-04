using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;

namespace CarRentPlatform.Application.Intefaces.Auth
{
    public interface IJwtProvider
    {
        public string Generate(Guid userId);
    }
}
