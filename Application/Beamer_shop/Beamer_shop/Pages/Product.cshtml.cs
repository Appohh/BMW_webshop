using Factory.Interfaces;
using Logic;
using Logic.Interfaces;
using Logic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Beamer_shop.Pages
{
    public class ProductModel : PageModel
    {
        IProductFactory _productFactory;
        IProductService _productService;   
        
        public List<Product> productCollection = new List<Product>();
        public List<Product> recommendedProducts = new List<Product>();
        public List<string> productImages = new List<string>();

        public Product? Product { get; private set; }

        public ProductModel(IProductFactory productFactory) {
            _productFactory = productFactory;
            _productService = _productFactory.ProductService;

            productCollection.AddRange(_productService.GetAllProducts());
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
            recommendedProducts.AddRange(_productService.GetProductAccessories(Product));
            productImages.AddRange(_productService.GetProductImages(Product));

        }
    }
}
