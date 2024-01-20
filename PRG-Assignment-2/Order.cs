using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG_Assignment_2
{
    class Order
    {
        //Properties
        public int Id { get; set; }

        public DateTime TimeReceived { get; set;}

        public DateTime? TimeFulfilled { get; set; }

        public List<IceCream> IceCreamList { get; set; }

        //Constructors
        public Order() { }

        public Order(int id, DateTime timeReceived)
        {
            Id = id;
            TimeReceived = timeReceived;            
        }
        //methods
        public void ModifyIceCream(int mod_IceCream) 
        {

        }

        public void AddIceCream(IceCream add_IceCream)
        {

        }

        public void DeleteIceCream(int del_IceCream)
        {

        }
        
        public double CalculateTotal()
        {
            double totalCost = 0;

            foreach (var iceCream in IceCreamList)
            {
                totalCost += iceCream.CalculatePrice();
            }

            return totalCost;
        }

        public override string ToString()
        {
            return $"Order ID : {Id}, Time Received : {TimeReceived}, TimeFulfilled : {TimeFulfilled}, Total : {CalculateTotal()}";
        }
    }
}
