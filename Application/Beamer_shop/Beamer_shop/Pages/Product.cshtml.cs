using Factory;
using Logic;
using Logic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Beamer_shop.Pages
{
    public class ProductModel : PageModel
    {
        CarService carService = CarFactory.CarService;
        AccessoryService accessoryService = AccessoryFactory.AccessoryService;

        public List<Product> productCollection = new List<Product>();
        public List<Product> recommendedProducts = new List<Product>();

        public Product? Product { get; private set; }

        public ProductModel() {
            productCollection.AddRange(carService.GetAllCars());
            productCollection.AddRange(accessoryService.GetAllAccessories());
        }

        public void OnGet(int Id)
        {
            Product = productCollection.FirstOrDefault(prod => prod.Id == Id);
            if (Product == null)
            {
                Product notFoundProduct = new Accessory("", -99, "Oops! Product not found :/", 0, "", "", "");
                Product = notFoundProduct;
            }
        }
    }
}
