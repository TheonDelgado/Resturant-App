using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Resturant_App.Core;

namespace Resturant_App.Data
{
    public interface IResturantData
    {
        IEnumerable<Resturant> GetResturantsByName(string name);
        Resturant GetById(int id);
    }

    public class InMemoryResturantData : IResturantData
    {
        List<Resturant> resturants;
        public InMemoryResturantData()
        {
            resturants = new List<Resturant>() 
            {
                new Resturant {Id = 1, Name = "Pizza Place", Location = "Maryland", Cuisine = CuisineType.OTHER},
                new Resturant {Id = 2, Name = "Mexican Fiesta", Location = "Dearborn", Cuisine = CuisineType.MEXICAN},
                new Resturant {Id = 3, Name = "Kyoto", Location = "Royal Oak", Cuisine = CuisineType.ASIAN},
                new Resturant {Id = 4, Name = "Leos Coney", Location = "Dearborn", Cuisine = CuisineType.AMERICAN}
            };


        }

        public Resturant GetById(int id)
        {
            return resturants.SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<Resturant> GetResturantsByName(string name = null) 
        {
            return from r in resturants where string.IsNullOrEmpty(name) || r.Name.StartsWith(name) orderby r.Name select r;
        }
    }
}