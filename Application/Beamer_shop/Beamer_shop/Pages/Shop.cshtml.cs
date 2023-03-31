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
        public string ModelFilter { get; set; }
        public string MakeFilter { get; set; }


        CarService carService = CarFactory.CarService;
        public List<Product> cars = new List<Product>();

        public ShopModel()
        {
            cars.AddRange(carService.GetAllCars());
        }

        public void OnGet()
        {
            var carFiltered = cars.OfType<Car>().Where(c => c.Make == "2019").ToList();
            var filteredProducts = cars.Cast<Product>().ToList();
            cars.Clear();
            cars.AddRange(filteredProducts);

        }
    }
}
