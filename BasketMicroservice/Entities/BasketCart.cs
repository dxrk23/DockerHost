using System.Collections.Generic;

namespace BasketMicroService.Entities
{
    public class BasketCart
    {
        public BasketCart()
        {
        }

        public BasketCart(string username)
        {
            Username = username;
        }

        public string Username { get; set; }
        public List<BasketCartItem> Items { get; set; } = new List<BasketCartItem>();

        public decimal TotalPrice
        {
            get
            {
                decimal totalprice = 0;
                foreach (var item in Items) totalprice += item.Price * item.Quantity;

                return totalprice;
            }
        }
    }
}