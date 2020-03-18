using System;
using Xunit;
using HF1_A1;

namespace Test
{
    public class UnitTest1
    {
        Shop shop = new Shop();
        [Fact]
        public void GetPrice()
        {
            shop.RegisterProduct("A", 50);
            Assert.Equal(100, shop.GetPrice("AA"));
        }
        [Fact]
        public void GetCountDiscount()
        {
            shop.RegisterProduct("A", 50);
            shop.RegisterCountDiscount("A", 3, 4, "n");
            Assert.Equal(150, shop.GetPrice("AAAA"));
        }
        [Fact]
        public void GetAmountDiscount()
        {
            shop.RegisterProduct("A", 10);
            shop.RegisterAmountDiscount("A", 3, 0.9, "n");
            Assert.Equal(27, shop.GetPrice("AAA"));
        }
        [Fact]
        public void GetComboDiscount()
        {
            shop.RegisterProduct("A", 10);
            shop.RegisterProduct("B", 10);
            shop.RegisterComboDiscount("AB", 15, "n");
            Assert.Equal(25, shop.GetPrice("AAB"));
        }
        [Fact]
        public void GetMember()
        {
            shop.RegisterProduct("A", 50);
            RewardsCard card = new RewardsCard(14);
            Assert.Equal(90, shop.GetPrice("AAv14"));
        }
        [Fact]
        public void GetMemberComboDiscount()
        {
            shop.RegisterProduct("A", 10);
            shop.RegisterProduct("B", 10);
            shop.RegisterComboDiscount("AB", 15, "y");
            RewardsCard card = new RewardsCard(22);
            Assert.Equal(27, shop.GetPrice("v22AABB"));
        }
        [Fact]
        public void GetCardDiscount()
        {
            shop.RegisterProduct("A", 100);
            RewardsCard card = new RewardsCard(12);
            shop.RegisterRewardsCard(card);
            shop.GetPrice("AAv12");
            Assert.Equal(2, card.points);

        }
        [Fact]
        public void PayByCard()
        {
            shop.RegisterProduct("A", 100);
            RewardsCard card = new RewardsCard(1);
            shop.RegisterRewardsCard(card);
            shop.GetPrice("Av1");
            Assert.Equal(89, shop.GetPrice("Av1p"));

        }
        [Fact]
        public void NotExistitem()
        {
            shop.RegisterProduct("A", 50);
            shop.RegisterAmountDiscount("B", 3, 0.9, "n");
            Assert.Throws<Exception>(() => shop.GetPrice("B"));
        }
        [Fact]
        public void Combo4Product()
        {
            shop.RegisterProduct("A", 50);
            shop.RegisterProduct("B", 50);
            shop.RegisterProduct("C", 50);
            shop.RegisterProduct("D", 50);
            shop.RegisterComboDiscount("ABCD", 190, "n");
            Assert.Equal(430, shop.GetPrice("ABCDABCDA"));
        }
        [Fact]
        public void GetLowerRegisterPrice()
        {
            shop.RegisterProduct("A", 50);
            shop.RegisterProduct("A", 40);
            Assert.Equal(40, shop.GetPrice("A"));
        }
        [Fact]
        public void GetCouponDiscount()
        {
            shop.RegisterProduct("A", 100);
            Coupon c = new Coupon(12 , 0.9);
            shop.RegisterCoupon(c);
            Assert.Equal(90, shop.GetPrice("Ak12"));

        }

        [Fact]
        public void GetMoreDiscount()
        {
            shop.RegisterProduct("A", 100);
            shop.RegisterProduct("B", 90);
            shop.RegisterCountDiscount("A", 3, 4, "n");
            shop.RegisterAmountDiscount("A", 3, 0.9, "n");
            shop.RegisterComboDiscount("AB", 15, "n");
            Assert.Equal(390, shop.GetPrice("AAAAB"));

        }

    }
}
