using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySecondBrain.Application.ViewModels
{
    public class NoteListViewModel
    {
        public IEnumerable<Infrastructure.ElasticSearch.IndexDocuments.NoteDocument> Notes { get; set; }
        public string query { get; set; }
        public int NotesCount
        {
            get
            {
                return Notes.Count();
            }
        }
        public IEnumerable<Infrastructure.DB.Category> Categories { get; set; }
    }
}
