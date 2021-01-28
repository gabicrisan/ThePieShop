using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebShop.Models
{
    public class PieRepository: IPieRepository
    {
        private readonly AppDbContext _appDbContext;

        //constructor pentru a include appdbcontext
        public PieRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Pie> AllPies
        {
            get
            {
                //cerem appdbcontext sa aduca din dbb Pies precum si categoria pt fiecare Pie
                return _appDbContext.Pies.Include(c => c.Category);
            }
        }

        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return _appDbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);
            }
            
        }

        public Pie GetPieById(int pieId)
        {
            return _appDbContext.Pies.FirstOrDefault(p => p.PieId == pieId);
        }

        public void AddNewPie(Pie pie)
        {
            _appDbContext.Pies.Add(pie);

            _appDbContext.SaveChanges();
        }

        public void RemovePie(Pie pie)
        {
            _appDbContext.Pies.Remove(pie);

            _appDbContext.SaveChanges();
        }

        public void EditPie(Pie pie)
        {
            _appDbContext.Attach(pie).State = EntityState.Modified;

            _appDbContext.SaveChanges();
        }
    }
}
