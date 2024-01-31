using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG_Assignment_2
{
    class Cone : IceCream
    {   
        //properties
        public bool Dipped { get; set; }

        //constructors 
        public Cone() { }

        public Cone(string option, int scoops,List<Flavour> flavours, List<Topping> toppings, bool dipped) : base(option, scoops, flavours,toppings)
        {
            Dipped = dipped;
        }

        //methods 
        public override double CalculatePrice()
        {
            //calculate price for number of scoops 
            double coneTotal = 0;

            if (Scoops == 1)
            {
                coneTotal = 4;
            }

            else if (Scoops == 2)
            {
                coneTotal = 5.50;
            }

            else if (Scoops == 3)
            {
                coneTotal = 6.50;
            }

            else
            {
                Console.WriteLine("Invalid Number of Scoops");
            }

            //calculate price for toppings 
            double toppingPrice = Toppings.Count * 1.00;

            //calculate price for chocolate-dipped cone 
            double dippedTotal = 0;
            if (Dipped == true)
            {
                dippedTotal += 2;
            }

            else dippedTotal = 0;

            //calculate premium price
            double flavourPrice = 0;
            foreach (Flavour f in Flavours)
            {
                if (f.Premium)
                {
                    flavourPrice += 2; // accumulate premium flavour prices
                }
            }

            //calculate total cost

            double totalCost = coneTotal + toppingPrice + flavourPrice + dippedTotal;

            return totalCost;
        }

        public override string ToString()
        {
            return $"Cone with {Scoops} scoops{(Dipped ? " (Dipped)" : "")}, Option: {Option}, Total Price: ${CalculatePrice():0.00}";
        }

    }
}
