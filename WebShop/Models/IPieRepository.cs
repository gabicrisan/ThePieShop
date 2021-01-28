using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public interface IPieRepository
    {
        IEnumerable<Pie> AllPies { get; }

        IEnumerable<Pie> PiesOfTheWeek { get; }

        Pie GetPieById(int pieId);

        void AddNewPie(Pie pie);

        void RemovePie(Pie pie);

        void EditPie(Pie pie);
     }
}
