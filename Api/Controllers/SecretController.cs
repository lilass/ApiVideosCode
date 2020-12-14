using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class SecretController
    {
        [Authorize]
        public string Index() 
        {
            return "secret message";
        }
    }
}
