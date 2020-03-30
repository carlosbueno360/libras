using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TecLibras.UI.Web.ViewComponents
{
    public class SummaryViewComponent : ViewComponent
    {

        public SummaryViewComponent()
        {
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notificacoes = await Task.FromResult(true);
            //notificacoes.ForEach(c => ViewData.ModelState.AddModelError(string.Empty, c.Value));

            return View();
        }
    }
}