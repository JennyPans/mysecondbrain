using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySecondBrain.Infrastructure.ElasticSearch.IndexNotes
{
    [ElasticsearchType(IdProperty = nameof(NoteDocument.NoteDocumentId))]
    public class NoteDocument
    {
        [Keyword(Name = nameof(NoteDocumentId))]
        public int NoteDocumentId { get; set; }

        [Text(Name = nameof(NoteDocumentName))]
        public string NoteDocumentName { get; set; }

        [Text(Name = nameof(NoteDocumentDescription))]
        public string NoteDocumentDescription { get; set; }

        [Text(Name = nameof(NoteDocumentText))]
        public string NoteDocumentText { get; set; }

        public NoteDocument()
        {

        }
    }
}