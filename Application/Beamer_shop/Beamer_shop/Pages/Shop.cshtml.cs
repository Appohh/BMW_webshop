using Beamer_shop.Interfaces;
using Beamer_shop.Services;
using Factory;
using Logic;
using Logic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Dynamic;
using System.Net.Http;
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

        //Shopping cart
        public ShoppingCart? shoppingCart;
        private IShoppingCartService? _shoppingCartService;

        public ShopModel(IShoppingCartService shoppingCartService)
        {
            productService = productFactory.ProductService;
            productCollection.AddRange(productService.GetAllProducts());

            storedProductCollection = productCollection;
            _shoppingCartService = shoppingCartService;
        }

        public void OnGet()
        {
            shoppingCart = _shoppingCartService.RetrieveShoppingCart();
            _shoppingCartService.SaveShoppingCart(shoppingCart);        
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

            shoppingCart = _shoppingCartService.RetrieveShoppingCart();

            if (shoppingCart == null) { return; }

            shoppingCart.AddItem(foundProduct);

            _shoppingCartService.SaveShoppingCart(shoppingCart);

        }




    }
}
