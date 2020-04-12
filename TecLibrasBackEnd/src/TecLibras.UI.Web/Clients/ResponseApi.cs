using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TecLibras.UI.Web.Clients
{
    public class ResponseApi<T>
    {
        public bool success { get; set; }
        public T data { get; set; }
    }
}
