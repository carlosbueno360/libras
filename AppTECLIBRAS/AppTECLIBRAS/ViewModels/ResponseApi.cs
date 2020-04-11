using System;
using System.Collections.Generic;
using System.Text;

namespace AppTECLIBRAS.ViewModels
{
    public class ResponseApi<T>
    {
        public bool success { get; set; }
        public T data { get; set; }
    }
}
