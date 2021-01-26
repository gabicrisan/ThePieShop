using System;
using System.Collections.Generic;
using WebShop.Models;

namespace WebShop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Pie> PiesOfTheWeek { get; set; }
    }
}
