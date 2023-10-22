using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.ViewModels.ViewModels
{
    public class JwtOptionsVm
    {
        public string Issuer { get; set; } = default!;
        public string Audience { get; set; } = default!;
        public string SecretKey { get; set; }= default!;
        public int TokenExpirationMinutes { get; set; }
    }
}