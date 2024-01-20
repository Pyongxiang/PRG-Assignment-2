using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace PRG_Assignment_2
{
    class Cup : IceCream
    {   
        //constructors 
        public Cup() { }
        public Cup(string option, int scoops, List<Flavour> flavours, List<Topping> toppings) : base(option, scoops, flavours, toppings) { }

        //methods
        public override double CalculatePrice()
        {
            //calculate price for number of scoops
            double cupTotal = 0; 

            if (Scoops == 1)
            {
                cupTotal = 4;
            }

            else if (Scoops == 2)
            {
                cupTotal = 5.50;
            }

            else if (Scoops == 3)
            {
                cupTotal = 6.50;
            }

            else
            {
                Console.WriteLine("Invalid Number of Scoops");
            }

            //calculate price for toppings 
            double toppingPrice = Toppings.Count * 1.00;

            //calculate price for premium flavours 
            double flavourPrice = 0;
            foreach (Flavour f in Flavours)
            {
                if (f.Premium == true)
                {
                    flavourPrice += 2;
                }

                else flavourPrice = 0;
            }

            double totalCost = cupTotal + toppingPrice + flavourPrice;

            return totalCost;
        }

        public override string ToString()
        {
            return $"Cup with {Scoops} Scoops, Option: {Option}, Total Price: ${CalculatePrice():0.00}";
        }

    }
}
