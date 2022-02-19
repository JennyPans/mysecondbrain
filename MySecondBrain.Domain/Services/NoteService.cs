using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MySecondBrain.Domain.Services
{
    public class NoteService
    {
        /// <summary>
        /// Renvoie toutes les notes d'un utilisateur
        /// </summary>
        /// <returns>Liste de notes</returns>
        public static List<Infrastructure.DB.Note> GetNotes()
        {
            using (Infrastructure.DB.MySecondBrainContext db = new Infrastructure.DB.MySecondBrainContext())
            {
                return db.Note.ToList();
            }
        }
    }
}
