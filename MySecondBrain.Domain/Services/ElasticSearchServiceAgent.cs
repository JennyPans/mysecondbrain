using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;

namespace MySecondBrain.Domain.Services.ElasticSearch
{
    /// <summary>
    /// Agent de service responsable d'encapsuler les accès à ElasticSearch
    /// </summary>
    public class ElasticSearchServiceAgent
    {
        // à déplacer dans l'appsettings
        static string elasticAddress = "http://localhost:9200";
        const string noteIndexName = "note_index";

        /// <summary>
        /// Crée l'objet settings nécessaire pour se connecter à ES
        /// </summary>
        /// <returns></returns>
        static ConnectionSettings GetESConnectionSettings()
        {
            var node = new Uri(elasticAddress);
            var settings = new ConnectionSettings(node);
            settings.ThrowExceptions(alwaysThrow: true);
            settings.PrettyJson(); // Good for DEBUG

            return settings;
        }

        /// <summary>
        ///  Création des index dans ElasticSearch
        /// </summary>
        public static bool CreateIndexes()
        {
            var esClient = new ElasticClient(GetESConnectionSettings());

            if (esClient.Indices.Exists(noteIndexName).Exists)
            {
                var response = esClient.Indices.Delete(noteIndexName);
            }

            var createIndexResponse = esClient.Indices.Create(noteIndexName, index => index.Map<Infrastructure.ElasticSearch.IndexDocuments.NoteDocument>(x => x.AutoMap()));

            return createIndexResponse.IsValid;
        }

        public static bool IndexAllNotes(List<Infrastructure.ElasticSearch.IndexDocuments.NoteDocument> noteDocuments)
        {
            var esClient = new ElasticClient(GetESConnectionSettings());

            foreach (var noteDocument in noteDocuments)
            {
                var indexResponse = esClient.Index(noteDocument, c => c.Index(noteIndexName));

                if (!indexResponse.IsValid)
                    return false;
            }

            return true;
        }

        public static bool IndexNote(Infrastructure.ElasticSearch.IndexDocuments.NoteDocument noteDocument)
        {
            var esClient = new ElasticClient(GetESConnectionSettings());

            var indexResponse = esClient.Index(noteDocument, c => c.Index(noteIndexName));

            return indexResponse.IsValid;
        }

        public static IEnumerable<Infrastructure.ElasticSearch.IndexDocuments.NoteDocument> GetAllNotes()
        {
            var esClient = new ElasticClient(GetESConnectionSettings());

            // récupération de tous les documents de l'index des albums
            var notes = esClient.Search<Infrastructure.ElasticSearch.IndexDocuments.NoteDocument>(search =>
                    search.Index(noteIndexName)
                            .Size(1000)
                            .Query(q => q.MatchAll()));


            return notes.Documents.ToList();
        }

        public static List<Infrastructure.ElasticSearch.IndexDocuments.NoteDocument> SearchNotesByTitle(string name)
        {
            var client = new ElasticClient(GetESConnectionSettings());

            // récupération des documents dont le nom de la note reprend le texte dans name
            var notes = client.Search<Infrastructure.ElasticSearch.IndexDocuments.NoteDocument>(search =>
                                search.Index(noteIndexName)
                                        .Size(1000)
                                        .Query(q => q.Match(m => m.Field(f => f.NoteDocumentName)
                                                                .Query(name))));

            return notes.Documents.ToList();
        }

        public static Infrastructure.ElasticSearch.IndexDocuments.NoteDocument SearchNoteById(int id)
        {
            var client = new ElasticClient(GetESConnectionSettings());

            // récupération des documents dont le nom de la note reprend le texte dans name
            var notes = client.Search<Infrastructure.ElasticSearch.IndexDocuments.NoteDocument>(search =>
                                search.Index(noteIndexName).Query(q => q.Match(m => m.Field(f => f.NoteDocumentId == id))));

            return notes.Documents.SingleOrDefault();
        }

        public static IEnumerable<Infrastructure.ElasticSearch.IndexDocuments.NoteDocument> SearchNotes(string searchQuery)
        {
            var client = new ElasticClient(GetESConnectionSettings());

            // ex: get all documents in index
            var notes = client.Search<Infrastructure.ElasticSearch.IndexDocuments.NoteDocument>(search =>
                                search.Index(noteIndexName)
                                        .Size(1000)
                                        .Query(q => q.MultiMatch(m => m.Query(searchQuery))));

            return notes.Documents.ToList();


        }

        public static void RemoveNote(int noteId)
        {
            var client = new ElasticClient(GetESConnectionSettings());
            var response = client.Delete<Infrastructure.ElasticSearch.IndexDocuments.NoteDocument>(noteId, d => d.Index(noteIndexName));
        }


    }
}
