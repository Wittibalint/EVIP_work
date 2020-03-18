using System;
using System.Collections.Generic;
using System.Text;

namespace HF1_A1
{

    public class Shop
    {
        public List<Product> itemList = new List<Product>();
        internal Dictionary<Product, int> items = new Dictionary<Product, int>();
        internal List<(Product, int, int, string)> countDiscount = new List<(Product, int, int, string)>();
        internal List<(Product, int, double, string)> amountDiscount = new List<(Product, int, double, string)>();
        internal List<(List<Product>, int,string)> comboDiscount = new List<(List<Product>, int,string)>();
        internal Membership membership = Membership.NOTMEMBER;
        internal List<RewardsCard> card = new List<RewardsCard>();
        internal List<Coupon> coupons = new List<Coupon>();
        internal RewardsCard activeCard = null;
        internal Coupon activeCoupon = null;
        internal Boolean payByRewardsCard;
        public List<Product> usedItems;
        public Shop()
        {
        }
        public List<Product> GetItemList()
        {
            return itemList;
        }

        public void RegisterProduct(String item, int price)
        {
            for(int i = 0; i<itemList.Count;i++)
            {
                if (itemList[i].GetItem().Equals(item))
                {
                    if (price < itemList[i].GetPrice())
                    {
                        itemList[i].SetPrice(price);
                    }
                    return;
                }
            }
            itemList.Add(new Product(item, price));
        }
        public void RegisterCountDiscount(string item, int amountPay, int amountGet, string member)
        {
            CountDiscount.RegisterDiscount(item, amountPay, amountGet, this, member);
        }
        public void RegisterAmountDiscount(string item, int amount, double discount, string member)
        {
            AmountDiscount.RegisterDiscount(item, amount, discount, this, member);
        }
        public void RegisterComboDiscount(string item, int cost,string member)
        {
            ComboDiscount.RegisterDiscount(item, cost, member, this);
        }
        public void RegisterRewardsCard(RewardsCard userID)
        {
            card.Add(userID);
        }
        public void RegisterCoupon(Coupon coupon)
        {
            coupons.Add(coupon);
        }

        public int GetPrice(string cart)
        {
            Initial();
            ReadCart.ReadItemsAndAmount(cart,this);
            int cost = ReadCart.GetBaseCost(this);
            cost -= CountDiscount.GetCountDiscount(this);
            cost -= AmountDiscount.GetAmountDiscount(this);
            cost -= ComboDiscount.GetComboDiscount(this);
            cost = MemberAndRewardsCardDiscount.CheckRewardsCard(cost,this);
            cost = MemberAndRewardsCardDiscount.CheckMember(cost, this);
            cost = CouponDiscount.ChecCouponCard(cost, this);
            return cost;
        }

        private void Initial()
        {
            items = new Dictionary<Product, int>();
            membership = Membership.NOTMEMBER;
            activeCard = null;
            activeCoupon = null;
            payByRewardsCard = false;
            usedItems = new List<Product>();
        }

        public int FindIndexInItemList(string item)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                if (itemList[i].GetItem().Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
