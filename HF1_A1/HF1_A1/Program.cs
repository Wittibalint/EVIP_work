using System;

namespace HF1_A1
{
    class Program
    {
        static void Main(string[] args)
        {
            RewardsCard card = new RewardsCard(1);
            Shop shop = new Shop();
            shop.RegisterRewardsCard(card);
            shop.RegisterProduct("A",100);
            shop.RegisterProduct("B",10);
            shop.RegisterProduct("C", 15);
            shop.RegisterCountDiscount("A", 3, 4 , "n");
            shop.RegisterAmountDiscount("B", 2, 0.9, "n");
            shop.RegisterComboDiscount("CB", 20,"y");
            shop.GetPrice("A1");
            Console.WriteLine(shop.GetPrice("A1pF"));
        }
    }
}
