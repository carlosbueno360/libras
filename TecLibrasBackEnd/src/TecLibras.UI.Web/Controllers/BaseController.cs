using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TecLibras.UI.Web.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
        }

        public bool IsValidOperation()
        {
            return (true);
        }
    }
}
