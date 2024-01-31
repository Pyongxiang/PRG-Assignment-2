using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG_Assignment_2
{
    class Order
    {
        // Properties
        public int Id { get; set; }
        public DateTime TimeReceived { get; set; }
        public DateTime? TimeFulfilled { get; set; }
        public List<IceCream> IceCreamList { get; set; }

        // Constructors
        public Order()
        {
            IceCreamList = new List<IceCream>(); // Initialize the IceCreamList to avoid null reference exceptions
        }

        public Order(int id, DateTime timeReceived)
        {
            Id = id;
            TimeReceived = timeReceived;
        }

        // Methods
        public void ModifyIceCream(int iceCreamIndex)
        {
            if (iceCreamIndex >= 0 && iceCreamIndex < IceCreamList.Count)
            {
                // Get the existing ice cream at the specified index
                IceCream existingIceCream = IceCreamList[iceCreamIndex];

                // Modify the existing ice cream properties based on your logic
                // For example, increment scoops or change flavors
                existingIceCream.Scoops++; // Example: Increment scoops by 1

                // Note: Modify other properties as needed

                Console.WriteLine($"Ice cream at index {iceCreamIndex} modified.");
            }
            else
            {
                Console.WriteLine("Invalid ice cream index.");
            }
        }

        public void AddIceCream(IceCream add_IceCream)
        {
            IceCreamList.Add(add_IceCream);
            Console.WriteLine("Ice cream added to the order.");
        }

        public void DeleteIceCream(int del_IceCream)
        {
            if (del_IceCream >= 0 && del_IceCream < IceCreamList.Count)
            {
                IceCreamList.RemoveAt(del_IceCream);
                Console.WriteLine($"Ice cream at index {del_IceCream} deleted.");
            }
            else
            {
                Console.WriteLine("Invalid ice cream index for deletion.");
            }
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
            StringBuilder orderDetails = new StringBuilder();

            orderDetails.AppendLine($"Order ID: {Id}, Time Received: {TimeReceived}, Time Fulfilled: {TimeFulfilled}, Total: {CalculateTotal()}");
            orderDetails.AppendLine("Ice Creams:");

            foreach (var iceCream in IceCreamList)
            {
                orderDetails.AppendLine(iceCream.ToString());
            }

            return orderDetails.ToString();
        }
    }
}