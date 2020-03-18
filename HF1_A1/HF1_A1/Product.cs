using System;
using System.Collections.Generic;
using System.Text;

namespace HF1_A1
{
    public class Product
    {
        private string item;
        private int price;
        public Product(string item,int price)
        {
            this.item = item;
            this.price = price;
        }
        public string GetItem()
        {
            return item;
        }
        public int GetPrice()
        {
            return price;
        }
        public void SetPrice(int price)
        {
            this.price = price;
        }
    }
}
