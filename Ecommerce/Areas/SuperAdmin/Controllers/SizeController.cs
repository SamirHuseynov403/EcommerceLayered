using Ecommerce.BLL.DTOs.Color;
using Ecommerce.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.MVC.Areas.SuperAdmin.Controllers
{
    public class SizeController : AdminController
    {
        private readonly ISizeService _sizeService;

        public SizeController(ISizeService sizeService)
        {
            _sizeService = sizeService;
        }

        public async Task<IActionResult> Index()
        {
            var listSizes =await _sizeService.GetAllAsync();
            return View(listSizes);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateSizeDto sizeDto)
        {
            if (!ModelState.IsValid)
            {
                return View(sizeDto);
            }
            var existSize = await _sizeService.GetByNameAsync(sizeDto.SizeProduct!);

            if (existSize != null)
            {
                ModelState.AddModelError("Name", "Bu Size bazada movcuddur.");
                return View(sizeDto);
            }

            await _sizeService.CreateAsync(sizeDto);

            return RedirectToAction("Index");
        }
    }
}
