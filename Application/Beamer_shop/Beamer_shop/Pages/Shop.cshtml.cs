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
        CarService carService = CarFactory.CarService;
        AccessoryService accessoryService = AccessoryFactory.AccessoryService;


        [BindProperty]
        public ProductFilter ProductFilter { get; set; }

        public List<Product> storedProductCollection = new List<Product>();
        public List<Product> productCollection = new List<Product>();

        public ShopModel()
        {
            productCollection.AddRange(carService.GetAllCars());
            productCollection.AddRange(accessoryService.GetAllAccessories());
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
