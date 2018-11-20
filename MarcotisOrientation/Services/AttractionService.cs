using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MacrotisOrientation.Models;
using MacrotisOrientation.Repositories;

namespace MacrotisOrientation.Services
{
    public class AttractionService : IAttractionService
    {
        private AttractionsRepository attractionsRepository;

        public AttractionService(AttractionsRepository attractionsRepository)
        {
            this.attractionsRepository = attractionsRepository;
        }

        public void AddAttraction(Attractions attraction)
        {
            attractionsRepository.Create(attraction);
        }

        public void Delete(Attractions attraction)
        {
            attractionsRepository.Delete(attraction);
        }

        public void EditAttraction(Attractions attraction)
        {
            attractionsRepository.Update(attraction);
        }

        public Attractions GetAttractionById(int id)
        {
            return attractionsRepository.GetElementById(id);
        }

        public List<Attractions> ListAllAttractions()
        {
            return attractionsRepository.Read();
        }

        public List<Attractions> ListByCategoryAndCity(string category, string city)
        {
            if (category is null && city is null)
            {
                return attractionsRepository.Read();
            }
            else if (city is null)
            {
                return attractionsRepository.Read().Where(attr => attr.Category.ToLower()
                .Contains(category.ToLower())).ToList();
            }
            else if (category is null)
            {
                return attractionsRepository.Read().Where(attr => attr.City.ToLower()
                .Contains(city.ToLower())).ToList();
            }
            return attractionsRepository.Read().Where(x => x.Category.ToLower()
            .Contains(category.ToLower())
            && x.City.ToLower().Contains(city.ToLower())).ToList();
        }

        public AttractionDTO CreateDTOBySearch(string category, string city)
        {
            AttractionDTO attractionDTO =
                new AttractionDTO("ok", ListByCategoryAndCity(category, city));
            return attractionDTO;
        }
    }
}
