using Microsoft.AspNetCore.Mvc;

namespace PetShop.MVC.Components.Header
{
    public class HeaderViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
