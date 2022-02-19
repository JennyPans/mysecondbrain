using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;

namespace MySecondBrain.Infrastructure.ElasticSearch
{
    /// <summary>
    /// Agent de service responsable d'encapsuler les accès à ElasticSearch
    /// </summary>
    public class ElasticSearchServiceAgent
    {
        // à déplacer dans l'appsettings
        static string elasticAddress = "http://localhost:9200";
/*        const string albumIndexName = "album_index";*/

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
      /*  public static bool CreateIndexes()
        {
            var esClient = new ElasticClient(GetESConnectionSettings());

            if (esClient.Indices.Exists(albumIndexName).Exists)
            {
                var response = esClient.Indices.Delete(albumIndexName);
            }

            var createIndexResponse = esClient.Indices.Create(albumIndexName, index => index.Map<IndexDocuments.AlbumDocument>(x => x.AutoMap()));

            return createIndexResponse.IsValid;
        }

        public static bool IndexAllAlbums(List<IndexDocuments.AlbumDocument> albumDocuments)
        {
            var esClient = new ElasticClient(GetESConnectionSettings());

            foreach(var albumDocument in albumDocuments)
            {
                var indexResponse = esClient.Index(albumDocument, c => c.Index(albumIndexName));

                if (!indexResponse.IsValid)
                    return false;
            }

            return true;
        }

        public static bool IndexAlbum(IndexDocuments.AlbumDocument albumDocument)
        {
            var esClient = new ElasticClient(GetESConnectionSettings());

                var indexResponse = esClient.Index(albumDocument, c => c.Index(albumIndexName));

            return indexResponse.IsValid;
        }

        public static List<IndexDocuments.AlbumDocument> GetAllAlbums()
        {
            var esClient = new ElasticClient(GetESConnectionSettings());

            // récupération de tous les documents de l'index des albums
            var albums = esClient.Search<IndexDocuments.AlbumDocument>(search =>
                    search.Index(albumIndexName)
                            .Size(1000)
                            .Query(q => q.MatchAll()));


            return albums.Documents.ToList();
        }

        public static List<IndexDocuments.AlbumDocument> SearchAlbumsByTitle(string title)
        {
            var client = new ElasticClient(GetESConnectionSettings());

            // récupération des documents dont le titre de l'album reprend le texte dans title
            var albums = client.Search<IndexDocuments.AlbumDocument>(search =>
                                search.Index(albumIndexName)
                                        .Size(1000)
                                        .Query(q => q.Match(m => m.Field(f => f.AlbumTitle)
                                                                .Query(title))));

            return albums.Documents.ToList();
        }

        public static List<IndexDocuments.AlbumDocument> SearchAlbums(string searchQuery)
        {
            var client = new ElasticClient(GetESConnectionSettings());

            // ex: get all documents in index
            var albums = client.Search<IndexDocuments.AlbumDocument>(search =>
                                search.Index(albumIndexName)
                                        .Size(1000)
                                        .Query(q => q.MultiMatch(m => m.Query(searchQuery))));

            return albums.Documents.ToList();


        }
*/

    }
}
