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
        //methods
        public void AddPoints(int addPoints)
        {
            Points += addPoints;

            string Tier = "Ordinary";

            if (Points > 0 && Points < 50)
            {
                Tier = "Ordinary";
            }
            else if (Points >= 50 && Points < 99)
            {
                Tier = "Silver";
            }
            else if (Points >= 100)
            {
                Tier = "Gold";
            }
        }

        public double RedeemPoints(int usePoints)
        {
            if (Tier == "Silver" || Tier == "Gold")
            {
                if (usePoints <= Points)
                {
                    
                    double redemptionAmount = usePoints * 0.02;

                    // Subtract redeemed points from total points
                    Points -= usePoints;

                    return redemptionAmount;
                }
                else
                {
                    Console.WriteLine("Insufficient points for redemption.");
                    return 0;
                }
            }
            else
            {
                Console.WriteLine("Only Silver and Gold members can redeem points.");
                return 0;
            }
        }
    
        public void Punch()
        {
            PunchCard++;

            if (PunchCard == 11)
            {
                PunchCard = 0;

            }
        }

        public override string ToString()
        {
            return $"Points = {Points}, PunchCard = {PunchCard}, Tier = {Tier}";    
        }


        
            
        
    }

}
