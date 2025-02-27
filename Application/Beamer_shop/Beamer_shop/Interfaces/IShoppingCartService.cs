﻿using Logic;
using Logic.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beamer_shop.Interfaces
{
    public interface IShoppingCartService
    {
        IShoppingCart? RetrieveShoppingCart();
        string SaveShoppingCart(IShoppingCart shoppingCart);
    }
}
