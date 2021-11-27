using System;
using System.Collections.Generic;

namespace MySecondBrain.Infrastructure.DB
{
    public partial class NoteTagRel
    {
        public int NoteId { get; set; }
        public int TagId { get; set; }
    }
}
