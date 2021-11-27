using System;
using System.Collections.Generic;

namespace MySecondBrain.Infrastructure.DB
{
    public partial class Tag
    {
        public Tag()
        {
            NoteTagRel = new HashSet<NoteTagRel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<NoteTagRel> NoteTagRel { get; set; }
    }
}
