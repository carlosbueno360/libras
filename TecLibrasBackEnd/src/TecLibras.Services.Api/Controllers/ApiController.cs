using System.Collections.Generic;
using System.Linq;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TecLibras.Services.Api.Controllers
{
    public abstract class ApiController : ControllerBase
    {
        protected ApiController()
        {
           
        }

        protected new IActionResult Response(object result = null)
        {
        
            return Ok(new
            {
                success = true,
                data = result
            });
          

            // return BadRequest(new
            // {
            //     success = false,
            //     errors = ""
            // });
        }

        protected void NotifyModelStateErrors()
        {
            var erros = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var erro in erros)
            {
                var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
            }
        }

        protected void AddIdentityErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
               
            }
        }
    }
}
