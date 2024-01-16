using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG_Assignment_2
{
    class Waffle : IceCream
    {
        public string WaffleFlavour { get; set; }

        public Waffle() { }

        public Waffle(string option, int scoops, List<Flavour> flavour, List<Topping> topping, string WaffleFlavour)
        {
            Option = option;
            Scoops = scoops;
            Flavours = flavour;
            Toppings = topping;

        }
        //Incomplete
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
