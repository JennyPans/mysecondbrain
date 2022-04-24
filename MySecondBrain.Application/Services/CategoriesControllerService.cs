using System;
using System.Collections.Generic;
using System.Text;

namespace MySecondBrain.Application.Services
{
    public class CategoriesControllerService
    {
        /// <summary>
        /// Appelle le service de la couche domain pour créer une catégorie
        /// </summary>
        /// <param name="categoryId">Catégorie à créer</param>
        /// <returns></returns>
        public static void CreateCategory(Infrastructure.DB.Category category)
        {
            Domain.Services.CategoryService.CreateCategory(category);
        }

        /// <summary>
        /// Renvoie une liste de toutes les catégories
        /// </summary>
        /// <returns>CategoriesListViewModdel</returns>
        public static ViewModels.CategoryListViewModel GetCategoryList()
        {
            ViewModels.CategoryListViewModel vm = new ViewModels.CategoryListViewModel();
            vm.Categories = Domain.Services.CategoryService.GetCategories();
            return vm;
        }
    }
}
