using System;
using System.Collections.Generic;
using System.Text;

namespace HF1_A1
{
    public class Coupon
    {
        public int couponID { get;}
        public double discount { get; }

        public Coupon(int ID, double discount)
        {
            this.couponID = ID;
            this.discount = discount;
        }
    }
}
