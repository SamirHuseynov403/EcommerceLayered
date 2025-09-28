using Ecommerce.BLL.DTOs.Category;
using Ecommerce.BLL.DTOs.Color;
using Ecommerce.BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerce.MVC.Areas.SuperAdmin.Controllers
{
    public class ColorController : AdminController
    {
        private readonly IColorService _colorService;

        public ColorController(IColorService colorService)
        {
            _colorService = colorService;
        }

        public async Task<IActionResult> Index()
        {
            var listColors = await _colorService.GetAllAsync();
            return View(listColors);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateColorDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var existColor = await _colorService.AddColorAsync(model);
            if (!existColor)
            {
                ModelState.AddModelError("Name", "Bu Color bazada movcuddur.");
                return View(model);
            }

           return RedirectToAction("Index");
        }
    }
}
