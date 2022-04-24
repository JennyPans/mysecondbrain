using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MySecondBrain.Domain.Services
{
    public class CategoryService
    {
        /// <summary>
        /// Renvoie toutes les catégories d'un utilisateur.
        /// </summary>
        /// <returns>Liste de catégories.</returns>
        public static IEnumerable<Infrastructure.DB.Category> GetNotes()
        {
            using (Infrastructure.DB.MySecondBrainContext db = new Infrastructure.DB.MySecondBrainContext())
            {
                return db.Category.ToList();
            }
        }

        /// <summary>
        /// Créer une catégorie
        /// </summary>
        /// <param name="category">La catégorie à créer</param>
        public static void CreateCategory(Infrastructure.DB.Category category)
        {
            using (Infrastructure.DB.MySecondBrainContext db = new Infrastructure.DB.MySecondBrainContext())
            {
                db.Category.Add(category);
                db.SaveChanges();
            }
        }
    }
}
