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
/*        public static List<Infrastructure.DB.Note> GetNotes(string aspNetUsersId)
        {
            using (Infrastructure.DB.MySecondBrainContext db = new Infrastructure.DB.MySecondBrainContext())
            {
                return db.Note.Where(n => n.AspNetUsersId == aspNetUsersId).ToList();
            }
        }*/

        /// <summary>
        /// Renvoie toutes les notes de la base de données. Utilisée à de fins de test.
        /// </summary>
        /// <returns>Liste de notes</returns>
        public static List<Infrastructure.DB.Note> GetAllNotes()
        {
            using (Infrastructure.DB.MySecondBrainContext db = new Infrastructure.DB.MySecondBrainContext())
            {
                return db.Note.ToList();
            }
        }

        /// <summary>
        /// Renvoie une note par son id
        /// </summary>
        /// <returns>Note</returns>
        public static Infrastructure.DB.Note GetNote(int noteId)
        {
            using (Infrastructure.DB.MySecondBrainContext db = new Infrastructure.DB.MySecondBrainContext())
            {
                return db.Note.Find(noteId);
            }
        }
    }
}
