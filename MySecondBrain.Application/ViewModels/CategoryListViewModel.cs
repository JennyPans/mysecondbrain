using System;
using System.Collections.Generic;
using System.Text;

namespace MySecondBrain.Application.ViewModels
{
    public class CategoryListViewModel
    {
        public IEnumerable<Infrastructure.DB.Category> Categories { get; set; }
    }
}
