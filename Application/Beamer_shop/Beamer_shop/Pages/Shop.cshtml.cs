using Beamer_shop.Interfaces;
using Beamer_shop.Services;
using Factory.Interfaces;
using Logic;
using Logic.Interfaces;
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
        IProductFactory _productFactory;
        IProductService _productService;

        //Shopping cart
        public ShoppingCart? shoppingCart;
        private IShoppingCartService _shoppingCartService;

        [BindProperty]
        public ProductFilter? ProductFilter { get; set; }

        [BindProperty]
        public int? CartReceivedProductId { get; set; }

        public List<Product> storedProductCollection = new List<Product>();
        public List<Product> productCollection = new List<Product>();



        public ShopModel(IProductFactory productFactory, IShoppingCartService shoppingCartService)
        {
            _productFactory = productFactory;
            _productService = _productFactory.ProductService;
            productCollection.AddRange(_productService.GetAllProducts());

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

    }
}
