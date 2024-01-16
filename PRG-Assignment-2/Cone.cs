using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG_Assignment_2
{
    class Cone : IceCream
    {
        public bool Dipped { get; set; }

        public Cone() { }

        public Cone(string option, int scoops,List<Flavour> flavours, List<Topping> toppings, bool dipped) : base(option, scoops, flavours,toppings)
        {
            Dipped = dipped;
        }
        //incomplete
        public override double CalculatePrice()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "x";
        }
    }
}
