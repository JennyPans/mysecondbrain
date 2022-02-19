using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MySecondBrain.Domain.Services
{
    public class TagService
    {
        /// <summary>
        /// Renvoie tous les tags
        /// </summary>
        /// <returns>Liste de tags</returns>
        public static List<Infrastructure.DB.Tag> GetTags(string aspNetUsersId)
        {
            using (Infrastructure.DB.MySecondBrainContext db = new Infrastructure.DB.MySecondBrainContext())
            {
                return db.Tag.Where(t => t.AspNetUsersId == aspNetUsersId).ToList();
            }
        }
    }
}
