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
            NoteCategoryRel = new HashSet<NoteCategoryRel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsFavorite { get; set; }
        public int Evaluation { get; set; }
        public DateTime CreateDatetime { get; set; }
        public DateTime WriteDatetime { get; set; }
        public string Text { get; set; }
        public string AspNetUsersId { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual ICollection<NoteCategoryRel> NoteCategoryRel { get; set; }
    }
}
