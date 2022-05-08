using System.Collections.Generic;
using System.Linq;
using ShoeShop.Dtos;

namespace ShoeShopWeb.Models
{
    public class CartItem
    {
        public ProductDto Product { get; set; }
        public int Quantity { get; set; }   
    }
    public class CartCollection
    {
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();

        public void Add(CartItem item)
        {
            var finding = CartItems.Find(c=>c.Product.ID == item.Product.ID);
            if (finding == null)
            {
                CartItems.Add(item);
            }
            else
            {
                finding.Quantity += item.Quantity;
            }
        }

        public void ClearAll()=>CartItems.Clear();

        public double GetTotalPrice() => CartItems.Sum(c => c.Product.Price * c.Quantity);

        public void Delete(int id) => CartItems.RemoveAll(c => c.Product.ID == id);
    }
}
