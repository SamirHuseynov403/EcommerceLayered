using Microsoft.AspNetCore.Mvc;

namespace PetShop.MVC.Components.Footer
{
    public class FooterViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
