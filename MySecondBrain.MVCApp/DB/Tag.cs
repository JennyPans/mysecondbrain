using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MySecondBrain.MVCApp.DB
{
    public partial class Tag
    {
        public Tag()
        {
            NoteTagRel = new HashSet<NoteTagRel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string AspNetUsersId { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual ICollection<NoteTagRel> NoteTagRel { get; set; }
    }
}
