using System;
using System.Collections.Generic;

namespace MySecondBrain.Infrastructure.DB
{
    public partial class Note
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsFavorite { get; set; }
        public int? CategoryId { get; set; }
        public int Evaluation { get; set; }

        public virtual Category Category { get; set; }
    }
}
