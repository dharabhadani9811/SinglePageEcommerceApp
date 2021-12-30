using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DharaProject.Configuration
{
    public class JwtConfig
    {
        public string Secrets { get; set; } = default!;
    }
}
