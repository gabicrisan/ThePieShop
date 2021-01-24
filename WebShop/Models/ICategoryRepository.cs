using System;
using System.Collections.Generic;

namespace WebShop.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
