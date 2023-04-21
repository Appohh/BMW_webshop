using Factory;
using Logic;
using Logic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;

namespace Beamer_shop.Pages
{
    public class ShopModel : PageModel
    {
        ProductFactory productFactory = new ProductFactory();
        ProductService productService;


        [BindProperty]
        public ProductFilter? ProductFilter { get; set; }

        public List<Product> storedProductCollection = new List<Product>();
        public List<Product> productCollection = new List<Product>();

        public ShoppingCart? shoppingCart;

        public ShopModel()
        {
            productService = productFactory.ProductService;
            productCollection.AddRange(productService.GetAllProducts());

            storedProductCollection = productCollection;


            if (HttpContext.Session.TryGetValue("Cart", out byte[]? data))
            {
                // Deserialize shopping cart object from session
                var json = Encoding.UTF8.GetString(data);
                shoppingCart = JsonConvert.DeserializeObject<ShoppingCart>(json);
            }

            // If shoppingCart still null, create new shopping cart
            if (shoppingCart == null)
            {
                shoppingCart = new ShoppingCart();
            }

        }

        public void OnPost()
        {
            if (ProductFilter != null)
            {
                productCollection = ProductFilter.FilterProducts(productCollection);
            }
        }

        //OnPostAddToCart(id){ }
    }
}
