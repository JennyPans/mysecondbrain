using System;
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
            TestServices();
        }

        /// <summary>
        /// Test diverses opérations en DB via le projet Domain.
        /// </summary>
        /// <returns></returns>
        public static void TestServices()
        {
            TestTags();
            TestNotes();
        }

        /// <summary>
        /// Effectue des opérations (lecture, écriture) sur les tags.
        /// </summary>
        /// <returns></returns>
        public static void TestTags()
        {
            foreach (var item in Domain.Services.TagService.GetTags())
            {
                Console.WriteLine(item.Name);
            }
        }

        /// <summary>
        /// Effectue des opérations (lecture, écriture) sur les Notes.
        /// </summary>
        /// <returns></returns>
        public static void TestNotes()
        {
            foreach (var item in Domain.Services.NoteService.GetNotes())
            {
                Console.WriteLine(item);
            }
        }
    }
}
