using System;
using System.Collections.Generic;
using System.Text;

namespace HF1_A1
{
    class MemberAndRewardsCardDiscount
    {
        public static int CheckRewardsCard(int cost,Shop shop)
        {
            if (shop.activeCard != null)
            {
                if (shop.payByRewardsCard == true)
                {
                    return PayByCard(cost, shop);
                }
                shop.activeCard.points += cost / 100;
            }
            return cost;
        }
        public static int CheckMember(int cost,Shop shop)
        {
            if (shop.membership.Equals(Membership.MEMBER))
            {
                return Convert.ToInt32(cost * 0.9);
            }
            return cost;
        }
        private static int PayByCard(int cost,Shop shop)
        {
            int costPayed = 0;
            if (shop.activeCard.points > cost)
            {
                costPayed = cost;
                shop.activeCard.points -= cost;
            }
            else
            {
                costPayed = cost - shop.activeCard.points;
                shop.activeCard.points = 0;
            }
            shop.activeCard.points += cost / 100;
            return costPayed;
        }
    }
}
