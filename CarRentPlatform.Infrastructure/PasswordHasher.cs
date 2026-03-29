using CarRentPlatform.Application.Intefaces.Auth;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Infrastructure
{
    public class PasswordHasher : IPasswordHasher
    {
        public string Generate(string passwod)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(passwod);
        }

        public bool Verify(string passwod, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(passwod, hashedPassword);
        }
    }
}
