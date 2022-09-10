using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApp.Core
{
    public class Resturant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public CusineType Cusine { get; set; }
    }
}