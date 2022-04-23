using System;
using System.Collections.Generic;
using System.Linq;

namespace MySecondBrain.TestConsole
{
    class Program
    {
        /// <summary>
        /// Méthode principale qui appelle TestServices.
        /// </summary>
        /// <returns></returns>
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // creation de l'index
            if (Domain.Services.ElasticSearch.ElasticSearchServiceAgent.CreateIndexes())
            {
                Console.WriteLine("Index créé avec succès :-)");
                IndexDatabaseNote();
            }
            else
                Console.WriteLine("Problème pendant la création de l'index!");

            /*            var notesFound = Domain.Services.ElasticSearch.ElasticSearchServiceAgent.SearchNotes("Hello");
                        foreach (var note in notesFound)
                        {
                            Console.WriteLine(note.NoteDocumentText);
                        }*/

            //TestServices();
            /*            Domain.Services.ElasticSearch.ElasticSearchServiceAgent.SearchNotes("Hello");*/
        }

        /// <summary>
        /// Test diverses opérations en DB via le projet Domain.
        /// </summary>
        /// <returns></returns>
        public static void TestServices()
        {
            //TestTags();
            TestNotes();
        }

        /// <summary>
        /// Effectue des opérations (lecture, écriture) sur les tags.
        /// </summary>
        /// <returns></returns>
/*        public static void TestTags()
        {
            foreach (var item in Domain.Services.TagService.GetTags())
            {
                Console.WriteLine(item.Name);
            }
        }*/

        /// <summary>
        /// Effectue des opérations (lecture, écriture) sur les Notes.
        /// </summary>
        /// <returns></returns>
        public static void TestNotes()
        {
            /*            foreach (var item in Domain.Services.NoteService.GetNotes())
                        {
                            Console.WriteLine(item);
                        }*/
            foreach (var item in Domain.Services.NoteService.GetAllNotes())
            {
                Console.WriteLine(item);
            }
        }

        private static void IndexDatabaseNote()
        {
            var noteDocuments = new List<Infrastructure.ElasticSearch.IndexDocuments.NoteDocument>();

            using (Infrastructure.DB.MySecondBrainContext db = new Infrastructure.DB.MySecondBrainContext())
            {
                // on construit la liste des documents à indexer sur base du contenu de la DB
                foreach (var note in db.Note.ToList())
                {
                    var noteDocument = new Infrastructure.ElasticSearch.IndexDocuments.NoteDocument()
                    {
                        NoteDocumentId = note.Id,
                        NoteDocumentName = note.Name,
                        NoteDocumentDescription = note.Description,
                        NoteDocumentText = note.Text
                    };

                    noteDocuments.Add(noteDocument);
                }
            }

            // on indexe
            if (Domain.Services.ElasticSearch.ElasticSearchServiceAgent.IndexAllNotes(noteDocuments))
                Console.WriteLine("Notes indexés avec succès :-)");
            else
                Console.WriteLine("Une erreur s'est produite pendant l'indexation des notes!");
        }

    }
}
