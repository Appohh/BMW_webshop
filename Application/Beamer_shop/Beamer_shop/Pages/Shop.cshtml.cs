using Factory;
using Logic;
using Logic.Models;
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

        [BindProperty]
        public int? CartReceivedProductId { get; set; }

        public List<Product> storedProductCollection = new List<Product>();
        public List<Product> productCollection = new List<Product>();

        public ShoppingCart? shoppingCart;

        public ShopModel()
        {
            productService = productFactory.ProductService;
            productCollection.AddRange(productService.GetAllProducts());

            storedProductCollection = productCollection;


            retrieveShoppingCart();

        }

        public void OnPostFilterProducts()
        {
            if (ProductFilter != null)
            {
                productCollection = ProductFilter.FilterProducts(productCollection);
            }
        }

        public void OnPostAddToCart()
        {
            if(CartReceivedProductId == null) { return; }

            Product? foundProduct = productService.getProductById(CartReceivedProductId.Value);
            if (foundProduct == null) { return; }


            retrieveShoppingCart();

            if(shoppingCart == null) { return; }

            shoppingCart.AddItem(foundProduct);

            saveShoppingCart();

        }

        public void retrieveShoppingCart()
        {
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            };

            if (HttpContext != null && HttpContext.Session != null && HttpContext.Session.TryGetValue("Cart", out byte[]? data))
            {
                // Deserialize shopping cart object from session
                var json = Encoding.UTF8.GetString(data);
                shoppingCart = JsonConvert.DeserializeObject<ShoppingCart>(json, settings);
            }

            // If shoppingCart still null, create new shopping cart
            if (shoppingCart == null)
            {
                shoppingCart = new ShoppingCart();
                saveShoppingCart();
            }
        }

        public void saveShoppingCart()
        {
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            };

            if (HttpContext == null || shoppingCart == null) return;

            var product1 = new Accessory("fd", 2, "fds", 1, "fdsg", "fdsfdsf", "fdss");
            shoppingCart.AddItem(product1);
            // Serialize shoppingcart to JSON
            var json = JsonConvert.SerializeObject(shoppingCart, settings);
            //byte[] data = Encoding.UTF8.GetBytes(json);

            // Store shoppingcart in session
            HttpContext.Session.SetString("Cart", json);
        }


    }
}
