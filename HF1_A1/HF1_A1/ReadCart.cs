using System;
using System.Collections.Generic;
using System.Text;

namespace HF1_A1
{
    class ReadCart
    {
        public static void ReadItemsAndAmount(string cart,Shop shop)
        {
            for (int i = 0; i < cart.Length; i++)
            {
                if (cart[i].Equals('p'))
                {
                    shop.payByRewardsCard = true;
                }
                else if (cart[i].Equals('v'))
                {
                    i++;
                    string cardNum = "";
                    while (true)
                    {   
                        if (cart.Length <= i)
                        {
                            break;
                        }
                        else if (!char.IsNumber(cart[i]))
                        {
                            i--;
                            break;
                        }
                        else
                        {
                            cardNum += cart[i];
                            i++;
                        }
                    }
                    GetActiveCard(cardNum, shop);
                    shop.membership = Membership.MEMBER;
                    continue;
                }
                else if (cart[i].Equals('k'))
                {
                    i++;
                    string couponNum = "";
                    while (true)
                    {
                        if (cart.Length <= i)
                        {
                            break;
                        }
                        else if (!char.IsNumber(cart[i]))
                        {
                            i--;
                            break;
                        }
                        else
                        {
                            couponNum += cart[i];
                            i++;
                        }
                    }
                    GetActiveCoupon(couponNum, shop);
                    continue;
                }
                else
                {
                    GetItems(cart[i], shop);
                }
            }
        }
        public static int GetBaseCost(Shop shop)
        {
            int cost = 0;
            foreach (Product p in shop.items.Keys)
            {
                cost += shop.items[p] * p.GetPrice();
            }
            return cost;
        }
        private static void GetActiveCard(string c,Shop shop)
        {
            foreach (RewardsCard r in shop.card)
            {
                if (r.userID.ToString().Equals(c))
                {
                    shop.activeCard = r;
                    break;
                }
            }
        }
        private static void GetActiveCoupon(string c, Shop shop)
        {
            foreach (Coupon r in shop.coupons)
            {
                if (r.couponID.ToString().Equals(c))
                {
                    shop.activeCoupon = r;
                    break;
                }
            }
        }
        private static void GetItems(char c,Shop shop)
        {
            for (int i = 0; i < shop.itemList.Count; i++)
            {
                if (shop.itemList[i].GetItem().Equals(c.ToString()))
                {
                    if (shop.items.ContainsKey(shop.itemList[i]))
                    {
                        shop.items[shop.itemList[i]]++;
                    }
                    else
                    {
                        shop.items.Add(shop.itemList[i], 1);
                    }
                    return;
                }
            }
            throw new Exception("Item does not exist: " + c);
        }
    }
}
