using MacrotisOrientation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MacrotisOrientation.Services
{
    public interface IAttractionService
    {
        List<Attractions> ListAllAttractions();
        void AddAttraction(Attractions attraction);
        void EditAttraction(Attractions attraction);
        Attractions GetAttractionById(int id);
        void Delete(Attractions attraction);
        List<Attractions> ListByCategoryAndCity(string category, string city);
        AttractionDTO CreateDTOBySearch(string category, string city);
    }
}
