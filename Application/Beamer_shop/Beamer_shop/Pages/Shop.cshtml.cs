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

        [BindProperty]
        public ProductFilter ProductFilter { get; set; }

        public List<Product> storedProductCollection = new List<Product>();
        public List<Product> productCollection = new List<Product>();

        public ShopModel()
        {
            productCollection = carService.GetAllCars();
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
