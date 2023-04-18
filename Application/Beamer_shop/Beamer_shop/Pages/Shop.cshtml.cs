using Factory;
using Logic;
using Logic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Beamer_shop.Pages
{
    public class ShopModel : PageModel
    {
        ProductFactory productFactory = new ProductFactory();
        ProductService productService;


        [BindProperty]
        public ProductFilter ProductFilter { get; set; }

        public List<Product> storedProductCollection = new List<Product>();
        public List<Product> productCollection = new List<Product>();

        public ShopModel()
        {
            productService = productFactory.ProductService;
            productCollection.AddRange(productService.GetAllProducts());

            storedProductCollection = productCollection;
        }

        public void OnPost()
        {
            if (ProductFilter != null)
            {
                productCollection = ProductFilter.FilterProducts(productCollection);
            }
        }
    }
}
