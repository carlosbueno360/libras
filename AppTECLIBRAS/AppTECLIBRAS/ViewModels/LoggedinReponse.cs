using System;
using System.Collections.Generic;
using System.Text;

namespace AppTECLIBRAS.ViewModels
{
    public class LoggedinReponse
    {
        public bool Success { get; set; }
        public string UserId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }
    }
}
