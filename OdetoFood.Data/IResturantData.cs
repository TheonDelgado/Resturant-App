using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OdetoFood.Core;

namespace OdetoFood.Data
{
    public interface IResturantData
    {
        IEnumerable<Resturant> GetAll();
    }

    public class InMemoryResturantData : IResturantData
    {
        List<Resturant> resturants;
        public InMemoryResturantData()
        {
            resturants = new List<Resturant>() 
            {
                new Resturant {Id = 1, Name = "Pizza Place", Location = "Maryland", Cuisine = CuisineType.Other},
                new Resturant {Id = 2, Name = "Mexican Fiesta", Location = "Dearborn", Cuisine = CuisineType.Mexican},
                new Resturant {Id = 3, Name = "Kyoto", Location = "Royal Oak", Cuisine = CuisineType.Asian},
                new Resturant {Id = 4, Name = "Leos Coney", Location = "Dearborn", Cuisine = CuisineType.American}
            };


        }

        public IEnumerable<Resturant> GetAll() 
        {
            return from r in resturants orderby r.Name select r;
        }
    }
}