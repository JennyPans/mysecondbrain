using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MySecondBrain.Infrastructure.DB
{
    public partial class Category
    {
        public Category()
        {
            InverseCategoryNavigation = new HashSet<Category>();
            NoteCategoryRel = new HashSet<NoteCategoryRel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? CategoryId { get; set; }
        public string AspNetUsersId { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual Category CategoryNavigation { get; set; }
        public virtual ICollection<Category> InverseCategoryNavigation { get; set; }
        public virtual ICollection<NoteCategoryRel> NoteCategoryRel { get; set; }
    }
}
