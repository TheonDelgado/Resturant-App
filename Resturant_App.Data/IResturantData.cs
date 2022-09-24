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
        Resturant Update(Resturant updatedResturant);
        int Commit();
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

        public Resturant Update(Resturant updatedResturant)
        {
            Resturant resturant = resturants.SingleOrDefault(r => r.Id == updatedResturant.Id);

            if(resturant != null)
            {
                resturant.Name = updatedResturant.Name;
                resturant.Location = updatedResturant.Location;
                resturant.Cuisine = updatedResturant.Cuisine;
            }
            return resturant;
        }

        public int Commit()
        {
            return 0;
        }
    }
}