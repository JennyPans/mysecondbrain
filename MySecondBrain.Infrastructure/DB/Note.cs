using System;
using System.Collections.Generic;

namespace MySecondBrain.Infrastructure.DB
{
    public partial class Note
    {
        public Note()
        {
            NoteTagRel = new HashSet<NoteTagRel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsFavorite { get; set; }
        public int? CategoryId { get; set; }
        public int Evaluation { get; set; }
        public string AspNetUsersId { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<NoteTagRel> NoteTagRel { get; set; }
    }
}
