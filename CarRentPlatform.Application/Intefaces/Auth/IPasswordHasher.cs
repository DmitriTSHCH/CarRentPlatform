using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Application.Intefaces.Auth
{
    public interface IPasswordHasher
    {
        public string Generate(string passwod);
        public bool Verify(string passwod, string hashedPassword);
    }
}
