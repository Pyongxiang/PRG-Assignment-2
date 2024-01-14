using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG_Assignment_2
{
    class Customer
    {
        //Properties
        public string Name { get; set; }

        public int MemberId { get; set; }

        public DateTime Dob { get; set; }

        public Order CurrentOrder { get; set; }

        public List<Order> OrderHistory { get; set; }

        public PointCard Rewards { get; set; }

        //Constructors
        public Customer() { }

        public Customer(string name, int memberId, DateTime dob)
        {
            Name = name;
            MemberId = memberId;
            Dob = dob;
        }

        //Method
        public Order MakeOrder()
        {

        }



    }
}
