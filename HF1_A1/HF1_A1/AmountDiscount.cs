
using System;
using System.Collections.Generic;
using System.Text;

namespace HF1_A1
{
    public class AmountDiscount
    {
        public static void RegisterDiscount(string item, int amount, double discount, Shop shop1, string member)
        {
            try
            {
                int index = shop1.FindIndexInItemList(item);
                shop1.amountDiscount.Add((shop1.itemList[index], amount, discount, member));
            }
            catch (Exception e)
            {
                Console.WriteLine("Item not exsist:" + item);
            }

        }
        public static int GetAmountDiscount(Shop shop1)
        {
            double discount = 0;
            for (int i = 0; i < shop1.amountDiscount.Count; i++)
            {
                int count;
                if (shop1.items.ContainsKey(shop1.amountDiscount[i].Item1) &&
                    !shop1.usedItems.Contains(shop1.amountDiscount[i].Item1))
                {
                    if (!shop1.amountDiscount[i].Item4.Equals("y") && shop1.membership.Equals(Membership.NOTMEMBER))
                    {
                        count = shop1.items[shop1.amountDiscount[i].Item1];
                        if (count >= shop1.amountDiscount[i].Item2)
                        {
                            discount += shop1.amountDiscount[i].Item1.GetPrice() * count * (1 - shop1.amountDiscount[i].Item3);
                            shop1.usedItems.Add(shop1.amountDiscount[i].Item1);
                        }
                    }
                }
            }
            return Convert.ToInt32(discount);
        }
    }
}
