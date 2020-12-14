using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server
{
    public class Constants
    {
        public const string Issuer = Audience; //the issuer here is the audience because the server is issuing the token to himself
        public const string Audience = "https://localhost:44367/";
        public const string Secret = "not_too_short_secret_otherwise_it_might_error";
    }
}
