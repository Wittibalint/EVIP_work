using System;
using System.Collections.Generic;
using System.Text;

namespace HF1_A1
{
    class CountDiscount
    {
        public static void RegisterDiscount(string item, int amountPay, int amountGet, Shop shop1, string member)
        {
            try
            {
                int index = shop1.FindIndexInItemList(item);
                shop1.countDiscount.Add((shop1.itemList[index], amountPay, amountGet, member));
            }
            catch (Exception e)
            {
                Console.WriteLine("Item not exsist:" + item);
            }

        }
        public static int GetCountDiscount(Shop shop)
        {
            int discount = 0;
            for (int i = 0; i < shop.countDiscount.Count; i++)
            {
                int count;
                if (shop.items.ContainsKey(shop.countDiscount[i].Item1))
                {
                    if (!shop.countDiscount[i].Item4.Equals("y") && shop.membership.Equals(Membership.NOTMEMBER))
                    {
                        count = shop.items[shop.countDiscount[i].Item1];
                        if (count >= shop.countDiscount[i].Item3)
                        {
                            discount += shop.countDiscount[i].Item1.GetPrice() * (count / shop.countDiscount[i].Item3);
                            shop.usedItems.Add(shop.countDiscount[i].Item1);
                        }
                    }
                }
            }
            return discount;
        }
    }
}
