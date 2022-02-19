using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

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
        public int Evaluation { get; set; }
        public string AspNetUsersId { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual ICollection<NoteTagRel> NoteTagRel { get; set; }
    }
}
