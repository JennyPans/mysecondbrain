using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MySecondBrain.MVCApp.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            var vm = Application.Services.CategoriesControllerService.GetCategoryList();
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(Application.ViewModels.CategoryDetailViewModel categoryDetailViewModel)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != null)
            {
                categoryDetailViewModel.Category.AspNetUsersId = userId;
                Application.Services.CategoriesControllerService.CreateCategory(categoryDetailViewModel.Category);
            }
            return View();
        }
    }
}
