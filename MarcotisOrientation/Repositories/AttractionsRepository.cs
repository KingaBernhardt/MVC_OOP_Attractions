using MacrotisOrientation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MacrotisOrientation.Repositories
{
    public class AttractionsRepository : IGenericRepository<Attractions>
    {
        private MacrotisOrientationExamContext attractionContext;

        public AttractionsRepository(MacrotisOrientationExamContext attractionContext)
        {
            this.attractionContext = attractionContext;
        }

        public void Create(Attractions attraction)
        {
            attractionContext.Attractions.Add(attraction);
            attractionContext.SaveChanges();
        }

        public void Delete(Attractions attraction)
        {
            attractionContext.Attractions.Remove(attraction);
            attractionContext.SaveChanges();
        }

        public Attractions GetElementById(int id)
        {
            return attractionContext.Attractions.ToList().FirstOrDefault(a => a.Id == id);
            //vagy: attractionContext.Attractions.Where(a => a.Id == id).FirstOrDefault();
        }

        public List<Attractions> Read()
        {
            return attractionContext.Attractions.ToList();
        }

        public void Update(Attractions attraction)
        {
            attractionContext.Attractions.Update(attraction);
            attractionContext.SaveChanges();
        }
    }
}
