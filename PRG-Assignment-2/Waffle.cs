using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG_Assignment_2
{
    class Waffle : IceCream
    {
        //properties
        public string WaffleFlavour { get; set; }

        //constructors
        public Waffle() { }

        public Waffle(string option, int scoops, List<Flavour> flavour, List<Topping> topping, string waffleFlavour) : base(option, scoops, flavour, topping)
        {
            Option = option;
            Scoops = scoops;
            Flavours = flavour;
            Toppings = topping;
            WaffleFlavour = waffleFlavour;

        }
        //methods
        public override double CalculatePrice()
        {
            //calculate price for number of scoops 
            double waffleTotal = 0;

            if (Scoops == 1)
            {
                waffleTotal = 7.00;
            }

            else if (Scoops == 2)
            {
                waffleTotal = 8.50;
            }

            else if (Scoops == 3)
            {
                waffleTotal = 9.50;
            }

            else
            {
                Console.WriteLine("Invalid Number of Scoops");
            }

            //calculate price for toppings 
            double toppingPrice = Toppings.Count * 1.00;

            //calculate premium price
            double flavourPrice = 0;
            foreach (Flavour f in Flavours)
            {
                if (f.Premium == true)
                {
                    flavourPrice += 2;
                }

                else flavourPrice = 0;
            }

            //calculate waffle flavours
            double waffleFlavourPrice = 0;
            if (WaffleFlavour == "Red velvet")
            {
                waffleFlavourPrice += 3;
            }
            else if (WaffleFlavour == "Charcoal")
            {
                waffleFlavourPrice += 3;
            }
            else if (WaffleFlavour == "Pandan Waffle")
            {
                waffleFlavourPrice += 3;
            }
            else waffleFlavourPrice = 0;

            //calculate total cost

            double totalCost = waffleTotal + toppingPrice + flavourPrice + waffleFlavourPrice;

            return totalCost;
        }

        public override string ToString()
        {
            return $"Waffle - Option: {Option}, Scoops: {Scoops}, Waffle Flavour: {WaffleFlavour}, Price: ${CalculatePrice()}";
        }
    }
}
