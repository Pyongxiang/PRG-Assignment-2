using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG_Assignment_2
{
    class Flavour
    {
        //properties
        public string Type { get; set; }
        public bool Premium { get; set; }
        public int Quantity { get; set; }

        //constructors 
        public Flavour() { }

        public Flavour(string type, bool premium, int quantity)
        {
            Type = type;
            Premium = premium;
            Quantity = quantity;
        }

        //methods
        public override string ToString()
        {
            return $"Type : {Type}, Premium : {Premium}, Quantity : {Quantity}";
        }
    }
}
