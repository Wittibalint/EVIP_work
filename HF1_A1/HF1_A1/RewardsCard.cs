using System;
using System.Collections.Generic;
using System.Text;

namespace HF1_A1
{
    public class RewardsCard
    {
        public int userID { get; set; }
        public int points { get; set; }
        
        public RewardsCard(int userID)
        {
            this.userID = userID;
            points = 0;
        }

    }
}
