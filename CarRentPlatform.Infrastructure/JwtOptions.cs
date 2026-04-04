using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Infrastructure
{
    internal class JwtOptions
    {
        public int ExpireHours { get; set; }
        public string SekretKey { get; set; }
        public string Isuer { get; set; }
        public string Aaudiens { get; set; }
    }
}
