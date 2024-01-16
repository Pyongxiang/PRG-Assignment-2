using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG_Assignment_2
{
    class PointCard
    {
        //properties 
        public int Points { get; set; }

        public int PunchCard { get; set; }

        public string Tier { get; set; }

        //constructors
        public PointCard() { }

        public PointCard(int points, int punchCard)
        {
            Points = points;
            PunchCard = punchCard; 
        }

        public AddPoints(int points)
        {
            Points += points;
        }

        public RedeemPoints(int points)
        {
            Points = points;
        }
        public Punch() { }

        public override string ToString()
        {
            return $"Points = {Points}, PunchCard = {PunchCard}, Tier = {Tier}";    
        }


        
            
        
    }

}
