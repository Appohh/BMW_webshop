using Beamer_shop.Interfaces;
using Logic;
using Logic.Interfaces;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text;


namespace Beamer_shop.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private JsonSerializerSettings settings = new JsonSerializerSettings
        {
            //Type hinting
            TypeNameHandling = TypeNameHandling.Auto
        };

        private IShoppingCart? shoppingCart = null;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ShoppingCartService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public IShoppingCart? RetrieveShoppingCart()
        {
            var httpContext = _httpContextAccessor.HttpContext;

            //Check for HttpContext and session availability
            if (httpContext?.Session == null)
            {
                return null;
            }

            //Retrieve cart from session
            if (httpContext.Session.TryGetValue("Cart", out byte[] data))
            {
                try
                {
                    //Deserialize cart from session
                    var json = Encoding.UTF8.GetString(data);

                    if (json == null)
                    {
                        return null;
                    }


                    return JsonConvert.DeserializeObject<ShoppingCart>(json, settings);
                }


                catch
                {
                    return null;
                }
            }

            //Create new cart if not found in session
            shoppingCart = new ShoppingCart();

            //Save cart to session
            if (SaveShoppingCart(shoppingCart) == "") { return null; }

            return shoppingCart;
        }

        public string SaveShoppingCart(IShoppingCart shoppingCart)
        {
            var httpContext = _httpContextAccessor.HttpContext;

            //Check for HttpContext and cart
            if (httpContext?.Session == null)
            {
                return "";
            }

            try
            {
                //Serialize cart object to JSON format
                var json = JsonConvert.SerializeObject(shoppingCart, settings);
                //Store cart object in session data
                httpContext.Session.SetString("Cart", json);
                return json;
            }
            catch
            {
                return "";
            }
        }
    }
}
