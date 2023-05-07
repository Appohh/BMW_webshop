using Logic.Models;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logic.Interfaces;
using Beamer_shop.Interfaces;

namespace Beamer_shop.Pages
{
    public class EditCart : PageModel
    {
        private IProductService _productService;
        private IShoppingCartService _shoppingCartService;
        private ShoppingCart? _shoppingCart = null;

        public EditCart(IProductService productService, IShoppingCartService shoppingCartService)
        {
            _productService = productService;
            _shoppingCartService = shoppingCartService;
        }

        public IActionResult OnGetAsync(int productId, string action)
        {

            //Check if id is valid
            if (productId <= 0 && action != "clear")
            {
                return BadRequest("Id not valid.");
            }

            //Check if product exists
            Product? product = _productService.getProductById(productId);
            if (product == null && action != "clear")
            {
                return NotFound("Product not found.");
            }

            _shoppingCart = _shoppingCartService.RetrieveShoppingCart();

            if(_shoppingCart == null) { return NotFound("Cart not found."); }


            //Switch for action
            switch (action)
            {
                case "add":
                    _shoppingCart.AddItem(product);
                    break;
                case "remove":
                    _shoppingCart.RemoveItem(product);
                    break;
                case "clear":
                    _shoppingCart.Clear();
                    break;
                default:
                    return BadRequest("Invalid action.");
            }

            //Try to save cart to session
            string result = _shoppingCartService.SaveShoppingCart(_shoppingCart);

            if (result.Length <= 0)
            {
                return BadRequest("Saving cart failed.");
            }
            else
            {
                //If success return cart in JSON format
                return new JsonResult(result);
            }
        }
    }
}
