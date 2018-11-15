using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MacrotisOrientation.Models
{
    public class AttractionDTO
    {
        public string result;
        public int count;
        public List<Attractions> attractions;

        public AttractionDTO(string result, List<Attractions> input)
        {
            this.result = result;
            this.count = input.Count();
            this.attractions = input;
        }

    }
}
