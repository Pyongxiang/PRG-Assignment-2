using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG_Assignment_2
{
    abstract class IceCream
    {   
        //Properties
        public string option { get; set; }
        public int scoops { get; set; }

        private List<Flavour> flavours; // Assuming a list of strings for flavor

        public List<Flavour> Flavours
        {
            get { return flavours; }
            set { flavours = value; }
        }

        private List<Topping> toppings;
        public List <Topping> Toppings
        {
            get { return toppings; }
            set { toppings = value; }
        }

        //Constructors
        public IceCream() { }
        public IceCream(string o, int s, List<Flavour> f, List<Topping> t)
        {
            Option = o;
            Scoops = s;
            Flavours = f;  
            Toppings = t;   
        }

    }
}
