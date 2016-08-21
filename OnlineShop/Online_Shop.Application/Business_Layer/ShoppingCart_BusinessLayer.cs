using System;
using Online_Shop.Application.DataAccessLayer;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Online_Shop.Application.Entities;

namespace Online_Shop.Application.Business_Layer
{
    public class ShoppingCart_BusinessLayer
    {
        ShopDAL Data = new ShopDAL();
        public string ShoppingCartId { get; set; }
        public const string CartSessionKey = "CartId";
        public static ShoppingCart_BusinessLayer GetCart(HttpContextBase context)
        {
            ShoppingCart_BusinessLayer Cart = new ShoppingCart_BusinessLayer();
            Cart.ShoppingCartId = Cart.GetCartId(context);
            return Cart;
        }

        public void AddToCart(Product product)
        {
            var CartItem = Data.Cart.SingleOrDefault(c => c.CartId == ShoppingCartId && c.ProductId == product.Id);

            if (CartItem == null)
            {
                CartItem = new Cart
                {
                    CartId = ShoppingCartId,
                    ProductId = product.Id,
                    Count = 1,
                    DateCreated = DateTime.Now
                };
                Data.Cart.Add(CartItem);
            }
            else
            {
                CartItem.Count++;
            }
            Data.SaveChanges();
        }


        public void removeFromCart(int id)
        {
            var cartItem = Data.Cart.SingleOrDefault(cart => cart.CartId == ShoppingCartId && cart.RecordId == id);
            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                    cartItem.Count--;
                else
                    Data.Cart.Remove(cartItem);

                Data.SaveChanges();
            }
        }

        public void EmptyCart()
        {
            var cartItem=Data.Cart.Where(cart=>cart.CartId==ShoppingCartId);
            foreach (var cart in cartItem)
            {
                Data.Cart.Remove(cart);
            }
            Data.SaveChanges();
        }

        public List<Cart> GetCartItems()
        { 
            
            List<Cart> cartItems = (from cart in Data.Cart
                             where cart.CartId == ShoppingCartId
                             select cart).ToList();
            return cartItems;

        }

        public int GetCount()
        {
            int? count = (from cartItems in Data.Cart
                          where cartItems.CartId == ShoppingCartId
                          select (int?)cartItems.Count).Sum();
            

            return count ?? 0;
        }
        public int GetCount1(int id)
        {
            int? count = (from cartItems in Data.Cart
                          where cartItems.CartId == ShoppingCartId && cartItems.RecordId == id
                          select (int?)cartItems.Count).Sum();


            return count ?? 0;
        }

        //public int GetProCount(int id,string ShopCart)
        //{
        //    int count =(from cartItem in Data.Cart
        //                 where cartItem.CartId == ShopCart && cartItem.ProductId == id
        //                 select (int)cartItem.Count).Sum();
        //    return count;
        //}
        public decimal GetTotal()
        {
            decimal? Total=(from cartItems in Data.Cart
                            where cartItems.CartId == ShoppingCartId
                            select (int?)cartItems.Count * cartItems.product.Price).Sum();

            return Total ?? decimal.Zero;
        }

        public int CreatOrder(Order order)
        {
            decimal OrderTotal = 0;
            List<Cart> cartItems = GetCartItems();
            if (cartItems != null)
            {
                foreach (Cart cartItem in cartItems)
                {
                    cartItem.product = Data.Products.Single(c => c.Id == cartItem.ProductId);
                    OrderDetail orderDetails = new OrderDetail();
                    
                        orderDetails.ProductId = cartItem.ProductId;
                        orderDetails.OrderId = order.OrderId;
                        orderDetails.UnitPrice = cartItem.product.Price;
                        orderDetails.Quantity = cartItem.Count;
                    
                    Data.OrderDetail.Add(orderDetails);
                    OrderTotal += (cartItem.Count * cartItem.product.Price);
                }
                Data.SaveChanges();
                EmptyCart();
                return order.OrderId;
            }

            else
                return 0;
            
        }

        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] = context.User.Identity.Name;
                }
                else
                {
                    Guid tempCartId = Guid.NewGuid();
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return context.Session[CartSessionKey].ToString();
        }

        public void MigrateCart(string userName)
        {
            var ShoppingCart = Data.Cart
                .Where(c => c.CartId == ShoppingCartId);
            foreach (Cart item in ShoppingCart)
            {
                item.CartId =ShoppingCartId;
            }
            Data.SaveChanges();
        }
    }
}
