using Factory;
using Logic;
using Logic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Dynamic;
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

        public ShoppingCart? shoppingCart = new ShoppingCart();

        public ShopModel()
        {
            productService = productFactory.ProductService;
            productCollection.AddRange(productService.GetAllProducts());

            storedProductCollection = productCollection;
        }

        public void OnGet()
        {
            shoppingCart = RetrieveShoppingCart();
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

            shoppingCart = RetrieveShoppingCart();

            if (shoppingCart == null) { return; }

            shoppingCart.AddItem(foundProduct);

            SaveShoppingCart(shoppingCart);

        }

        public ShoppingCart RetrieveShoppingCart()
        {
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            };


            // Check for HttpContext and session availability
            if (HttpContext?.Session == null)
            {
                throw new Exception("Session not available.");
            }

            // Retrieve shopping cart object from session
            if (HttpContext.Session.TryGetValue("Cart", out byte[] data))
            {
                try
                {
                    // Deserialize shopping cart object from session
                    var json = Encoding.UTF8.GetString(data);

                    if (json == null)
                    {
                        throw new ArgumentNullException(nameof(json));
                    }


                    return JsonConvert.DeserializeObject<ShoppingCart>(json, settings);
                }


                catch (Exception ex)
                {
                    throw new Exception("Failed to deserialize shopping cart from session.", ex);
                }
            }

            // Create new shopping cart object if not found in session
            shoppingCart = new ShoppingCart();
            SaveShoppingCart(shoppingCart);
            return shoppingCart;
        }

        public void SaveShoppingCart(ShoppingCart shoppingCart)
        {
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            };

            // Check for HttpContext and shopping cart
            if (HttpContext?.Session == null || shoppingCart == null)
            {
                throw new ArgumentNullException();
            }

            try
            {
                // Serialize shopping cart object to JSON format
                var json = JsonConvert.SerializeObject(shoppingCart, settings);

                // Store shopping cart object in session data
                HttpContext.Session.SetString("Cart", json);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to serialize shopping cart object to session.", ex);
            }
        }


    }
}
