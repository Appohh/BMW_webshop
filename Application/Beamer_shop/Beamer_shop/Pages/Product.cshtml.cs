using Factory;
using Logic;
using Logic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Beamer_shop.Pages
{
    public class ProductModel : PageModel
    {
        ProductFactory productFactory = new ProductFactory();
        ProductService productService;   
        
        public List<Product> productCollection = new List<Product>();
        public List<Product> recommendedProducts = new List<Product>();
        public List<string> productImages = new List<string>();

        public Product? Product { get; private set; }

        public ProductModel() {
            productService = productFactory.ProductService;

            productCollection.AddRange(productService.GetAllProducts());
        }

        public void OnGet(int Id)
        {
            Product = productCollection.FirstOrDefault(prod => prod.Id == Id);
            if (Product == null)
            {
                Product notFoundProduct = new Accessory("", -99, "Oops! Product not found :/", 0, "", "", "");
                Product = notFoundProduct;
                return;
            }
            recommendedProducts.AddRange(productService.GetProductAccessories(Product));
            productImages.AddRange(productService.GetProductImages(Product));

        }
    }
}
