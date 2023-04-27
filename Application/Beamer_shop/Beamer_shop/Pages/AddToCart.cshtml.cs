using Logic.Models;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logic.Interfaces;
using Beamer_shop.Interfaces;

namespace Beamer_shop.Pages
{
    public class AddToCartModel : PageModel
    {
        private IProductService _productService;
        private IShoppingCartService _shoppingCartService;
        private ShoppingCart? _shoppingCart = null;

        public AddToCartModel(IProductService productService, IShoppingCartService shoppingCartService)
        {
            _productService = productService;
            _shoppingCartService = shoppingCartService;
        }

        public IActionResult OnGetAsync(int productId)
        {

            //Check if id is valid
            if (productId <= 0)
            {
                return BadRequest("Id not valid.");
            }

            //Check if product exists
            Product? product = _productService.getProductById(productId);
            if (product == null)
            {
                return NotFound("Product not found.");
            }

            _shoppingCart = _shoppingCartService.RetrieveShoppingCart();

            if(_shoppingCart == null) { return NotFound("Cart not found."); }

            _shoppingCart.AddItem(product);
            
            //Try to save cart to session
            string result = _shoppingCartService.SaveShoppingCart(_shoppingCart);

            if(result.Length <= 0) { return BadRequest("Saving cart failed."); }
            else
            {   //If succes return cart in json format
                return new JsonResult(result);
            }
        }
    }
}
