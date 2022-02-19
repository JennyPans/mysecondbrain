using System;
using System.Collections.Generic;

namespace MySecondBrain.Infrastructure.DB
{
    public partial class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CategoryId { get; set; }
    }
}
