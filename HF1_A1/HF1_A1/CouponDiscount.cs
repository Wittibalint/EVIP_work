using System;
using System.Collections.Generic;
using System.Text;

namespace HF1_A1
{
    class CouponDiscount
    {
        public static int ChecCouponCard(int cost, Shop shop)
        {
            if (shop.activeCoupon != null)
            {
                cost = (int)(cost * shop.activeCoupon.discount);
                shop.coupons.Remove(shop.activeCoupon);
            }
            return cost;
        }
    }
}
