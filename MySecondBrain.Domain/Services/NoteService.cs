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

        /// <summary>
        /// Créer une note
        /// </summary>
        /// <param name="note">La note à créer</param>
        public static void CreateNote(Infrastructure.DB.Note note)
        {
            using (Infrastructure.DB.MySecondBrainContext db = new Infrastructure.DB.MySecondBrainContext())
            {
                db.Note.Add(note);
                db.SaveChanges();
                // dans l'idéal, c'est l'objet qui devrait faire tout ça
                var noteDocument = new Infrastructure.ElasticSearch.IndexDocuments.NoteDocument()
                {
                    NoteDocumentId = note.Id,
                    NoteDocumentName = note.Name,
                    NoteDocumentDescription = note.Description,
                    NoteDocumentText = note.Text
                };
                ElasticSearch.ElasticSearchServiceAgent.IndexNote(noteDocument);
            }
        }

    }
}
