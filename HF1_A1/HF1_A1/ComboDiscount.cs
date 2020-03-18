using System;
using System.Collections.Generic;
using System.Text;

namespace HF1_A1
{
    class ComboDiscount
    {
        public static void RegisterDiscount(string item, int cost, string member, Shop shop)
        {
            try
            {
                List<Product> products = new List<Product>();
                foreach (char p in item)
                {
                    products.Add(shop.itemList[shop.FindIndexInItemList(p.ToString())]);
                }
                shop.comboDiscount.Add((products, cost, member));
            }
            catch (Exception e)
            {
                Console.WriteLine("Item not exsist:" + item);
            }
        }
        public static int GetComboDiscount(Shop shop)
        {
            int discount = 0;
            for (int i = 0; i < shop.comboDiscount.Count; i++)
            {
                if (shop.membership == Membership.NOTMEMBER && shop.comboDiscount[i].Item3.Equals("y"))
                {
                    continue;
                }

                int basicPrice = 0;
                int count = Int32.MaxValue;
                foreach (Product p in shop.comboDiscount[i].Item1)
                {
                    if (shop.items.ContainsKey(p) && !shop.usedItems.Contains(p))
                    {
                        if (count > shop.items[p])
                        {
                            count = shop.items[p];
                        }            
                        basicPrice += p.GetPrice();
                    }
                    else
                    {
                        count = 0;
                        break;
                    }
                }
                discount += count * (basicPrice - shop.comboDiscount[i].Item2);
            }
            return discount;
        }
    }
}
