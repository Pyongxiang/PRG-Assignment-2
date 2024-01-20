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
        public string Option { get; set; }
        public int Scoops { get; set; }

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
        public IceCream(string option, int scoops, List<Flavour> flavours, List<Topping> toppings)
        {
            Option = option;
            Scoops = scoops;
            Flavours = flavours;  
            Toppings = toppings;   
        }

        public abstract double CalculatePrice();
        public override string ToString()
        {
            return $"Option : {Option}, Scoops : {Scoops}, Flavours : {Flavours}, Toppings : {Toppings}";
        }

    }
}
