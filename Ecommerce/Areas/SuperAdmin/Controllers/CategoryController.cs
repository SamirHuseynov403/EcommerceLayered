using Ecommerce.BLL.DTOs.Category;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerce.MVC.Areas.SuperAdmin.Controllers
{
    public class CategoryController : AdminController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<ActionResult> Index()
        {
            var listCategory = await _categoryService.GetAllAsync();
            return View(listCategory);
        }
        public async Task<IActionResult> Create()
        {
            var categories = await _categoryService.GetAllAsync();
            ViewBag.ParentCategories = new SelectList(categories, "Id", "Name");
            return View(new CreateCategoryDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return View(categoryDto);
            }
            var existCategory = await _categoryService.GetByNameAsync(categoryDto.Name);

            if (existCategory != null)
            {
                ModelState.AddModelError("Name", "Bu Category bazada movcuddur.");
                return View(categoryDto);
            }

            await _categoryService.CreateAsync(categoryDto);
            return RedirectToAction("Index");
        }
    }
}
