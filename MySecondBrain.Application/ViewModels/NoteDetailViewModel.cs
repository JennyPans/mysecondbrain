using System;
using System.Collections.Generic;
using System.Text;

namespace MySecondBrain.Application.ViewModels
{
    public class NoteDetailViewModel
    {
        public Infrastructure.DB.Note Note { get; set; }
        public IEnumerable<Infrastructure.DB.Category> Categories { get; set; }
        public int? CategoryId { get; set; }

    }
}
